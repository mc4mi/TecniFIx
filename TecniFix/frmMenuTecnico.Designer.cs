namespace TecniFix
{
    partial class frmMenuTecnico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuTecnico));
            this.btnInicio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlInicio = new System.Windows.Forms.Panel();
            this.picBienvenidaTecnico = new System.Windows.Forms.PictureBox();
            this.btnGestionServicios = new System.Windows.Forms.Button();
            this.btnProgramacionServicios = new System.Windows.Forms.Button();
            this.btnDetalleServicio = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBienvenidaTecnico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(134)))));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInicio.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(0, 135);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(308, 43);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.btnDetalleServicio);
            this.panel1.Controls.Add(this.btnProgramacionServicios);
            this.panel1.Controls.Add(this.btnGestionServicios);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 669);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::TecniFix.Properties.Resources.LogoMediano;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 135);
            this.panel2.TabIndex = 0;
            // 
            // pnlInicio
            // 
            this.pnlInicio.Controls.Add(this.picBienvenidaTecnico);
            this.pnlInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInicio.Location = new System.Drawing.Point(308, 0);
            this.pnlInicio.Name = "pnlInicio";
            this.pnlInicio.Size = new System.Drawing.Size(883, 669);
            this.pnlInicio.TabIndex = 8;
            // 
            // picBienvenidaTecnico
            // 
            this.picBienvenidaTecnico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBienvenidaTecnico.Image = global::TecniFix.Properties.Resources.bienvenidaTecnico;
            this.picBienvenidaTecnico.Location = new System.Drawing.Point(0, 0);
            this.picBienvenidaTecnico.Name = "picBienvenidaTecnico";
            this.picBienvenidaTecnico.Size = new System.Drawing.Size(883, 669);
            this.picBienvenidaTecnico.TabIndex = 0;
            this.picBienvenidaTecnico.TabStop = false;
            this.picBienvenidaTecnico.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGestionServicios
            // 
            this.btnGestionServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(134)))));
            this.btnGestionServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionServicios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGestionServicios.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionServicios.ForeColor = System.Drawing.Color.White;
            this.btnGestionServicios.Location = new System.Drawing.Point(0, 178);
            this.btnGestionServicios.Name = "btnGestionServicios";
            this.btnGestionServicios.Size = new System.Drawing.Size(308, 43);
            this.btnGestionServicios.TabIndex = 2;
            this.btnGestionServicios.Text = "Gestión Servicios";
            this.btnGestionServicios.UseVisualStyleBackColor = false;
            this.btnGestionServicios.Click += new System.EventHandler(this.btnGestionServicios_Click);
            // 
            // btnProgramacionServicios
            // 
            this.btnProgramacionServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(134)))));
            this.btnProgramacionServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProgramacionServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProgramacionServicios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProgramacionServicios.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramacionServicios.ForeColor = System.Drawing.Color.White;
            this.btnProgramacionServicios.Location = new System.Drawing.Point(0, 221);
            this.btnProgramacionServicios.Name = "btnProgramacionServicios";
            this.btnProgramacionServicios.Size = new System.Drawing.Size(308, 43);
            this.btnProgramacionServicios.TabIndex = 3;
            this.btnProgramacionServicios.Text = "Programación Servicios";
            this.btnProgramacionServicios.UseVisualStyleBackColor = false;
            this.btnProgramacionServicios.Click += new System.EventHandler(this.btnProgramacionServicios_Click);
            // 
            // btnDetalleServicio
            // 
            this.btnDetalleServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(134)))));
            this.btnDetalleServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalleServicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDetalleServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetalleServicio.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleServicio.ForeColor = System.Drawing.Color.White;
            this.btnDetalleServicio.Location = new System.Drawing.Point(0, 264);
            this.btnDetalleServicio.Name = "btnDetalleServicio";
            this.btnDetalleServicio.Size = new System.Drawing.Size(308, 43);
            this.btnDetalleServicio.TabIndex = 4;
            this.btnDetalleServicio.Text = "Detalles Servicios";
            this.btnDetalleServicio.UseVisualStyleBackColor = false;
            this.btnDetalleServicio.Click += new System.EventHandler(this.btnDetalleServicio_Click);
            // 
            // frmMenuTecnico
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1191, 669);
            this.Controls.Add(this.pnlInicio);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuTecnico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeniFix Técnico";
            this.panel1.ResumeLayout(false);
            this.pnlInicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBienvenidaTecnico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInicio;
        private System.Windows.Forms.PictureBox picBienvenidaTecnico;
        private System.Windows.Forms.Button btnDetalleServicio;
        private System.Windows.Forms.Button btnProgramacionServicios;
        private System.Windows.Forms.Button btnGestionServicios;
    }
}