using System;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio para calcular la valuación sugerida de artículos ofrecidos por clientes
    /// según su estado físico (Excelente, Bueno, Regular, Malo), utilizando los porcentajes
    /// configurados en el sistema.
    /// </summary>
    public class ValuacionService
    {
        private readonly ConfiguracionService _configuracionService;

        public ValuacionService()
        {
            _configuracionService = new ConfiguracionService();
        }

        public ValuacionService(ConfiguracionService configuracionService)
        {
            _configuracionService = configuracionService ?? new ConfiguracionService();
        }

        /// <summary>
        /// Obtiene el porcentaje de valuación (entre 0.0 y 1.0) correspondiente al estado del artículo.
        /// </summary>
        public decimal ObtenerPorcentajePorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return 0.50m;

            string e = estado.Trim().ToLower();

            if (e.Contains("excelente"))
            {
                return _configuracionService.ObtenerDecimal("PorcentajeValuacionExcelente", 0.70m);
            }
            if (e.Contains("bueno"))
            {
                return _configuracionService.ObtenerDecimal("PorcentajeValuacionBueno", 0.50m);
            }
            if (e.Contains("regular"))
            {
                return _configuracionService.ObtenerDecimal("PorcentajeValuacionRegular", 0.30m);
            }
            if (e.Contains("malo"))
            {
                return _configuracionService.ObtenerDecimal("PorcentajeValuacionMalo", 0.15m);
            }

            return 0.50m;
        }

        /// <summary>
        /// Calcula la valuación sugerida multiplicando el precio de referencia por el porcentaje del estado.
        /// </summary>
        public decimal CalcularValuacion(string estado, decimal precioReferencia)
        {
            if (precioReferencia <= 0) return 0m;

            decimal porcentaje = ObtenerPorcentajePorEstado(estado);
            decimal resultado = precioReferencia * porcentaje;

            // Redondeo comercial a 2 decimales
            return Math.Round(resultado, 2);
        }
    }
}

