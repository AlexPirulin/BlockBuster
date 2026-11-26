using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica de negocio para la compra/abastecimiento de artículos de clientes.
    /// Si quien registra es Caja o Admin, confirma directo y agrega el artículo al inventario;
    /// si es Cliente, la deja en estado Pendiente para posterior aprobación o rechazo.
    /// Cada operación se guarda en una sola transacción atómica de base de datos.
    /// </summary>
    public class CompraService
    {
        private readonly ValuacionService _valuacionService;
        private readonly TicketService _ticketService;

        public CompraService()
        {
            _valuacionService = new ValuacionService();
            _ticketService = new TicketService();
        }

        public CompraService(ValuacionService valuacionService, TicketService ticketService)
        {
            _valuacionService = valuacionService ?? new ValuacionService();
            _ticketService = ticketService ?? new TicketService();
        }

        /// <summary>
        /// Registra una propuesta de compra de artículo ofrecido por un cliente.
        /// Si el rol actual es Admin o Caja, la compra se confirma de inmediato y se añade al inventario.
        /// Si el rol es Cliente, queda registrada con estado 'Pendiente' para revisión.
        /// </summary>
        public bool RegistrarCompra(
            int idCliente,
            int idUsuario,
            string nombreArticulo,
            string tipoArticulo,
            string generoPlataforma,
            string estadoFisico,
            decimal precioReferencia,
            decimal precioValuacionAcordado,
            out string mensajeError,
            out Ticket ticketGenerado,
            out bool quedoPendiente)
        {
            mensajeError = string.Empty;
            ticketGenerado = null;
            quedoPendiente = false;

            if (idCliente <= 0)
            {
                mensajeError = "Debe asociar la compra a un cliente registrado.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombreArticulo))
            {
                mensajeError = "El nombre o título del artículo es requerido.";
                return false;
            }

            if (precioValuacionAcordado <= 0)
            {
                mensajeError = "El precio de valuación o compra debe ser mayor a 0.";
                return false;
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
                            return false;
                        }

                        var usuario = db.Usuarios.Find(idUsuario);
                        if (usuario == null)
                        {
                            mensajeError = "Usuario no identificado.";
                            return false;
                        }

                        // Determinar si confirma directo o queda pendiente según el rol
                        bool esStaff = PermisosService.EsAdministrador(usuario.Rol) || PermisosService.EsCajero(usuario.Rol);
                        string estadoInicial = esStaff ? "Completada" : "Pendiente";
                        quedoPendiente = !esStaff;

                        int siguienteIdTrx = (db.Transacciones.Select(t => (int?)t.IdTransaccion).Max() ?? 0) + 1;
                        string folioTrx = $"CMP-{DateTime.Now:yyyyMMdd}-{siguienteIdTrx:D4}";

                        var transaccion = new Transaccion
                        {
                            Folio = folioTrx,
                            Fecha = DateTime.Now,
                            Tipo = "Compra",
                            IdCliente = cliente.IdCliente,
                            IdUsuario = usuario.IdUsuario,
                            MetodoPago = "Efectivo",
                            Total = precioValuacionAcordado,
                            Estado = estadoInicial,
                            Observaciones = $"Compra a cliente. Artículo: '{nombreArticulo.Trim()}', Estado físico: '{estadoFisico}'."
                        };

                        db.Transacciones.Add(transaccion);
                        db.SaveChanges();

                        Articulo articuloCreado = null;

                        // Si confirma directo (Admin o Caja), sumar inmediatamente al inventario
                        if (esStaff)
                        {
                            articuloCreado = AgregarOIncrementarArticulo(
                                db,
                                nombreArticulo.Trim(),
                                tipoArticulo,
                                generoPlataforma,
                                precioValuacionAcordado,
                                precioReferencia);
                        }

                        var detalle = new DetalleTransaccion
                        {
                            IdTransaccion = transaccion.IdTransaccion,
                            IdArticulo = articuloCreado?.IdArticulo,
                            Descripcion = $"Compra: {nombreArticulo.Trim()} (Condición: {estadoFisico})",
                            Cantidad = 1,
                            PrecioUnitario = precioValuacionAcordado,
                            Subtotal = precioValuacionAcordado
                        };

                        db.DetallesTransacciones.Add(detalle);
                        db.SaveChanges();

                        // Solo generar ticket si la compra quedó confirmada
                        if (esStaff)
                        {
                            ticketGenerado = _ticketService.Generar(
                                db,
                                transaccion,
                                cliente,
                                usuario,
                                new List<DetalleTransaccion> { detalle },
                                null);
                        }

                        dbTx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al procesar la compra: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Consulta todas las compras de clientes en estado 'Pendiente' de revisión.
        /// </summary>
        public List<Transaccion> ObtenerComprasPendientes()
        {
            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var lista = db.Transacciones
                        .Where(t => t.Tipo == "Compra" && t.Estado == "Pendiente")
                        .OrderByDescending(t => t.Fecha)
                        .ToList();

                    foreach (var t in lista)
                    {
                        if (t.IdCliente > 0)
                        {
                            t.Cliente = db.Clientes.Find(t.IdCliente);
                        }
                        if (t.IdUsuario > 0)
                        {
                            t.Usuario = db.Usuarios.Find(t.IdUsuario);
                        }
                        t.Detalles = db.DetallesTransacciones.Where(d => d.IdTransaccion == t.IdTransaccion).ToList();
                    }

                    return lista;
                }
            }
            catch
            {
                return new List<Transaccion>();
            }
        }

        /// <summary>
        /// Aprueba una compra pendiente (exclusivo para Caja o Admin):
        /// Cambia el estado a 'Aprobada', suma el artículo al inventario y genera el ticket oficial.
        /// Todo en una sola transacción atómica.
        /// </summary>
        public bool AprobarCompra(
            int idTransaccion,
            int idUsuarioAprobador,
            out string mensajeError,
            out Ticket ticketGenerado)
        {
            mensajeError = string.Empty;
            ticketGenerado = null;

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    using (var dbTx = db.Database.BeginTransaction())
                    {
                        var transaccion = db.Transacciones.FirstOrDefault(t => t.IdTransaccion == idTransaccion);

                        if (transaccion == null)
                        {
                            mensajeError = "Transacción no encontrada.";
                            return false;
                        }

                        if (transaccion.Estado != "Pendiente")
                        {
                            mensajeError = $"La transacción ya fue procesada previamente (Estado: {transaccion.Estado}).";
                            return false;
                        }

                        if (transaccion.IdCliente > 0)
                        {
                            transaccion.Cliente = db.Clientes.Find(transaccion.IdCliente);
                        }
                        transaccion.Detalles = db.DetallesTransacciones.Where(d => d.IdTransaccion == transaccion.IdTransaccion).ToList();

                        var usuarioAprobador = db.Usuarios.Find(idUsuarioAprobador);

                        // Actualizar estado
                        transaccion.Estado = "Aprobada";
                        transaccion.IdUsuario = idUsuarioAprobador; // Usuario staff que aprueba
                        transaccion.Observaciones += $" [Aprobada por: {usuarioAprobador?.NombreUsuario} en {DateTime.Now:dd/MM/yyyy HH:mm}]";

                        // Sumar al inventario
                        var primerDetalle = transaccion.Detalles.FirstOrDefault();
                        string nombre = primerDetalle?.Descripcion?.Replace("Compra: ", "") ?? "Artículo Adquirido";
                        if (nombre.Contains("(")) nombre = nombre.Substring(0, nombre.IndexOf("(")).Trim();

                        var articulo = AgregarOIncrementarArticulo(
                            db,
                            nombre,
                            "General",
                            "Usado / Adquirido",
                            transaccion.Total,
                            transaccion.Total * 1.5m);

                        if (primerDetalle != null)
                        {
                            primerDetalle.IdArticulo = articulo.IdArticulo;
                        }

                        db.SaveChanges();

                        // Generar el ticket oficial
                        ticketGenerado = _ticketService.Generar(
                            db,
                            transaccion,
                            transaccion.Cliente,
                            usuarioAprobador,
                            transaccion.Detalles.ToList(),
                            null);

                        dbTx.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al aprobar la compra: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Rechaza una compra pendiente de un cliente.
        /// </summary>
        public bool RechazarCompra(
            int idTransaccion,
            int idUsuarioRechazador,
            string motivo,
            out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var transaccion = db.Transacciones.Find(idTransaccion);
                    if (transaccion == null)
                    {
                        mensajeError = "Transacción no encontrada.";
                        return false;
                    }

                    if (transaccion.Estado != "Pendiente")
                    {
                        mensajeError = $"La transacción ya se encuentra en estado '{transaccion.Estado}'.";
                        return false;
                    }

                    var usuario = db.Usuarios.Find(idUsuarioRechazador);

                    transaccion.Estado = "Rechazada";
                    transaccion.Observaciones += $" [Rechazada por: {usuario?.NombreUsuario}. Motivo: {motivo ?? "No cumple estándares físicos"}]";

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al rechazar compra: " + ex.Message;
                return false;
            }
        }

        private Articulo AgregarOIncrementarArticulo(
            BlockBusterDbContext db,
            string nombreArticulo,
            string tipo,
            string genero,
            decimal precioCompra,
            decimal precioVentaSugerido)
        {
            string nombreNorm = nombreArticulo.Trim().ToLower();

            // Buscar si ya existe para incrementar stock
            var existente = db.Articulos.FirstOrDefault(a => a.Titulo.ToLower() == nombreNorm && a.Activo);

            if (existente != null)
            {
                existente.Stock += 1;
                db.SaveChanges();
                return existente;
            }

            // Si es un producto nuevo que no existía en inventario, se crea
            string codigoAuto = $"CMP-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
            decimal precioVenta = precioVentaSugerido > 0 ? precioVentaSugerido : Math.Round(precioCompra * 1.5m, 2);
            decimal precioRenta = Math.Round(precioVenta * 0.15m, 2);

            var nuevo = new Articulo
            {
                Codigo = codigoAuto,
                Titulo = nombreArticulo.Trim(),
                Tipo = string.IsNullOrWhiteSpace(tipo) ? "General" : tipo.Trim(),
                Genero = string.IsNullOrWhiteSpace(genero) ? "Adquirido" : genero.Trim(),
                PrecioRenta = precioRenta,
                PrecioVenta = precioVenta,
                Stock = 1,
                Activo = true,
                RutaImagen = null
            };

            db.Articulos.Add(nuevo);
            db.SaveChanges();
            return nuevo;
        }
    }
}
