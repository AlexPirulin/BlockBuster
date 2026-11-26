namespace BlockBuster.Interfaz
{
    partial class frmVentas
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
            this.grpAgregar = new System.Windows.Forms.GroupBox();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblStockInfo = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.cboArticulos = new System.Windows.Forms.ComboBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.grpCarrito = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCarrito = new System.Windows.Forms.Button();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.pnlPago = new System.Windows.Forms.Panel();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.btnConfirmarVenta = new System.Windows.Forms.Button();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.grpCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlPago.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(940, 70);
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
            this.lblOperacionCategoria.Text = "🛒 MÓDULO DE VENTA EN MOSTRADOR";
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
            this.pnlPrincipal.Controls.Add(this.grpAgregar);
            this.pnlPrincipal.Controls.Add(this.grpCarrito);
            this.pnlPrincipal.Controls.Add(this.pnlPago);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 70);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(15);
            this.pnlPrincipal.Size = new System.Drawing.Size(940, 590);
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
            this.grpCliente.Size = new System.Drawing.Size(900, 75);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "1. Cliente Comprador";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(745, 26);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(140, 32);
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
            this.btnRecargarClientes.Location = new System.Drawing.Point(625, 26);
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
            this.cboClientes.Location = new System.Drawing.Point(120, 28);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(490, 27);
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
            // grpAgregar
            // 
            this.grpAgregar.Controls.Add(this.btnAgregarCarrito);
            this.grpAgregar.Controls.Add(this.numCantidad);
            this.grpAgregar.Controls.Add(this.lblCantidad);
            this.grpAgregar.Controls.Add(this.lblStockInfo);
            this.grpAgregar.Controls.Add(this.lblPrecioVenta);
            this.grpAgregar.Controls.Add(this.cboArticulos);
            this.grpAgregar.Controls.Add(this.lblArticulo);
            this.grpAgregar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpAgregar.Location = new System.Drawing.Point(20, 95);
            this.grpAgregar.Name = "grpAgregar";
            this.grpAgregar.Size = new System.Drawing.Size(900, 100);
            this.grpAgregar.TabIndex = 1;
            this.grpAgregar.TabStop = false;
            this.grpAgregar.Text = "2. Agregar Artículos a la Venta";
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAgregarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCarrito.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.btnAgregarCarrito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCarrito.Location = new System.Drawing.Point(715, 26);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(170, 60);
            this.btnAgregarCarrito.TabIndex = 6;
            this.btnAgregarCarrito.Text = "➕ Agregar al Carrito";
            this.btnAgregarCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click);
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.numCantidad.Location = new System.Drawing.Point(595, 30);
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(90, 29);
            this.numCantidad.TabIndex = 5;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(505, 34);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(84, 18);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblStockInfo
            // 
            this.lblStockInfo.AutoSize = true;
            this.lblStockInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblStockInfo.ForeColor = System.Drawing.Color.LightGreen;
            this.lblStockInfo.Location = new System.Drawing.Point(260, 68);
            this.lblStockInfo.Name = "lblStockInfo";
            this.lblStockInfo.Size = new System.Drawing.Size(125, 17);
            this.lblStockInfo.TabIndex = 3;
            this.lblStockInfo.Text = "Stock disponible: -";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.Gold;
            this.lblPrecioVenta.Location = new System.Drawing.Point(120, 68);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(120, 18);
            this.lblPrecioVenta.TabIndex = 2;
            this.lblPrecioVenta.Text = "Precio: $0.00";
            // 
            // cboArticulos
            // 
            this.cboArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulos.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboArticulos.FormattingEnabled = true;
            this.cboArticulos.Location = new System.Drawing.Point(120, 28);
            this.cboArticulos.Name = "cboArticulos";
            this.cboArticulos.Size = new System.Drawing.Size(370, 27);
            this.cboArticulos.TabIndex = 1;
            this.cboArticulos.SelectedIndexChanged += new System.EventHandler(this.cboArticulos_SelectedIndexChanged);
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblArticulo.ForeColor = System.Drawing.Color.White;
            this.lblArticulo.Location = new System.Drawing.Point(20, 32);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(76, 18);
            this.lblArticulo.TabIndex = 0;
            this.lblArticulo.Text = "Artículo:";
            // 
            // grpCarrito
            // 
            this.grpCarrito.Controls.Add(this.btnLimpiarCarrito);
            this.grpCarrito.Controls.Add(this.btnQuitarItem);
            this.grpCarrito.Controls.Add(this.dgvCarrito);
            this.grpCarrito.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.grpCarrito.Location = new System.Drawing.Point(20, 205);
            this.grpCarrito.Name = "grpCarrito";
            this.grpCarrito.Size = new System.Drawing.Size(900, 240);
            this.grpCarrito.TabIndex = 2;
            this.grpCarrito.TabStop = false;
            this.grpCarrito.Text = "3. Carrito de Compra del Cliente";
            // 
            // btnLimpiarCarrito
            // 
            this.btnLimpiarCarrito.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpiarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarCarrito.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnLimpiarCarrito.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarCarrito.Location = new System.Drawing.Point(745, 195);
            this.btnLimpiarCarrito.Name = "btnLimpiarCarrito";
            this.btnLimpiarCarrito.Size = new System.Drawing.Size(140, 32);
            this.btnLimpiarCarrito.TabIndex = 2;
            this.btnLimpiarCarrito.Text = "Vaciar Carrito";
            this.btnLimpiarCarrito.UseVisualStyleBackColor = false;
            this.btnLimpiarCarrito.Click += new System.EventHandler(this.btnLimpiarCarrito_Click);
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.BackColor = System.Drawing.Color.Firebrick;
            this.btnQuitarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnQuitarItem.ForeColor = System.Drawing.Color.White;
            this.btnQuitarItem.Location = new System.Drawing.Point(595, 195);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(140, 32);
            this.btnQuitarItem.TabIndex = 1;
            this.btnQuitarItem.Text = "🗑 Quitar Artículo";
            this.btnQuitarItem.UseVisualStyleBackColor = false;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvCarrito.Location = new System.Drawing.Point(15, 28);
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 25;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(870, 160);
            this.dgvCarrito.TabIndex = 0;
            // 
            // pnlPago
            // 
            this.pnlPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPago.Controls.Add(this.btnCerrar);
            this.pnlPago.Controls.Add(this.cboMetodoPago);
            this.pnlPago.Controls.Add(this.lblMetodoPago);
            this.pnlPago.Controls.Add(this.btnConfirmarVenta);
            this.pnlPago.Controls.Add(this.lblTotalTitulo);
            this.pnlPago.Controls.Add(this.lblTotal);
            this.pnlPago.Location = new System.Drawing.Point(20, 455);
            this.pnlPago.Name = "pnlPago";
            this.pnlPago.Size = new System.Drawing.Size(900, 115);
            this.pnlPago.TabIndex = 3;
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Arial", 10.5F);
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cboMetodoPago.Location = new System.Drawing.Point(155, 60);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(180, 27);
            this.cboMetodoPago.TabIndex = 4;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.White;
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 63);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(127, 20);
            this.lblMetodoPago.TabIndex = 3;
            this.lblMetodoPago.Text = "Forma de Pago:";
            // 
            // btnConfirmarVenta
            // 
            this.btnConfirmarVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarVenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmarVenta.FlatAppearance.BorderSize = 2;
            this.btnConfirmarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btnConfirmarVenta.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarVenta.Location = new System.Drawing.Point(645, 15);
            this.btnConfirmarVenta.Name = "btnConfirmarVenta";
            this.btnConfirmarVenta.Size = new System.Drawing.Size(240, 50);
            this.btnConfirmarVenta.TabIndex = 2;
            this.btnConfirmarVenta.Text = "✔ Confirmar Venta";
            this.btnConfirmarVenta.UseVisualStyleBackColor = false;
            this.btnConfirmarVenta.Click += new System.EventHandler(this.btnConfirmarVenta_Click);
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(197, 26);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "TOTAL A PAGAR:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(220, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(117, 44);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "$0.00";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(745, 72);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 32);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 660);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Módulo de Venta";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpAgregar.ResumeLayout(false);
            this.grpAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.grpCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlPago.ResumeLayout(false);
            this.pnlPago.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpAgregar;
        private System.Windows.Forms.ComboBox cboArticulos;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblStockInfo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.GroupBox grpCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.Button btnLimpiarCarrito;
        private System.Windows.Forms.Panel pnlPago;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.Button btnCerrar;
    }
}
