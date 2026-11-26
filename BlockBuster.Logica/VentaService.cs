using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica de negocio para la gestión de ventas de artículos.
    /// Valida existencias en carrito, descuenta inventario, guarda la transacción con el método de pago
    /// seleccionado (Efectivo o Tarjeta) en una sola transacción atómica y emite el ticket oficial.
    /// </summary>
    public class VentaService
    {
        private readonly TicketService _ticketService;

        public VentaService()
        {
            _ticketService = new TicketService();
        }

        public VentaService(TicketService ticketService)
        {
            _ticketService = ticketService ?? new TicketService();
        }

        /// <summary>
        /// Procesa la venta de uno o varios artículos para un cliente, validando existencias,
        /// descontando inventario y emitiendo el ticket en una sola transacción segura.
        /// </summary>
        public bool RegistrarVenta(
            int idCliente,
            int idUsuario,
            List<ItemCarritoDto> carrito,
            string metodoPago,
            out string mensajeError,
            out Ticket ticketGenerado)
        {
            mensajeError = string.Empty;
            ticketGenerado = null;

            // 1. Validación de permisos en la capa lógica (Admin o Caja)
            if (SesionActual.EstaAutenticado && !PermisosService.PuedeRealizarVentas())
            {
                mensajeError = $"Acceso denegado: el rol '{SesionActual.Rol}' no tiene permisos para registrar ventas.";
                return false;
            }

            if (idCliente <= 0)
            {
                mensajeError = "Debe asociar la venta a un cliente registrado.";
                return false;
            }

            if (idUsuario <= 0)
            {
                mensajeError = "No se ha identificado el usuario que atiende la venta.";
                return false;
            }

            if (carrito == null || carrito.Count == 0)
            {
                mensajeError = "El carrito de venta se encuentra vacío.";
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
                    using (var dbTx = db.Database.BeginTransaction())
                    {
                        var cliente = db.Clientes.Find(idCliente);
                        if (cliente == null || !cliente.Activo)
                        {
                            mensajeError = "El cliente seleccionado no existe o está inactivo.";
                            dbTx.Rollback();
                            return false;
                        }

                        var usuario = db.Usuarios.Find(idUsuario);
                        if (usuario == null)
                        {
                            mensajeError = "Usuario de atención no encontrado.";
                            dbTx.Rollback();
                            return false;
                        }

                        decimal totalGeneral = 0m;
                        var detalles = new List<DetalleTransaccion>();

                        // Validar cantidades y existencias de cada artículo antes de descontar
                        foreach (var item in carrito)
                        {
                            if (item.Cantidad <= 0)
                            {
                                mensajeError = $"La cantidad para '{item.Titulo}' debe ser mayor a cero.";
                                dbTx.Rollback();
                                return false;
                            }

                            var artDb = db.Articulos.Find(item.IdArticulo);
                            if (artDb == null || !artDb.Activo)
                            {
                                mensajeError = $"El artículo '{item.Titulo}' no está disponible para venta.";
                                dbTx.Rollback();
                                return false;
                            }

                            if (artDb.Stock < item.Cantidad)
                            {
                                mensajeError = $"Existencia insuficiente para '{artDb.Titulo}'. Disponibles: {artDb.Stock}, Solicitados: {item.Cantidad}.";
                                dbTx.Rollback();
                                return false;
                            }

                            // Descuento físico de inventario
                            artDb.Stock -= item.Cantidad;

                            decimal subtotal = Math.Round(item.PrecioUnitario * item.Cantidad, 2);
                            totalGeneral += subtotal;

                            detalles.Add(new DetalleTransaccion
                            {
                                IdArticulo = artDb.IdArticulo,
                                Descripcion = artDb.Titulo,
                                Cantidad = item.Cantidad,
                                PrecioUnitario = item.PrecioUnitario,
                                Subtotal = subtotal
                            });
                        }

                        // Generar Folio de Venta único basado en el último ID registrado
                        int siguienteIdTrx = (db.Transacciones.Select(t => (int?)t.IdTransaccion).Max() ?? 0) + 1;
                        string folioTrx = $"VNT-{DateTime.Now:yyyyMMdd}-{siguienteIdTrx:D4}";

                        var transaccion = new Transaccion
                        {
                            Folio = folioTrx,
                            Fecha = DateTime.Now,
                            Tipo = "Venta",
                            IdCliente = cliente.IdCliente,
                            IdUsuario = usuario.IdUsuario,
                            MetodoPago = metodoPago,
                            Total = totalGeneral,
                            Estado = "Completada",
                            Observaciones = $"Venta de {carrito.Count} producto(s) en mostrador."
                        };

                        db.Transacciones.Add(transaccion);
                        db.SaveChanges();

                        foreach (var d in detalles)
                        {
                            d.IdTransaccion = transaccion.IdTransaccion;
                            db.DetallesTransacciones.Add(d);
                        }
                        db.SaveChanges();

                        // Generar y registrar Ticket oficial
                        ticketGenerado = _ticketService.Generar(db, transaccion, cliente, usuario, detalles, null);

                        dbTx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error en transacción de venta: " + ex.Message;
                return false;
            }
        }
    }
}

