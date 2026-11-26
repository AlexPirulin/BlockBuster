using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica de negocio para la gestión, búsqueda y catálogo de Artículos.
    /// Valida reglas de negocio y permisos en la capa lógica.
    /// </summary>
    public class ArticuloService
    {
        private readonly ArticuloDatos _articuloDatos;

        public ArticuloService()
        {
            _articuloDatos = new ArticuloDatos();
        }

        public ArticuloService(ArticuloDatos articuloDatos)
        {
            _articuloDatos = articuloDatos ?? throw new ArgumentNullException(nameof(articuloDatos));
        }

        /// <summary>
        /// Obtiene todos los artículos registrados y activos en el sistema.
        /// </summary>
        public List<Articulo> ObtenerTodos()
        {
            try
            {
                return _articuloDatos.ListarArticulos()
                    .Where(a => a.Activo)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los artículos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene un artículo por su identificador único.
        /// </summary>
        public Articulo ObtenerPorId(int idArticulo)
        {
            if (idArticulo <= 0) return null;

            try
            {
                return _articuloDatos.ObtenerPorId(idArticulo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el artículo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Busca artículos filtrando por texto (título, código o género), categoría (Tipo) y disponibilidad.
        /// </summary>
        /// <param name="texto">Texto a buscar en título, código o género.</param>
        /// <param name="categoria">Categoría (Películas, Videojuegos, Consolas o vacío/"Todas").</param>
        /// <param name="soloDisponibles">Si es true, solo retorna artículos con Stock mayor a 0.</param>
        public List<Articulo> Buscar(string texto, string categoria, bool soloDisponibles)
        {
            try
            {
                var query = _articuloDatos.ListarArticulos().AsQueryable();

                // 1. Filtrar por activos
                query = query.Where(a => a.Activo);

                // 2. Filtrar por texto si se especifica
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    string t = texto.Trim().ToLower();
                    query = query.Where(a =>
                        (!string.IsNullOrEmpty(a.Titulo) && a.Titulo.ToLower().Contains(t)) ||
                        (!string.IsNullOrEmpty(a.Codigo) && a.Codigo.ToLower().Contains(t)) ||
                        (!string.IsNullOrEmpty(a.Genero) && a.Genero.ToLower().Contains(t))
                    );
                }

                // 3. Filtrar por categoría si no es "Todas" ni vacío (normalizando acentos y plurales)
                if (!string.IsNullOrWhiteSpace(categoria) && !categoria.Equals("Todas", StringComparison.OrdinalIgnoreCase))
                {
                    string catNorm = NormalizarTexto(categoria);

                    query = query.Where(a => CoincideCategoria(a.Tipo, catNorm));
                }

                // 4. Filtrar por disponibilidad (Stock > 0)
                if (soloDisponibles)
                {
                    query = query.Where(a => a.Stock > 0);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar artículos: " + ex.Message, ex);
            }
        }

        private static bool CoincideCategoria(string tipoArticulo, string catNorm)
        {
            if (string.IsNullOrEmpty(tipoArticulo)) return false;
            string tipoNorm = NormalizarTexto(tipoArticulo);

            return tipoNorm.Contains(catNorm) ||
                   (catNorm.Contains("pelicula") && tipoNorm.Contains("pelicula")) ||
                   (catNorm.Contains("videojuego") && tipoNorm.Contains("videojuego")) ||
                   (catNorm.Contains("consola") && tipoNorm.Contains("consola"));
        }

        private static string NormalizarTexto(string texto)
        {
            return (texto ?? string.Empty)
                .Trim()
                .ToLowerInvariant()
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");
        }

        /// <summary>
        /// Valida reglas de negocio y permisos en la lógica, y agrega un nuevo artículo.
        /// </summary>
        public bool Agregar(Articulo articulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validación de permisos en la capa lógica
            if (!PermisosService.PuedeEditarInventario())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para crear o modificar artículos en el inventario.";
                return false;
            }

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
                mensajeError = "Los precios de renta y venta no pueden ser negativos.";
                return false;
            }

            if (articulo.Stock < 0)
            {
                mensajeError = "La existencia (stock) no puede ser un número negativo.";
                return false;
            }

            try
            {
                string tituloNorm = articulo.Titulo.Trim().ToLower();
                string codigoNorm = articulo.Codigo?.Trim().ToLower();

                // Validación de no duplicidad de artículos (por código o por título)
                var existentes = _articuloDatos.ListarArticulos();
                bool repetido = existentes.Any(a => a.Activo && (
                    (!string.IsNullOrEmpty(codigoNorm) && !string.IsNullOrEmpty(a.Codigo) && a.Codigo.Trim().ToLower() == codigoNorm) ||
                    (!string.IsNullOrEmpty(a.Titulo) && a.Titulo.Trim().ToLower() == tituloNorm)
                ));

                if (repetido)
                {
                    mensajeError = $"Ya existe un artículo registrado con el título '{articulo.Titulo.Trim()}' o con el mismo código.";
                    return false;
                }

                articulo.Titulo = articulo.Titulo.Trim();
                articulo.Codigo = articulo.Codigo?.Trim() ?? string.Empty;
                articulo.Tipo = articulo.Tipo?.Trim() ?? "General";
                articulo.Genero = articulo.Genero?.Trim() ?? string.Empty;
                articulo.RutaImagen = articulo.RutaImagen?.Trim();

                return _articuloDatos.InsertarArticulo(articulo);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al agregar el artículo: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida reglas de negocio y permisos en la lógica, y guarda un nuevo artículo.
        /// Alias de Agregar para compatibilidad.
        /// </summary>
        public bool Guardar(Articulo articulo, out string mensajeError)
        {
            return Agregar(articulo, out mensajeError);
        }

        /// <summary>
        /// Valida reglas de negocio y permisos en la lógica, y edita un artículo existente.
        /// </summary>
        public bool Editar(Articulo articulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validación de permisos en la capa lógica
            if (!PermisosService.PuedeEditarInventario())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para editar artículos en el inventario.";
                return false;
            }

            if (articulo == null || articulo.IdArticulo <= 0)
            {
                mensajeError = "Identificador de artículo inválido.";
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
                mensajeError = "La existencia (stock) no puede ser negativa.";
                return false;
            }

            try
            {
                string tituloNorm = articulo.Titulo.Trim().ToLower();
                string codigoNorm = articulo.Codigo?.Trim().ToLower();

                // Validación de no duplicidad de artículos (excluyendo el mismo artículo)
                var existentes = _articuloDatos.ListarArticulos();
                bool repetido = existentes.Any(a => a.Activo && a.IdArticulo != articulo.IdArticulo && (
                    (!string.IsNullOrEmpty(codigoNorm) && !string.IsNullOrEmpty(a.Codigo) && a.Codigo.Trim().ToLower() == codigoNorm) ||
                    (!string.IsNullOrEmpty(a.Titulo) && a.Titulo.Trim().ToLower() == tituloNorm)
                ));

                if (repetido)
                {
                    mensajeError = $"Ya existe otro artículo registrado con el título '{articulo.Titulo.Trim()}' o con el mismo código.";
                    return false;
                }

                articulo.Titulo = articulo.Titulo.Trim();
                articulo.Codigo = articulo.Codigo?.Trim() ?? string.Empty;
                articulo.Tipo = articulo.Tipo?.Trim() ?? "General";
                articulo.Genero = articulo.Genero?.Trim() ?? string.Empty;
                articulo.RutaImagen = articulo.RutaImagen?.Trim();

                return _articuloDatos.ActualizarArticulo(articulo);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al actualizar el artículo: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida reglas de negocio y permisos en la lógica, y actualiza un artículo existente.
        /// Alias de Editar para compatibilidad.
        /// </summary>
        public bool Actualizar(Articulo articulo, out string mensajeError)
        {
            return Editar(articulo, out mensajeError);
        }

        /// <summary>
        /// Elimina o da de baja un artículo del sistema validando permisos en la lógica.
        /// </summary>
        public bool Eliminar(int idArticulo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (!PermisosService.PuedeEditarInventario())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para eliminar artículos del inventario.";
                return false;
            }

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
                mensajeError = "Error al eliminar el artículo: " + ex.Message;
                return false;
            }
        }
    }
}

