namespace BlockBuster.Interfaz
{
    partial class frmConfiguracion
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.grpRentas = new System.Windows.Forms.GroupBox();
            this.numDiasMaximos = new System.Windows.Forms.NumericUpDown();
            this.lblDiasMax = new System.Windows.Forms.Label();
            this.numDiasMinimos = new System.Windows.Forms.NumericUpDown();
            this.lblDiasMin = new System.Windows.Forms.Label();
            this.numTarifaRecargo = new System.Windows.Forms.NumericUpDown();
            this.lblTarifaRecargo = new System.Windows.Forms.Label();
            this.grpValuacion = new System.Windows.Forms.GroupBox();
            this.numPorcMalo = new System.Windows.Forms.NumericUpDown();
            this.lblMalo = new System.Windows.Forms.Label();
            this.numPorcRegular = new System.Windows.Forms.NumericUpDown();
            this.lblRegular = new System.Windows.Forms.Label();
            this.numPorcBueno = new System.Windows.Forms.NumericUpDown();
            this.lblBueno = new System.Windows.Forms.Label();
            this.numPorcExcelente = new System.Windows.Forms.NumericUpDown();
            this.lblExcelente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpRentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasMaximos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasMinimos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarifaRecargo)).BeginInit();
            this.grpValuacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcMalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcRegular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcBueno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcExcelente)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(640, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(370, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Parámetros globales de operación (Exclusivo Administrador)";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.5F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(255, 204, 0);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "⚙️ CONFIGURACIÓN DEL SISTEMA";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(30, 50, 80);
            this.pnlBody.Controls.Add(this.btnCerrar);
            this.pnlBody.Controls.Add(this.btnGuardar);
            this.pnlBody.Controls.Add(this.grpValuacion);
            this.pnlBody.Controls.Add(this.grpRentas);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 70);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(640, 440);
            this.pnlBody.TabIndex = 1;
            // 
            // grpRentas
            // 
            this.grpRentas.Controls.Add(this.numDiasMaximos);
            this.grpRentas.Controls.Add(this.lblDiasMax);
            this.grpRentas.Controls.Add(this.numDiasMinimos);
            this.grpRentas.Controls.Add(this.lblDiasMin);
            this.grpRentas.Controls.Add(this.numTarifaRecargo);
            this.grpRentas.Controls.Add(this.lblTarifaRecargo);
            this.grpRentas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpRentas.ForeColor = System.Drawing.Color.Gold;
            this.grpRentas.Location = new System.Drawing.Point(20, 15);
            this.grpRentas.Name = "grpRentas";
            this.grpRentas.Size = new System.Drawing.Size(600, 155);
            this.grpRentas.TabIndex = 0;
            this.grpRentas.TabStop = false;
            this.grpRentas.Text = "Parámetros de Rentas y Recargos";
            // 
            // lblTarifaRecargo
            // 
            this.lblTarifaRecargo.AutoSize = true;
            this.lblTarifaRecargo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblTarifaRecargo.ForeColor = System.Drawing.Color.White;
            this.lblTarifaRecargo.Location = new System.Drawing.Point(20, 35);
            this.lblTarifaRecargo.Name = "lblTarifaRecargo";
            this.lblTarifaRecargo.Size = new System.Drawing.Size(260, 18);
            this.lblTarifaRecargo.TabIndex = 0;
            this.lblTarifaRecargo.Text = "Tarifa de recargo por día ($ MXN):";
            // 
            // numTarifaRecargo
            // 
            this.numTarifaRecargo.DecimalPlaces = 2;
            this.numTarifaRecargo.Font = new System.Drawing.Font("Arial", 10F);
            this.numTarifaRecargo.Location = new System.Drawing.Point(340, 32);
            this.numTarifaRecargo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numTarifaRecargo.Name = "numTarifaRecargo";
            this.numTarifaRecargo.Size = new System.Drawing.Size(230, 27);
            this.numTarifaRecargo.TabIndex = 1;
            this.numTarifaRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiasMin
            // 
            this.lblDiasMin.AutoSize = true;
            this.lblDiasMin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblDiasMin.ForeColor = System.Drawing.Color.White;
            this.lblDiasMin.Location = new System.Drawing.Point(20, 75);
            this.lblDiasMin.Name = "lblDiasMin";
            this.lblDiasMin.Size = new System.Drawing.Size(210, 18);
            this.lblDiasMin.TabIndex = 2;
            this.lblDiasMin.Text = "Días mínimos de renta:";
            // 
            // numDiasMinimos
            // 
            this.numDiasMinimos.Font = new System.Drawing.Font("Arial", 10F);
            this.numDiasMinimos.Location = new System.Drawing.Point(340, 72);
            this.numDiasMinimos.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numDiasMinimos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDiasMinimos.Name = "numDiasMinimos";
            this.numDiasMinimos.Size = new System.Drawing.Size(230, 27);
            this.numDiasMinimos.TabIndex = 3;
            this.numDiasMinimos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDiasMinimos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDiasMax
            // 
            this.lblDiasMax.AutoSize = true;
            this.lblDiasMax.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblDiasMax.ForeColor = System.Drawing.Color.White;
            this.lblDiasMax.Location = new System.Drawing.Point(20, 115);
            this.lblDiasMax.Name = "lblDiasMax";
            this.lblDiasMax.Size = new System.Drawing.Size(215, 18);
            this.lblDiasMax.TabIndex = 4;
            this.lblDiasMax.Text = "Días máximos de renta:";
            // 
            // numDiasMaximos
            // 
            this.numDiasMaximos.Font = new System.Drawing.Font("Arial", 10F);
            this.numDiasMaximos.Location = new System.Drawing.Point(340, 112);
            this.numDiasMaximos.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            this.numDiasMaximos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDiasMaximos.Name = "numDiasMaximos";
            this.numDiasMaximos.Size = new System.Drawing.Size(230, 27);
            this.numDiasMaximos.TabIndex = 5;
            this.numDiasMaximos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDiasMaximos.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // grpValuacion
            // 
            this.grpValuacion.Controls.Add(this.numPorcMalo);
            this.grpValuacion.Controls.Add(this.lblMalo);
            this.grpValuacion.Controls.Add(this.numPorcRegular);
            this.grpValuacion.Controls.Add(this.lblRegular);
            this.grpValuacion.Controls.Add(this.numPorcBueno);
            this.grpValuacion.Controls.Add(this.lblBueno);
            this.grpValuacion.Controls.Add(this.numPorcExcelente);
            this.grpValuacion.Controls.Add(this.lblExcelente);
            this.grpValuacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.grpValuacion.ForeColor = System.Drawing.Color.Gold;
            this.grpValuacion.Location = new System.Drawing.Point(20, 180);
            this.grpValuacion.Name = "grpValuacion";
            this.grpValuacion.Size = new System.Drawing.Size(600, 190);
            this.grpValuacion.TabIndex = 1;
            this.grpValuacion.TabStop = false;
            this.grpValuacion.Text = "Porcentajes de Valuación en Compra a Clientes (%)";
            // 
            // lblExcelente
            // 
            this.lblExcelente.AutoSize = true;
            this.lblExcelente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblExcelente.ForeColor = System.Drawing.Color.White;
            this.lblExcelente.Location = new System.Drawing.Point(20, 35);
            this.lblExcelente.Name = "lblExcelente";
            this.lblExcelente.Size = new System.Drawing.Size(195, 18);
            this.lblExcelente.TabIndex = 0;
            this.lblExcelente.Text = "Estado Excelente (%):";
            // 
            // numPorcExcelente
            // 
            this.numPorcExcelente.Font = new System.Drawing.Font("Arial", 10F);
            this.numPorcExcelente.Location = new System.Drawing.Point(340, 32);
            this.numPorcExcelente.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPorcExcelente.Name = "numPorcExcelente";
            this.numPorcExcelente.Size = new System.Drawing.Size(230, 27);
            this.numPorcExcelente.TabIndex = 1;
            this.numPorcExcelente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBueno
            // 
            this.lblBueno.AutoSize = true;
            this.lblBueno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblBueno.ForeColor = System.Drawing.Color.White;
            this.lblBueno.Location = new System.Drawing.Point(20, 72);
            this.lblBueno.Name = "lblBueno";
            this.lblBueno.Size = new System.Drawing.Size(170, 18);
            this.lblBueno.TabIndex = 2;
            this.lblBueno.Text = "Estado Bueno (%):";
            // 
            // numPorcBueno
            // 
            this.numPorcBueno.Font = new System.Drawing.Font("Arial", 10F);
            this.numPorcBueno.Location = new System.Drawing.Point(340, 69);
            this.numPorcBueno.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPorcBueno.Name = "numPorcBueno";
            this.numPorcBueno.Size = new System.Drawing.Size(230, 27);
            this.numPorcBueno.TabIndex = 3;
            this.numPorcBueno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegular
            // 
            this.lblRegular.AutoSize = true;
            this.lblRegular.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblRegular.ForeColor = System.Drawing.Color.White;
            this.lblRegular.Location = new System.Drawing.Point(20, 110);
            this.lblRegular.Name = "lblRegular";
            this.lblRegular.Size = new System.Drawing.Size(185, 18);
            this.lblRegular.TabIndex = 4;
            this.lblRegular.Text = "Estado Regular (%):";
            // 
            // numPorcRegular
            // 
            this.numPorcRegular.Font = new System.Drawing.Font("Arial", 10F);
            this.numPorcRegular.Location = new System.Drawing.Point(340, 107);
            this.numPorcRegular.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPorcRegular.Name = "numPorcRegular";
            this.numPorcRegular.Size = new System.Drawing.Size(230, 27);
            this.numPorcRegular.TabIndex = 5;
            this.numPorcRegular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMalo
            // 
            this.lblMalo.AutoSize = true;
            this.lblMalo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.lblMalo.ForeColor = System.Drawing.Color.White;
            this.lblMalo.Location = new System.Drawing.Point(20, 148);
            this.lblMalo.Name = "lblMalo";
            this.lblMalo.Size = new System.Drawing.Size(160, 18);
            this.lblMalo.TabIndex = 6;
            this.lblMalo.Text = "Estado Malo (%):";
            // 
            // numPorcMalo
            // 
            this.numPorcMalo.Font = new System.Drawing.Font("Arial", 10F);
            this.numPorcMalo.Location = new System.Drawing.Point(340, 145);
            this.numPorcMalo.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPorcMalo.Name = "numPorcMalo";
            this.numPorcMalo.Size = new System.Drawing.Size(230, 27);
            this.numPorcMalo.TabIndex = 7;
            this.numPorcMalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.5F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(280, 382);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(215, 42);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "💾 Guardar Configuración";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(505, 382);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 42);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 510);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockBuster - Configuración del Sistema";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.grpRentas.ResumeLayout(false);
            this.grpRentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasMaximos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasMinimos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarifaRecargo)).EndInit();
            this.grpValuacion.ResumeLayout(false);
            this.grpValuacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcMalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcRegular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcBueno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcExcelente)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.GroupBox grpRentas;
        private System.Windows.Forms.Label lblTarifaRecargo;
        private System.Windows.Forms.NumericUpDown numTarifaRecargo;
        private System.Windows.Forms.Label lblDiasMin;
        private System.Windows.Forms.NumericUpDown numDiasMinimos;
        private System.Windows.Forms.Label lblDiasMax;
        private System.Windows.Forms.NumericUpDown numDiasMaximos;
        private System.Windows.Forms.GroupBox grpValuacion;
        private System.Windows.Forms.Label lblExcelente;
        private System.Windows.Forms.NumericUpDown numPorcExcelente;
        private System.Windows.Forms.Label lblBueno;
        private System.Windows.Forms.NumericUpDown numPorcBueno;
        private System.Windows.Forms.Label lblRegular;
        private System.Windows.Forms.NumericUpDown numPorcRegular;
        private System.Windows.Forms.Label lblMalo;
        private System.Windows.Forms.NumericUpDown numPorcMalo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}

