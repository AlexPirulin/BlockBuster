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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
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
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
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
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 40);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
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
            this.lblUsuarioActual.Click += new System.EventHandler(this.lblUsuarioActual_Click);
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
            this.pnlToolbar.Controls.Add(this.btnClientes);
            this.pnlToolbar.Controls.Add(this.btnUsuarios);
            this.pnlToolbar.Controls.Add(this.btnInventario);
            this.pnlToolbar.Controls.Add(this.btnCompra);
            this.pnlToolbar.Controls.Add(this.btnVenta);
            this.pnlToolbar.Controls.Add(this.btnRenta);
            this.pnlToolbar.Controls.Add(this.lblAccionesTitulo);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 75);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1150, 70);
            this.pnlToolbar.TabIndex = 2;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClientes.FlatAppearance.BorderSize = 2;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(930, 10);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(160, 48);
            this.btnClientes.TabIndex = 6;
            this.btnClientes.Text = "👥 CLIENTES";
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
            this.btnUsuarios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(760, 10);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(160, 48);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "👤 USUARIOS";
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
            this.btnInventario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(585, 10);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(165, 48);
            this.btnInventario.TabIndex = 4;
            this.btnInventario.Text = "⚙️ INVENTARIO";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCompra.FlatAppearance.BorderSize = 2;
            this.btnCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.ForeColor = System.Drawing.Color.White;
            this.btnCompra.Location = new System.Drawing.Point(430, 10);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(145, 48);
            this.btnCompra.TabIndex = 3;
            this.btnCompra.Text = "📦 COMPRA";
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
            this.btnVenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.White;
            this.btnVenta.Location = new System.Drawing.Point(285, 10);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(135, 48);
            this.btnVenta.TabIndex = 2;
            this.btnVenta.Text = "🛒 VENTA";
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
            this.btnRenta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenta.ForeColor = System.Drawing.Color.White;
            this.btnRenta.Location = new System.Drawing.Point(140, 10);
            this.btnRenta.Name = "btnRenta";
            this.btnRenta.Size = new System.Drawing.Size(135, 48);
            this.btnRenta.TabIndex = 1;
            this.btnRenta.Text = "🔄 RENTA";
            this.btnRenta.UseVisualStyleBackColor = false;
            this.btnRenta.Click += new System.EventHandler(this.btnRenta_Click);
            // 
            // lblAccionesTitulo
            // 
            this.lblAccionesTitulo.AutoSize = true;
            this.lblAccionesTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccionesTitulo.ForeColor = System.Drawing.Color.LightCyan;
            this.lblAccionesTitulo.Location = new System.Drawing.Point(23, 23);
            this.lblAccionesTitulo.Name = "lblAccionesTitulo";
            this.lblAccionesTitulo.Size = new System.Drawing.Size(142, 23);
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
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblAccionesTitulo;
        private System.Windows.Forms.Button btnRenta;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRol;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
    }
}