using System;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class AuthService
    {
        private readonly UsuarioDatos _usuarioDatos;

        public AuthService()
        {
            _usuarioDatos = new UsuarioDatos();
        }

        public AuthService(UsuarioDatos usuarioDatos)
        {
            _usuarioDatos = usuarioDatos ?? throw new ArgumentNullException(nameof(usuarioDatos));
        }

        /// <summary>
        /// Busca en la tabla Usuarios las credenciales especificadas.
        /// Devuelve el objeto Usuario si es válido y está activo, o null si las credenciales son incorrectas.
        /// </summary>
        public Usuario Login(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            try
            {
                Usuario usuarioEncontrado = _usuarioDatos.ValidarCredenciales(usuario.Trim(), password.Trim());

                if (usuarioEncontrado != null && usuarioEncontrado.Activo)
                {
                    SesionActual.IniciarSesion(usuarioEncontrado);
                    return usuarioEncontrado;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Cierra la sesión actual del sistema.
        /// </summary>
        public void Logout()
        {
            SesionActual.CerrarSesion();
        }
    }
}
