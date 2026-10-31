using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class ArticuloDatos
    {
        public ArticuloDatos()
        {
            BlockBusterDbContext.InicializarBaseDatos();
        }

        /// <summary>
        /// Obtiene todos los artículos disponibles.
        /// </summary>
        public List<Articulo> ListarArticulos()
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Articulos.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Obtiene un artículo por su identificador.
        /// </summary>
        public Articulo ObtenerPorId(int idArticulo)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Articulos.Find(idArticulo);
            }
        }

        /// <summary>
        /// Busca un artículo por su código.
        /// </summary>
        public Articulo ObtenerPorCodigo(string codigo)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Articulos.AsNoTracking().FirstOrDefault(a => a.Codigo == codigo);
            }
        }

        /// <summary>
        /// Busca artículos por título, código, género o tipo.
        /// </summary>
        public List<Articulo> BuscarArticulos(string criterio)
        {
            using (var db = new BlockBusterDbContext())
            {
                if (string.IsNullOrWhiteSpace(criterio))
                    return db.Articulos.AsNoTracking().ToList();

                criterio = criterio.ToLower();
                return db.Articulos.AsNoTracking()
                    .Where(a => (a.Titulo != null && a.Titulo.ToLower().Contains(criterio))
                             || (a.Codigo != null && a.Codigo.ToLower().Contains(criterio))
                             || (a.Genero != null && a.Genero.ToLower().Contains(criterio))
                             || (a.Tipo != null && a.Tipo.ToLower().Contains(criterio)))
                    .ToList();
            }
        }

        /// <summary>
        /// Registra un nuevo artículo en la base de datos.
        /// </summary>
        public bool InsertarArticulo(Articulo articulo)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Articulos.Add(articulo);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Actualiza un artículo existente.
        /// </summary>
        public bool ActualizarArticulo(Articulo articulo)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Articulos.Update(articulo);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Elimina un artículo por su identificador.
        /// </summary>
        public bool EliminarArticulo(int idArticulo)
        {
            using (var db = new BlockBusterDbContext())
            {
                var articulo = db.Articulos.Find(idArticulo);
                if (articulo == null) return false;

                db.Articulos.Remove(articulo);
                return db.SaveChanges() > 0;
            }
        }
    }
}
