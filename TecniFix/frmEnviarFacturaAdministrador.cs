using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecniFix
{
    public partial class frmEnviarFacturaAdministrador: Form
    {
        public frmEnviarFacturaAdministrador()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarSolicitudes();
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
                            cli.id_cliente AS [Cédula Cliente],
                            cli.nombre + ' ' + cli.apellido AS [Nombre Cliente],
                            cli.correo AS [Correo],
                            comp.marca + ' ' + comp.modelo AS [Computador],
                            dom.fecha AS [Fecha],
                            dom.hora AS [Hora],
                            sol.estado AS [Estado]
                        FROM Solicitud sol
                        INNER JOIN Cliente cli ON sol.id_cliente = cli.id_cliente
                        INNER JOIN Computador comp ON sol.id_computador = comp.id_computador
                        INNER JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
                        WHERE sol.estado = 'Aprobado' AND sol.id_tecnico IS NOT NULL
                        ORDER BY sol.id_solicitud";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar solicitudes: " + ex.Message);
            }
        }
        


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            int idSolicitud = Convert.ToInt32(fila.Cells["ID Solicitud"].Value);

            try
            {
                var facturaData = ObtenerDatosFactura(idSolicitud);

                if (string.IsNullOrWhiteSpace(facturaData.CorreoCliente))
                {
                    MessageBox.Show("La solicitud no tiene un correo válido para enviar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generar contenido de factura
                string contenidoFactura = GenerarContenidoFactura(facturaData);

                // Ruta para guardar la factura
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    $"Factura_{facturaData.IdSolicitud}.txt");

                File.WriteAllText(rutaArchivo, contenidoFactura, Encoding.UTF8);

                // Enviar correo con factura adjunta
                EnviarCorreoConFactura(facturaData.CorreoCliente, "Factura de Servicio TecniFix", contenidoFactura, rutaArchivo);

                MessageBox.Show("Factura enviada y archivo descargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private dynamic ObtenerDatosFactura(int idSolicitud)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                sol.id_solicitud,
                cli.nombre AS NombreCliente,
                cli.apellido AS ApellidoCliente,
                cli.correo,                      
                cli.id_cliente,                  
                comp.marca,
                comp.modelo,
                sol.descripcion_problema,
                sol.estado,
                tec.nombre AS NombreTecnico,
                dom.direccion,
                dom.fecha,     -- Ahora es string
                dom.hora       -- string también
            FROM Solicitud sol
            INNER JOIN Cliente cli ON sol.id_cliente = cli.id_cliente
            INNER JOIN Computador comp ON sol.id_computador = comp.id_computador
            INNER JOIN Tecnico tec ON sol.id_tecnico = tec.id_tecnico
            LEFT JOIN Domicilio dom ON dom.id_solicitud = sol.id_solicitud
            WHERE sol.id_solicitud = @id_solicitud";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new
                        {
                            IdSolicitud = reader["id_solicitud"],
                            NombreCliente = reader["NombreCliente"] == DBNull.Value ? "" : reader["NombreCliente"].ToString(),
                            ApellidoCliente = reader["ApellidoCliente"] == DBNull.Value ? "" : reader["ApellidoCliente"].ToString(),
                            CorreoCliente = reader["correo"] == DBNull.Value ? "" : reader["correo"].ToString(),
                            IdCliente = reader["id_cliente"] == DBNull.Value ? "" : reader["id_cliente"].ToString(),
                            MarcaComputador = reader["marca"] == DBNull.Value ? "" : reader["marca"].ToString(),
                            ModeloComputador = reader["modelo"] == DBNull.Value ? "" : reader["modelo"].ToString(),
                            DescripcionProblema = reader["descripcion_problema"] == DBNull.Value ? "" : reader["descripcion_problema"].ToString(),
                            Estado = reader["estado"] == DBNull.Value ? "" : reader["estado"].ToString(),
                            NombreTecnico = reader["NombreTecnico"] == DBNull.Value ? "" : reader["NombreTecnico"].ToString(),
                            Direccion = reader["direccion"] == DBNull.Value ? "" : reader["direccion"].ToString(),
                            Fecha = reader["fecha"] == DBNull.Value ? "" : reader["fecha"].ToString(),   // ahora string
                            Hora = reader["hora"] == DBNull.Value ? "" : reader["hora"].ToString()
                        };
                    }
                    else
                    {
                        throw new Exception("No se encontró la solicitud para generar la factura.");
                    }
                }
            }
        }



        private string GenerarContenidoFactura(dynamic facturaData)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Factura TecniFix");
            sb.AppendLine("----------------------------");
            sb.AppendLine($"ID Solicitud: {facturaData.IdSolicitud}");
            sb.AppendLine($"Cliente: {facturaData.NombreCliente} {facturaData.ApellidoCliente}");
            sb.AppendLine($"Cédula Cliente: {facturaData.IdCliente}");
            sb.AppendLine($"Correo: {facturaData.CorreoCliente}");
            sb.AppendLine($"Computador: {facturaData.MarcaComputador} {facturaData.ModeloComputador}");
            sb.AppendLine($"Descripción del problema: {facturaData.DescripcionProblema}");
            sb.AppendLine($"Estado: {facturaData.Estado}");
            sb.AppendLine($"Técnico asignado: {facturaData.NombreTecnico}");
            sb.AppendLine($"Dirección: {facturaData.Direccion}");
            sb.AppendLine($"Fecha: {(!string.IsNullOrWhiteSpace(facturaData.Fecha) ? facturaData.Fecha : "No asignada")}");
            sb.AppendLine($"Hora: {facturaData.Hora}");
            sb.AppendLine("----------------------------");
            sb.AppendLine("Gracias por confiar en TecniFix.");

            return sb.ToString();
        }

        private void EnviarCorreoConFactura(string correoDestino, string asunto, string cuerpo, string rutaAdjunto)
        {
            // Simulación de envío de correo sin conexión real
            MessageBox.Show($"Simulación: Se enviaría un correo a {correoDestino} con asunto '{asunto}'.", "Simulación envío correo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Código real comentado para evitar error SMTP
            /*
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("tuemail@gmail.com", "tucontraseña"), // Cambia por tu email y contraseña
                EnableSsl = true
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("tuemail@gmail.com"),
                Subject = asunto,
                Body = cuerpo
            };
            mail.To.Add(correoDestino);

            if (File.Exists(rutaAdjunto))
            {
                mail.Attachments.Add(new Attachment(rutaAdjunto));
            }

            smtp.Send(mail);
            */
        }
    }
}


