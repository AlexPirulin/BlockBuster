using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica de negocio para la gestión de rentas de artículos.
    /// Valida días de renta, calcula totales (tarifa diaria * días), valida y descuenta existencias,
    /// guarda la transacción completa de forma atómica y genera el ticket correspondiente.
    /// </summary>
    public class RentaService
    {
        private readonly ConfiguracionService _configuracionService;
        private readonly TicketService _ticketService;

        public RentaService()
        {
            _configuracionService = new ConfiguracionService();
            _ticketService = new TicketService();
        }

        public RentaService(ConfiguracionService configuracionService, TicketService ticketService)
        {
            _configuracionService = configuracionService ?? new ConfiguracionService();
            _ticketService = ticketService ?? new TicketService();
        }

        /// <summary>
        /// Calcula el total a pagar por la renta de un artículo: precio de renta * días.
        /// </summary>
        public decimal CalcularTotal(decimal precioRentaDiario, int dias)
        {
            if (precioRentaDiario <= 0 || dias <= 0) return 0m;
            return Math.Round(precioRentaDiario * dias, 2);
        }

        /// <summary>
        /// Valida que la cantidad de días solicitados se encuentre dentro de los límites mínimo y máximo configurados.
        /// </summary>
        public bool ValidarDiasRenta(int dias, out string mensajeError)
        {
            mensajeError = string.Empty;
            int diasMin = _configuracionService.ObtenerInt("DiasMinimosRenta", 1);
            int diasMax = _configuracionService.ObtenerInt("DiasMaximosRenta", 14);

            if (dias < diasMin)
            {
                mensajeError = $"El periodo mínimo de renta es de {diasMin} día(s).";
                return false;
            }

            if (dias > diasMax)
            {
                mensajeError = $"El periodo máximo de renta es de {diasMax} días. Para plazos mayores comuníquese con gerencia.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Registra una operación de renta completa en una sola transacción de base de datos.
        /// Descuenta stock de los artículos rentados, registra la transacción, la renta y emite el ticket.
        /// </summary>
        public bool RegistrarRenta(
            int idCliente,
            int idUsuario,
            List<ItemCarritoDto> articulosRenta,
            int diasRenta,
            string metodoPago,
            out string mensajeError,
            out Ticket ticketGenerado)
        {
            mensajeError = string.Empty;
            ticketGenerado = null;

            // 1. Validaciones previas
            if (idCliente <= 0)
            {
                mensajeError = "Debe seleccionar un cliente registrado para asociar a la renta.";
                return false;
            }

            if (idUsuario <= 0)
            {
                mensajeError = "No se ha identificado el usuario de atención en sesión.";
                return false;
            }

            if (articulosRenta == null || articulosRenta.Count == 0)
            {
                mensajeError = "Debe incluir al menos un artículo para realizar la renta.";
                return false;
            }

            if (!ValidarDiasRenta(diasRenta, out mensajeError))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(metodoPago))
            {
                metodoPago = "Efectivo";
            }

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    // Iniciar transacción atómica de base de datos
                    using (var dbTx = db.Database.BeginTransaction())
                    {
                        var cliente = db.Clientes.Find(idCliente);
                        if (cliente == null || !cliente.Activo)
                        {
                            mensajeError = "El cliente seleccionado no existe o está inactivo.";
                            return false;
                        }

                        var usuario = db.Usuarios.Find(idUsuario);
                        if (usuario == null)
                        {
                            mensajeError = "El usuario que atiende no fue encontrado en la base de datos.";
                            return false;
                        }

                        decimal totalGeneral = 0m;
                        var detallesTransaccion = new List<DetalleTransaccion>();

                        // 2. Validar existencias y descontar inventario
                        foreach (var item in articulosRenta)
                        {
                            var articuloDb = db.Articulos.Find(item.IdArticulo);
                            if (articuloDb == null || !articuloDb.Activo)
                            {
                                mensajeError = $"El artículo '{item.Titulo}' no se encuentra disponible.";
                                dbTx.Rollback();
                                return false;
                            }

                            if (articuloDb.Stock < item.Cantidad)
                            {
                                mensajeError = $"Existencias insuficientes para '{articuloDb.Titulo}'. Stock disponible: {articuloDb.Stock}, solicitado: {item.Cantidad}.";
                                dbTx.Rollback();
                                return false;
                            }

                            // Descontar inventario
                            articuloDb.Stock -= item.Cantidad;

                            // Calcular subtotal de este artículo por los días de renta
                            decimal subtotalArticulo = CalcularTotal(item.PrecioUnitario * item.Cantidad, diasRenta);
                            totalGeneral += subtotalArticulo;

                            detallesTransaccion.Add(new DetalleTransaccion
                            {
                                IdArticulo = articuloDb.IdArticulo,
                                Descripcion = $"{articuloDb.Titulo} ({diasRenta} días)",
                                Cantidad = item.Cantidad,
                                PrecioUnitario = item.PrecioUnitario * diasRenta,
                                Subtotal = subtotalArticulo
                            });
                        }

                        // 3. Crear registro de Transaccion
                        int countTrx = db.Transacciones.Count() + 1;
                        string folioTrx = $"RNT-{DateTime.Now:yyyyMMdd}-{countTrx:D4}";

                        var transaccion = new Transaccion
                        {
                            Folio = folioTrx,
                            Fecha = DateTime.Now,
                            Tipo = "Renta",
                            IdCliente = cliente.IdCliente,
                            IdUsuario = usuario.IdUsuario,
                            MetodoPago = metodoPago,
                            Total = totalGeneral,
                            Estado = "Completada",
                            Observaciones = $"Renta de {articulosRenta.Count} artículo(s) por {diasRenta} día(s)."
                        };

                        db.Transacciones.Add(transaccion);
                        db.SaveChanges(); // Para obtener IdTransaccion

                        // 4. Asignar transacción a los detalles y guardar
                        foreach (var d in detallesTransaccion)
                        {
                            d.IdTransaccion = transaccion.IdTransaccion;
                            db.DetallesTransacciones.Add(d);
                        }
                        db.SaveChanges();

                        // 5. Crear registro de Renta
                        var renta = new Renta
                        {
                            IdTransaccion = transaccion.IdTransaccion,
                            FechaInicio = DateTime.Now,
                            FechaDevolucionPrevista = DateTime.Now.Date.AddDays(diasRenta).AddHours(23).AddMinutes(59),
                            DiasRenta = diasRenta,
                            Estado = "Activa",
                            Recargo = 0m
                        };

                        db.Rentas.Add(renta);
                        db.SaveChanges();

                        // 6. Generar Ticket oficial
                        ticketGenerado = _ticketService.Generar(db, transaccion, cliente, usuario, detallesTransaccion, renta);

                        // 7. Confirmar transacción de base de datos
                        dbTx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al procesar la renta en la base de datos: " + ex.Message;
                return false;
            }
        }
    }
}

