using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class RentaActivaDto
    {
        public int IdRenta { get; set; }
        public int IdTransaccion { get; set; }
        public string FolioTransaccion { get; set; }
        public string ClienteNombre { get; set; }
        public string ArticulosResumen { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucionPrevista { get; set; }
        public int DiasRenta { get; set; }
        public string Estado { get; set; }
        public int DiasRetraso { get; set; }
        public decimal RecargoEstimado { get; set; }
        public decimal TotalRenta { get; set; }
        public bool EstaVencida => Estado.Equals("Vencida", StringComparison.OrdinalIgnoreCase) || DiasRetraso > 0;
    }

    /// <summary>
    /// Servicio de lógica para gestionar rentas activas/vencidas, calcular recargos por retraso
    /// y registrar devoluciones regresando el inventario de forma atómica.
    /// </summary>
    public class DevolucionService
    {
        private readonly ConfiguracionService _configuracionService;

        public DevolucionService()
        {
            _configuracionService = new ConfiguracionService();
        }

        public DevolucionService(ConfiguracionService configuracionService)
        {
            _configuracionService = configuracionService ?? new ConfiguracionService();
        }

        /// <summary>
        /// Actualiza automáticamente a estado "Vencida" las rentas activas cuya fecha de devolución prevista ya pasó.
        /// </summary>
        public int ActualizarRentasVencidas()
        {
            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    DateTime hoy = DateTime.Now.Date;
                    var vencidas = db.Rentas
                        .Where(r => r.Estado == "Activa" && r.FechaDevolucionPrevista.Date < hoy)
                        .ToList();

                    if (vencidas.Count == 0) return 0;

                    foreach (var r in vencidas)
                    {
                        r.Estado = "Vencida";
                    }

                    db.SaveChanges();
                    return vencidas.Count;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Calcula el recargo por días de retraso usando la tarifa configurable en Configuracion.
        /// </summary>
        public decimal CalcularRecargo(DateTime fechaDevolucionPrevista, DateTime? fechaDevolucionReal = null)
        {
            DateTime fechaComparacion = (fechaDevolucionReal ?? DateTime.Now).Date;
            int diasRetraso = (fechaComparacion - fechaDevolucionPrevista.Date).Days;

            if (diasRetraso <= 0) return 0m;

            decimal tarifaPorDia = _configuracionService.ObtenerDecimal("TarifaRecargoPorDia", 15.00m);
            return Math.Round(diasRetraso * tarifaPorDia, 2);
        }

        /// <summary>
        /// Obtiene la lista de rentas activas y vencidas, actualizando primero los estados vencidos.
        /// </summary>
        public List<RentaActivaDto> ObtenerRentasActivas(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (SesionActual.EstaAutenticado && !PermisosService.PuedeRegistrarDevolucion())
            {
                mensajeError = $"Acceso denegado: el rol '{SesionActual.Rol}' no puede gestionar devoluciones de rentas.";
                return new List<RentaActivaDto>();
            }

            try
            {
                ActualizarRentasVencidas();

                using (var db = new BlockBusterDbContext())
                {
                    var rentas = db.Rentas
                        .Where(r => r.Estado == "Activa" || r.Estado == "Vencida")
                        .OrderBy(r => r.FechaDevolucionPrevista)
                        .ToList();

                    var idsTrx = rentas.Select(r => r.IdTransaccion).Distinct().ToList();
                    var transacciones = db.Transacciones
                        .Where(t => idsTrx.Contains(t.IdTransaccion))
                        .ToDictionary(t => t.IdTransaccion);

                    var clientes = db.Clientes.ToDictionary(c => c.IdCliente);
                    var detalles = db.DetallesTransacciones
                        .Where(d => idsTrx.Contains(d.IdTransaccion))
                        .ToList();

                    DateTime hoy = DateTime.Now.Date;
                    decimal tarifa = _configuracionService.ObtenerDecimal("TarifaRecargoPorDia", 15.00m);

                    var resultado = new List<RentaActivaDto>();

                    foreach (var r in rentas)
                    {
                        transacciones.TryGetValue(r.IdTransaccion, out var trx);
                        string clienteNombre = "Cliente no encontrado";
                        if (trx != null && clientes.TryGetValue(trx.IdCliente, out var cli))
                        {
                            clienteNombre = $"{cli.Nombre} {cli.Apellido}".Trim();
                        }

                        var dets = detalles.Where(d => d.IdTransaccion == r.IdTransaccion).ToList();
                        string resumenArticulos = dets.Count > 0
                            ? string.Join(", ", dets.Select(d => $"{d.Descripcion} (x{d.Cantidad})"))
                            : "Sin detalle";

                        int diasRetraso = Math.Max(0, (hoy - r.FechaDevolucionPrevista.Date).Days);
                        decimal recargoEstimado = Math.Round(diasRetraso * tarifa, 2);

                        resultado.Add(new RentaActivaDto
                        {
                            IdRenta = r.IdRenta,
                            IdTransaccion = r.IdTransaccion,
                            FolioTransaccion = trx?.Folio ?? "N/A",
                            ClienteNombre = clienteNombre,
                            ArticulosResumen = resumenArticulos,
                            FechaInicio = r.FechaInicio,
                            FechaDevolucionPrevista = r.FechaDevolucionPrevista,
                            DiasRenta = r.DiasRenta,
                            Estado = diasRetraso > 0 ? "Vencida" : r.Estado,
                            DiasRetraso = diasRetraso,
                            RecargoEstimado = recargoEstimado,
                            TotalRenta = trx?.Total ?? 0m
                        });
                    }

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error de base de datos al consultar rentas activas: " + ex.Message;
                return new List<RentaActivaDto>();
            }
        }

        /// <summary>
        /// Registra la devolución de una renta: marca la renta como "Devuelta", regresa el artículo al inventario
        /// y calcula/guarda el recargo correspondiente en una sola transacción de base de datos.
        /// </summary>
        public bool RegistrarDevolucion(
            int idRenta,
            int idUsuarioRecibe,
            out decimal recargoCalculado,
            out int diasRetraso,
            out string mensajeError)
        {
            recargoCalculado = 0m;
            diasRetraso = 0;
            mensajeError = string.Empty;

            if (SesionActual.EstaAutenticado && !PermisosService.PuedeRegistrarDevolucion())
            {
                mensajeError = $"Acceso denegado: el rol '{SesionActual.Rol}' no tiene permisos para registrar devoluciones.";
                return false;
            }

            if (idRenta <= 0)
            {
                mensajeError = "Debe seleccionar una renta válida para devolver.";
                return false;
            }

            try
            {
                using (var db = new BlockBusterDbContext())
                using (var dbTx = db.Database.BeginTransaction())
                {
                    var renta = db.Rentas.FirstOrDefault(r => r.IdRenta == idRenta);
                    if (renta == null)
                    {
                        mensajeError = "No se encontró el registro de renta especificado.";
                        return false;
                    }

                    if (renta.Estado.Equals("Devuelta", StringComparison.OrdinalIgnoreCase))
                    {
                        mensajeError = "Esta renta ya fue marcada como devuelta anteriormente.";
                        return false;
                    }

                    DateTime ahora = DateTime.Now;
                    diasRetraso = Math.Max(0, (ahora.Date - renta.FechaDevolucionPrevista.Date).Days);
                    recargoCalculado = CalcularRecargo(renta.FechaDevolucionPrevista, ahora);

                    renta.Estado = "Devuelta";
                    renta.FechaDevolucionReal = ahora;
                    renta.Recargo = recargoCalculado;

                    // Regresar artículos al inventario
                    var detalles = db.DetallesTransacciones
                        .Where(d => d.IdTransaccion == renta.IdTransaccion)
                        .ToList();

                    foreach (var det in detalles)
                    {
                        if (det.IdArticulo.HasValue && det.IdArticulo.Value > 0)
                        {
                            var articulo = db.Articulos.Find(det.IdArticulo.Value);
                            if (articulo != null)
                            {
                                articulo.Stock += det.Cantidad;
                            }
                        }
                    }

                    // Actualizar observaciones de la transacción
                    var transaccion = db.Transacciones.Find(renta.IdTransaccion);
                    if (transaccion != null)
                    {
                        var usr = db.Usuarios.Find(idUsuarioRecibe);
                        string notaRecargo = recargoCalculado > 0
                            ? $" [Devuelta con {diasRetraso} día(s) de retraso. Recargo: {recargoCalculado:C2}]"
                            : " [Devuelta a tiempo]";
                        transaccion.Observaciones = (transaccion.Observaciones ?? string.Empty) +
                            $"{notaRecargo} (Recibió: {usr?.NombreUsuario ?? "Sistema"} el {ahora:dd/MM/yyyy HH:mm})";
                    }

                    db.SaveChanges();
                    dbTx.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error de base de datos al registrar la devolución: " + ex.Message;
                return false;
            }
        }
    }
}
