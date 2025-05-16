using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecniFix
{
    public partial class frmVerificarPreciosAdministrador: Form
    {
        public frmVerificarPreciosAdministrador()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarServicios();
        }
        private void ConfigurarDataGridView()
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.RowHeadersVisible = false;
        }

        private void CargarServicios()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            id_servicio AS [ID Servicio],
                            nombre_servicio AS [Nombre del Servicio],
                            descripcion AS [Descripción],
                            precio_base AS [Precio Base]
                        FROM Servicio
                        ORDER BY id_servicio";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
