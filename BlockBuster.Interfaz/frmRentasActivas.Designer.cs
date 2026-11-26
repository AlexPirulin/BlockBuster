namespace BlockBuster.Interfaz
{
    partial class frmRentasActivas
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvRentasActivas = new System.Windows.Forms.DataGridView();
            this.colIdRenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaPrevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiasRetraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentasActivas)).BeginInit();
            this.pnlAcciones.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(1020, 70);
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
            this.lblSubtitulo.Text = "Control de rentas activas, vencidas (resaltadas en rojo) y cálculo de recargos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.5F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(255, 204, 0);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(420, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📥 RENTAS ACTIVAS Y DEVOLUCIONES";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(30, 50, 80);
            this.pnlBody.Controls.Add(this.dgvRentasActivas);
            this.pnlBody.Controls.Add(this.pnlAcciones);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 70);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBody.Size = new System.Drawing.Size(1020, 520);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvRentasActivas
            // 
            this.dgvRentasActivas.AllowUserToAddRows = false;
            this.dgvRentasActivas.AllowUserToDeleteRows = false;
            this.dgvRentasActivas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentasActivas.BackgroundColor = System.Drawing.Color.FromArgb(20, 35, 60);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(15, 25, 45);
            headerStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            headerStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgvRentasActivas.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvRentasActivas.ColumnHeadersHeight = 36;
            this.dgvRentasActivas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRenta,
            this.colFolio,
            this.colCliente,
            this.colArticulos,
            this.colFechaInicio,
            this.colFechaPrevista,
            this.colDiasRetraso,
            this.colEstado,
            this.colRecargo,
            this.colTotal});
            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = System.Drawing.Color.FromArgb(25, 40, 65);
            cellStyle.Font = new System.Drawing.Font("Arial", 9F);
            cellStyle.ForeColor = System.Drawing.Color.White;
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(50, 85, 130);
            cellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRentasActivas.DefaultCellStyle = cellStyle;
            this.dgvRentasActivas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRentasActivas.EnableHeadersVisualStyles = false;
            this.dgvRentasActivas.Location = new System.Drawing.Point(15, 15);
            this.dgvRentasActivas.MultiSelect = false;
            this.dgvRentasActivas.Name = "dgvRentasActivas";
            this.dgvRentasActivas.ReadOnly = true;
            this.dgvRentasActivas.RowHeadersVisible = false;
            this.dgvRentasActivas.RowTemplate.Height = 32;
            this.dgvRentasActivas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentasActivas.Size = new System.Drawing.Size(990, 415);
            this.dgvRentasActivas.TabIndex = 0;
            // 
            // colIdRenta
            // 
            this.colIdRenta.HeaderText = "ID";
            this.colIdRenta.Name = "colIdRenta";
            this.colIdRenta.ReadOnly = true;
            this.colIdRenta.Visible = false;
            // 
            // colFolio
            // 
            this.colFolio.FillWeight = 85F;
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.FillWeight = 110F;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colArticulos
            // 
            this.colArticulos.FillWeight = 150F;
            this.colArticulos.HeaderText = "Artículos";
            this.colArticulos.Name = "colArticulos";
            this.colArticulos.ReadOnly = true;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.FillWeight = 75F;
            this.colFechaInicio.HeaderText = "Inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.ReadOnly = true;
            // 
            // colFechaPrevista
            // 
            this.colFechaPrevista.FillWeight = 85F;
            this.colFechaPrevista.HeaderText = "Dev. Prevista";
            this.colFechaPrevista.Name = "colFechaPrevista";
            this.colFechaPrevista.ReadOnly = true;
            // 
            // colDiasRetraso
            // 
            this.colDiasRetraso.FillWeight = 60F;
            this.colDiasRetraso.HeaderText = "Retraso";
            this.colDiasRetraso.Name = "colDiasRetraso";
            this.colDiasRetraso.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.FillWeight = 65F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colRecargo
            // 
            this.colRecargo.FillWeight = 70F;
            this.colRecargo.HeaderText = "Recargo";
            this.colRecargo.Name = "colRecargo";
            this.colRecargo.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.FillWeight = 65F;
            this.colTotal.HeaderText = "Total Renta";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(20, 35, 60);
            this.pnlAcciones.Controls.Add(this.lblLeyenda);
            this.pnlAcciones.Controls.Add(this.lblContador);
            this.pnlAcciones.Controls.Add(this.btnRefrescar);
            this.pnlAcciones.Controls.Add(this.btnRegistrarDevolucion);
            this.pnlAcciones.Controls.Add(this.btnCerrar);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(15, 430);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(990, 75);
            this.pnlAcciones.TabIndex = 1;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeyenda.ForeColor = System.Drawing.Color.Salmon;
            this.lblLeyenda.Location = new System.Drawing.Point(160, 42);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(270, 17);
            this.lblLeyenda.TabIndex = 4;
            this.lblLeyenda.Text = "■ Filas en rojo indican rentas vencidas";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.lblContador.ForeColor = System.Drawing.Color.Gold;
            this.lblContador.Location = new System.Drawing.Point(160, 15);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(180, 20);
            this.lblContador.TabIndex = 3;
            this.lblContador.Text = "Rentas activas: 0";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(15, 16);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(130, 42);
            this.btnRefrescar.TabIndex = 0;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarDevolucion.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegistrarDevolucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarDevolucion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegistrarDevolucion.FlatAppearance.BorderSize = 2;
            this.btnRegistrarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDevolucion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F);
            this.btnRegistrarDevolucion.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(625, 16);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(230, 42);
            this.btnRegistrarDevolucion.TabIndex = 1;
            this.btnRegistrarDevolucion.Text = "✔ Registrar devolución";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(865, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmRentasActivas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 590);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmRentasActivas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Rentas Activas y Devoluciones";
            this.Load += new System.EventHandler(this.frmRentasActivas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentasActivas)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgvRentasActivas;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaPrevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiasRetraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}

