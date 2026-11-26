namespace BlockBuster.Interfaz
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblRolActual = new System.Windows.Forms.Label();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnTickets = new System.Windows.Forms.Button();
            this.btnRentasActivas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.btnComprasPendientes = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnRenta = new System.Windows.Forms.Button();
            this.lblAccionesTitulo = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusRol = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.btnCerrarSesion);
            this.pnlHeader.Controls.Add(this.lblRolActual);
            this.pnlHeader.Controls.Add(this.lblUsuarioActual);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1150, 75);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(980, 18);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(165, 40);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblRolActual
            // 
            this.lblRolActual.AutoSize = true;
            this.lblRolActual.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRolActual.ForeColor = System.Drawing.Color.Gold;
            this.lblRolActual.Location = new System.Drawing.Point(340, 42);
            this.lblRolActual.Name = "lblRolActual";
            this.lblRolActual.Size = new System.Drawing.Size(57, 22);
            this.lblRolActual.TabIndex = 2;
            this.lblRolActual.Text = "Rol: -";
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioActual.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioActual.Location = new System.Drawing.Point(340, 15);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(97, 22);
            this.lblUsuarioActual.TabIndex = 1;
            this.lblUsuarioActual.Text = "Usuario: -";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblLogo.Location = new System.Drawing.Point(20, 18);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(280, 39);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "BLOCKBUSTER";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.pnlToolbar.Controls.Add(this.lblAccionesTitulo);
            this.pnlToolbar.Controls.Add(this.btnRenta);
            this.pnlToolbar.Controls.Add(this.btnVenta);
            this.pnlToolbar.Controls.Add(this.btnCompra);
            this.pnlToolbar.Controls.Add(this.btnCatalogo);
            this.pnlToolbar.Controls.Add(this.btnTickets);
            this.pnlToolbar.Controls.Add(this.btnRentasActivas);
            this.pnlToolbar.Controls.Add(this.btnComprasPendientes);
            this.pnlToolbar.Controls.Add(this.btnClientes);
            this.pnlToolbar.Controls.Add(this.btnInventario);
            this.pnlToolbar.Controls.Add(this.btnUsuarios);
            this.pnlToolbar.Controls.Add(this.btnReportes);
            this.pnlToolbar.Controls.Add(this.btnConfiguracion);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 75);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlToolbar.Size = new System.Drawing.Size(1260, 118);
            this.pnlToolbar.TabIndex = 2;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(95)))));
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnConfiguracion.FlatAppearance.BorderSize = 2;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(170, 44);
            this.btnConfiguracion.TabIndex = 12;
            this.btnConfiguracion.Text = "🛠️ Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(100)))), ((int)(((byte)(90)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnReportes.FlatAppearance.BorderSize = 2;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(180, 44);
            this.btnReportes.TabIndex = 11;
            this.btnReportes.Text = "📊 Reportes y Stock";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(95)))), ((int)(((byte)(120)))));
            this.btnTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTickets.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTickets.FlatAppearance.BorderSize = 2;
            this.btnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTickets.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTickets.ForeColor = System.Drawing.Color.White;
            this.btnTickets.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(195, 44);
            this.btnTickets.TabIndex = 10;
            this.btnTickets.Text = "🧾 Historial de Tickets";
            this.btnTickets.UseVisualStyleBackColor = false;
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnRentasActivas
            // 
            this.btnRentasActivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(120)))), ((int)(((byte)(165)))));
            this.btnRentasActivas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRentasActivas.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnRentasActivas.FlatAppearance.BorderSize = 2;
            this.btnRentasActivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentasActivas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentasActivas.ForeColor = System.Drawing.Color.White;
            this.btnRentasActivas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRentasActivas.Name = "btnRentasActivas";
            this.btnRentasActivas.Size = new System.Drawing.Size(215, 44);
            this.btnRentasActivas.TabIndex = 9;
            this.btnRentasActivas.Text = "📥 Devoluciones y Rentas";
            this.btnRentasActivas.UseVisualStyleBackColor = false;
            this.btnRentasActivas.Click += new System.EventHandler(this.btnRentasActivas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClientes.FlatAppearance.BorderSize = 2;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(195, 44);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "👥 Registro de Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnUsuarios.FlatAppearance.BorderSize = 2;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(195, 44);
            this.btnUsuarios.TabIndex = 7;
            this.btnUsuarios.Text = "👤 Gestión de Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(50)))), ((int)(((byte)(140)))));
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnInventario.FlatAppearance.BorderSize = 2;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(205, 44);
            this.btnInventario.TabIndex = 6;
            this.btnInventario.Text = "⚙️ Gestión de Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCatalogo.FlatAppearance.BorderSize = 2;
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.Color.White;
            this.btnCatalogo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(165, 44);
            this.btnCatalogo.TabIndex = 5;
            this.btnCatalogo.Text = "🔍 Ver Catálogo";
            this.btnCatalogo.UseVisualStyleBackColor = false;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // btnComprasPendientes
            // 
            this.btnComprasPendientes.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnComprasPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprasPendientes.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnComprasPendientes.FlatAppearance.BorderSize = 2;
            this.btnComprasPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprasPendientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprasPendientes.ForeColor = System.Drawing.Color.White;
            this.btnComprasPendientes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnComprasPendientes.Name = "btnComprasPendientes";
            this.btnComprasPendientes.Size = new System.Drawing.Size(200, 44);
            this.btnComprasPendientes.TabIndex = 4;
            this.btnComprasPendientes.Text = "📋 Compras Pendientes";
            this.btnComprasPendientes.UseVisualStyleBackColor = false;
            this.btnComprasPendientes.Click += new System.EventHandler(this.btnComprasPendientes_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCompra.FlatAppearance.BorderSize = 2;
            this.btnCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.ForeColor = System.Drawing.Color.White;
            this.btnCompra.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(185, 44);
            this.btnCompra.TabIndex = 3;
            this.btnCompra.Text = "📦 Compra a Clientes";
            this.btnCompra.UseVisualStyleBackColor = false;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVenta.FlatAppearance.BorderSize = 2;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.White;
            this.btnVenta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(185, 44);
            this.btnVenta.TabIndex = 2;
            this.btnVenta.Text = "🛒 Venta / Comprar";
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnRenta
            // 
            this.btnRenta.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenta.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRenta.FlatAppearance.BorderSize = 2;
            this.btnRenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenta.ForeColor = System.Drawing.Color.White;
            this.btnRenta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRenta.Name = "btnRenta";
            this.btnRenta.Size = new System.Drawing.Size(180, 44);
            this.btnRenta.TabIndex = 1;
            this.btnRenta.Text = "🔄 Rentar Productos";
            this.btnRenta.UseVisualStyleBackColor = false;
            this.btnRenta.Click += new System.EventHandler(this.btnRenta_Click);
            // 
            // lblAccionesTitulo
            // 
            this.lblAccionesTitulo.AutoSize = true;
            this.lblAccionesTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccionesTitulo.ForeColor = System.Drawing.Color.LightCyan;
            this.lblAccionesTitulo.Margin = new System.Windows.Forms.Padding(3, 14, 8, 4);
            this.lblAccionesTitulo.Name = "lblAccionesTitulo";
            this.lblAccionesTitulo.Size = new System.Drawing.Size(112, 20);
            this.lblAccionesTitulo.TabIndex = 0;
            this.lblAccionesTitulo.Text = "Operaciones:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUsuario,
            this.lblStatusRol,
            this.lblStatusInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusUsuario
            // 
            this.lblStatusUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusUsuario.Name = "lblStatusUsuario";
            this.lblStatusUsuario.Size = new System.Drawing.Size(77, 20);
            this.lblStatusUsuario.Text = "Usuario: -";
            // 
            // lblStatusRol
            // 
            this.lblStatusRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusRol.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatusRol.Name = "lblStatusRol";
            this.lblStatusRol.Size = new System.Drawing.Size(46, 20);
            this.lblStatusRol.Text = "Rol: -";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(259, 20);
            this.lblStatusInfo.Text = " | BlockBuster v1.0 | SQLite Conectado";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Sistema Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.Label lblRolActual;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.FlowLayoutPanel pnlToolbar;
        private System.Windows.Forms.Label lblAccionesTitulo;
        private System.Windows.Forms.Button btnRenta;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnComprasPendientes;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Button btnRentasActivas;
        private System.Windows.Forms.Button btnTickets;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRol;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
    }
}