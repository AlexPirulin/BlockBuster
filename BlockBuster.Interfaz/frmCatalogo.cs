using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmCatalogo : Form
    {
        private static frmCatalogo _instancia;
        private readonly ArticuloService _articuloService;

        public string Operacion { get; set; } = "Renta";
        public string CategoriaSeleccionada { get; set; } = "Todas";

        /// <summary>
        /// Singleton: Obtiene o reactiva la instancia única del Catálogo.
        /// </summary>
        public static frmCatalogo ObtenerInstancia(string operacion = "Renta", string categoria = "Todas")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmCatalogo(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Renta";
                _instancia.CategoriaSeleccionada = string.IsNullOrWhiteSpace(categoria) ? "Todas" : categoria;
                _instancia.ActualizarHeaderYCategoria();
                _instancia.CargarTarjetas();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }
            return _instancia;
        }

        public static frmCatalogo Instancia => _instancia;

        /// <summary>
        /// Refresca las tarjetas del catálogo si la ventana se encuentra abierta.
        /// </summary>
        public static void RefrescarSiEstaAbierto()
        {
            if (_instancia != null && !_instancia.IsDisposed)
            {
                _instancia.CargarTarjetas();
            }
        }

        public frmCatalogo()
        {
            InitializeComponent();
            _articuloService = new ArticuloService();
        }

        public frmCatalogo(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Renta";
            CategoriaSeleccionada = string.IsNullOrWhiteSpace(categoria) ? "Todas" : categoria;
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            ActualizarHeaderYCategoria();
            ConfigurarBotonAccionOperacion();
            CargarTarjetas();
        }

        private void ConfigurarBotonAccionOperacion()
        {
            if (btnIrAOperacion == null)
            {
                btnIrAOperacion = new Button
                {
                    Size = new Size(185, 38),
                    Location = new Point(535, 16),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Arial Rounded MT Bold", 9.5f, FontStyle.Bold),
                    ForeColor = Color.White
                };
                btnIrAOperacion.FlatAppearance.BorderSize = 2;
                btnIrAOperacion.Click += (s, ev) => AbrirFormularioOperacion(cboCategoria.SelectedItem?.ToString());
                pnlHeader.Controls.Add(btnIrAOperacion);
            }

            if (Operacion.Equals("Renta", StringComparison.OrdinalIgnoreCase))
            {
                btnIrAOperacion.Text = "🔄 Ir a Rentar";
                btnIrAOperacion.BackColor = Color.DodgerBlue;
            }
            else if (Operacion.Equals("Compra", StringComparison.OrdinalIgnoreCase))
            {
                btnIrAOperacion.Text = "📦 Ir a Comprar";
                btnIrAOperacion.BackColor = Color.DarkOrange;
            }
            else
            {
                btnIrAOperacion.Text = "🛒 Ir a Ventas";
                btnIrAOperacion.BackColor = Color.SeaGreen;
            }
        }

        private Button btnIrAOperacion;

        public void AbrirFormularioOperacion(string categoria = null)
        {
            Form parentMdi = this.MdiParent;
            string cat = !string.IsNullOrWhiteSpace(categoria) && !categoria.Equals("Todas", StringComparison.OrdinalIgnoreCase)
                ? categoria
                : (cboCategoria.SelectedItem?.ToString() ?? "Películas");

            Form formOp;
            if (Operacion.Equals("Renta", StringComparison.OrdinalIgnoreCase))
                formOp = frmRentas.ObtenerInstancia("Renta", cat);
            else if (Operacion.Equals("Compra", StringComparison.OrdinalIgnoreCase))
                formOp = frmCompras.ObtenerInstancia("Compra", cat);
            else
                formOp = frmVentas.ObtenerInstancia("Venta", cat);

            if (parentMdi != null)
            {
                foreach (Form hijo in parentMdi.MdiChildren)
                {
                    if (hijo != formOp && hijo != this)
                        hijo.Close();
                }
                formOp.MdiParent = parentMdi;
            }

            this.Close();
            formOp.Show();
            formOp.BringToFront();
            formOp.Activate();
        }

        public void ActualizarHeaderYCategoria()
        {
            lblTituloOperacion.Text = $"CATÁLOGO DE {Operacion.ToUpper()}";
            this.Text = $"BlockBuster - Catálogo ({Operacion})";

            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Sesión: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }

            // Seleccionar en el ComboBox la categoría solicitada
            if (!string.IsNullOrWhiteSpace(CategoriaSeleccionada))
            {
                int idx = cboCategoria.FindStringExact(CategoriaSeleccionada);
                if (idx >= 0)
                {
                    cboCategoria.SelectedIndex = idx;
                }
                else
                {
                    cboCategoria.SelectedIndex = 0; // "Todas"
                }
            }
            else
            {
                cboCategoria.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Realiza la búsqueda a través de ArticuloService y construye las tarjetas visuales.
        /// </summary>
        public void CargarTarjetas()
        {
            try
            {
                string texto = txtBuscar.Text.Trim();
                string categoria = cboCategoria.Text;
                bool soloDisponibles = chkSoloDisponibles.Checked;

                List<Articulo> articulos = _articuloService.Buscar(texto, categoria, soloDisponibles);

                flpTarjetas.SuspendLayout();

                // Liberar recursos GDI de tarjetas anteriores para optimizar memoria
                while (flpTarjetas.Controls.Count > 0)
                {
                    Control c = flpTarjetas.Controls[0];
                    flpTarjetas.Controls.RemoveAt(0);
                    c.Dispose();
                }

                lblContador.Text = $"Artículos: {articulos.Count}";

                if (articulos.Count == 0)
                {
                    Label lblVacio = new Label
                    {
                        Text = "No se encontraron artículos con los filtros seleccionados.",
                        Font = new Font("Arial Rounded MT Bold", 13, FontStyle.Italic),
                        ForeColor = Color.Gold,
                        AutoSize = false,
                        Size = new Size(flpTarjetas.Width - 40, 60),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(20, 40, 20, 20)
                    };
                    flpTarjetas.Controls.Add(lblVacio);
                }
                else
                {
                    foreach (var art in articulos)
                    {
                        Panel card = CrearTarjetaArticulo(art);
                        flpTarjetas.Controls.Add(card);
                    }
                }

                flpTarjetas.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el catálogo de artículos:\n" + ex.Message,
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Crea una tarjeta individual con imagen, nombre, categoría, precio y etiqueta de disponibilidad.
        /// </summary>
        private Panel CrearTarjetaArticulo(Articulo articulo)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 340),
                BackColor = Color.FromArgb(22, 35, 58),
                Margin = new Padding(12),
                BorderStyle = BorderStyle.FixedSingle
            };

            // 1. Imagen del artículo
            PictureBox pic = new PictureBox
            {
                Size = new Size(196, 170),
                Location = new Point(11, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(12, 20, 35),
                BorderStyle = BorderStyle.FixedSingle,
                Image = ImagenService.CargarImagen(articulo.RutaImagen, articulo.Titulo)
            };
            card.Controls.Add(pic);

            // 2. Nombre / Título
            Label lblNombre = new Label
            {
                Location = new Point(10, 185),
                Size = new Size(198, 38),
                Font = new Font("Arial Rounded MT Bold", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                Text = articulo.Titulo,
                AutoEllipsis = true
            };
            card.Controls.Add(lblNombre);

            // 3. Categoría y Género/Plataforma
            string detalleCat = $"{articulo.Tipo} | {articulo.Genero}";
            Label lblCat = new Label
            {
                Location = new Point(10, 225),
                Size = new Size(198, 20),
                Font = new Font("Arial", 8.2f, FontStyle.Regular),
                ForeColor = Color.LightCyan,
                Text = detalleCat,
                AutoEllipsis = true
            };
            card.Controls.Add(lblCat);

            // 4. Precio según la operación (Renta vs Venta / Compra)
            decimal precioAMostrar = Operacion.Equals("Renta", StringComparison.OrdinalIgnoreCase)
                ? articulo.PrecioRenta
                : articulo.PrecioVenta;

            string etiquetaOperacion = Operacion.Equals("Renta", StringComparison.OrdinalIgnoreCase) ? "Renta" : "Precio";

            Label lblPrecio = new Label
            {
                Location = new Point(10, 250),
                Size = new Size(198, 26),
                Font = new Font("Arial Rounded MT Bold", 11.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 204, 0), // Dorado Blockbuster
                Text = $"{etiquetaOperacion}: {precioAMostrar:C2}"
            };
            card.Controls.Add(lblPrecio);

            // 5. Etiqueta de disponibilidad ("Disponible" o "No disponible" si existencia en 0)
            bool estaDisponible = articulo.Stock > 0;
            Label lblDisponibilidad = new Label
            {
                Location = new Point(10, 285),
                Size = new Size(198, 32),
                Font = new Font("Arial Rounded MT Bold", 9.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            if (estaDisponible)
            {
                lblDisponibilidad.Text = $"🟢 DISPONIBLE ({articulo.Stock})";
                lblDisponibilidad.ForeColor = Color.FromArgb(120, 255, 140);
                lblDisponibilidad.BackColor = Color.FromArgb(18, 55, 30);
            }
            else
            {
                lblDisponibilidad.Text = "🔴 NO DISPONIBLE";
                lblDisponibilidad.ForeColor = Color.FromArgb(255, 130, 130);
                lblDisponibilidad.BackColor = Color.FromArgb(75, 20, 20);
            }
            card.Controls.Add(lblDisponibilidad);

            card.Cursor = Cursors.Hand;
            pic.Cursor = Cursors.Hand;
            lblNombre.Cursor = Cursors.Hand;
            lblDisponibilidad.Cursor = Cursors.Hand;

            Action clicAccion = () => AbrirFormularioOperacion(articulo.Tipo);
            card.Click += (s, ev) => clicAccion();
            pic.Click += (s, ev) => clicAccion();
            lblNombre.Click += (s, ev) => clicAccion();
            lblDisponibilidad.Click += (s, ev) => clicAccion();

            return card;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTarjetas();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTarjetas();
        }

        private void chkSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            CargarTarjetas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cboCategoria.SelectedIndex = 0; // "Todas"
            chkSoloDisponibles.Checked = false;
            CargarTarjetas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Vuelve a la selección de categoría
            Form parentMdi = this.MdiParent;
            this.Close();

            if (parentMdi != null)
            {
                frmSeleccionCategoria selector = frmSeleccionCategoria.ObtenerInstancia(Operacion);
                selector.MdiParent = parentMdi;
                selector.Show();
                selector.BringToFront();
                selector.Activate();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }
    }
}

