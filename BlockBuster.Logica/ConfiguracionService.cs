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
    }
}

