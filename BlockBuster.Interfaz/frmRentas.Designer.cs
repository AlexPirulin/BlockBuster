namespace BlockBuster.Interfaz
{
    partial class frmRentas
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblOperacionCategoria = new System.Windows.Forms.Label();
            this.lblUsuarioSesion = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnRecargarClientes = new System.Windows.Forms.Button();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.grpArticulo = new System.Windows.Forms.GroupBox();
            this.lblTipoGenero = new System.Windows.Forms.Label();
            this.lblStockDisponible = new System.Windows.Forms.Label();
            this.lblPrecioDiario = new System.Windows.Forms.Label();
            this.cboArticulos = new System.Windows.Forms.ComboBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.grpPeriodo = new System.Windows.Forms.GroupBox();
            this.lblFechaDevolucion = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.numDias = new System.Windows.Forms.NumericUpDown();
            this.lblDias = new System.Windows.Forms.Label();
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblDesglose = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmarRenta = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpArticulo.SuspendLayout();
            this.grpPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).BeginInit();
            this.grpPago.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblOperacionCategoria);
            this.pnlHeader.Controls.Add(this.lblUsuarioSesion);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblOperacionCategoria
            // 
            this.lblOperacionCategoria.AutoSize = true;
            this.lblOperacionCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.5F);
            this.lblOperacionCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblOperacionCategoria.Location = new System.Drawing.Point(20, 12);
            this.lblOperacionCategoria.Name = "lblOperacionCategoria";
            this.lblOperacionCategoria.Size = new System.Drawing.Size(430, 30);
            this.lblOperacionCategoria.TabIndex = 0;
            this.lblOperacionCategoria.Text = "🔄 REGISTRO DE RENTA DE ARTÍCULOS";
            // 
            // lblUsuarioSesion
            // 
            this.lblUsuarioSesion.AutoSize = true;
            this.lblUsuarioSesion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblUsuarioSesion.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblUsuarioSesion.Location = new System.Drawing.Point(23, 44);
            this.lblUsuarioSesion.Name = "lblUsuarioSesion";
            this.lblUsuarioSesion.Size = new System.Drawing.Size(66, 17);
            this.lblUsuarioSesion.TabIndex = 1;
            this.lblUsuarioSesion.Text = "Sesión: -";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.pnlPrincipal.Controls.Add(this.grpCliente);
            this.pnlPrincipal.Controls.Add(this.grpArticulo);
            this.pnlPrincipal.Controls.Add(this.grpPeriodo);
            this.pnlPrincipal.Controls.Add(this.grpPago);
            this.pnlPrincipal.Controls.Add(this.pnlResumen);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 70);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(15);
            this.pnlPrincipal.Size = new System.Drawing.Size(880, 520);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.btnNuevoCliente);
            this.grpCliente.Controls.Add(this.btnRecargarClientes);
            this.grpCliente.Controls.Add(this.cboClientes);
            this.grpCliente.Controls.Add(this.lblCliente);
            this.grpCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpCliente.Location = new System.Drawing.Point(20, 15);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(840, 80);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "1. Cliente Titular de la Renta";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(690, 28);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(135, 32);
            this.btnNuevoCliente.TabIndex = 3;
            this.btnNuevoCliente.Text = "+ Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnRecargarClientes
            // 
            this.btnRecargarClientes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRecargarClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecargarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargarClientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnRecargarClientes.ForeColor = System.Drawing.Color.White;
            this.btnRecargarClientes.Location = new System.Drawing.Point(570, 28);
            this.btnRecargarClientes.Name = "btnRecargarClientes";
            this.btnRecargarClientes.Size = new System.Drawing.Size(110, 32);
            this.btnRecargarClientes.TabIndex = 2;
            this.btnRecargarClientes.Text = "🔄 Recargar";
            this.btnRecargarClientes.UseVisualStyleBackColor = false;
            this.btnRecargarClientes.Click += new System.EventHandler(this.btnRecargarClientes_Click);
            // 
            // cboClientes
            // 
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(135, 30);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(425, 27);
            this.cboClientes.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(20, 34);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(110, 18);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Seleccionar:";
            // 
            // grpArticulo
            // 
            this.grpArticulo.Controls.Add(this.lblTipoGenero);
            this.grpArticulo.Controls.Add(this.lblStockDisponible);
            this.grpArticulo.Controls.Add(this.lblPrecioDiario);
            this.grpArticulo.Controls.Add(this.cboArticulos);
            this.grpArticulo.Controls.Add(this.lblArticulo);
            this.grpArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.grpArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpArticulo.Location = new System.Drawing.Point(20, 105);
            this.grpArticulo.Name = "grpArticulo";
            this.grpArticulo.Size = new System.Drawing.Size(840, 110);
            this.grpArticulo.TabIndex = 1;
            this.grpArticulo.TabStop = false;
            this.grpArticulo.Text = "2. Selección de Artículo";
            // 
            // lblTipoGenero
            // 
            this.lblTipoGenero.AutoSize = true;
            this.lblTipoGenero.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTipoGenero.ForeColor = System.Drawing.Color.LightCyan;
            this.lblTipoGenero.Location = new System.Drawing.Point(135, 75);
            this.lblTipoGenero.Name = "lblTipoGenero";
            this.lblTipoGenero.Size = new System.Drawing.Size(155, 17);
            this.lblTipoGenero.TabIndex = 4;
            this.lblTipoGenero.Text = "Categoría: - | Género: -";
            // 
            // lblStockDisponible
            // 
            this.lblStockDisponible.AutoSize = true;
            this.lblStockDisponible.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblStockDisponible.ForeColor = System.Drawing.Color.LightGreen;
            this.lblStockDisponible.Location = new System.Drawing.Point(650, 34);
            this.lblStockDisponible.Name = "lblStockDisponible";
            this.lblStockDisponible.Size = new System.Drawing.Size(83, 18);
            this.lblStockDisponible.TabIndex = 3;
            this.lblStockDisponible.Text = "Stock: -";
            // 
            // lblPrecioDiario
            // 
            this.lblPrecioDiario.AutoSize = true;
            this.lblPrecioDiario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblPrecioDiario.ForeColor = System.Drawing.Color.Gold;
            this.lblPrecioDiario.Location = new System.Drawing.Point(450, 72);
            this.lblPrecioDiario.Name = "lblPrecioDiario";
            this.lblPrecioDiario.Size = new System.Drawing.Size(185, 20);
            this.lblPrecioDiario.TabIndex = 2;
            this.lblPrecioDiario.Text = "Tarifa Diaria: $0.00";
            // 
            // cboArticulos
            // 
            this.cboArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulos.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboArticulos.FormattingEnabled = true;
            this.cboArticulos.Location = new System.Drawing.Point(135, 30);
            this.cboArticulos.Name = "cboArticulos";
            this.cboArticulos.Size = new System.Drawing.Size(490, 27);
            this.cboArticulos.TabIndex = 1;
            this.cboArticulos.SelectedIndexChanged += new System.EventHandler(this.cboArticulos_SelectedIndexChanged);
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblArticulo.ForeColor = System.Drawing.Color.White;
            this.lblArticulo.Location = new System.Drawing.Point(20, 34);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(76, 18);
            this.lblArticulo.TabIndex = 0;
            this.lblArticulo.Text = "Artículo:";
            // 
            // grpPeriodo
            // 
            this.grpPeriodo.Controls.Add(this.lblFechaDevolucion);
            this.grpPeriodo.Controls.Add(this.lblFechaInicio);
            this.grpPeriodo.Controls.Add(this.numDias);
            this.grpPeriodo.Controls.Add(this.lblDias);
            this.grpPeriodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.grpPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpPeriodo.Location = new System.Drawing.Point(20, 225);
            this.grpPeriodo.Name = "grpPeriodo";
            this.grpPeriodo.Size = new System.Drawing.Size(450, 110);
            this.grpPeriodo.TabIndex = 2;
            this.grpPeriodo.TabStop = false;
            this.grpPeriodo.Text = "3. Plazo de Renta";
            // 
            // lblFechaDevolucion
            // 
            this.lblFechaDevolucion.AutoSize = true;
            this.lblFechaDevolucion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblFechaDevolucion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblFechaDevolucion.Location = new System.Drawing.Point(180, 68);
            this.lblFechaDevolucion.Name = "lblFechaDevolucion";
            this.lblFechaDevolucion.Size = new System.Drawing.Size(155, 18);
            this.lblFechaDevolucion.TabIndex = 3;
            this.lblFechaDevolucion.Text = "Devolución: -";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            this.lblFechaInicio.Location = new System.Drawing.Point(180, 32);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(100, 17);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio: -";
            // 
            // numDias
            // 
            this.numDias.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.numDias.Location = new System.Drawing.Point(23, 58);
            this.numDias.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDias.Name = "numDias";
            this.numDias.Size = new System.Drawing.Size(120, 31);
            this.numDias.TabIndex = 1;
            this.numDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDias.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDias.ValueChanged += new System.EventHandler(this.numDias_ValueChanged);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblDias.ForeColor = System.Drawing.Color.White;
            this.lblDias.Location = new System.Drawing.Point(20, 30);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(117, 18);
            this.lblDias.TabIndex = 0;
            this.lblDias.Text = "Días de Renta:";
            // 
            // grpPago
            // 
            this.grpPago.Controls.Add(this.cboMetodoPago);
            this.grpPago.Controls.Add(this.lblMetodo);
            this.grpPago.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.grpPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpPago.Location = new System.Drawing.Point(490, 225);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(370, 110);
            this.grpPago.TabIndex = 3;
            this.grpPago.TabStop = false;
            this.grpPago.Text = "4. Método de Pago";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cboMetodoPago.Location = new System.Drawing.Point(30, 60);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(300, 27);
            this.cboMetodoPago.TabIndex = 1;
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblMetodo.ForeColor = System.Drawing.Color.White;
            this.lblMetodo.Location = new System.Drawing.Point(27, 30);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(150, 18);
            this.lblMetodo.TabIndex = 0;
            this.lblMetodo.Text = "Forma de Liquidar:";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumen.Controls.Add(this.lblDesglose);
            this.pnlResumen.Controls.Add(this.lblTotalTitulo);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.btnConfirmarRenta);
            this.pnlResumen.Controls.Add(this.btnCerrar);
            this.pnlResumen.Location = new System.Drawing.Point(20, 350);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(840, 140);
            this.pnlResumen.TabIndex = 4;
            // 
            // lblDesglose
            // 
            this.lblDesglose.AutoSize = true;
            this.lblDesglose.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDesglose.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblDesglose.Location = new System.Drawing.Point(20, 20);
            this.lblDesglose.Name = "lblDesglose";
            this.lblDesglose.Size = new System.Drawing.Size(260, 19);
            this.lblDesglose.TabIndex = 0;
            this.lblDesglose.Text = "Desglose: 0 días x $0.00 = $0.00";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitulo.Location = new System.Drawing.Point(20, 55);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(197, 26);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "TOTAL A PAGAR:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(230, 42);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(126, 46);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "$0.00";
            // 
            // btnConfirmarRenta
            // 
            this.btnConfirmarRenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmarRenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarRenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmarRenta.FlatAppearance.BorderSize = 2;
            this.btnConfirmarRenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarRenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btnConfirmarRenta.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarRenta.Location = new System.Drawing.Point(580, 25);
            this.btnConfirmarRenta.Name = "btnConfirmarRenta";
            this.btnConfirmarRenta.Size = new System.Drawing.Size(240, 50);
            this.btnConfirmarRenta.TabIndex = 3;
            this.btnConfirmarRenta.Text = "✔ Confirmar Renta";
            this.btnConfirmarRenta.UseVisualStyleBackColor = false;
            this.btnConfirmarRenta.Click += new System.EventHandler(this.btnConfirmarRenta_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(680, 85);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 32);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmRentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 590);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmRentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Módulo de Renta";
            this.Load += new System.EventHandler(this.frmRentas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpArticulo.ResumeLayout(false);
            this.grpArticulo.PerformLayout();
            this.grpPeriodo.ResumeLayout(false);
            this.grpPeriodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).EndInit();
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblOperacionCategoria;
        private System.Windows.Forms.Label lblUsuarioSesion;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnRecargarClientes;
        private System.Windows.Forms.GroupBox grpArticulo;
        private System.Windows.Forms.ComboBox cboArticulos;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label lblPrecioDiario;
        private System.Windows.Forms.Label lblStockDisponible;
        private System.Windows.Forms.Label lblTipoGenero;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.NumericUpDown numDias;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaDevolucion;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblDesglose;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnConfirmarRenta;
        private System.Windows.Forms.Button btnCerrar;
    }
}
