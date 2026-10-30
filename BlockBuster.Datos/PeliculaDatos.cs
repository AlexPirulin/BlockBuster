using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class PeliculaDatos
    {
        public PeliculaDatos()
        {
            // Garantiza que el archivo SQLite 'blockbuster.db' y las tablas existan
            GarantizarBaseDatos();
        }

        /// <summary>
        /// Crea el archivo de base de datos SQLite y las tablas si aún no existen.
        /// </summary>
        public void GarantizarBaseDatos()
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Obtiene todas las películas usando Entity Framework Core.
        /// </summary>
        public List<Pelicula> ListarPeliculas()
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Peliculas.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Inserta una nueva película mediante Entity Framework Core en SQLite.
        /// </summary>
        public bool InsertarPelicula(Pelicula pelicula)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Peliculas.Add(pelicula);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Actualiza una película existente en SQLite.
        /// </summary>
        public bool ActualizarPelicula(Pelicula pelicula)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Peliculas.Update(pelicula);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Elimina una película por su identificador en SQLite.
        /// </summary>
        public bool EliminarPelicula(int idPelicula)
        {
            using (var db = new BlockBusterDbContext())
            {
                var pelicula = db.Peliculas.Find(idPelicula);
                if (pelicula == null)
                    return false;

                db.Peliculas.Remove(pelicula);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Busca una película por su ID.
        /// </summary>
        public Pelicula ObtenerPorId(int idPelicula)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Peliculas.Find(idPelicula);
            }
        }
    }
}
