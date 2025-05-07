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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_TecniFixDataSet = new TecniFix.db_TecniFixDataSet();
            this.solicitudBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solicitudTableAdapter = new TecniFix.db_TecniFixDataSetTableAdapters.SolicitudTableAdapter();
            this.idsolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtecnicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcomputadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechasolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiererepuestoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_TecniFixDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idsolicitudDataGridViewTextBoxColumn,
            this.idclienteDataGridViewTextBoxColumn,
            this.idtecnicoDataGridViewTextBoxColumn,
            this.idcomputadorDataGridViewTextBoxColumn,
            this.fechasolicitudDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.requiererepuestoDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.solicitudBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(64, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 222);
            this.dataGridView1.TabIndex = 0;
            // 
            // db_TecniFixDataSet
            // 
            this.db_TecniFixDataSet.DataSetName = "db_TecniFixDataSet";
            this.db_TecniFixDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // solicitudBindingSource
            // 
            this.solicitudBindingSource.DataMember = "Solicitud";
            this.solicitudBindingSource.DataSource = this.db_TecniFixDataSet;
            // 
            // solicitudTableAdapter
            // 
            this.solicitudTableAdapter.ClearBeforeFill = true;
            // 
            // idsolicitudDataGridViewTextBoxColumn
            // 
            this.idsolicitudDataGridViewTextBoxColumn.DataPropertyName = "id_solicitud";
            this.idsolicitudDataGridViewTextBoxColumn.HeaderText = "id_solicitud";
            this.idsolicitudDataGridViewTextBoxColumn.Name = "idsolicitudDataGridViewTextBoxColumn";
            this.idsolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idclienteDataGridViewTextBoxColumn
            // 
            this.idclienteDataGridViewTextBoxColumn.DataPropertyName = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.HeaderText = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.Name = "idclienteDataGridViewTextBoxColumn";
            // 
            // idtecnicoDataGridViewTextBoxColumn
            // 
            this.idtecnicoDataGridViewTextBoxColumn.DataPropertyName = "id_tecnico";
            this.idtecnicoDataGridViewTextBoxColumn.HeaderText = "id_tecnico";
            this.idtecnicoDataGridViewTextBoxColumn.Name = "idtecnicoDataGridViewTextBoxColumn";
            // 
            // idcomputadorDataGridViewTextBoxColumn
            // 
            this.idcomputadorDataGridViewTextBoxColumn.DataPropertyName = "id_computador";
            this.idcomputadorDataGridViewTextBoxColumn.HeaderText = "id_computador";
            this.idcomputadorDataGridViewTextBoxColumn.Name = "idcomputadorDataGridViewTextBoxColumn";
            // 
            // fechasolicitudDataGridViewTextBoxColumn
            // 
            this.fechasolicitudDataGridViewTextBoxColumn.DataPropertyName = "fecha_solicitud";
            this.fechasolicitudDataGridViewTextBoxColumn.HeaderText = "fecha_solicitud";
            this.fechasolicitudDataGridViewTextBoxColumn.Name = "fechasolicitudDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // requiererepuestoDataGridViewCheckBoxColumn
            // 
            this.requiererepuestoDataGridViewCheckBoxColumn.DataPropertyName = "requiere_repuesto";
            this.requiererepuestoDataGridViewCheckBoxColumn.HeaderText = "requiere_repuesto";
            this.requiererepuestoDataGridViewCheckBoxColumn.Name = "requiererepuestoDataGridViewCheckBoxColumn";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(124, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(622, 86);
            this.label10.TabIndex = 2;
            this.label10.Text = "Detalles del Servicio";
            // 
            // frmDetalleServicioCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::TecniFix.Properties.Resources.FondoMediano;
            this.ClientSize = new System.Drawing.Size(867, 630);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetalleServicioCliente";
            this.Text = "Detalle Servicio";
            this.Load += new System.EventHandler(this.frmDetalleServicioCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_TecniFixDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private db_TecniFixDataSet db_TecniFixDataSet;
        private System.Windows.Forms.BindingSource solicitudBindingSource;
        private db_TecniFixDataSetTableAdapters.SolicitudTableAdapter solicitudTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtecnicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomputadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechasolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn requiererepuestoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label label10;
    }
}