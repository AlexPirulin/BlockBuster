using System;
using System.Data;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class PeliculaLogica
    {
        private readonly PeliculaDatos _peliculaDatos;

        public PeliculaLogica()
        {
            _peliculaDatos = new PeliculaDatos();
        }

        /// <summary>
        /// Obtiene todas las películas para la interfaz de usuario.
        /// </summary>
        public DataTable ObtenerPeliculas()
        {
            return _peliculaDatos.ListarPeliculas();
        }

        /// <summary>
        /// Valida las reglas de negocio y registra una nueva película.
        /// </summary>
        public bool RegistrarPelicula(Pelicula pelicula, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validaciones de negocio
            if (pelicula == null)
            {
                mensajeError = "Los datos de la película no pueden estar vacíos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(pelicula.Titulo))
            {
                mensajeError = "El título de la película es obligatorio.";
                return false;
            }

            if (pelicula.PrecioRenta <= 0)
            {
                mensajeError = "El precio de renta debe ser mayor a 0.";
                return false;
            }

            if (pelicula.Stock < 0)
            {
                mensajeError = "El stock disponible no puede ser negativo.";
                return false;
            }

            try
            {
                bool resultado = _peliculaDatos.InsertarPelicula(pelicula);
                if (!resultado)
                {
                    mensajeError = "No se pudo insertar el registro en la base de datos.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error en la capa de datos: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida y elimina una película por su identificador.
        /// </summary>
        public bool EliminarPelicula(int idPelicula, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idPelicula <= 0)
            {
                mensajeError = "El identificador de la película no es válido.";
                return false;
            }

            try
            {
                bool resultado = _peliculaDatos.EliminarPelicula(idPelicula);
                if (!resultado)
                {
                    mensajeError = "No se encontró la película especificada o no se pudo eliminar.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error en la capa de datos: " + ex.Message;
                return false;
            }
        }
    }
}

