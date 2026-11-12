using System;
using System.IO;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmArticuloForm : Form
    {
        public Articulo ArticuloActual { get; private set; }
        public string RutaImagenSeleccionada { get; private set; }

        public frmArticuloForm()
        {
            InitializeComponent();
        }

        public frmArticuloForm(Articulo articulo) : this()
        {
            ArticuloActual = articulo;
        }

        private void frmArticuloForm_Load(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex == -1 && cboCategoria.Items.Count > 0)
            {
                cboCategoria.SelectedIndex = 0;
            }

            if (ArticuloActual != null)
            {
                lblTituloVentana.Text = "EDITAR ARTÍCULO";
                this.Text = "BlockBuster - Editar Artículo";

                txtTitulo.Text = ArticuloActual.Titulo;
                txtCodigo.Text = ArticuloActual.Codigo;
                cboCategoria.Text = ArticuloActual.Tipo;
                txtGenero.Text = ArticuloActual.Genero;
                numPrecioRenta.Value = ArticuloActual.PrecioRenta;
                numPrecioVenta.Value = ArticuloActual.PrecioVenta;
                numStock.Value = ArticuloActual.Stock;
                chkActivo.Checked = ArticuloActual.Activo;
                RutaImagenSeleccionada = ArticuloActual.RutaImagen;

                lblRutaImagen.Text = string.IsNullOrEmpty(RutaImagenSeleccionada)
                    ? "Sin imagen asignada"
                    : Path.GetFileName(RutaImagenSeleccionada);

                picImagen.Image = ImagenService.CargarImagen(RutaImagenSeleccionada, ArticuloActual.Titulo);
            }
            else
            {
                lblTituloVentana.Text = "NUEVO ARTÍCULO";
                this.Text = "BlockBuster - Nuevo Artículo";
                picImagen.Image = ImagenService.GenerarImagenPorDefecto("NUEVO ARTÍCULO");
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Imagen del Artículo";
                ofd.Filter = "Archivos de Imagen (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Todos los Archivos (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Copia la imagen a la carpeta 'Imagenes' y devuelve la ruta relativa
                        string rutaRelativa = ImagenService.CopiarImagen(ofd.FileName);
                        RutaImagenSeleccionada = rutaRelativa;
                        lblRutaImagen.Text = Path.GetFileName(rutaRelativa);
                        picImagen.Image = ImagenService.CargarImagen(rutaRelativa, txtTitulo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al procesar la imagen seleccionada:\n" + ex.Message,
                            "Error de Imagen",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show(
                    "El nombre o título del artículo es requerido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }

            if (ArticuloActual == null)
            {
                ArticuloActual = new Articulo();
            }

            ArticuloActual.Titulo = txtTitulo.Text.Trim();
            ArticuloActual.Codigo = txtCodigo.Text.Trim();
            ArticuloActual.Tipo = cboCategoria.Text;
            ArticuloActual.Genero = txtGenero.Text.Trim();
            ArticuloActual.PrecioRenta = numPrecioRenta.Value;
            ArticuloActual.PrecioVenta = numPrecioVenta.Value;
            ArticuloActual.Stock = (int)numStock.Value;
            ArticuloActual.Activo = chkActivo.Checked;
            ArticuloActual.RutaImagen = RutaImagenSeleccionada;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

