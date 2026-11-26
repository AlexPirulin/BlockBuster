using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmVentas : Form
    {
        private static frmVentas _instancia;
        private readonly VentaService _ventaService;
        private readonly ArticuloService _articuloService;
        private readonly ClienteService _clienteService;

        private List<Cliente> _listaClientes;
        private List<Articulo> _listaArticulos;
        private readonly List<ItemCarritoDto> _carrito;

        public static frmVentas ObtenerInstancia(string operacion = "Venta", string categoria = "Películas")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmVentas(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Venta";
                _instancia.Categoria = categoria ?? "Películas";
                _instancia.ActualizarVista();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public static frmVentas Instancia => _instancia;

        public string Operacion { get; set; } = "Venta";
        public string Categoria { get; set; } = "Películas";

        public frmVentas()
        {
            InitializeComponent();
            _ventaService = new VentaService();
            _articuloService = new ArticuloService();
            _clienteService = new ClienteService();
            _carrito = new List<ItemCarritoDto>();
        }

        public frmVentas(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Venta";
            Categoria = categoria ?? "Películas";
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRealizarVentas())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para realizar ventas.",
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
            RefrescarGridCarrito();
        }

        public void ActualizarVista()
        {
            this.Text = "BlockBuster - Módulo de Venta";
            lblOperacionCategoria.Text = "🛒 MÓDULO DE VENTA EN MOSTRADOR";

            if (SesionActual.EstaAutenticado)
            {
                lblUsuarioSesion.Text = $"Atendido por: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
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
                _listaArticulos = _articuloService.Buscar(null, null, true)
                    .Where(a => a.Stock > 0 && a.PrecioVenta > 0)
                    .ToList();

                cboArticulos.DataSource = null;
                var articulosDisplay = _listaArticulos.Select(a => new
                {
                    IdArticulo = a.IdArticulo,
                    Titulo = $"{a.Titulo} [{a.Tipo}] - Stock: {a.Stock} - ${a.PrecioVenta:F2}"
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
                    lblPrecioVenta.Text = "Precio: $0.00";
                    lblStockInfo.Text = "Stock: 0";
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
                lblPrecioVenta.Text = $"Precio: {art.PrecioVenta:C2}";
                lblStockInfo.Text = $"Stock disponible: {art.Stock}";
                numCantidad.Maximum = art.Stock > 0 ? art.Stock : 1;
                numCantidad.Value = 1;
            }
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            var art = ObtenerArticuloSeleccionado();
            if (art == null)
            {
                MessageBox.Show("Seleccione un artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero (no se permiten cantidades negativas o nulas).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return;
            }

            if (cantidad > art.Stock)
            {
                MessageBox.Show($"Existencia insuficiente. Solo hay {art.Stock} unidad(es) disponible(s) en inventario.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return;
            }

            // Verificar si ya está en carrito para sumar cantidad
            var existente = _carrito.FirstOrDefault(c => c.IdArticulo == art.IdArticulo);
            if (existente != null)
            {
                if (existente.Cantidad + cantidad > art.Stock)
                {
                    MessageBox.Show(
                        $"No puede agregar más unidades de las disponibles en inventario ({art.Stock}).",
                        "Stock Insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                existente.Cantidad += cantidad;
            }
            else
            {
                _carrito.Add(new ItemCarritoDto
                {
                    IdArticulo = art.IdArticulo,
                    Codigo = art.Codigo,
                    Titulo = art.Titulo,
                    Tipo = art.Tipo,
                    Cantidad = cantidad,
                    PrecioUnitario = art.PrecioVenta
                });
            }

            RefrescarGridCarrito();
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo del carrito para quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = dgvCarrito.SelectedRows[0].Index;
            if (index >= 0 && index < _carrito.Count)
            {
                _carrito.RemoveAt(index);
                RefrescarGridCarrito();
            }
        }

        private void btnLimpiarCarrito_Click(object sender, EventArgs e)
        {
            _carrito.Clear();
            RefrescarGridCarrito();
        }

        private void RefrescarGridCarrito()
        {
            dgvCarrito.DataSource = null;

            var itemsGrid = _carrito.Select(c => new
            {
                c.IdArticulo,
                c.Codigo,
                c.Titulo,
                c.Cantidad,
                PrecioUnitario = c.PrecioUnitario.ToString("C2"),
                Subtotal = c.Subtotal.ToString("C2")
            }).ToList();

            dgvCarrito.DataSource = itemsGrid;

            if (dgvCarrito.Columns.Count > 0)
            {
                dgvCarrito.Columns["IdArticulo"].Width = 45;
                dgvCarrito.Columns["Codigo"].Width = 90;
                dgvCarrito.Columns["Titulo"].FillWeight = 160;
                dgvCarrito.Columns["Cantidad"].Width = 70;
                dgvCarrito.Columns["PrecioUnitario"].Width = 100;
                dgvCarrito.Columns["Subtotal"].Width = 110;
            }

            decimal total = _carrito.Sum(c => c.Subtotal);
            lblTotal.Text = total.ToString("C2");
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente para la venta.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_carrito.Count == 0)
            {
                MessageBox.Show("El carrito de compra está vacío.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = (int)cboClientes.SelectedValue;
            int idUsuario = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;
            string metodoPago = cboMetodoPago.Text;

            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar venta de {_carrito.Sum(c => c.Cantidad)} artículo(s) por un total de {lblTotal.Text} (Pago: {metodoPago})?",
                "Confirmar Venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string error;
                Ticket ticket;
                bool ok = _ventaService.RegistrarVenta(
                    idCliente,
                    idUsuario,
                    _carrito,
                    metodoPago,
                    out error,
                    out ticket);

                if (ok)
                {
                    MessageBox.Show(
                        $"¡Venta registrada con éxito!\nFolio Ticket: {ticket?.Folio}\nTotal: {lblTotal.Text}",
                        "Venta Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Mostrar el ticket oficial
                    frmTicketViewer.MostrarTicketModal(ticket, this);

                    // Limpiar carrito y refrescar artículos
                    _carrito.Clear();
                    RefrescarGridCarrito();
                    CargarArticulos();
                }
                else
                {
                    MessageBox.Show(error, "Error en Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
