using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class ResumenReporteDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadVentas { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadRentas { get; set; }
        public decimal TotalRentas { get; set; }
        public decimal TotalRecargos { get; set; }
        public int CantidadCompras { get; set; }
        public decimal TotalCompras { get; set; }
        public decimal BalanceNeto => (TotalVentas + TotalRentas + TotalRecargos) - TotalCompras;
        public List<Articulo> ArticulosBajoStock { get; set; } = new List<Articulo>();
        public List<Transaccion> TransaccionesPeriodo { get; set; } = new List<Transaccion>();
    }

    /// <summary>
    /// Servicio de lógica para generar reportes financieros por día o rango de fechas
    /// y consultar los artículos con menos existencias en el inventario.
    /// Exclusivo para Administrador.
    /// </summary>
    public class ReporteService
    {
        public ReporteService()
        {
            BlockBusterDbContext.InicializarBaseDatos();
        }

        /// <summary>
        /// Genera el reporte financiero del día o de un rango de fechas, incluyendo recargos
        /// y la lista de artículos con menos existencias.
        /// </summary>
        public ResumenReporteDto GenerarReporte(
            DateTime fechaInicio,
            DateTime fechaFin,
            int umbralStockBajo,
            out string mensajeError)
        {
            mensajeError = string.Empty;

            if (SesionActual.EstaAutenticado && !PermisosService.PuedeVerReportes())
            {
                mensajeError = $"Acceso denegado: el rol '{SesionActual.Rol}' no tiene permisos para consultar reportes administrativos.";
                return null;
            }

            if (fechaInicio.Date > fechaFin.Date)
            {
                mensajeError = "La fecha inicial no puede ser posterior a la fecha final.";
                return null;
            }

            if (umbralStockBajo < 0)
            {
                mensajeError = "El umbral de existencias no puede ser negativo.";
                return null;
            }

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    DateTime inicio = fechaInicio.Date;
                    DateTime fin = fechaFin.Date.AddDays(1).AddTicks(-1);

                    // Filtrar transacciones efectivas del periodo en modo solo lectura (AsNoTracking)
                    var transacciones = db.Transacciones
                        .AsNoTracking()
                        .Where(t => t.Fecha >= inicio && t.Fecha <= fin &&
                                    (t.Estado == "Completada" || t.Estado == "Aprobada"))
                        .OrderByDescending(t => t.Fecha)
                        .ToList();

                    var idsClientes = transacciones.Select(t => t.IdCliente).Distinct().ToList();
                    var idsUsuarios = transacciones.Select(t => t.IdUsuario).Distinct().ToList();

                    var clientes = db.Clientes.AsNoTracking().Where(c => idsClientes.Contains(c.IdCliente)).ToDictionary(c => c.IdCliente);
                    var usuarios = db.Usuarios.AsNoTracking().Where(u => idsUsuarios.Contains(u.IdUsuario)).ToDictionary(u => u.IdUsuario);
                    foreach (var t in transacciones)
                    {
                        if (clientes.TryGetValue(t.IdCliente, out var cli)) t.Cliente = cli;
                        if (usuarios.TryGetValue(t.IdUsuario, out var usr)) t.Usuario = usr;
                    }

                    var ventas = transacciones.Where(t => t.Tipo == "Venta").ToList();
                    var rentasTrx = transacciones.Where(t => t.Tipo == "Renta").ToList();
                    var compras = transacciones.Where(t => t.Tipo == "Compra").ToList();

                    // Recargos cobrados en devoluciones durante el periodo
                    decimal totalRecargos = db.Rentas
                        .AsNoTracking()
                        .Where(r => r.FechaDevolucionReal.HasValue &&
                                    r.FechaDevolucionReal.Value >= inicio &&
                                    r.FechaDevolucionReal.Value <= fin)
                        .AsEnumerable()
                        .Sum(r => r.Recargo);

                    // Artículos con menos existencias (activos)
                    var articulosBajoStock = db.Articulos
                        .AsNoTracking()
                        .Where(a => a.Activo)
                        .OrderBy(a => a.Stock)
                        .ThenBy(a => a.Titulo)
                        .AsEnumerable()
                        .Where(a => a.Stock <= umbralStockBajo)
                        .ToList();

                    // Si no hay ninguno debajo del umbral, mostrar los 10 con menor stock de todas formas
                    if (articulosBajoStock.Count == 0)
                    {
                        articulosBajoStock = db.Articulos
                            .AsNoTracking()
                            .Where(a => a.Activo)
                            .OrderBy(a => a.Stock)
                            .ThenBy(a => a.Titulo)
                            .Take(10)
                            .ToList();
                    }

                    return new ResumenReporteDto
                    {
                        FechaInicio = inicio,
                        FechaFin = fechaFin.Date,
                        CantidadVentas = ventas.Count,
                        TotalVentas = ventas.Sum(v => v.Total),
                        CantidadRentas = rentasTrx.Count,
                        TotalRentas = rentasTrx.Sum(r => r.Total),
                        TotalRecargos = totalRecargos,
                        CantidadCompras = compras.Count,
                        TotalCompras = compras.Sum(c => c.Total),
                        ArticulosBajoStock = articulosBajoStock,
                        TransaccionesPeriodo = transacciones
                    };
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error de base de datos al generar el reporte: " + ex.Message;
                return null;
            }
        }
    }
}

