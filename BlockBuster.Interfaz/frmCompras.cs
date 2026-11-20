using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmCompras : Form
    {
        private static frmCompras _instancia;
        private readonly CompraService _compraService;
        private readonly ValuacionService _valuacionService;
        private readonly ClienteService _clienteService;

        private List<Cliente> _listaClientes;

        public static frmCompras ObtenerInstancia(string operacion = "Compra", string categoria = "General")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmCompras(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Compra";
                _instancia.Categoria = categoria ?? "General";
                _instancia.ActualizarVista();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public static frmCompras Instancia => _instancia;

        public string Operacion { get; set; } = "Compra";
        public string Categoria { get; set; } = "General";

        public frmCompras()
        {
            InitializeComponent();
            _compraService = new CompraService();
            _valuacionService = new ValuacionService();
            _clienteService = new ClienteService();
        }

        public frmCompras(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Compra";
            Categoria = categoria ?? "General";
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            ActualizarVista();
            InicializarCombos();
            CargarClientes();
            RecalcularValuacion();
        }

        public void ActualizarVista()
        {
            this.Text = "BlockBuster - Compra de Artículos a Clientes";
            lblOperacionCategoria.Text = "📦 COMPRA DE ARTÍCULOS A CLIENTES";

            if (SesionActual.EstaAutenticado)
            {
                lblUsuarioSesion.Text = $"Sesión: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";

                bool esStaff = PermisosService.EsAdministrador() || PermisosService.EsCajero();
                if (esStaff)
                {
                    lblNotaRol.Text = "ℹ️ Modo Caja / Administrador:\nLa compra se confirmará de inmediato, se agregará el artículo al inventario y se generará el ticket comprobante.";
                    btnVerPendientes.Visible = true;
                }
                else
                {
                    lblNotaRol.Text = "ℹ️ Modo Cliente:\nLa propuesta de compra se registrará con estado PENDIENTE para su revisión y aprobación por personal de tienda.";
                    btnVerPendientes.Visible = false;
                }
            }
            else
            {
                lblUsuarioSesion.Text = "Sesión: No autenticado";
                btnVerPendientes.Visible = false;
            }
        }

        private void InicializarCombos()
        {
            if (cboTipo.Items.Count > 0 && cboTipo.SelectedIndex < 0)
            {
                int idx = cboTipo.FindStringExact(Categoria);
                cboTipo.SelectedIndex = idx >= 0 ? idx : 0;
            }

            if (cboEstadoFisico.Items.Count > 0 && cboEstadoFisico.SelectedIndex < 0)
            {
                cboEstadoFisico.SelectedIndex = 0; // Excelente (70%)
            }

            if (numPrecioReferencia.Value == 0)
            {
                numPrecioReferencia.Value = 500m;
            }
        }

        private void CargarClientes()
        {
            try
            {
                _listaClientes = _clienteService.ObtenerTodos();
                cboClientes.DataSource = null;

                if (_listaClientes == null || _listaClientes.Count == 0)
                {
                    cboClientes.Items.Clear();
                    cboClientes.Items.Add("-- No hay clientes registrados --");
                    cboClientes.SelectedIndex = 0;
                    return;
                }

                var itemsCombo = _listaClientes.Select(c => new
                {
                    c.IdCliente,
                    Descripcion = $"{c.NombreCompleto} - Tel: {c.Telefono}"
                }).ToList();

                cboClientes.DisplayMember = "Descripcion";
                cboClientes.ValueMember = "IdCliente";
                cboClientes.DataSource = itemsCombo;
                cboClientes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de clientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ObtenerEstadoSeleccionado()
        {
            string seleccionado = cboEstadoFisico.SelectedItem?.ToString() ?? "Excelente";
            if (seleccionado.StartsWith("Excelente", StringComparison.OrdinalIgnoreCase)) return "Excelente";
            if (seleccionado.StartsWith("Bueno", StringComparison.OrdinalIgnoreCase)) return "Bueno";
            if (seleccionado.StartsWith("Regular", StringComparison.OrdinalIgnoreCase)) return "Regular";
            if (seleccionado.StartsWith("Malo", StringComparison.OrdinalIgnoreCase)) return "Malo";
            return "Excelente";
        }

        private void RecalcularValuacion()
        {
            try
            {
                string estado = ObtenerEstadoSeleccionado();
                decimal precioRef = numPrecioReferencia.Value;
                decimal valuacion = _valuacionService.CalcularValuacion(estado, precioRef);
                decimal porcentaje = _valuacionService.ObtenerPorcentajePorEstado(estado);

                lblValuacionSugerida.Text = $"Valuación sugerida: {valuacion:C2} ({porcentaje * 100:0}% según estado '{estado}')";
                numPrecioAcordado.Value = valuacion;
            }
            catch
            {
                // Silencioso ante edición rápida
            }
        }

        private void cboEstadoFisico_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularValuacion();
        }

        private void numPrecioReferencia_ValueChanged(object sender, EventArgs e)
        {
            RecalcularValuacion();
        }

        private void btnRecargarClientes_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmRegistroCliente formCli = frmRegistroCliente.ObtenerInstancia();
            formCli.ShowDialog(this);
            CargarClientes();
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedValue == null || !int.TryParse(cboClientes.SelectedValue.ToString(), out int idCliente) || idCliente <= 0)
            {
                MessageBox.Show("Por favor seleccione un cliente válido de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboClientes.Focus();
                return;
            }

            string nombreArticulo = txtNombreArticulo.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreArticulo))
            {
                MessageBox.Show("Por favor ingrese el nombre del artículo a adquirir.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreArticulo.Focus();
                return;
            }

            string tipo = cboTipo.SelectedItem?.ToString() ?? "General";
            string genero = txtGenero.Text.Trim();
            string estadoFisico = ObtenerEstadoSeleccionado();
            decimal precioRef = numPrecioReferencia.Value;
            decimal precioAcordado = numPrecioAcordado.Value;

            if (precioAcordado <= 0)
            {
                MessageBox.Show("El precio de valuación acordado debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecioAcordado.Focus();
                return;
            }

            int idUsuario = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;

            string confirmMsg = $"¿Desea registrar la compra de:\n\n" +
                                $"Artículo: {nombreArticulo}\n" +
                                $"Tipo: {tipo}\n" +
                                $"Estado físico: {estadoFisico}\n" +
                                $"Monto acordado: {precioAcordado:C2}?";

            DialogResult dlg = MessageBox.Show(confirmMsg, "Confirmar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg != DialogResult.Yes) return;

            bool exito = _compraService.RegistrarCompra(
                idCliente,
                idUsuario,
                nombreArticulo,
                tipo,
                genero,
                estadoFisico,
                precioRef,
                precioAcordado,
                out string mensajeError,
                out Ticket ticketGenerado,
                out bool quedoPendiente);

            if (!exito)
            {
                MessageBox.Show(
                    "No se pudo completar la operación:\n" + mensajeError,
                    "Error en Compra",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (quedoPendiente)
            {
                MessageBox.Show(
                    "¡Propuesta de compra registrada con éxito!\n\n" +
                    "La transacción quedó en estado 'PENDIENTE' para su revisión y aprobación por un cajero o administrador.",
                    "Compra Registrada (Pendiente)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "¡Compra confirmada y procesada con éxito!\n\n" +
                    "El artículo fue agregado al inventario y se emitió el comprobante.",
                    "Compra Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (ticketGenerado != null)
                {
                    frmTicketViewer.MostrarTicketModal(ticketGenerado, this);
                }
            }

            // Limpiar formulario para la siguiente compra
            txtNombreArticulo.Clear();
            txtGenero.Clear();
            numPrecioReferencia.Value = 500m;
            RecalcularValuacion();
            txtNombreArticulo.Focus();
        }

        private void btnVerPendientes_Click(object sender, EventArgs e)
        {
            if (!PermisosService.EsAdministrador() && !PermisosService.EsCajero())
            {
                MessageBox.Show(
                    "Solo el personal de Caja o Administrador puede acceder al panel de compras pendientes.",
                    "Acceso Restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            frmComprasPendientes formPendientes = frmComprasPendientes.ObtenerInstancia();
            formPendientes.ShowDialog(this);
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
