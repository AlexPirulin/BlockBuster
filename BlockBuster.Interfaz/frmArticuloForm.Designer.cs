namespace BlockBuster.Interfaz
{
    partial class frmArticuloForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloVentana = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.lblPrecioRenta = new System.Windows.Forms.Label();
            this.numPrecioRenta = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.numPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.pnlImagen = new System.Windows.Forms.Panel();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarImagen = new System.Windows.Forms.Button();
            this.lblRutaImagen = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioRenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.pnlImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblTituloVentana);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloVentana
            // 
            this.lblTituloVentana.AutoSize = true;
            this.lblTituloVentana.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVentana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblTituloVentana.Location = new System.Drawing.Point(20, 16);
            this.lblTituloVentana.Name = "lblTituloVentana";
            this.lblTituloVentana.Size = new System.Drawing.Size(350, 29);
            this.lblTituloVentana.TabIndex = 0;
            this.lblTituloVentana.Text = "FORMULARIO DE ARTÍCULO";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 80);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nombre:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtTitulo.Location = new System.Drawing.Point(140, 78);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(260, 27);
            this.txtTitulo.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(25, 120);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(73, 20);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtCodigo.Location = new System.Drawing.Point(140, 118);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(260, 27);
            this.txtCodigo.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(25, 160);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(95, 20);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Items.AddRange(new object[] {
            "Películas",
            "Videojuegos",
            "Consolas"});
            this.cboCategoria.Location = new System.Drawing.Point(140, 158);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(260, 27);
            this.cboCategoria.TabIndex = 6;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.8F);
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            this.lblGenero.Location = new System.Drawing.Point(25, 200);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(107, 20);
            this.lblGenero.TabIndex = 7;
            this.lblGenero.Text = "Plat./Género:";
            // 
            // txtGenero
            // 
            this.txtGenero.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtGenero.Location = new System.Drawing.Point(140, 198);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(260, 27);
            this.txtGenero.TabIndex = 8;
            // 
            // lblPrecioRenta
            // 
            this.lblPrecioRenta.AutoSize = true;
            this.lblPrecioRenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblPrecioRenta.ForeColor = System.Drawing.Color.White;
            this.lblPrecioRenta.Location = new System.Drawing.Point(25, 240);
            this.lblPrecioRenta.Name = "lblPrecioRenta";
            this.lblPrecioRenta.Size = new System.Drawing.Size(107, 20);
            this.lblPrecioRenta.TabIndex = 9;
            this.lblPrecioRenta.Text = "P. de Renta:";
            // 
            // numPrecioRenta
            // 
            this.numPrecioRenta.DecimalPlaces = 2;
            this.numPrecioRenta.Font = new System.Drawing.Font("Arial", 10.2F);
            this.numPrecioRenta.Location = new System.Drawing.Point(140, 238);
            this.numPrecioRenta.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrecioRenta.Name = "numPrecioRenta";
            this.numPrecioRenta.Size = new System.Drawing.Size(120, 27);
            this.numPrecioRenta.TabIndex = 10;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.White;
            this.lblPrecioVenta.Location = new System.Drawing.Point(25, 280);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(107, 20);
            this.lblPrecioVenta.TabIndex = 11;
            this.lblPrecioVenta.Text = "P. de Venta:";
            // 
            // numPrecioVenta
            // 
            this.numPrecioVenta.DecimalPlaces = 2;
            this.numPrecioVenta.Font = new System.Drawing.Font("Arial", 10.2F);
            this.numPrecioVenta.Location = new System.Drawing.Point(140, 278);
            this.numPrecioVenta.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrecioVenta.Name = "numPrecioVenta";
            this.numPrecioVenta.Size = new System.Drawing.Size(120, 27);
            this.numPrecioVenta.TabIndex = 12;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblStock.ForeColor = System.Drawing.Color.White;
            this.lblStock.Location = new System.Drawing.Point(25, 320);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(100, 20);
            this.lblStock.TabIndex = 13;
            this.lblStock.Text = "Existencia:";
            // 
            // numStock
            // 
            this.numStock.Font = new System.Drawing.Font("Arial", 10.2F);
            this.numStock.Location = new System.Drawing.Point(140, 318);
            this.numStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(120, 27);
            this.numStock.TabIndex = 14;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.chkActivo.ForeColor = System.Drawing.Color.Gold;
            this.chkActivo.Location = new System.Drawing.Point(140, 360);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(161, 24);
            this.chkActivo.TabIndex = 15;
            this.chkActivo.Text = "Estado: Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // pnlImagen
            // 
            this.pnlImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImagen.Controls.Add(this.picImagen);
            this.pnlImagen.Location = new System.Drawing.Point(430, 78);
            this.pnlImagen.Name = "pnlImagen";
            this.pnlImagen.Size = new System.Drawing.Size(190, 240);
            this.pnlImagen.TabIndex = 16;
            // 
            // picImagen
            // 
            this.picImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImagen.Location = new System.Drawing.Point(0, 0);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(188, 238);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagen.TabIndex = 0;
            this.picImagen.TabStop = false;
            // 
            // btnSeleccionarImagen
            // 
            this.btnSeleccionarImagen.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSeleccionarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarImagen.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarImagen.Location = new System.Drawing.Point(430, 325);
            this.btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            this.btnSeleccionarImagen.Size = new System.Drawing.Size(190, 35);
            this.btnSeleccionarImagen.TabIndex = 17;
            this.btnSeleccionarImagen.Text = "📁 Seleccionar Imagen";
            this.btnSeleccionarImagen.UseVisualStyleBackColor = false;
            this.btnSeleccionarImagen.Click += new System.EventHandler(this.btnSeleccionarImagen_Click);
            // 
            // lblRutaImagen
            // 
            this.lblRutaImagen.AutoEllipsis = true;
            this.lblRutaImagen.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblRutaImagen.ForeColor = System.Drawing.Color.LightCyan;
            this.lblRutaImagen.Location = new System.Drawing.Point(430, 365);
            this.lblRutaImagen.Name = "lblRutaImagen";
            this.lblRutaImagen.Size = new System.Drawing.Size(190, 20);
            this.lblRutaImagen.TabIndex = 18;
            this.lblRutaImagen.Text = "Sin imagen seleccionada";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.2F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(140, 410);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 42);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "💾 Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.2F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(320, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 42);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "← Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmArticuloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(650, 475);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblRutaImagen);
            this.Controls.Add(this.btnSeleccionarImagen);
            this.Controls.Add(this.pnlImagen);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numPrecioVenta);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.numPrecioRenta);
            this.Controls.Add(this.lblPrecioRenta);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArticuloForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BlockBuster - Datos del Artículo";
            this.Load += new System.EventHandler(this.frmArticuloForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioRenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.pnlImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloVentana;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label lblPrecioRenta;
        private System.Windows.Forms.NumericUpDown numPrecioRenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlImagen;
        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.Button btnSeleccionarImagen;
        private System.Windows.Forms.Label lblRutaImagen;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

