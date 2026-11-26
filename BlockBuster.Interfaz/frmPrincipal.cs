using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarInformacionUsuario();
            AplicarPermisos();
        }

        /// <summary>
        /// Muestra en la ventana principal el nombre completo y el rol guardados en SesionActual.
        /// </summary>
        public void ActualizarInformacionUsuario()
        {
            if (SesionActual.EstaAutenticado)
            {
                string infoUsuario = $"{SesionActual.NombreCompleto} ({SesionActual.NombreUsuario})";
                string infoRol = SesionActual.Rol;

                // 1. Título de la ventana
                this.Text = $"BlockBuster - Sistema Principal | Usuario: {infoUsuario} | Rol: {infoRol}";

                // 2. Etiquetas visuales en el panel superior
                lblUsuarioActual.Text = $"Usuario: {infoUsuario}";
                lblRolActual.Text = $"Rol: {infoRol}";

                // 3. Barra de estado inferior
                lblStatusUsuario.Text = $"Usuario: {infoUsuario}";
                lblStatusRol.Text = $"Rol: {infoRol}";
            }
            else
            {
                this.Text = "BlockBuster - Sistema Principal | Sesión no iniciada";
                lblUsuarioActual.Text = "Usuario: No autenticado";
                lblRolActual.Text = "Rol: -";
                lblStatusUsuario.Text = "Usuario: -";
                lblStatusRol.Text = "Rol: -";
            }
        }

        /// <summary>
        /// Aplica la autorización para las ventanas y botones según los métodos de PermisosService.
        /// Inventario es exclusivo para Administrador; Registro de Clientes para Admin y Caja.
        /// </summary>
        public void AplicarPermisos()
        {
            btnRenta.Enabled = PermisosService.PuedeRealizarRentas();
            btnVenta.Enabled = PermisosService.PuedeRealizarVentas();
            btnCompra.Enabled = SesionActual.EstaAutenticado;
            btnCatalogo.Visible = true;
            btnTickets.Visible = SesionActual.EstaAutenticado;

            // Devoluciones y compras pendientes exclusivos para Administrador y Caja
            btnRentasActivas.Visible = PermisosService.PuedeRegistrarDevolucion();
            btnComprasPendientes.Visible = PermisosService.EsAdministrador() || PermisosService.EsCajero();

            // Inventario, Usuarios, Reportes y Configuración exclusivos para Administrador
            btnInventario.Visible = PermisosService.PuedeEditarInventario();
            btnUsuarios.Visible = PermisosService.PuedeGestionarUsuarios();
            btnReportes.Visible = PermisosService.PuedeVerReportes();
            btnConfiguracion.Visible = PermisosService.PuedeConfigurarSistema();

            // Registro de Clientes disponible para Administrador y Caja
            btnClientes.Visible = PermisosService.EsAdministrador() || PermisosService.EsCajero();
        }

        #region Eventos de Botones Principales

        /// <summary>
        /// Método auxiliar que valida permisos antes de abrir una ventana MDI Singleton,
        /// evitando duplicar cuadros de diálogo de acceso denegado.
        /// </summary>
        private void AbrirSiTienePermiso(bool autorizado, string nombreModulo, Func<Form> obtenerInstancia)
        {
            if (!autorizado)
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para acceder a {nombreModulo}.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AbrirVentanaMdi(obtenerInstancia());
        }

        private void btnRenta_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(PermisosService.PuedeRealizarRentas(), "módulo de rentas", () => frmRentas.ObtenerInstancia());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(PermisosService.PuedeRealizarVentas(), "módulo de ventas", () => frmVentas.ObtenerInstancia());
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmCompras.ObtenerInstancia());
        }

        private void btnComprasPendientes_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.EsAdministrador() || PermisosService.EsCajero(),
                "revisar compras pendientes",
                () => frmComprasPendientes.ObtenerInstancia());
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmSeleccionCategoria.ObtenerInstancia("Catálogo"));
        }

        private void btnRentasActivas_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.PuedeRegistrarDevolucion(),
                "registrar devoluciones de rentas",
                () => frmRentasActivas.ObtenerInstancia());
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmHistorialTickets.ObtenerInstancia());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.PuedeVerReportes(),
                "consultar reportes administrativos",
                () => frmReportes.ObtenerInstancia());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.PuedeConfigurarSistema(),
                "modificar la configuración del sistema",
                () => frmConfiguracion.ObtenerInstancia());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.PuedeEditarInventario(),
                "gestionar el inventario",
                () => frmInventario.ObtenerInstancia());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.PuedeGestionarUsuarios(),
                "gestionar usuarios del sistema",
                () => fmrRegistroUsuario.ObtenerInstancia());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirSiTienePermiso(
                PermisosService.EsAdministrador() || PermisosService.EsCajero(),
                "gestionar clientes",
                () => frmRegistroCliente.ObtenerInstancia());
        }

        #endregion

        /// <summary>
        /// Cierra cualquier otra ventana secundaria para mantener una sola activa a la vez (Singleton)
        /// y presenta la ventana MDI solicitada en primer plano.
        /// </summary>
        private void AbrirVentanaMdi(Form ventana)
        {
            if (ventana == null) return;

            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != ventana)
                {
                    hijo.Close();
                }
            }

            ventana.MdiParent = this;
            ventana.Show();
            ventana.BringToFront();
            ventana.Activate();
        }

        /// <summary>
        /// Cierra la sesión activa del usuario y retorna a la pantalla de Login.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Limpia la sesión actual
                SesionActual.CerrarSesion();

                // Cierra la ventana principal; Program.cs detecta el cierre de sesión y reabre Form1
                this.Close();
            }
        }
    }
}
