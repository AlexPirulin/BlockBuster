using System;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Guarda la información del usuario autenticado en la sesión actual de la aplicación.
    /// </summary>
    public static class SesionActual
    {
        public static Usuario UsuarioLogueado { get; private set; }

        public static int IdUsuario => UsuarioLogueado?.IdUsuario ?? 0;
        public static string NombreUsuario => UsuarioLogueado?.NombreUsuario ?? string.Empty;
        public static string NombreCompleto => UsuarioLogueado?.NombreCompleto ?? string.Empty;
        public static string Rol => UsuarioLogueado?.Rol ?? string.Empty;
        public static bool EstaAutenticado => UsuarioLogueado != null;

        /// <summary>
        /// Establece el usuario que inició sesión.
        /// </summary>
        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioLogueado = usuario;
        }

        /// <summary>
        /// Limpia los datos de la sesión actual al cerrar sesión.
        /// </summary>
        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
    }
}
