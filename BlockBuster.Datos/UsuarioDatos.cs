using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class UsuarioDatos
    {
        public UsuarioDatos()
        {
            BlockBusterDbContext.InicializarBaseDatos();
        }

        /// <summary>
        /// Valida las credenciales de un usuario para el inicio de sesión.
        /// </summary>
        public Usuario ValidarCredenciales(string nombreUsuario, string contrasena)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Usuarios.AsNoTracking()
                    .FirstOrDefault(u => u.NombreUsuario == nombreUsuario 
                                      && u.Contrasena == contrasena 
                                      && u.Activo);
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        public List<Usuario> ListarUsuarios()
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Usuarios.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Obtiene un usuario por su identificador.
        /// </summary>
        public Usuario ObtenerPorId(int idUsuario)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Usuarios.Find(idUsuario);
            }
        }

        /// <summary>
        /// Busca un usuario por su nombre de usuario.
        /// </summary>
        public Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Usuarios.AsNoTracking().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            }
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos.
        /// </summary>
        public bool InsertarUsuario(Usuario usuario)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Usuarios.Add(usuario);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        public bool ActualizarUsuario(Usuario usuario)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Usuarios.Update(usuario);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Desactiva (baja lógica) un usuario.
        /// </summary>
        public bool DesactivarUsuario(int idUsuario)
        {
            using (var db = new BlockBusterDbContext())
            {
                var user = db.Usuarios.Find(idUsuario);
                if (user == null) return false;

                user.Activo = false;
                return db.SaveChanges() > 0;
            }
        }
    }
}

