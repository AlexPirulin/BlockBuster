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
        /// Determina si el rol tiene permiso para realizar ventas / compras en tienda.
        /// Permitido para: Administrador, Caja y Cliente.
        /// </summary>
        public static bool PuedeRealizarVentas(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol) || EsCliente(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para realizar o registrar rentas de películas/artículos.
        /// Permitido para: Administrador, Caja y Cliente.
        /// </summary>
        public static bool PuedeRealizarRentas(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol) || EsCliente(rol);
        }

        /// <summary>
        /// Determina si el rol puede registrar devoluciones de rentas activas/vencidas.
        /// Permitido para: Administrador y Caja.
        /// </summary>
        public static bool PuedeRegistrarDevolucion(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol);
        }

        /// <summary>
        /// Determina si el rol puede consultar el historial completo de tickets de todos los usuarios.
        /// Admin y Caja ven todo; Cliente solo ve sus propios tickets.
        /// </summary>
        public static bool PuedeVerHistorialCompletoTickets(string rol = null)
        {
            return EsAdministrador(rol) || EsCajero(rol);
        }

        /// <summary>
        /// Determina si el rol tiene acceso a reportes financieros y de inventario bajo.
        /// Permitido para: Administrador.
        /// </summary>
        public static bool PuedeVerReportes(string rol = null)
        {
            return EsAdministrador(rol);
        }

        /// <summary>
        /// Determina si el rol tiene permiso para modificar la configuración del sistema.
        /// Permitido para: Administrador.
        /// </summary>
        public static bool PuedeConfigurarSistema(string rol = null)
        {
            return EsAdministrador(rol);
        }
    }
}

