namespace BlockBuster.Interfaz
{
    partial class frmReportes
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle headerStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.numUmbralStock = new System.Windows.Forms.NumericUpDown();
            this.lblUmbral = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.pnlCardBalance = new System.Windows.Forms.Panel();
            this.lblBalanceValor = new System.Windows.Forms.Label();
            this.lblBalanceTit = new System.Windows.Forms.Label();
            this.pnlCardCompras = new System.Windows.Forms.Panel();
            this.lblComprasDetalle = new System.Windows.Forms.Label();
            this.lblComprasValor = new System.Windows.Forms.Label();
            this.lblComprasTit = new System.Windows.Forms.Label();
            this.pnlCardRentas = new System.Windows.Forms.Panel();
            this.lblRentasDetalle = new System.Windows.Forms.Label();
            this.lblRentasValor = new System.Windows.Forms.Label();
            this.lblRentasTit = new System.Windows.Forms.Label();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblVentasDetalle = new System.Windows.Forms.Label();
            this.lblVentasValor = new System.Windows.Forms.Label();
            this.lblVentasTit = new System.Windows.Forms.Label();
            this.tabDatos = new System.Windows.Forms.TabControl();
            this.tabBajoStock = new System.Windows.Forms.TabPage();
            this.dgvBajoStock = new System.Windows.Forms.DataGridView();
            this.colArtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtPrecioRenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMovimientos = new System.Windows.Forms.TabPage();
            this.dgvTransacciones = new System.Windows.Forms.DataGridView();
            this.colTrxFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxMetodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrxEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUmbralStock)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.pnlCardBalance.SuspendLayout();
            this.pnlCardCompras.SuspendLayout();
            this.pnlCardRentas.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.tabDatos.SuspendLayout();
            this.tabBajoStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).BeginInit();
            this.tabMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(20, 35, 60);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(480, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Resumen de ventas, rentas, compras y existencias bajas (Exclusivo Administrador)";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.5F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(255, 204, 0);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(410, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 REPORTES ADMINISTRATIVOS";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(30, 50, 80);
            this.pnlFiltros.Controls.Add(this.btnCerrar);
            this.pnlFiltros.Controls.Add(this.btnConsultar);
            this.pnlFiltros.Controls.Add(this.btnHoy);
            this.pnlFiltros.Controls.Add(this.numUmbralStock);
            this.pnlFiltros.Controls.Add(this.lblUmbral);
            this.pnlFiltros.Controls.Add(this.dtpFin);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpInicio);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 70);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1060, 58);
            this.pnlFiltros.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblDesde.ForeColor = System.Drawing.Color.White;
            this.lblDesde.Location = new System.Drawing.Point(20, 19);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(58, 18);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(85, 16);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(130, 26);
            this.dtpInicio.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblHasta.ForeColor = System.Drawing.Color.White;
            this.lblHasta.Location = new System.Drawing.Point(230, 19);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(55, 18);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Arial", 9.5F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(290, 16);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(130, 26);
            this.dtpFin.TabIndex = 3;
            // 
            // lblUmbral
            // 
            this.lblUmbral.AutoSize = true;
            this.lblUmbral.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblUmbral.ForeColor = System.Drawing.Color.White;
            this.lblUmbral.Location = new System.Drawing.Point(438, 19);
            this.lblUmbral.Name = "lblUmbral";
            this.lblUmbral.Size = new System.Drawing.Size(128, 18);
            this.lblUmbral.TabIndex = 4;
            this.lblUmbral.Text = "Stock bajo ≤:";
            // 
            // numUmbralStock
            // 
            this.numUmbralStock.Font = new System.Drawing.Font("Arial", 9.5F);
            this.numUmbralStock.Location = new System.Drawing.Point(555, 16);
            this.numUmbralStock.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numUmbralStock.Name = "numUmbralStock";
            this.numUmbralStock.Size = new System.Drawing.Size(65, 26);
            this.numUmbralStock.TabIndex = 5;
            this.numUmbralStock.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnHoy.ForeColor = System.Drawing.Color.White;
            this.btnHoy.Location = new System.Drawing.Point(640, 12);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(95, 34);
            this.btnHoy.TabIndex = 6;
            this.btnHoy.Text = "📅 Hoy";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(745, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(175, 34);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "📊 Generar Reporte";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(940, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 34);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(24, 42, 70);
            this.pnlResumen.Controls.Add(this.pnlCardBalance);
            this.pnlResumen.Controls.Add(this.pnlCardCompras);
            this.pnlResumen.Controls.Add(this.pnlCardRentas);
            this.pnlResumen.Controls.Add(this.pnlCardVentas);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Location = new System.Drawing.Point(0, 128);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1060, 115);
            this.pnlResumen.TabIndex = 2;
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.FromArgb(20, 90, 55);
            this.pnlCardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardVentas.Controls.Add(this.lblVentasDetalle);
            this.pnlCardVentas.Controls.Add(this.lblVentasValor);
            this.pnlCardVentas.Controls.Add(this.lblVentasTit);
            this.pnlCardVentas.Location = new System.Drawing.Point(20, 12);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(240, 90);
            this.pnlCardVentas.TabIndex = 0;
            // 
            // lblVentasTit
            // 
            this.lblVentasTit.AutoSize = true;
            this.lblVentasTit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblVentasTit.ForeColor = System.Drawing.Color.LightGreen;
            this.lblVentasTit.Location = new System.Drawing.Point(10, 8);
            this.lblVentasTit.Name = "lblVentasTit";
            this.lblVentasTit.Size = new System.Drawing.Size(120, 20);
            this.lblVentasTit.TabIndex = 0;
            this.lblVentasTit.Text = "🛒 VENTAS";
            // 
            // lblVentasValor
            // 
            this.lblVentasValor.AutoSize = true;
            this.lblVentasValor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.lblVentasValor.ForeColor = System.Drawing.Color.White;
            this.lblVentasValor.Location = new System.Drawing.Point(10, 32);
            this.lblVentasValor.Name = "lblVentasValor";
            this.lblVentasValor.Size = new System.Drawing.Size(85, 31);
            this.lblVentasValor.TabIndex = 1;
            this.lblVentasValor.Text = "$0.00";
            // 
            // lblVentasDetalle
            // 
            this.lblVentasDetalle.AutoSize = true;
            this.lblVentasDetalle.Font = new System.Drawing.Font("Arial", 8.5F);
            this.lblVentasDetalle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblVentasDetalle.Location = new System.Drawing.Point(12, 65);
            this.lblVentasDetalle.Name = "lblVentasDetalle";
            this.lblVentasDetalle.Size = new System.Drawing.Size(110, 16);
            this.lblVentasDetalle.TabIndex = 2;
            this.lblVentasDetalle.Text = "0 operaciones";
            // 
            // pnlCardRentas
            // 
            this.pnlCardRentas.BackColor = System.Drawing.Color.FromArgb(20, 75, 130);
            this.pnlCardRentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardRentas.Controls.Add(this.lblRentasDetalle);
            this.pnlCardRentas.Controls.Add(this.lblRentasValor);
            this.pnlCardRentas.Controls.Add(this.lblRentasTit);
            this.pnlCardRentas.Location = new System.Drawing.Point(275, 12);
            this.pnlCardRentas.Name = "pnlCardRentas";
            this.pnlCardRentas.Size = new System.Drawing.Size(255, 90);
            this.pnlCardRentas.TabIndex = 1;
            // 
            // lblRentasTit
            // 
            this.lblRentasTit.AutoSize = true;
            this.lblRentasTit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblRentasTit.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblRentasTit.Location = new System.Drawing.Point(10, 8);
            this.lblRentasTit.Name = "lblRentasTit";
            this.lblRentasTit.Size = new System.Drawing.Size(180, 20);
            this.lblRentasTit.TabIndex = 0;
            this.lblRentasTit.Text = "🔄 RENTAS + RECARGOS";
            // 
            // lblRentasValor
            // 
            this.lblRentasValor.AutoSize = true;
            this.lblRentasValor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.lblRentasValor.ForeColor = System.Drawing.Color.White;
            this.lblRentasValor.Location = new System.Drawing.Point(10, 32);
            this.lblRentasValor.Name = "lblRentasValor";
            this.lblRentasValor.Size = new System.Drawing.Size(85, 31);
            this.lblRentasValor.TabIndex = 1;
            this.lblRentasValor.Text = "$0.00";
            // 
            // lblRentasDetalle
            // 
            this.lblRentasDetalle.AutoSize = true;
            this.lblRentasDetalle.Font = new System.Drawing.Font("Arial", 8.5F);
            this.lblRentasDetalle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRentasDetalle.Location = new System.Drawing.Point(12, 65);
            this.lblRentasDetalle.Name = "lblRentasDetalle";
            this.lblRentasDetalle.Size = new System.Drawing.Size(170, 16);
            this.lblRentasDetalle.TabIndex = 2;
            this.lblRentasDetalle.Text = "0 rentas | Recargos: $0.00";
            // 
            // pnlCardCompras
            // 
            this.pnlCardCompras.BackColor = System.Drawing.Color.FromArgb(145, 75, 15);
            this.pnlCardCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardCompras.Controls.Add(this.lblComprasDetalle);
            this.pnlCardCompras.Controls.Add(this.lblComprasValor);
            this.pnlCardCompras.Controls.Add(this.lblComprasTit);
            this.pnlCardCompras.Location = new System.Drawing.Point(545, 12);
            this.pnlCardCompras.Name = "pnlCardCompras";
            this.pnlCardCompras.Size = new System.Drawing.Size(240, 90);
            this.pnlCardCompras.TabIndex = 2;
            // 
            // lblComprasTit
            // 
            this.lblComprasTit.AutoSize = true;
            this.lblComprasTit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblComprasTit.ForeColor = System.Drawing.Color.NavajoWhite;
            this.lblComprasTit.Location = new System.Drawing.Point(10, 8);
            this.lblComprasTit.Name = "lblComprasTit";
            this.lblComprasTit.Size = new System.Drawing.Size(130, 20);
            this.lblComprasTit.TabIndex = 0;
            this.lblComprasTit.Text = "📦 COMPRAS";
            // 
            // lblComprasValor
            // 
            this.lblComprasValor.AutoSize = true;
            this.lblComprasValor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.lblComprasValor.ForeColor = System.Drawing.Color.White;
            this.lblComprasValor.Location = new System.Drawing.Point(10, 32);
            this.lblComprasValor.Name = "lblComprasValor";
            this.lblComprasValor.Size = new System.Drawing.Size(85, 31);
            this.lblComprasValor.TabIndex = 1;
            this.lblComprasValor.Text = "$0.00";
            // 
            // lblComprasDetalle
            // 
            this.lblComprasDetalle.AutoSize = true;
            this.lblComprasDetalle.Font = new System.Drawing.Font("Arial", 8.5F);
            this.lblComprasDetalle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblComprasDetalle.Location = new System.Drawing.Point(12, 65);
            this.lblComprasDetalle.Name = "lblComprasDetalle";
            this.lblComprasDetalle.Size = new System.Drawing.Size(110, 16);
            this.lblComprasDetalle.TabIndex = 2;
            this.lblComprasDetalle.Text = "0 compras";
            // 
            // pnlCardBalance
            // 
            this.pnlCardBalance.BackColor = System.Drawing.Color.FromArgb(40, 40, 85);
            this.pnlCardBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardBalance.Controls.Add(this.lblBalanceValor);
            this.pnlCardBalance.Controls.Add(this.lblBalanceTit);
            this.pnlCardBalance.Location = new System.Drawing.Point(800, 12);
            this.pnlCardBalance.Name = "pnlCardBalance";
            this.pnlCardBalance.Size = new System.Drawing.Size(240, 90);
            this.pnlCardBalance.TabIndex = 3;
            // 
            // lblBalanceTit
            // 
            this.lblBalanceTit.AutoSize = true;
            this.lblBalanceTit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblBalanceTit.ForeColor = System.Drawing.Color.Gold;
            this.lblBalanceTit.Location = new System.Drawing.Point(10, 12);
            this.lblBalanceTit.Name = "lblBalanceTit";
            this.lblBalanceTit.Size = new System.Drawing.Size(150, 20);
            this.lblBalanceTit.TabIndex = 0;
            this.lblBalanceTit.Text = "💰 BALANCE NETO";
            // 
            // lblBalanceValor
            // 
            this.lblBalanceValor.AutoSize = true;
            this.lblBalanceValor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 17F);
            this.lblBalanceValor.ForeColor = System.Drawing.Color.Gold;
            this.lblBalanceValor.Location = new System.Drawing.Point(10, 40);
            this.lblBalanceValor.Name = "lblBalanceValor";
            this.lblBalanceValor.Size = new System.Drawing.Size(90, 33);
            this.lblBalanceValor.TabIndex = 1;
            this.lblBalanceValor.Text = "$0.00";
            // 
            // tabDatos
            // 
            this.tabDatos.Controls.Add(this.tabBajoStock);
            this.tabDatos.Controls.Add(this.tabMovimientos);
            this.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.tabDatos.Location = new System.Drawing.Point(0, 243);
            this.tabDatos.Name = "tabDatos";
            this.tabDatos.SelectedIndex = 0;
            this.tabDatos.Size = new System.Drawing.Size(1060, 377);
            this.tabDatos.TabIndex = 3;
            // 
            // tabBajoStock
            // 
            this.tabBajoStock.BackColor = System.Drawing.Color.FromArgb(30, 50, 80);
            this.tabBajoStock.Controls.Add(this.dgvBajoStock);
            this.tabBajoStock.Location = new System.Drawing.Point(4, 27);
            this.tabBajoStock.Name = "tabBajoStock";
            this.tabBajoStock.Padding = new System.Windows.Forms.Padding(10);
            this.tabBajoStock.Size = new System.Drawing.Size(1052, 346);
            this.tabBajoStock.TabIndex = 0;
            this.tabBajoStock.Text = "📉 Artículos con Menos Existencias";
            // 
            // dgvBajoStock
            // 
            this.dgvBajoStock.AllowUserToAddRows = false;
            this.dgvBajoStock.AllowUserToDeleteRows = false;
            this.dgvBajoStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBajoStock.BackgroundColor = System.Drawing.Color.FromArgb(20, 35, 60);
            headerStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle1.BackColor = System.Drawing.Color.FromArgb(15, 25, 45);
            headerStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            headerStyle1.ForeColor = System.Drawing.Color.Gold;
            this.dgvBajoStock.ColumnHeadersDefaultCellStyle = headerStyle1;
            this.dgvBajoStock.ColumnHeadersHeight = 34;
            this.dgvBajoStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArtCodigo,
            this.colArtTitulo,
            this.colArtTipo,
            this.colArtStock,
            this.colArtPrecioVenta,
            this.colArtPrecioRenta});
            cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle1.BackColor = System.Drawing.Color.FromArgb(25, 40, 65);
            cellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            cellStyle1.ForeColor = System.Drawing.Color.White;
            cellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(50, 85, 130);
            cellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBajoStock.DefaultCellStyle = cellStyle1;
            this.dgvBajoStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBajoStock.EnableHeadersVisualStyles = false;
            this.dgvBajoStock.Location = new System.Drawing.Point(10, 10);
            this.dgvBajoStock.MultiSelect = false;
            this.dgvBajoStock.Name = "dgvBajoStock";
            this.dgvBajoStock.ReadOnly = true;
            this.dgvBajoStock.RowHeadersVisible = false;
            this.dgvBajoStock.RowTemplate.Height = 30;
            this.dgvBajoStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBajoStock.Size = new System.Drawing.Size(1032, 326);
            this.dgvBajoStock.TabIndex = 0;
            // 
            // colArtCodigo
            // 
            this.colArtCodigo.FillWeight = 70F;
            this.colArtCodigo.HeaderText = "Código";
            this.colArtCodigo.Name = "colArtCodigo";
            this.colArtCodigo.ReadOnly = true;
            // 
            // colArtTitulo
            // 
            this.colArtTitulo.FillWeight = 170F;
            this.colArtTitulo.HeaderText = "Artículo";
            this.colArtTitulo.Name = "colArtTitulo";
            this.colArtTitulo.ReadOnly = true;
            // 
            // colArtTipo
            // 
            this.colArtTipo.FillWeight = 85F;
            this.colArtTipo.HeaderText = "Categoría";
            this.colArtTipo.Name = "colArtTipo";
            this.colArtTipo.ReadOnly = true;
            // 
            // colArtStock
            // 
            this.colArtStock.FillWeight = 65F;
            this.colArtStock.HeaderText = "Existencias";
            this.colArtStock.Name = "colArtStock";
            this.colArtStock.ReadOnly = true;
            // 
            // colArtPrecioVenta
            // 
            this.colArtPrecioVenta.FillWeight = 75F;
            this.colArtPrecioVenta.HeaderText = "Precio Venta";
            this.colArtPrecioVenta.Name = "colArtPrecioVenta";
            this.colArtPrecioVenta.ReadOnly = true;
            // 
            // colArtPrecioRenta
            // 
            this.colArtPrecioRenta.FillWeight = 75F;
            this.colArtPrecioRenta.HeaderText = "Precio Renta";
            this.colArtPrecioRenta.Name = "colArtPrecioRenta";
            this.colArtPrecioRenta.ReadOnly = true;
            // 
            // tabMovimientos
            // 
            this.tabMovimientos.BackColor = System.Drawing.Color.FromArgb(30, 50, 80);
            this.tabMovimientos.Controls.Add(this.dgvTransacciones);
            this.tabMovimientos.Location = new System.Drawing.Point(4, 27);
            this.tabMovimientos.Name = "tabMovimientos";
            this.tabMovimientos.Padding = new System.Windows.Forms.Padding(10);
            this.tabMovimientos.Size = new System.Drawing.Size(1052, 346);
            this.tabMovimientos.TabIndex = 1;
            this.tabMovimientos.Text = "📋 Detalle de Transacciones del Periodo";
            // 
            // dgvTransacciones
            // 
            this.dgvTransacciones.AllowUserToAddRows = false;
            this.dgvTransacciones.AllowUserToDeleteRows = false;
            this.dgvTransacciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransacciones.BackgroundColor = System.Drawing.Color.FromArgb(20, 35, 60);
            headerStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle2.BackColor = System.Drawing.Color.FromArgb(15, 25, 45);
            headerStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            headerStyle2.ForeColor = System.Drawing.Color.Gold;
            this.dgvTransacciones.ColumnHeadersDefaultCellStyle = headerStyle2;
            this.dgvTransacciones.ColumnHeadersHeight = 34;
            this.dgvTransacciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrxFolio,
            this.colTrxFecha,
            this.colTrxTipo,
            this.colTrxCliente,
            this.colTrxMetodo,
            this.colTrxTotal,
            this.colTrxEstado});
            cellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle2.BackColor = System.Drawing.Color.FromArgb(25, 40, 65);
            cellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            cellStyle2.ForeColor = System.Drawing.Color.White;
            cellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(50, 85, 130);
            cellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTransacciones.DefaultCellStyle = cellStyle2;
            this.dgvTransacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransacciones.EnableHeadersVisualStyles = false;
            this.dgvTransacciones.Location = new System.Drawing.Point(10, 10);
            this.dgvTransacciones.MultiSelect = false;
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.ReadOnly = true;
            this.dgvTransacciones.RowHeadersVisible = false;
            this.dgvTransacciones.RowTemplate.Height = 30;
            this.dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransacciones.Size = new System.Drawing.Size(1032, 326);
            this.dgvTransacciones.TabIndex = 0;
            // 
            // colTrxFolio
            // 
            this.colTrxFolio.FillWeight = 90F;
            this.colTrxFolio.HeaderText = "Folio";
            this.colTrxFolio.Name = "colTrxFolio";
            this.colTrxFolio.ReadOnly = true;
            // 
            // colTrxFecha
            // 
            this.colTrxFecha.FillWeight = 85F;
            this.colTrxFecha.HeaderText = "Fecha";
            this.colTrxFecha.Name = "colTrxFecha";
            this.colTrxFecha.ReadOnly = true;
            // 
            // colTrxTipo
            // 
            this.colTrxTipo.FillWeight = 65F;
            this.colTrxTipo.HeaderText = "Tipo";
            this.colTrxTipo.Name = "colTrxTipo";
            this.colTrxTipo.ReadOnly = true;
            // 
            // colTrxCliente
            // 
            this.colTrxCliente.FillWeight = 120F;
            this.colTrxCliente.HeaderText = "Cliente";
            this.colTrxCliente.Name = "colTrxCliente";
            this.colTrxCliente.ReadOnly = true;
            // 
            // colTrxMetodo
            // 
            this.colTrxMetodo.FillWeight = 70F;
            this.colTrxMetodo.HeaderText = "Método Pago";
            this.colTrxMetodo.Name = "colTrxMetodo";
            this.colTrxMetodo.ReadOnly = true;
            // 
            // colTrxTotal
            // 
            this.colTrxTotal.FillWeight = 70F;
            this.colTrxTotal.HeaderText = "Total";
            this.colTrxTotal.Name = "colTrxTotal";
            this.colTrxTotal.ReadOnly = true;
            // 
            // colTrxEstado
            // 
            this.colTrxEstado.FillWeight = 70F;
            this.colTrxEstado.HeaderText = "Estado";
            this.colTrxEstado.Name = "colTrxEstado";
            this.colTrxEstado.ReadOnly = true;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 620);
            this.Controls.Add(this.tabDatos);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Reportes Administrativos";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUmbralStock)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlCardBalance.ResumeLayout(false);
            this.pnlCardBalance.PerformLayout();
            this.pnlCardCompras.ResumeLayout(false);
            this.pnlCardCompras.PerformLayout();
            this.pnlCardRentas.ResumeLayout(false);
            this.pnlCardRentas.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.tabDatos.ResumeLayout(false);
            this.tabBajoStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).EndInit();
            this.tabMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblUmbral;
        private System.Windows.Forms.NumericUpDown numUmbralStock;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.Label lblVentasTit;
        private System.Windows.Forms.Label lblVentasValor;
        private System.Windows.Forms.Label lblVentasDetalle;
        private System.Windows.Forms.Panel pnlCardRentas;
        private System.Windows.Forms.Label lblRentasTit;
        private System.Windows.Forms.Label lblRentasValor;
        private System.Windows.Forms.Label lblRentasDetalle;
        private System.Windows.Forms.Panel pnlCardCompras;
        private System.Windows.Forms.Label lblComprasTit;
        private System.Windows.Forms.Label lblComprasValor;
        private System.Windows.Forms.Label lblComprasDetalle;
        private System.Windows.Forms.Panel pnlCardBalance;
        private System.Windows.Forms.Label lblBalanceTit;
        private System.Windows.Forms.Label lblBalanceValor;
        private System.Windows.Forms.TabControl tabDatos;
        private System.Windows.Forms.TabPage tabBajoStock;
        private System.Windows.Forms.DataGridView dgvBajoStock;
        private System.Windows.Forms.TabPage tabMovimientos;
        private System.Windows.Forms.DataGridView dgvTransacciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtPrecioRenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxMetodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxEstado;
    }
}
