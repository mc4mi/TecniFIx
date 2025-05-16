namespace TecniFix
{
    partial class frmDetalleServicioCliente
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
            this.components = new System.ComponentModel.Container();
            this.solicitudBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_TecniFixDataSet = new TecniFix.db_TecniFixDataSet();
            this.solicitudTableAdapter = new TecniFix.db_TecniFixDataSetTableAdapters.SolicitudTableAdapter();
            this.label10 = new System.Windows.Forms.Label();
            this.txtboxCedulaCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_TecniFixDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // solicitudBindingSource
            // 
            this.solicitudBindingSource.DataMember = "Solicitud";
            this.solicitudBindingSource.DataSource = this.db_TecniFixDataSet;
            // 
            // db_TecniFixDataSet
            // 
            this.db_TecniFixDataSet.DataSetName = "db_TecniFixDataSet";
            this.db_TecniFixDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // solicitudTableAdapter
            // 
            this.solicitudTableAdapter.ClearBeforeFill = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(121, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(622, 86);
            this.label10.TabIndex = 2;
            this.label10.Text = "Detalles del Servicio";
            // 
            // txtboxCedulaCliente
            // 
            this.txtboxCedulaCliente.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxCedulaCliente.Location = new System.Drawing.Point(263, 235);
            this.txtboxCedulaCliente.Name = "txtboxCedulaCliente";
            this.txtboxCedulaCliente.Size = new System.Drawing.Size(219, 29);
            this.txtboxCedulaCliente.TabIndex = 74;
            this.txtboxCedulaCliente.TextChanged += new System.EventHandler(this.txtboxCedulaCliente_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(185, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 30);
            this.label7.TabIndex = 73;
            this.label7.Text = "Cédula";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.LightGray;
            this.label12.Location = new System.Drawing.Point(155, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(537, 30);
            this.label12.TabIndex = 75;
            this.label12.Text = "Escribe tu cédula y observa los detalles de tus servicios";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(73, 290);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(715, 230);
            this.dataGridView2.TabIndex = 76;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(48)))), ((int)(((byte)(255)))));
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConsultar.Location = new System.Drawing.Point(503, 227);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(160, 38);
            this.btnConsultar.TabIndex = 77;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click_1);
            // 
            // frmDetalleServicioCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::TecniFix.Properties.Resources.FondoMediano;
            this.ClientSize = new System.Drawing.Size(867, 630);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtboxCedulaCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetalleServicioCliente";
            this.Text = "Detalle Servicio";
            this.Load += new System.EventHandler(this.frmDetalleServicioCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.solicitudBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_TecniFixDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private db_TecniFixDataSet db_TecniFixDataSet;
        private System.Windows.Forms.BindingSource solicitudBindingSource;
        private db_TecniFixDataSetTableAdapters.SolicitudTableAdapter solicitudTableAdapter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtboxCedulaCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnConsultar;
    }
}