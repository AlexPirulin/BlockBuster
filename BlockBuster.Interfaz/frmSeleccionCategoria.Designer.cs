namespace BlockBuster.Interfaz
{
    partial class frmSeleccionCategoria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.btnPeliculas = new System.Windows.Forms.Button();
            this.btnVideojuegos = new System.Windows.Forms.Button();
            this.btnConsolas = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblOperacion);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblOperacion.Location = new System.Drawing.Point(25, 20);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(370, 34);
            this.lblOperacion.TabIndex = 0;
            this.lblOperacion.Text = "Operación: SELECCIÓN";
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(30, 95);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(437, 27);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Seleccione una categoría de artículo:";
            // 
            // btnPeliculas
            // 
            this.btnPeliculas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPeliculas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPeliculas.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnPeliculas.FlatAppearance.BorderSize = 2;
            this.btnPeliculas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeliculas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeliculas.ForeColor = System.Drawing.Color.White;
            this.btnPeliculas.Location = new System.Drawing.Point(50, 150);
            this.btnPeliculas.Name = "btnPeliculas";
            this.btnPeliculas.Size = new System.Drawing.Size(180, 130);
            this.btnPeliculas.TabIndex = 2;
            this.btnPeliculas.Text = "🎬\r\nPelículas";
            this.btnPeliculas.UseVisualStyleBackColor = false;
            this.btnPeliculas.Click += new System.EventHandler(this.btnPeliculas_Click);
            // 
            // btnVideojuegos
            // 
            this.btnVideojuegos.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnVideojuegos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVideojuegos.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnVideojuegos.FlatAppearance.BorderSize = 2;
            this.btnVideojuegos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideojuegos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideojuegos.ForeColor = System.Drawing.Color.White;
            this.btnVideojuegos.Location = new System.Drawing.Point(260, 150);
            this.btnVideojuegos.Name = "btnVideojuegos";
            this.btnVideojuegos.Size = new System.Drawing.Size(180, 130);
            this.btnVideojuegos.TabIndex = 3;
            this.btnVideojuegos.Text = "🎮\r\nVideojuegos";
            this.btnVideojuegos.UseVisualStyleBackColor = false;
            this.btnVideojuegos.Click += new System.EventHandler(this.btnVideojuegos_Click);
            // 
            // btnConsolas
            // 
            this.btnConsolas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnConsolas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsolas.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnConsolas.FlatAppearance.BorderSize = 2;
            this.btnConsolas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsolas.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsolas.ForeColor = System.Drawing.Color.White;
            this.btnConsolas.Location = new System.Drawing.Point(470, 150);
            this.btnConsolas.Name = "btnConsolas";
            this.btnConsolas.Size = new System.Drawing.Size(180, 130);
            this.btnConsolas.TabIndex = 4;
            this.btnConsolas.Text = "🕹️\r\nConsolas";
            this.btnConsolas.UseVisualStyleBackColor = false;
            this.btnConsolas.Click += new System.EventHandler(this.btnConsolas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.DimGray;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(260, 310);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(180, 42);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "← Cancelar / Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblInfoUsuario
            // 
            this.lblInfoUsuario.AutoSize = true;
            this.lblInfoUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.LightCyan;
            this.lblInfoUsuario.Location = new System.Drawing.Point(30, 375);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(66, 17);
            this.lblInfoUsuario.TabIndex = 6;
            this.lblInfoUsuario.Text = "Sesión: -";
            // 
            // frmSeleccionCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(700, 410);
            this.Controls.Add(this.lblInfoUsuario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConsolas);
            this.Controls.Add(this.btnVideojuegos);
            this.Controls.Add(this.btnPeliculas);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BlockBuster - Selección de Categoría";
            this.Load += new System.EventHandler(this.frmSeleccionCategoria_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Button btnPeliculas;
        private System.Windows.Forms.Button btnVideojuegos;
        private System.Windows.Forms.Button btnConsolas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblInfoUsuario;
    }
}
