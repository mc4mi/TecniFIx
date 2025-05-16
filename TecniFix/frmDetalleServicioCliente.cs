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
using TecniFix.db_TecniFixDataSetTableAdapters;

namespace TecniFix
{
    public partial class frmDetalleServicioCliente : Form
    {
        public frmDetalleServicioCliente()
        {
            InitializeComponent();
        }

        private void frmDetalleServicioCliente_Load(object sender, EventArgs e)
        {
            // Configuración visual del DataGridView
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.RowHeadersVisible = false;
        }


     

        private void CargarDetalleServiciosCliente(string cedula)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            c.nombre AS [Nombre del Cliente],
                            comp.marca AS [Nombre del Computador],
                            comp.modelo AS [Modelo],
                            s.nombre_servicio AS [Servicio Solicitado],
                            dom.fecha AS [Fecha],
                            dom.hora AS [Hora],
                            sol.estado AS [Estado de la Solicitud]
                        FROM Cliente c
                        INNER JOIN Computador comp ON c.id_cliente = comp.id_cliente
                        INNER JOIN Solicitud sol ON sol.id_computador = comp.id_computador AND sol.id_cliente = c.id_cliente
                        INNER JOIN SolicitudServicio ss ON ss.id_solicitud = sol.id_solicitud
                        INNER JOIN Servicio s ON s.id_servicio = ss.id_servicio
                        LEFT JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
                        WHERE c.id_cliente = @Cedula";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros para la cédula ingresada.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView2.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si necesitas manejar clics en celdas, lo haces aquí.
        }

        private void txtboxCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            // Este evento puede usarse para autocompletar o validar en tiempo real si lo deseas.
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            string cedula = txtboxCedulaCliente.Text.Trim();

            // Validación simple de cédula ecuatoriana: 10 dígitos numéricos
            if (cedula.Length == 10 && cedula.All(char.IsDigit))
            {
                CargarDetalleServiciosCliente(cedula);
            }
            else
            {
                MessageBox.Show("Por favor ingrese una cédula válida de 10 dígitos numéricos.",
                    "Cédula inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

