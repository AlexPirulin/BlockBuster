using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmRentas : Form
    {
        private static frmRentas _instancia;
        private readonly RentaService _rentaService;
        private readonly ArticuloService _articuloService;
        private readonly ClienteService _clienteService;

        private List<Cliente> _listaClientes;
        private List<Articulo> _listaArticulos;

        public static frmRentas ObtenerInstancia(string operacion = "Renta", string categoria = "Películas")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmRentas(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Renta";
                _instancia.Categoria = categoria ?? "Películas";
                _instancia.ActualizarVista();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public static frmRentas Instancia => _instancia;

        public string Operacion { get; set; } = "Renta";
        public string Categoria { get; set; } = "Películas";

        public frmRentas()
        {
            InitializeComponent();
            _rentaService = new RentaService();
            _articuloService = new ArticuloService();
            _clienteService = new ClienteService();
        }

        public frmRentas(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Renta";
            Categoria = categoria ?? "Películas";
        }

        private void frmRentas_Load(object sender, EventArgs e)
        {
            // Validar permiso en lógica
            if (!PermisosService.PuedeRealizarRentas())
            {
                MessageBox.Show(
                    $"El rol actual '{SesionActual.Rol}' no cuenta con permisos para registrar rentas.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            ActualizarVista();
            cboMetodoPago.SelectedIndex = 0; // Efectivo
            CargarClientes();
            CargarArticulos();
            ActualizarCalculoTotal();
        }

        public void ActualizarVista()
        {
            this.Text = "BlockBuster - Módulo de Renta";
            lblOperacionCategoria.Text = $"🔄 REGISTRO DE RENTA";

            if (SesionActual.EstaAutenticado)
            {
                lblUsuarioSesion.Text = $"Atendido por: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }
            else
            {
                lblUsuarioSesion.Text = "Sesión: No autenticado";
            }
        }

        private void CargarClientes()
        {
            try
            {
                _listaClientes = _clienteService.ObtenerTodos();
                cboClientes.DataSource = null;
                cboClientes.DisplayMember = "NombreCompleto";
                cboClientes.ValueMember = "IdCliente";

                var clientesDisplay = _listaClientes.Select(c => new
                {
                    IdCliente = c.IdCliente,
                    NombreCompleto = $"{c.Nombre} {c.Apellido} (Tel: {c.Telefono})"
                }).ToList();

                cboClientes.DataSource = clientesDisplay;

                if (cboClientes.Items.Count > 0)
                {
                    cboClientes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarArticulos()
        {
            try
            {
                // Solo artículos activos con stock > 0 y que tengan tarifa de renta configurada
                _listaArticulos = _articuloService.Buscar(null, null, true)
                    .Where(a => a.Stock > 0 && a.PrecioRenta > 0)
                    .ToList();

                cboArticulos.DataSource = null;
                var articulosDisplay = _listaArticulos.Select(a => new
                {
                    IdArticulo = a.IdArticulo,
                    Titulo = $"{a.Titulo} [{a.Tipo}] - Stock: {a.Stock} - ${a.PrecioRenta:F2}/día"
                }).ToList();

                cboArticulos.DataSource = articulosDisplay;
                cboArticulos.DisplayMember = "Titulo";
                cboArticulos.ValueMember = "IdArticulo";

                if (cboArticulos.Items.Count > 0)
                {
                    cboArticulos.SelectedIndex = 0;
                }
                else
                {
                    lblPrecioDiario.Text = "Tarifa Diaria: $0.00";
                    lblStockDisponible.Text = "Stock: 0";
                    lblTipoGenero.Text = "No hay artículos disponibles para renta.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Articulo ObtenerArticuloSeleccionado()
        {
            if (cboArticulos.SelectedValue is int id && _listaArticulos != null)
            {
                return _listaArticulos.FirstOrDefault(a => a.IdArticulo == id);
            }
            return null;
        }

        private void cboArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var art = ObtenerArticuloSeleccionado();
            if (art != null)
            {
                lblPrecioDiario.Text = $"Tarifa Diaria: {art.PrecioRenta:C2}";
                lblStockDisponible.Text = $"Stock: {art.Stock} disp.";
                lblTipoGenero.Text = $"Categoría: {art.Tipo} | Género: {art.Genero}";
            }
            ActualizarCalculoTotal();
        }

        private void numDias_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculoTotal();
        }

        private void ActualizarCalculoTotal()
        {
            int dias = (int)numDias.Value;
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaDevolucion = fechaInicio.AddDays(dias);

            lblFechaInicio.Text = $"Fecha Renta: {fechaInicio:dd/MM/yyyy}";
            lblFechaDevolucion.Text = $"Devolución: {fechaDevolucion:dd/MM/yyyy}";

            var art = ObtenerArticuloSeleccionado();
            if (art != null)
            {
                decimal tarifa = art.PrecioRenta;
                decimal subtotal = _rentaService.CalcularTotal(tarifa, dias);

                lblDesglose.Text = $"Desglose: {dias} días x {tarifa:C2}/día = {subtotal:C2}";
                lblTotal.Text = subtotal.ToString("C2");
            }
            else
            {
                lblDesglose.Text = "Desglose: 0 días x $0.00 = $0.00";
                lblTotal.Text = "$0.00";
            }
        }

        private void btnConfirmarRenta_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente titular de la renta.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var articulo = ObtenerArticuloSeleccionado();
            if (articulo == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo disponible.", "Artículo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = (int)cboClientes.SelectedValue;
            int idUsuario = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;
            int dias = (int)numDias.Value;
            string metodoPago = cboMetodoPago.Text;

            if (dias < 1)
            {
                MessageBox.Show("Los días de renta deben ser al menos 1.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDias.Focus();
                return;
            }

            if (articulo.Stock < 1)
            {
                MessageBox.Show("El artículo seleccionado no cuenta con existencias suficientes.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(metodoPago))
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMetodoPago.Focus();
                return;
            }

            var lista = new List<ItemCarritoDto>
            {
                new ItemCarritoDto
                {
                    IdArticulo = articulo.IdArticulo,
                    Titulo = articulo.Titulo,
                    Cantidad = 1,
                    PrecioUnitario = articulo.PrecioRenta
                }
            };

            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar renta del artículo '{articulo.Titulo}' por {dias} días a un total de {lblTotal.Text}?",
                "Confirmar Renta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string error;
                Ticket ticket;
                bool ok = _rentaService.RegistrarRenta(
                    idCliente,
                    idUsuario,
                    lista,
                    dias,
                    metodoPago,
                    out error,
                    out ticket);

                if (ok)
                {
                    MessageBox.Show(
                        $"¡Renta registrada exitosamente!\nFolio Ticket: {ticket?.Folio}\nFecha de devolución: {DateTime.Now.AddDays(dias):dd/MM/yyyy}",
                        "Renta Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Mostrar comprobante oficial inmediatamente
                    frmTicketViewer.MostrarTicketModal(ticket, this);

                    // Recargar existencias
                    CargarArticulos();
                    ActualizarCalculoTotal();
                }
                else
                {
                    MessageBox.Show(error, "Error en Renta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmRegistroCliente form = frmRegistroCliente.ObtenerInstancia();
            form.ShowDialog(this);
            CargarClientes();
        }

        private void btnRecargarClientes_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
