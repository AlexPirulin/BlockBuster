namespace BlockBuster.Interfaz
{
    partial class frmTicketViewer
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.rtbTicket = new System.Windows.Forms.RichTextBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnAbrirArchivo = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.5F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "COMPROBANTE OFICIAL";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(280, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Detalle del comprobante de la transacción.";
            // 
            // rtbTicket
            // 
            this.rtbTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.rtbTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTicket.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.rtbTicket.Location = new System.Drawing.Point(0, 65);
            this.rtbTicket.Name = "rtbTicket";
            this.rtbTicket.ReadOnly = true;
            this.rtbTicket.Size = new System.Drawing.Size(560, 480);
            this.rtbTicket.TabIndex = 1;
            this.rtbTicket.Text = "";
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.pnlBotones.Controls.Add(this.btnAbrirArchivo);
            this.pnlBotones.Controls.Add(this.btnCopiar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 545);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(560, 55);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnAbrirArchivo
            // 
            this.btnAbrirArchivo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnAbrirArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirArchivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnAbrirArchivo.ForeColor = System.Drawing.Color.White;
            this.btnAbrirArchivo.Location = new System.Drawing.Point(15, 10);
            this.btnAbrirArchivo.Name = "btnAbrirArchivo";
            this.btnAbrirArchivo.Size = new System.Drawing.Size(155, 35);
            this.btnAbrirArchivo.TabIndex = 2;
            this.btnAbrirArchivo.Text = "Abrir Archivo";
            this.btnAbrirArchivo.UseVisualStyleBackColor = false;
            this.btnAbrirArchivo.Click += new System.EventHandler(this.btnAbrirArchivo_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnCopiar.ForeColor = System.Drawing.Color.White;
            this.btnCopiar.Location = new System.Drawing.Point(180, 10);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(140, 35);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "Copiar Texto";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(405, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(140, 35);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmTicketViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Controls.Add(this.rtbTicket);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTicketViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sistema - Visualizador de Comprobante";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.RichTextBox rtbTicket;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnAbrirArchivo;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnAceptar;
    }
}

