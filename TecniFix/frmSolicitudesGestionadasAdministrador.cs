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
using Microsoft.VisualBasic;

namespace TecniFix
{
    public partial class frmSolicitudesGestionadasAdministrador: Form
    {
        public frmSolicitudesGestionadasAdministrador()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarSolicitudesAprobadas();
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

            dataGridView2.CellDoubleClick += dataGridView2_CellContentClick;
        }

        private void CargarSolicitudesAprobadas()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    sol.id_solicitud AS [ID Solicitud],
                    sol.id_tecnico AS [ID Técnico],
                    cli.nombre + ' ' + cli.apellido AS [Cliente],
                    comp.marca + ' ' + comp.modelo AS [Computador],
                    dom.direccion AS [Dirección],
                    CONVERT(varchar(10), dom.fecha, 120) AS [Fecha],
                    CONVERT(varchar(5), dom.hora, 108) AS [Hora],
                    sol.estado AS [Estado]
                FROM Solicitud sol
                INNER JOIN Cliente cli ON sol.id_cliente = cli.id_cliente
                INNER JOIN Computador comp ON sol.id_computador = comp.id_computador
                LEFT JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
                WHERE sol.estado = 'Aprobado'
                ORDER BY sol.id_solicitud";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dataGridView2.DataSource = dt;

                    // No se necesita formato adicional en columnas Fecha y Hora, ya son string
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las solicitudes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           

        private void frmSolicitudesGestionadasAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            int idSolicitud = Convert.ToInt32(fila.Cells["ID Solicitud"].Value);
            string estado = fila.Cells["Estado"].Value.ToString();
            object tecnicoActual = fila.Cells["ID Técnico"].Value;

            if (estado != "Aprobado")
            {
                MessageBox.Show("Solo puede asignar técnico a solicitudes aprobadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tecnicoActual != DBNull.Value && tecnicoActual.ToString() != "")
            {
                MessageBox.Show("Esta solicitud ya tiene un técnico asignado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese el ID del técnico que desea asignar a la solicitud {idSolicitud}:",
                "Asignar Técnico");

            if (int.TryParse(input, out int idTecnico))
            {
                AsignarTecnico(idSolicitud, idTecnico);
            }
            else
            {
                MessageBox.Show("ID de técnico inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AsignarTecnico(int idSolicitud, int idTecnico)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE Solicitud SET id_tecnico = @id_tecnico WHERE id_solicitud = @id_solicitud";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_tecnico", idTecnico);
                        cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Técnico asignado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarSolicitudesAprobadas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo asignar el técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar técnico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

