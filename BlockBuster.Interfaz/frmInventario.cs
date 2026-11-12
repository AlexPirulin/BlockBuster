using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmInventario : Form
    {
        private static frmInventario _instancia;
        private readonly ArticuloService _articuloService;

        /// <summary>
        /// Singleton: Obtiene la instancia única de la ventana de Inventario.
        /// </summary>
        public static frmInventario ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmInventario();
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

        public static frmInventario Instancia => _instancia;

        public frmInventario()
        {
            InitializeComponent();
            _articuloService = new ArticuloService();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            // Validación de permisos en la capa lógica: Solo Admin puede gestionar inventario
            if (!PermisosService.PuedeEditarInventario())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no tiene permisos para acceder a la administración de inventario.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Administrador: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }

            if (cboFiltroCategoria.SelectedIndex == -1)
            {
                cboFiltroCategoria.SelectedIndex = 0; // "Todas"
            }

            CargarArticulos();
        }

        /// <summary>
        /// Carga y filtra los artículos utilizando ArticuloService.Buscar.
        /// </summary>
        public void CargarArticulos()
        {
            try
            {
                string texto = txtBuscar.Text.Trim();
                string categoria = cboFiltroCategoria.Text;
                bool soloDisponibles = chkSoloDisponibles.Checked;

                List<Articulo> articulos = _articuloService.Buscar(texto, categoria, soloDisponibles);
                dgvArticulos.DataSource = articulos;

                ConfigurarColumnasGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar artículos del inventario:\n" + ex.Message,
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvArticulos.Columns.Count > 0)
            {
                dgvArticulos.Columns["IdArticulo"].HeaderText = "ID";
                dgvArticulos.Columns["IdArticulo"].Width = 45;

                dgvArticulos.Columns["Codigo"].HeaderText = "Código";
                dgvArticulos.Columns["Codigo"].Width = 90;

                dgvArticulos.Columns["Titulo"].HeaderText = "Título / Nombre";
                dgvArticulos.Columns["Titulo"].FillWeight = 160;

                dgvArticulos.Columns["Tipo"].HeaderText = "Categoría";
                dgvArticulos.Columns["Tipo"].Width = 110;

                dgvArticulos.Columns["Genero"].HeaderText = "Plataforma / Género";
                dgvArticulos.Columns["Genero"].Width = 140;

                dgvArticulos.Columns["PrecioRenta"].HeaderText = "P. Renta";
                dgvArticulos.Columns["PrecioRenta"].DefaultCellStyle.Format = "$0.00";
                dgvArticulos.Columns["PrecioRenta"].Width = 85;

                dgvArticulos.Columns["PrecioVenta"].HeaderText = "P. Venta";
                dgvArticulos.Columns["PrecioVenta"].DefaultCellStyle.Format = "$0.00";
                dgvArticulos.Columns["PrecioVenta"].Width = 85;

                dgvArticulos.Columns["Stock"].HeaderText = "Existencia";
                dgvArticulos.Columns["Stock"].Width = 80;

                dgvArticulos.Columns["Activo"].HeaderText = "Activo";
                dgvArticulos.Columns["Activo"].Width = 60;

                if (dgvArticulos.Columns.Contains("RutaImagen"))
                {
                    dgvArticulos.Columns["RutaImagen"].HeaderText = "Imagen";
                    dgvArticulos.Columns["RutaImagen"].Width = 130;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void cboFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void chkSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cboFiltroCategoria.SelectedIndex = 0;
            chkSoloDisponibles.Checked = false;
            CargarArticulos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // "Conectar el botón de agregar con el formulario, sin guardar todavía"
            using (var form = new frmArticuloForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        "Formulario completado correctamente.\n(Modo de diseño: conectado con formulario de artículo sin guardar todavía en base de datos)",
                        "Nuevo Artículo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un artículo de la lista para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Articulo articuloSeleccionado = dgvArticulos.SelectedRows[0].DataBoundItem as Articulo;
            if (articuloSeleccionado != null)
            {
                using (var form = new frmArticuloForm(articuloSeleccionado))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string error;
                        if (_articuloService.Actualizar(form.ArticuloActual, out error))
                        {
                            MessageBox.Show("Artículo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarArticulos();
                        }
                        else
                        {
                            MessageBox.Show(error, "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un artículo de la lista para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Articulo articuloSeleccionado = dgvArticulos.SelectedRows[0].DataBoundItem as Articulo;
            if (articuloSeleccionado != null)
            {
                var confirm = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el artículo '{articuloSeleccionado.Titulo}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string error;
                    if (_articuloService.Eliminar(articuloSeleccionado.IdArticulo, out error))
                    {
                        MessageBox.Show("Artículo eliminado del inventario.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarArticulos();
                    }
                    else
                    {
                        MessageBox.Show(error, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

