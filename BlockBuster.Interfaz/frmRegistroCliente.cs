using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmRegistroCliente : Form
    {
        private static frmRegistroCliente _instancia;
        private readonly ClienteService _clienteService;

        /// <summary>
        /// Singleton: Obtiene la instancia única de la ventana de registro de clientes.
        /// </summary>
        public static frmRegistroCliente ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmRegistroCliente();
            }
            else
            {
                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;
                _instancia.BringToFront();
                _instancia.Activate();
            }
            return _instancia;
        }

        public static frmRegistroCliente Instancia => _instancia;

        public frmRegistroCliente()
        {
            InitializeComponent();
            _clienteService = new ClienteService();
        }

        private void frmRegistroCliente_Load(object sender, EventArgs e)
        {
            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Usuario: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }

            CargarClientes();
        }

        /// <summary>
        /// Carga la lista de clientes en el DataGridView.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                List<Cliente> clientes = _clienteService.ObtenerTodos();
                dgvClientes.DataSource = clientes;

                // Configurar columnas visibles
                if (dgvClientes.Columns.Count > 0)
                {
                    dgvClientes.Columns["IdCliente"].HeaderText = "ID";
                    dgvClientes.Columns["IdCliente"].Width = 50;
                    dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
                    dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
                    dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvClientes.Columns["Email"].HeaderText = "Correo";
                    dgvClientes.Columns["Direccion"].HeaderText = "Dirección";

                    if (dgvClientes.Columns.Contains("Activo"))
                        dgvClientes.Columns["Activo"].Visible = false;
                    if (dgvClientes.Columns.Contains("FechaRegistro"))
                        dgvClientes.Columns["FechaRegistro"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de clientes: " + ex.Message,
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre del cliente es obligatorio.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            string mensajeError;
            bool resultado = _clienteService.Guardar(nuevoCliente, out mensajeError);

            if (resultado)
            {
                MessageBox.Show(
                    "Cliente registrado exitosamente.",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            else
            {
                MessageBox.Show(
                    mensajeError,
                    "Error al Registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string criterio = txtBuscar.Text.Trim();
                List<Cliente> resultados = _clienteService.Buscar(criterio);
                dgvClientes.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar clientes: " + ex.Message,
                    "Error de Búsqueda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtNombre.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }
    }
}

