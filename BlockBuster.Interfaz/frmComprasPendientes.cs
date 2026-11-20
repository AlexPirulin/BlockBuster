using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmComprasPendientes : Form
    {
        private static frmComprasPendientes _instancia;
        private readonly CompraService _compraService;
        private List<Transaccion> _listaPendientes;

        public static frmComprasPendientes ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmComprasPendientes();
            }
            else
            {
                _instancia.CargarPendientes();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public static frmComprasPendientes Instancia => _instancia;

        public frmComprasPendientes()
        {
            InitializeComponent();
            _compraService = new CompraService();
        }

        private void frmComprasPendientes_Load(object sender, EventArgs e)
        {
            // Validar permisos en lógica: Solo Admin o Caja pueden gestionar compras pendientes
            if (!PermisosService.EsAdministrador() && !PermisosService.EsCajero())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para revisar compras de clientes.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarPendientes();
        }

        public void CargarPendientes()
        {
            try
            {
                _listaPendientes = _compraService.ObtenerComprasPendientes();
                dgvPendientes.Rows.Clear();

                foreach (var trx in _listaPendientes)
                {
                    string clienteNombre = trx.Cliente != null ? trx.Cliente.NombreCompleto : "Sin cliente";
                    var primerDetalle = trx.Detalles?.FirstOrDefault();
                    string descripcion = primerDetalle != null ? primerDetalle.Descripcion : trx.Observaciones;

                    dgvPendientes.Rows.Add(
                        trx.IdTransaccion,
                        trx.Folio,
                        trx.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        clienteNombre,
                        descripcion,
                        trx.Total.ToString("C2"),
                        trx.Estado
                    );
                }

                lblContador.Text = $"Pendientes: {_listaPendientes.Count} compra(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las compras pendientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPendientes();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvPendientes.CurrentRow == null || dgvPendientes.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor seleccione una compra de la lista para aprobar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idTrx = Convert.ToInt32(dgvPendientes.CurrentRow.Cells["colIdTransaccion"].Value);
            string folio = dgvPendientes.CurrentRow.Cells["colFolio"].Value?.ToString();
            string articulo = dgvPendientes.CurrentRow.Cells["colDescripcion"].Value?.ToString();
            string total = dgvPendientes.CurrentRow.Cells["colTotal"].Value?.ToString();

            string confirmMsg = $"¿Está seguro de APROBAR la siguiente compra?\n\n" +
                                $"Folio: {folio}\n" +
                                $"Artículo: {articulo}\n" +
                                $"Monto a pagar: {total}\n\n" +
                                $"El artículo será ingresado al inventario activo y se generará el ticket oficial.";

            DialogResult dlg = MessageBox.Show(confirmMsg, "Aprobar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg != DialogResult.Yes) return;

            int idUsuarioAprobador = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;

            bool exito = _compraService.AprobarCompra(
                idTrx,
                idUsuarioAprobador,
                out string mensajeError,
                out Ticket ticketGenerado);

            if (!exito)
            {
                MessageBox.Show(
                    "No se pudo aprobar la compra:\n" + mensajeError,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "¡Compra aprobada con éxito!\n\nEl artículo ha sido registrado en inventario.",
                "Compra Aprobada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarPendientes();

            if (ticketGenerado != null)
            {
                frmTicketViewer.MostrarTicketModal(ticketGenerado, this);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvPendientes.CurrentRow == null || dgvPendientes.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor seleccione una compra de la lista para rechazar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idTrx = Convert.ToInt32(dgvPendientes.CurrentRow.Cells["colIdTransaccion"].Value);
            string folio = dgvPendientes.CurrentRow.Cells["colFolio"].Value?.ToString();
            string articulo = dgvPendientes.CurrentRow.Cells["colDescripcion"].Value?.ToString();

            string confirmMsg = $"¿Está seguro de RECHAZAR la propuesta de compra {folio} ({articulo})?";
            DialogResult dlg = MessageBox.Show(confirmMsg, "Rechazar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg != DialogResult.Yes) return;

            int idUsuario = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;

            bool exito = _compraService.RechazarCompra(
                idTrx,
                idUsuario,
                "Rechazada tras inspección física del personal",
                out string mensajeError);

            if (!exito)
            {
                MessageBox.Show(
                    "No se pudo rechazar la compra:\n" + mensajeError,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "La propuesta de compra ha sido marcada como Rechazada.",
                "Compra Rechazada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarPendientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }
    }
}

