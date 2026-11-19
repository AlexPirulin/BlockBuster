using System;
using System.Collections.Generic;
using System.Linq;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de lógica de negocio para la gestión y administración de usuarios del sistema.
    /// Valida roles, duplicidad de nombres de usuario y gestiona excepciones de base de datos.
    /// </summary>
    public class UsuarioService
    {
        private readonly UsuarioDatos _usuarioDatos;

        public UsuarioService()
        {
            _usuarioDatos = new UsuarioDatos();
        }

        public UsuarioService(UsuarioDatos usuarioDatos)
        {
            _usuarioDatos = usuarioDatos ?? throw new ArgumentNullException(nameof(usuarioDatos));
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios registrados en el sistema.
        /// </summary>
        public List<Usuario> ObtenerTodos()
        {
            try
            {
                return _usuarioDatos.ListarUsuarios()
                    .OrderBy(u => u.IdUsuario)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los usuarios en la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene un usuario específico por su identificador único.
        /// </summary>
        public Usuario ObtenerPorId(int idUsuario)
        {
            if (idUsuario <= 0) return null;

            try
            {
                return _usuarioDatos.ObtenerPorId(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por ID: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Busca un usuario por su nombre de usuario (sin distinción de mayúsculas/minúsculas).
        /// </summary>
        public Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return null;

            try
            {
                return _usuarioDatos.ObtenerPorNombreUsuario(nombreUsuario.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el nombre de usuario: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema validando permisos en lógica,
        /// campos obligatorios y no repetición de nombre de usuario.
        /// </summary>
        public bool Crear(Usuario usuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            // 1. Validación de permisos en la capa lógica
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para crear usuarios.";
                return false;
            }

            if (usuario == null)
            {
                mensajeError = "Los datos del usuario son obligatorios.";
                return false;
            }

            // 2. Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                mensajeError = "El nombre de usuario (login) es obligatorio.";
                return false;
            }

            if (usuario.NombreUsuario.Trim().Length < 3)
            {
                mensajeError = "El nombre de usuario debe contener al menos 3 caracteres.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                mensajeError = "La contraseña del usuario es obligatoria.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
            {
                mensajeError = "El nombre completo del usuario es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Rol))
            {
                mensajeError = "Debe asignar un rol válido al usuario.";
                return false;
            }

            try
            {
                string usernameNorm = usuario.NombreUsuario.Trim().ToLower();

                // 3. Validación de no repetición de nombre de usuario
                var usuariosExistentes = _usuarioDatos.ListarUsuarios();
                bool yaExiste = usuariosExistentes.Any(u =>
                    !string.IsNullOrEmpty(u.NombreUsuario) &&
                    u.NombreUsuario.Trim().ToLower() == usernameNorm
                );

                if (yaExiste)
                {
                    mensajeError = $"El nombre de usuario '{usuario.NombreUsuario.Trim()}' ya está registrado. Elija un nombre diferente.";
                    return false;
                }

                // Normalizar valores
                usuario.NombreUsuario = usuario.NombreUsuario.Trim();
                usuario.Contrasena = usuario.Contrasena.Trim();
                usuario.NombreCompleto = usuario.NombreCompleto.Trim();
                usuario.Rol = NormalizarRol(usuario.Rol);
                usuario.FechaCreacion = DateTime.Now;

                bool resultado = _usuarioDatos.InsertarUsuario(usuario);
                if (!resultado)
                {
                    mensajeError = "No se pudo guardar el usuario en la base de datos.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar el usuario en la base de datos: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Edita la información de un usuario existente validando permisos y no repetición de nombre de usuario.
        /// Si la contraseña viene en blanco, se conserva la contraseña anterior.
        /// </summary>
        public bool Editar(Usuario usuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            // 1. Validación de permisos
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para modificar usuarios.";
                return false;
            }

            if (usuario == null || usuario.IdUsuario <= 0)
            {
                mensajeError = "Identificador de usuario inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                mensajeError = "El nombre de usuario es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
            {
                mensajeError = "El nombre completo es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Rol))
            {
                mensajeError = "El rol es obligatorio.";
                return false;
            }

            try
            {
                // Buscar usuario actual en la base de datos
                var usuarioDb = _usuarioDatos.ObtenerPorId(usuario.IdUsuario);
                if (usuarioDb == null)
                {
                    mensajeError = "El usuario seleccionado no existe en la base de datos.";
                    return false;
                }

                string usernameNorm = usuario.NombreUsuario.Trim().ToLower();

                // 2. Validación de no repetición de nombre de usuario entre otros usuarios
                var usuariosExistentes = _usuarioDatos.ListarUsuarios();
                bool repetido = usuariosExistentes.Any(u =>
                    u.IdUsuario != usuario.IdUsuario &&
                    !string.IsNullOrEmpty(u.NombreUsuario) &&
                    u.NombreUsuario.Trim().ToLower() == usernameNorm
                );

                if (repetido)
                {
                    mensajeError = $"El nombre de usuario '{usuario.NombreUsuario.Trim()}' ya se encuentra en uso por otra cuenta.";
                    return false;
                }

                // Asignar campos
                usuarioDb.NombreUsuario = usuario.NombreUsuario.Trim();
                usuarioDb.NombreCompleto = usuario.NombreCompleto.Trim();
                usuarioDb.Rol = NormalizarRol(usuario.Rol);
                usuarioDb.Activo = usuario.Activo;

                // Solo actualizar contraseña si se especificó una nueva
                if (!string.IsNullOrWhiteSpace(usuario.Contrasena))
                {
                    usuarioDb.Contrasena = usuario.Contrasena.Trim();
                }

                bool resultado = _usuarioDatos.ActualizarUsuario(usuarioDb);
                if (!resultado)
                {
                    mensajeError = "No se pudieron aplicar los cambios del usuario.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al actualizar el usuario: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Desactiva lógicamente a un usuario validando permisos y evitando que el usuario actual se inactive a sí mismo.
        /// </summary>
        public bool Desactivar(int idUsuario, out string mensajeError)
        {
            mensajeError = string.Empty;

            // 1. Validación de permisos
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para desactivar usuarios.";
                return false;
            }

            if (idUsuario <= 0)
            {
                mensajeError = "Identificador de usuario inválido.";
                return false;
            }

            try
            {
                var usuario = _usuarioDatos.ObtenerPorId(idUsuario);
                if (usuario == null)
                {
                    mensajeError = "El usuario no existe.";
                    return false;
                }

                // Evitar que el usuario logueado desactive su propia cuenta
                if (SesionActual.EstaAutenticado &&
                    !string.IsNullOrEmpty(SesionActual.NombreUsuario) &&
                    usuario.NombreUsuario.Trim().Equals(SesionActual.NombreUsuario.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    mensajeError = "No puede desactivar su propia cuenta de usuario mientras tiene la sesión activa.";
                    return false;
                }

                // Evitar desactivar al único administrador activo
                if (usuario.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ||
                    usuario.Rol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var administradoresActivos = _usuarioDatos.ListarUsuarios()
                        .Count(u => u.Activo && (u.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase) || u.Rol.Equals("Admin", StringComparison.OrdinalIgnoreCase)));

                    if (administradoresActivos <= 1)
                    {
                        mensajeError = "No se puede desactivar al único Administrador activo del sistema.";
                        return false;
                    }
                }

                bool resultado = _usuarioDatos.DesactivarUsuario(idUsuario);
                if (!resultado)
                {
                    mensajeError = "No se pudo desactivar el usuario en la base de datos.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al desactivar el usuario: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cambia el estado de activación (activo/inactivo) de un usuario.
        /// </summary>
        public bool CambiarEstado(int idUsuario, bool nuevoEstado, out string mensajeError)
        {
            if (!nuevoEstado)
            {
                return Desactivar(idUsuario, out mensajeError);
            }

            mensajeError = string.Empty;
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                mensajeError = $"El rol actual '{SesionActual.Rol}' no tiene permisos para reactivar usuarios.";
                return false;
            }

            try
            {
                var usuario = _usuarioDatos.ObtenerPorId(idUsuario);
                if (usuario == null)
                {
                    mensajeError = "El usuario no existe.";
                    return false;
                }

                usuario.Activo = true;
                bool ok = _usuarioDatos.ActualizarUsuario(usuario);
                if (!ok)
                {
                    mensajeError = "No se pudo reactivar el usuario.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al cambiar el estado del usuario: " + ex.Message;
                return false;
            }
        }

        private string NormalizarRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol)) return "Cliente";

            string r = rol.Trim();
            if (r.Equals("Administrador", StringComparison.OrdinalIgnoreCase) || r.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                return "Administrador";
            if (r.Equals("Caja", StringComparison.OrdinalIgnoreCase) || r.Equals("Cajero", StringComparison.OrdinalIgnoreCase))
                return "Caja";

            return "Cliente";
        }
    }
}
