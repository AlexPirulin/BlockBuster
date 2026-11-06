namespace BlockBuster.Interfaz
{
    partial class frmRentas
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
            this.lblOperacionCategoria = new System.Windows.Forms.Label();
            this.lblUsuarioSesion = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblMensajeContenido = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(850, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblOperacionCategoria
            // 
            this.lblOperacionCategoria.AutoSize = true;
            this.lblOperacionCategoria.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacionCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblOperacionCategoria.Location = new System.Drawing.Point(20, 15);
            this.lblOperacionCategoria.Name = "lblOperacionCategoria";
            this.lblOperacionCategoria.Size = new System.Drawing.Size(434, 32);
            this.lblOperacionCategoria.TabIndex = 0;
            this.lblOperacionCategoria.Text = "MÓDULO DE RENTA: PELÍCULAS";
            // 
            // lblUsuarioSesion
            // 
            this.lblUsuarioSesion.AutoSize = true;
            this.lblUsuarioSesion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSesion.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioSesion.Location = new System.Drawing.Point(23, 49);
            this.lblUsuarioSesion.Name = "lblUsuarioSesion";
            this.lblUsuarioSesion.Size = new System.Drawing.Size(66, 17);
            this.lblUsuarioSesion.TabIndex = 1;
            this.lblUsuarioSesion.Text = "Usuario: -";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(710, 430);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 38);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblMensajeContenido
            // 
            this.lblMensajeContenido.AutoSize = true;
            this.lblMensajeContenido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeContenido.ForeColor = System.Drawing.Color.White;
            this.lblMensajeContenido.Location = new System.Drawing.Point(22, 100);
            this.lblMensajeContenido.Name = "lblMensajeContenido";
            this.lblMensajeContenido.Size = new System.Drawing.Size(534, 23);
            this.lblMensajeContenido.TabIndex = 2;
            this.lblMensajeContenido.Text = "Gestión de Rentas para los artículos de esta categoría.";
            // 
            // frmRentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(this.lblMensajeContenido);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmRentas";
            this.Text = "BlockBuster - Rentas";
            this.Load += new System.EventHandler(this.frmRentas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblOperacionCategoria;
        private System.Windows.Forms.Label lblUsuarioSesion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblMensajeContenido;
    }
}
