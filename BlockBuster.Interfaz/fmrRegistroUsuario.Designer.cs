namespace BlockBuster.Interfaz
{
    partial class fmrRegistroUsuario
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
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblIdInfo = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblListaTitulo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblInfoUsuario);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(988, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblInfoUsuario
            // 
            this.lblInfoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoUsuario.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblInfoUsuario.Location = new System.Drawing.Point(520, 22);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(450, 22);
            this.lblInfoUsuario.TabIndex = 1;
            this.lblInfoUsuario.Text = "Sesión: -";
            this.lblInfoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(370, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "👥 GESTIÓN DE USUARIOS";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.pnlFormulario.Controls.Add(this.lblIdInfo);
            this.pnlFormulario.Controls.Add(this.chkActivo);
            this.pnlFormulario.Controls.Add(this.cboRol);
            this.pnlFormulario.Controls.Add(this.lblRol);
            this.pnlFormulario.Controls.Add(this.txtNombreCompleto);
            this.pnlFormulario.Controls.Add(this.lblNombreCompleto);
            this.pnlFormulario.Controls.Add(this.txtContrasena);
            this.pnlFormulario.Controls.Add(this.lblContrasena);
            this.pnlFormulario.Controls.Add(this.txtNombreUsuario);
            this.pnlFormulario.Controls.Add(this.lblNombreUsuario);
            this.pnlFormulario.Controls.Add(this.btnCerrar);
            this.pnlFormulario.Controls.Add(this.btnDesactivar);
            this.pnlFormulario.Controls.Add(this.btnLimpiar);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 65);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(988, 175);
            this.pnlFormulario.TabIndex = 1;
            // 
            // lblIdInfo
            // 
            this.lblIdInfo.AutoSize = true;
            this.lblIdInfo.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblIdInfo.ForeColor = System.Drawing.Color.Gold;
            this.lblIdInfo.Location = new System.Drawing.Point(20, 96);
            this.lblIdInfo.Name = "lblIdInfo";
            this.lblIdInfo.Size = new System.Drawing.Size(130, 17);
            this.lblIdInfo.TabIndex = 13;
            this.lblIdInfo.Text = "Modo: Nuevo Usuario";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.chkActivo.ForeColor = System.Drawing.Color.White;
            this.chkActivo.Location = new System.Drawing.Point(825, 57);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(83, 24);
            this.chkActivo.TabIndex = 9;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Items.AddRange(new object[] {
            "Administrador",
            "Caja",
            "Cliente"});
            this.cboRol.Location = new System.Drawing.Point(620, 55);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(185, 27);
            this.cboRol.TabIndex = 8;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(525, 58);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(42, 20);
            this.lblRol.TabIndex = 7;
            this.lblRol.Text = "Rol:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtNombreCompleto.Location = new System.Drawing.Point(175, 55);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(325, 27);
            this.txtNombreCompleto.TabIndex = 6;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.White;
            this.lblNombreCompleto.Location = new System.Drawing.Point(20, 58);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(155, 20);
            this.lblNombreCompleto.TabIndex = 5;
            this.lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtContrasena.Location = new System.Drawing.Point(620, 16);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(288, 27);
            this.txtContrasena.TabIndex = 4;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblContrasena.ForeColor = System.Drawing.Color.White;
            this.lblContrasena.Location = new System.Drawing.Point(525, 19);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(92, 20);
            this.lblContrasena.TabIndex = 3;
            this.lblContrasena.Text = "Password:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtNombreUsuario.Location = new System.Drawing.Point(175, 16);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(325, 27);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(20, 19);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(147, 20);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Usuario (Login):";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(740, 120);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 38);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "← Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackColor = System.Drawing.Color.Firebrick;
            this.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(545, 120);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(175, 38);
            this.btnDesactivar.TabIndex = 12;
            this.btnDesactivar.Text = "🚫 Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(340, 120);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(185, 38);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "🔄 Nuevo / Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(175, 120);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(145, 38);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlLista
            // 
            this.pnlLista.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlLista.Controls.Add(this.btnRefrescar);
            this.pnlLista.Controls.Add(this.dgvUsuarios);
            this.pnlLista.Controls.Add(this.btnBuscar);
            this.pnlLista.Controls.Add(this.txtBuscar);
            this.pnlLista.Controls.Add(this.lblListaTitulo);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(0, 240);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(988, 335);
            this.pnlLista.TabIndex = 2;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(685, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 30);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 45);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersWidth = 30;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(948, 275);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(575, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtBuscar.Location = new System.Drawing.Point(240, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(325, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblListaTitulo
            // 
            this.lblListaTitulo.AutoSize = true;
            this.lblListaTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.2F);
            this.lblListaTitulo.ForeColor = System.Drawing.Color.White;
            this.lblListaTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblListaTitulo.Name = "lblListaTitulo";
            this.lblListaTitulo.Size = new System.Drawing.Size(212, 22);
            this.lblListaTitulo.TabIndex = 0;
            this.lblListaTitulo.Text = "Usuarios Registrados:";
            // 
            // fmrRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 575);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlHeader);
            this.Name = "fmrRegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Gestión de Usuarios";
            this.Load += new System.EventHandler(this.fmrRegistroUsuario_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblIdInfo;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.Label lblListaTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}
