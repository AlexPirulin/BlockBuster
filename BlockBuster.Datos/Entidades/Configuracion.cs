using System;

namespace BlockBuster.Datos.Entidades
{
    /// <summary>
    /// Parámetros de configuración del sistema (tarifa de recargo, porcentajes de valuación, días máximos de renta).
    /// </summary>
    public class Configuracion
    {
        public int IdConfiguracion { get; set; }
        public string Clave { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
    }
}

