namespace BlockBuster.Interfaz
{
    partial class frmCompras
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
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.lblNombreArticulo = new System.Windows.Forms.Label();
            this.grpValuacion = new System.Windows.Forms.GroupBox();
            this.numPrecioAcordado = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioAcordado = new System.Windows.Forms.Label();
            this.lblValuacionSugerida = new System.Windows.Forms.Label();
            this.numPrecioReferencia = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioRef = new System.Windows.Forms.Label();
            this.cboEstadoFisico = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.btnVerPendientes = new System.Windows.Forms.Button();
            this.lblNotaRol = new System.Windows.Forms.Label();
            this.btnConfirmarCompra = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpArticulo.SuspendLayout();
            this.grpValuacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioAcordado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioReferencia)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(900, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblOperacionCategoria
            // 
            this.lblOperacionCategoria.AutoSize = true;
            this.lblOperacionCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.lblOperacionCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblOperacionCategoria.Location = new System.Drawing.Point(20, 12);
            this.lblOperacionCategoria.Name = "lblOperacionCategoria";
            this.lblOperacionCategoria.Size = new System.Drawing.Size(460, 29);
            this.lblOperacionCategoria.TabIndex = 0;
            this.lblOperacionCategoria.Text = "📦 COMPRA DE ARTÍCULOS A CLIENTES";
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
            this.pnlPrincipal.Controls.Add(this.grpValuacion);
            this.pnlPrincipal.Controls.Add(this.pnlResumen);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 70);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(15);
            this.pnlPrincipal.Size = new System.Drawing.Size(900, 560);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.btnNuevoCliente);
            this.grpCliente.Controls.Add(this.btnRecargarClientes);
            this.grpCliente.Controls.Add(this.cboClientes);
            this.grpCliente.Controls.Add(this.lblCliente);
            this.grpCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpCliente.Location = new System.Drawing.Point(20, 10);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(860, 75);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "1. Cliente que Vende o Entrega el Artículo";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(710, 26);
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
            this.btnRecargarClientes.Location = new System.Drawing.Point(615, 26);
            this.btnRecargarClientes.Name = "btnRecargarClientes";
            this.btnRecargarClientes.Size = new System.Drawing.Size(85, 32);
            this.btnRecargarClientes.TabIndex = 2;
            this.btnRecargarClientes.Text = "🔄";
            this.btnRecargarClientes.UseVisualStyleBackColor = false;
            this.btnRecargarClientes.Click += new System.EventHandler(this.btnRecargarClientes_Click);
            // 
            // cboClientes
            // 
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(120, 28);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(480, 27);
            this.cboClientes.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(20, 32);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(70, 18);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // grpArticulo
            // 
            this.grpArticulo.Controls.Add(this.txtGenero);
            this.grpArticulo.Controls.Add(this.lblGenero);
            this.grpArticulo.Controls.Add(this.cboTipo);
            this.grpArticulo.Controls.Add(this.lblTipo);
            this.grpArticulo.Controls.Add(this.txtNombreArticulo);
            this.grpArticulo.Controls.Add(this.lblNombreArticulo);
            this.grpArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpArticulo.Location = new System.Drawing.Point(20, 95);
            this.grpArticulo.Name = "grpArticulo";
            this.grpArticulo.Size = new System.Drawing.Size(860, 115);
            this.grpArticulo.TabIndex = 1;
            this.grpArticulo.TabStop = false;
            this.grpArticulo.Text = "2. Datos del Artículo Ofrecido";
            // 
            // txtGenero
            // 
            this.txtGenero.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGenero.Location = new System.Drawing.Point(540, 70);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(305, 27);
            this.txtGenero.TabIndex = 5;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblGenero.ForeColor = System.Drawing.Color.White;
            this.lblGenero.Location = new System.Drawing.Point(380, 74);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(147, 18);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "Género/Plataforma:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Arial", 10F);
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Películas",
            "Videojuegos",
            "Consolas",
            "General"});
            this.cboTipo.Location = new System.Drawing.Point(120, 70);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(240, 27);
            this.cboTipo.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(20, 74);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(46, 18);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo:";
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtNombreArticulo.Location = new System.Drawing.Point(120, 28);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(725, 27);
            this.txtNombreArticulo.TabIndex = 1;
            // 
            // lblNombreArticulo
            // 
            this.lblNombreArticulo.AutoSize = true;
            this.lblNombreArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblNombreArticulo.ForeColor = System.Drawing.Color.White;
            this.lblNombreArticulo.Location = new System.Drawing.Point(20, 32);
            this.lblNombreArticulo.Name = "lblNombreArticulo";
            this.lblNombreArticulo.Size = new System.Drawing.Size(76, 18);
            this.lblNombreArticulo.TabIndex = 0;
            this.lblNombreArticulo.Text = "Nombre:";
            // 
            // grpValuacion
            // 
            this.grpValuacion.Controls.Add(this.numPrecioAcordado);
            this.grpValuacion.Controls.Add(this.lblPrecioAcordado);
            this.grpValuacion.Controls.Add(this.lblValuacionSugerida);
            this.grpValuacion.Controls.Add(this.numPrecioReferencia);
            this.grpValuacion.Controls.Add(this.lblPrecioRef);
            this.grpValuacion.Controls.Add(this.cboEstadoFisico);
            this.grpValuacion.Controls.Add(this.lblEstado);
            this.grpValuacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpValuacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpValuacion.Location = new System.Drawing.Point(20, 220);
            this.grpValuacion.Name = "grpValuacion";
            this.grpValuacion.Size = new System.Drawing.Size(860, 160);
            this.grpValuacion.TabIndex = 2;
            this.grpValuacion.TabStop = false;
            this.grpValuacion.Text = "3. Estado Físico y Valuación Sugerida";
            // 
            // numPrecioAcordado
            // 
            this.numPrecioAcordado.DecimalPlaces = 2;
            this.numPrecioAcordado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.numPrecioAcordado.ForeColor = System.Drawing.Color.DarkGreen;
            this.numPrecioAcordado.Location = new System.Drawing.Point(600, 105);
            this.numPrecioAcordado.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrecioAcordado.Name = "numPrecioAcordado";
            this.numPrecioAcordado.Size = new System.Drawing.Size(245, 31);
            this.numPrecioAcordado.TabIndex = 6;
            this.numPrecioAcordado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrecioAcordado
            // 
            this.lblPrecioAcordado.AutoSize = true;
            this.lblPrecioAcordado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblPrecioAcordado.ForeColor = System.Drawing.Color.White;
            this.lblPrecioAcordado.Location = new System.Drawing.Point(380, 110);
            this.lblPrecioAcordado.Name = "lblPrecioAcordado";
            this.lblPrecioAcordado.Size = new System.Drawing.Size(205, 20);
            this.lblPrecioAcordado.TabIndex = 5;
            this.lblPrecioAcordado.Text = "Precio Compra Acordado:";
            // 
            // lblValuacionSugerida
            // 
            this.lblValuacionSugerida.AutoSize = true;
            this.lblValuacionSugerida.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.lblValuacionSugerida.ForeColor = System.Drawing.Color.Gold;
            this.lblValuacionSugerida.Location = new System.Drawing.Point(20, 75);
            this.lblValuacionSugerida.Name = "lblValuacionSugerida";
            this.lblValuacionSugerida.Size = new System.Drawing.Size(350, 22);
            this.lblValuacionSugerida.TabIndex = 4;
            this.lblValuacionSugerida.Text = "Valuación sugerida: $0.00 (0% según estado)";
            // 
            // numPrecioReferencia
            // 
            this.numPrecioReferencia.DecimalPlaces = 2;
            this.numPrecioReferencia.Font = new System.Drawing.Font("Arial", 10F);
            this.numPrecioReferencia.Location = new System.Drawing.Point(600, 30);
            this.numPrecioReferencia.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrecioReferencia.Name = "numPrecioReferencia";
            this.numPrecioReferencia.Size = new System.Drawing.Size(245, 27);
            this.numPrecioReferencia.TabIndex = 3;
            this.numPrecioReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPrecioReferencia.ValueChanged += new System.EventHandler(this.numPrecioReferencia_ValueChanged);
            // 
            // lblPrecioRef
            // 
            this.lblPrecioRef.AutoSize = true;
            this.lblPrecioRef.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblPrecioRef.ForeColor = System.Drawing.Color.White;
            this.lblPrecioRef.Location = new System.Drawing.Point(380, 34);
            this.lblPrecioRef.Name = "lblPrecioRef";
            this.lblPrecioRef.Size = new System.Drawing.Size(183, 18);
            this.lblPrecioRef.TabIndex = 2;
            this.lblPrecioRef.Text = "Valor Ref. / Comercial:";
            // 
            // cboEstadoFisico
            // 
            this.cboEstadoFisico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoFisico.Font = new System.Drawing.Font("Arial", 10F);
            this.cboEstadoFisico.FormattingEnabled = true;
            this.cboEstadoFisico.Items.AddRange(new object[] {
            "Excelente (70%)",
            "Bueno (50%)",
            "Regular (30%)",
            "Malo (15%)"});
            this.cboEstadoFisico.Location = new System.Drawing.Point(120, 30);
            this.cboEstadoFisico.Name = "cboEstadoFisico";
            this.cboEstadoFisico.Size = new System.Drawing.Size(240, 27);
            this.cboEstadoFisico.TabIndex = 1;
            this.cboEstadoFisico.SelectedIndexChanged += new System.EventHandler(this.cboEstadoFisico_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(20, 34);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(68, 18);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Estado:";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumen.Controls.Add(this.btnVerPendientes);
            this.pnlResumen.Controls.Add(this.lblNotaRol);
            this.pnlResumen.Controls.Add(this.btnConfirmarCompra);
            this.pnlResumen.Controls.Add(this.btnCerrar);
            this.pnlResumen.Location = new System.Drawing.Point(20, 395);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(860, 145);
            this.pnlResumen.TabIndex = 3;
            // 
            // btnVerPendientes
            // 
            this.btnVerPendientes.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnVerPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPendientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnVerPendientes.ForeColor = System.Drawing.Color.White;
            this.btnVerPendientes.Location = new System.Drawing.Point(20, 85);
            this.btnVerPendientes.Name = "btnVerPendientes";
            this.btnVerPendientes.Size = new System.Drawing.Size(260, 42);
            this.btnVerPendientes.TabIndex = 3;
            this.btnVerPendientes.Text = "📋 Ver Compras Pendientes";
            this.btnVerPendientes.UseVisualStyleBackColor = false;
            this.btnVerPendientes.Click += new System.EventHandler(this.btnVerPendientes_Click);
            // 
            // lblNotaRol
            // 
            this.lblNotaRol.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNotaRol.ForeColor = System.Drawing.Color.LightCyan;
            this.lblNotaRol.Location = new System.Drawing.Point(20, 12);
            this.lblNotaRol.Name = "lblNotaRol";
            this.lblNotaRol.Size = new System.Drawing.Size(530, 60);
            this.lblNotaRol.TabIndex = 0;
            this.lblNotaRol.Text = "Nota de operación...";
            // 
            // btnConfirmarCompra
            // 
            this.btnConfirmarCompra.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarCompra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmarCompra.FlatAppearance.BorderSize = 2;
            this.btnConfirmarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.5F);
            this.btnConfirmarCompra.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarCompra.Location = new System.Drawing.Point(580, 15);
            this.btnConfirmarCompra.Name = "btnConfirmarCompra";
            this.btnConfirmarCompra.Size = new System.Drawing.Size(260, 52);
            this.btnConfirmarCompra.TabIndex = 1;
            this.btnConfirmarCompra.Text = "✔ Confirmar Compra";
            this.btnConfirmarCompra.UseVisualStyleBackColor = false;
            this.btnConfirmarCompra.Click += new System.EventHandler(this.btnConfirmarCompra_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(700, 85);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 630);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Módulo de Compra";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpArticulo.ResumeLayout(false);
            this.grpArticulo.PerformLayout();
            this.grpValuacion.ResumeLayout(false);
            this.grpValuacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioAcordado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioReferencia)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblOperacionCategoria;
        private System.Windows.Forms.Label lblUsuarioSesion;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnRecargarClientes;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox grpArticulo;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.Label lblNombreArticulo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.GroupBox grpValuacion;
        private System.Windows.Forms.ComboBox cboEstadoFisico;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.NumericUpDown numPrecioReferencia;
        private System.Windows.Forms.Label lblPrecioRef;
        private System.Windows.Forms.Label lblValuacionSugerida;
        private System.Windows.Forms.NumericUpDown numPrecioAcordado;
        private System.Windows.Forms.Label lblPrecioAcordado;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblNotaRol;
        private System.Windows.Forms.Button btnConfirmarCompra;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnVerPendientes;
    }
}
