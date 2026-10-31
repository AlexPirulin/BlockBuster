using System;
using System.Collections.Generic;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class ArticuloLogica
    {
        private readonly ArticuloDatos _articuloDatos;

        public ArticuloLogica()
        {
            _articuloDatos = new ArticuloDatos();
        }

        /// <summary>
        /// Obtiene todos los artículos registrados.
        /// </summary>
        public List<Articulo> ObtenerArticulos()
        {
            return _articuloDatos.ListarArticulos();
        }

        /// <summary>
        /// Busca artículos por título, código, género o tipo.
        /// </summary>
        public List<Articulo> BuscarArticulos(string criterio)
        {
            return _articuloDatos.BuscarArticulos(criterio);
        }

        /// <summary>
        /// Obtiene un artículo por su ID.
        /// </summary>
        public Articulo ObtenerArticulo(int idArticulo)
        {
            if (idArticulo <= 0) return null;
            return _articuloDatos.ObtenerPorId(idArticulo);
        }

        /// <summary>
        /// Obtiene un artículo por su código.
        /// </summary>
        public Articulo ObtenerArticuloPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            return _articuloDatos.ObtenerPorCodigo(codigo.Trim());
        }

        /// <summary>
        /// Valida y registra un nuevo artículo en la base de datos.
        /// </summary>
        public bool RegistrarArticulo(Articulo articulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (articulo == null)
            {
                mensajeError = "Los datos del artículo son requeridos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(articulo.Titulo))
            {
                mensajeError = "El título o nombre del artículo es obligatorio.";
                return false;
            }

            if (articulo.PrecioRenta < 0 || articulo.PrecioVenta < 0)
            {
                mensajeError = "Los precios no pueden ser negativos.";
                return false;
            }

            if (articulo.Stock < 0)
            {
                mensajeError = "El stock disponible no puede ser negativo.";
                return false;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(articulo.Codigo))
                {
                    var existente = _articuloDatos.ObtenerPorCodigo(articulo.Codigo.Trim());
                    if (existente != null)
                    {
                        mensajeError = "Ya existe un artículo registrado con el mismo código.";
                        return false;
                    }
                    articulo.Codigo = articulo.Codigo.Trim();
                }

                articulo.Titulo = articulo.Titulo.Trim();
                articulo.Tipo = articulo.Tipo?.Trim();
                articulo.Genero = articulo.Genero?.Trim();

                return _articuloDatos.InsertarArticulo(articulo);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar artículo: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida y actualiza los datos de un artículo existente.
        /// </summary>
        public bool ModificarArticulo(Articulo articulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (articulo == null || articulo.IdArticulo <= 0)
            {
                mensajeError = "Identificador de artículo inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(articulo.Titulo))
            {
                mensajeError = "El título del artículo es obligatorio.";
                return false;
            }

            if (articulo.PrecioRenta < 0 || articulo.PrecioVenta < 0)
            {
                mensajeError = "Los precios no pueden ser negativos.";
                return false;
            }

            if (articulo.Stock < 0)
            {
                mensajeError = "El stock disponible no puede ser negativo.";
                return false;
            }

            try
            {
                articulo.Titulo = articulo.Titulo.Trim();
                articulo.Codigo = articulo.Codigo?.Trim();
                articulo.Tipo = articulo.Tipo?.Trim();
                articulo.Genero = articulo.Genero?.Trim();

                return _articuloDatos.ActualizarArticulo(articulo);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al modificar artículo: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Elimina un artículo por su ID.
        /// </summary>
        public bool EliminarArticulo(int idArticulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idArticulo <= 0)
            {
                mensajeError = "Identificador de artículo inválido.";
                return false;
            }

            try
            {
                return _articuloDatos.EliminarArticulo(idArticulo);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al eliminar artículo: " + ex.Message;
                return false;
            }
        }
    }
}
