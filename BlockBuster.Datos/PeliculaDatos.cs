using System;
using System.Data;
using System.Data.SqlClient;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class PeliculaDatos
    {
        private readonly ConexionBD _conexion;

        public PeliculaDatos()
        {
            _conexion = new ConexionBD();
        }

        /// <summary>
        /// Obtiene todas las películas en un DataTable para enlazar a DataGridView o vistas.
        /// </summary>
        public DataTable ListarPeliculas()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                string query = "SELECT IdPelicula, Titulo, Genero, PrecioRenta, Stock FROM Peliculas";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        /// <summary>
        /// Inserta una nueva película en la base de datos.
        /// </summary>
        public bool InsertarPelicula(Pelicula pelicula)
        {
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Peliculas (Titulo, Genero, PrecioRenta, Stock) " +
                               "VALUES (@Titulo, @Genero, @PrecioRenta, @Stock)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
                    cmd.Parameters.AddWithValue("@Genero", (object)pelicula.Genero ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioRenta", pelicula.PrecioRenta);
                    cmd.Parameters.AddWithValue("@Stock", pelicula.Stock);

                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        /// <summary>
        /// Elimina una película por su ID.
        /// </summary>
        public bool EliminarPelicula(int idPelicula)
        {
            using (SqlConnection con = _conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Peliculas WHERE IdPelicula = @IdPelicula";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdPelicula", idPelicula);

                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}

