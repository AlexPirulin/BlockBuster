using System;
using System.Collections.Generic;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos _usuarioDatos;

        public UsuarioLogica()
        {
            _usuarioDatos = new UsuarioDatos();
        }

        /// <summary>
        /// Autentica las credenciales de un usuario.
        /// Retorna el objeto Usuario autenticado o null si las credenciales son incorrectas.
        /// </summary>
        public Usuario IniciarSesion(string nombreUsuario, string contrasena, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                mensaje = "El nombre de usuario es obligatorio.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                mensaje = "La contraseña es obligatoria.";
                return null;
            }

            try
            {
                var usuario = _usuarioDatos.ValidarCredenciales(nombreUsuario.Trim(), contrasena.Trim());
                if (usuario == null)
                {
                    mensaje = "Usuario o contraseña incorrectos.";
                    return null;
                }

                if (!usuario.Activo)
                {
                    mensaje = "La cuenta de usuario se encuentra inactiva.";
                    return null;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                mensaje = "Error al intentar autenticar: " + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Lista todos los usuarios.
        /// </summary>
        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarioDatos.ListarUsuarios();
        }

        /// <summary>
        /// Valida y registra un nuevo usuario en la base de datos.
        /// </summary>
        public bool RegistrarUsuario(Usuario usuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (usuario == null)
            {
                mensajeError = "Los datos del usuario son requeridos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                mensajeError = "El nombre de usuario no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                mensajeError = "La contraseña no puede estar vacía.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Rol))
            {
                mensajeError = "Debe asignar un rol al usuario (ej. Administrador, Caja, Cliente).";
                return false;
            }

            try
            {
                var existente = _usuarioDatos.ObtenerPorNombreUsuario(usuario.NombreUsuario.Trim());
                if (existente != null)
                {
                    mensajeError = "El nombre de usuario ya está registrado.";
                    return false;
                }

                usuario.NombreUsuario = usuario.NombreUsuario.Trim();
                usuario.Contrasena = usuario.Contrasena.Trim();

                return _usuarioDatos.InsertarUsuario(usuario);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar usuario: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Desactiva (baja lógica) un usuario.
        /// </summary>
        public bool DesactivarUsuario(int idUsuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idUsuario <= 0)
            {
                mensajeError = "Identificador de usuario inválido.";
                return false;
            }

            try
            {
                return _usuarioDatos.DesactivarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al desactivar usuario: " + ex.Message;
                return false;
            }
        }
    }
}
