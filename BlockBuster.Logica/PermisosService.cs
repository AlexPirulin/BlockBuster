using System;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio para la verificación y autorización de permisos de usuario según su rol en el sistema.
    /// Roles admitidos: Administrador (admin), Caja (caja) y Cliente (cliente).
    /// </summary>
    public static class PermisosService
    {
        public static bool EsAdministrador(string rol = null)
        {
            string rolVerificar = rol ?? SesionActual.Rol;
            if (string.IsNullOrWhiteSpace(rolVerificar)) return false;

            return rolVerificar.Equals("Administrador", StringComparison.OrdinalIgnoreCase)
                || rolVerificar.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        public static bool EsCajero(string rol = null)
        {
            string rolVerificar = rol ?? SesionActual.Rol;
            if (string.IsNullOrWhiteSpace(rolVerificar)) return false;

            return rolVerificar.Equals("Caja", StringComparison.OrdinalIgnoreCase)
                || rolVerificar.Equals("Cajero", StringComparison.OrdinalIgnoreCase);
        }

        public static bool EsCliente(string rol = null)
        {
            string rolVerificar = rol ?? SesionActual.Rol;
            if (string.IsNullOrWhiteSpace(rolVerificar)) return false;

            return rolVerificar.Equals("Cliente", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para editar o modificar el inventario de artículos y películas.
        /// Permitido para: Administrador.
        /// </summary>
        public static bool PuedeEditarInventario(string rol = null)
        {
            return EsAdministrador(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para crear, modificar o desactivar cuentas de usuarios.
        /// Permitido para: Administrador.
        /// </summary>
        public static bool PuedeGestionarUsuarios(string rol = null)
        {
            return EsAdministrador(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para registrar compras de proveedores o abastecimiento.
        /// Permitido para: Administrador.
        /// </summary>
        public static bool PuedeRealizarCompras(string rol = null)
        {
            return EsAdministrador(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para realizar ventas de artículos.
        /// Permitido para: Administrador y Caja.
        /// </summary>
        public static bool PuedeRealizarVentas(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para realizar o registrar rentas de películas/artículos.
        /// Permitido para: Administrador y Caja.
        /// </summary>
        public static bool PuedeRealizarRentas(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol);
        }
    }
}

