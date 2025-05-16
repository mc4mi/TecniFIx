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
    public partial class frmDetallesServicioTecnico: Form
    {
        public frmDetallesServicioTecnico()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDetallesServicios();
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
        private void CargarDetallesServicios()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            sol.id_solicitud AS [ID Solicitud],
                            cli.nombre + ' ' + cli.apellido AS [Cliente],
                            comp.marca AS [Marca],
                            comp.modelo AS [Modelo],
                            comp.ram AS [RAM],
                            comp.procesador AS [Procesador],
                            comp.almacenamiento AS [Almacenamiento],
                            s.nombre_servicio AS [Tipo de Servicio],
                            sol.descripcion_problema AS [Descripción del Problema],
                            dom.fecha AS [Fecha Visita],
                            dom.hora AS [Hora Visita],
                            CASE sol.requiere_repuesto 
                                WHEN 1 THEN 'Sí' 
                                ELSE 'No' 
                            END AS [Requiere Repuesto]
                        FROM Solicitud sol
                        INNER JOIN Cliente cli ON cli.id_cliente = sol.id_cliente
                        INNER JOIN Computador comp ON comp.id_computador = sol.id_computador
                        INNER JOIN SolicitudServicio ss ON ss.id_solicitud = sol.id_solicitud
                        INNER JOIN Servicio s ON s.id_servicio = ss.id_servicio
                        INNER JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
                        ORDER BY sol.id_solicitud DESC";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles del servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
