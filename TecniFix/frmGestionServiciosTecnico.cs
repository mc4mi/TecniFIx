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
    public partial class frmGestionServiciosTecnico: Form
    {
        public frmGestionServiciosTecnico()
        {
            InitializeComponent();
        }

        private void frmGestionServiciosTecnico_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarSolicitudes();
        }
        //Método para configurar el grid
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

            dataGridView2.CellDoubleClick += dataGridView2_CellContentClick; // Evento para cambiar estado
        }

        private void CargarSolicitudes()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            sol.id_solicitud AS [ID Solicitud],
                            comp.marca + ' ' + comp.modelo AS [Computador],
                            dom.fecha AS [Fecha],
                            dom.hora AS [Hora],
                            CASE sol.requiere_repuesto WHEN 1 THEN 'Sí' ELSE 'No' END AS [Requiere Repuesto],
                            sol.estado AS [Estado]
                        FROM Solicitud sol
                        INNER JOIN Computador comp ON sol.id_computador = comp.id_computador
                        LEFT JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
                        ORDER BY sol.id_solicitud";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar solicitudes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que se haya clickeado en una fila válida
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            int idSolicitud = Convert.ToInt32(fila.Cells["ID Solicitud"].Value);
            string estadoActual = fila.Cells["Estado"].Value.ToString();

            if (estadoActual == "Aprobado")
            {
                MessageBox.Show("Esta solicitud ya está aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show($"¿Desea cambiar el estado de la solicitud {idSolicitud} a 'Aprobado'?",
                "Confirmar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                CambiarEstadoSolicitud(idSolicitud, "Aprobado");
            }
        }

        private void CambiarEstadoSolicitud(int idSolicitud, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string updateQuery = "UPDATE Solicitud SET estado = @estado WHERE id_solicitud = @id_solicitud";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Estado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarSolicitudes(); // Recargar para reflejar cambio
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la solicitud para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

