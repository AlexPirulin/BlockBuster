using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica para consultar y administrar parámetros de configuración del sistema
    /// (días mínimos/máximos de renta, tarifa de recargo, porcentajes de valuación).
    /// </summary>
    public class ConfiguracionService
    {
        public ConfiguracionService()
        {
            BlockBusterDbContext.InicializarBaseDatos();
        }

        /// <summary>
        /// Obtiene el valor textual de una clave de configuración.
        /// </summary>
        public string ObtenerValor(string clave, string valorPorDefecto = "")
        {
            if (string.IsNullOrWhiteSpace(clave)) return valorPorDefecto;

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var cfg = db.Configuraciones.FirstOrDefault(c => c.Clave == clave);
                    return cfg != null ? cfg.Valor : valorPorDefecto;
                }
            }
            catch
            {
                return valorPorDefecto;
            }
        }

        /// <summary>
        /// Obtiene el valor decimal de una clave de configuración.
        /// </summary>
        public decimal ObtenerDecimal(string clave, decimal valorPorDefecto)
        {
            string str = ObtenerValor(clave, null);
            if (string.IsNullOrEmpty(str)) return valorPorDefecto;

            if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal res))
            {
                return res;
            }
            if (decimal.TryParse(str, out res))
            {
                return res;
            }
            return valorPorDefecto;
        }

        /// <summary>
        /// Obtiene el valor entero de una clave de configuración.
        /// </summary>
        public int ObtenerInt(string clave, int valorPorDefecto)
        {
            string str = ObtenerValor(clave, null);
            if (string.IsNullOrEmpty(str)) return valorPorDefecto;

            if (int.TryParse(str, out int res))
            {
                return res;
            }
            return valorPorDefecto;
        }

        /// <summary>
        /// Guarda o actualiza un parámetro de configuración.
        /// </summary>
        public bool GuardarValor(string clave, string valor, string descripcion = null)
        {
            if (string.IsNullOrWhiteSpace(clave)) return false;
            if (SesionActual.EstaAutenticado && !PermisosService.PuedeConfigurarSistema())
            {
                return false;
            }

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var cfg = db.Configuraciones.FirstOrDefault(c => c.Clave == clave);
                    if (cfg == null)
                    {
                        cfg = new Configuracion
                        {
                            Clave = clave,
                            Valor = valor ?? string.Empty,
                            Descripcion = descripcion ?? string.Empty
                        };
                        db.Configuraciones.Add(cfg);
                    }
                    else
                    {
                        cfg.Valor = valor ?? string.Empty;
                        if (!string.IsNullOrEmpty(descripcion))
                            cfg.Descripcion = descripcion;
                    }

                    return db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Guarda toda la configuración operativa del sistema con validación de permisos y rangos.
        /// </summary>
        public bool GuardarConfiguracionGeneral(
            decimal tarifaRecargoDia,
            decimal porcExcelente,
            decimal porcBueno,
            decimal porcRegular,
            decimal porcMalo,
            int diasMinRenta,
            int diasMaxRenta,
            out string mensajeError)
        {
            mensajeError = string.Empty;

            if (SesionActual.EstaAutenticado && !PermisosService.PuedeConfigurarSistema())
            {
                mensajeError = $"Acceso denegado: el rol '{SesionActual.Rol}' no puede modificar la configuración del sistema.";
                return false;
            }

            if (tarifaRecargoDia < 0)
            {
                mensajeError = "La tarifa de recargo por día no puede ser negativa.";
                return false;
            }

            if (porcExcelente < 0 || porcExcelente > 1 ||
                porcBueno < 0 || porcBueno > 1 ||
                porcRegular < 0 || porcRegular > 1 ||
                porcMalo < 0 || porcMalo > 1)
            {
                mensajeError = "Los porcentajes de valuación deben estar entre 0% y 100%.";
                return false;
            }

            if (diasMinRenta < 1 || diasMaxRenta < 1 || diasMinRenta > diasMaxRenta)
            {
                mensajeError = "Los días de renta deben ser mayores o iguales a 1 y el mínimo no puede superar al máximo.";
                return false;
            }

            try
            {
                using (var db = new BlockBusterDbContext())
                using (var tx = db.Database.BeginTransaction())
                {
                    UpsertConfig(db, "TarifaRecargoPorDia", tarifaRecargoDia.ToString("0.00", CultureInfo.InvariantCulture), "Tarifa de recargo por cada día de retraso");
                    UpsertConfig(db, "PorcentajeValuacionExcelente", porcExcelente.ToString("0.00", CultureInfo.InvariantCulture), "Porcentaje de valuación estado Excelente");
                    UpsertConfig(db, "PorcentajeValuacionBueno", porcBueno.ToString("0.00", CultureInfo.InvariantCulture), "Porcentaje de valuación estado Bueno");
                    UpsertConfig(db, "PorcentajeValuacionRegular", porcRegular.ToString("0.00", CultureInfo.InvariantCulture), "Porcentaje de valuación estado Regular");
                    UpsertConfig(db, "PorcentajeValuacionMalo", porcMalo.ToString("0.00", CultureInfo.InvariantCulture), "Porcentaje de valuación estado Malo");
                    UpsertConfig(db, "DiasMinimosRenta", diasMinRenta.ToString(CultureInfo.InvariantCulture), "Días mínimos permitidos de renta");
                    UpsertConfig(db, "DiasMaximosRenta", diasMaxRenta.ToString(CultureInfo.InvariantCulture), "Días máximos permitidos de renta");

                    db.SaveChanges();
                    tx.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error de base de datos al guardar la configuración: " + ex.Message;
                return false;
            }
        }

        private void UpsertConfig(BlockBusterDbContext db, string clave, string valor, string descripcion)
        {
            var cfg = db.Configuraciones.FirstOrDefault(c => c.Clave == clave);
            if (cfg == null)
            {
                db.Configuraciones.Add(new Configuracion
                {
                    Clave = clave,
                    Valor = valor,
                    Descripcion = descripcion
                });
            }
            else
            {
                cfg.Valor = valor;
                if (!string.IsNullOrEmpty(descripcion))
                    cfg.Descripcion = descripcion;
            }
        }
    }
}

