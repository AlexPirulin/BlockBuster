using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BlockBuster.Datos
{
    public class ConexionBD
    {
        private readonly string _cadenaConexion;

        public ConexionBD()
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings["BlockBusterDB"];
            if (connectionSetting != null && !string.IsNullOrWhiteSpace(connectionSetting.ConnectionString))
            {
                _cadenaConexion = connectionSetting.ConnectionString;
            }
            else
            {
                // Cadena de conexión por defecto
                _cadenaConexion = "Server=localhost;Database=BlockBusterDB;Integrated Security=True;";
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}

