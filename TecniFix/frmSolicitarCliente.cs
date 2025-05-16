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
    public partial class frmSolicitadCliente : Form
    {

        private int id_servicio;


        // Constructor del formulario que recibe la cédula como parámetro
        public frmSolicitadCliente()
        {
            InitializeComponent();     // Inicializa los componentes del formulario

        }

        private void frmSolicitadCliente_Load(object sender, EventArgs e)

        {
            cmbServicio.SelectedIndexChanged += cmbServicio_SelectedIndexChanged;
            this.Load += frmSolicitadCliente_Load;
            CargarRepuesto();
            CargarServicios();

        }
        private void CargarDatosCliente(string cedula)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT nombre, apellido, correo, telefono, celular, direccion FROM Cliente WHERE id_cliente = @id", conn);
                    cmd.Parameters.AddWithValue("@id", cedula);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtboxNombre.Text = reader["nombre"].ToString();
                            txtboxApellido.Text = reader["apellido"].ToString();
                            txtboxTelefono.Text = reader["telefono"].ToString();
                            txtboxCelular.Text = reader["celular"].ToString();
                            txtboxDireccion.Text = reader["direccion"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún cliente con esa cédula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LimpiarCamposCliente();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComputadores(string cedula)
        {
            cmbComputador.Items.Clear();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id_computador FROM Computador WHERE id_cliente = @id", conn);
                cmd.Parameters.AddWithValue("@id", cedula);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbComputador.Items.Add(reader["id_computador"].ToString());
                    }
                }
            }

            if (cmbComputador.Items.Count > 0)
                cmbComputador.SelectedIndex = 0;
        }

        private void CargarServicios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_servicio", typeof(int));
            dt.Columns.Add("nombre_servicio", typeof(string));

            dt.Rows.Add(1, "Mantenimiento");
            dt.Rows.Add(2, "Reparación");
            dt.Rows.Add(3, "Formateo e instalación de programas");

            cmbServicio.DataSource = dt;
            cmbServicio.DisplayMember = "nombre_servicio";
            cmbServicio.ValueMember = "id_servicio";
        }



        // Método para cargar las opciones de requiere repuesto
        private void CargarRepuesto()
        {
            cmbRepuesto.Items.Clear();
            cmbRepuesto.Items.Add("Sí");  // Corresponde a 1 en la BD
            cmbRepuesto.Items.Add("No");  // Corresponde a 2 en la BD
            cmbRepuesto.SelectedIndex = 1; // Por defecto "No"
        }


        private void LimpiarCamposCliente()
        {
            txtboxNombre.Text = "";
            txtboxApellido.Text = "";
            txtboxTelefono.Text = "";
            txtboxCelular.Text = "";
            txtboxDireccion.Text = "";
            cmbComputador.Items.Clear();
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Info Cliente
            string cedula = txtboxCedulaCliente.Text.Trim();
            string nombre = txtboxNombre.Text.Trim();
            string apellido = txtboxApellido.Text.Trim();
            string telefono = txtboxTelefono.Text.Trim();
            string celular = txtboxCelular.Text.Trim();
            string direccion = txtboxDireccion.Text.Trim();

            int servicioIdSeleccionado = id_servicio;
            string idComputador = cmbComputador.SelectedItem?.ToString();
            int requiereRepuesto = (cmbRepuesto.SelectedItem?.ToString() == "Sí") ? 1 : 2;
            string descripcionProblema = txtboxDetalleServicio.Text.Trim();

            string fechaInput = txtboxFecha.Text.Trim();  // formato requerido: yyyy-MM-dd
            string horaInput = txtboxHora.Text.Trim();    // formato requerido: HH:mm

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido)
                || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(celular)
                || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(idComputador)
                || string.IsNullOrEmpty(descripcionProblema) || string.IsNullOrEmpty(fechaInput) || string.IsNullOrEmpty(horaInput))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato de fecha (yyyy-MM-dd)
            if (!DateTime.TryParseExact(fechaInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Formato de fecha inválido. Use yyyy-MM-dd (Ejemplo: 2025-05-16).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar formato de hora (HH:mm)
            if (!DateTime.TryParseExact(horaInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Formato de hora inválido. Use HH:mm (Ejemplo: 14:30).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Validar si la combinación de fecha y hora ya está ocupada
                    SqlCommand validarHorario = new SqlCommand("SELECT COUNT(*) FROM Domicilio WHERE fecha = @fecha AND hora = @hora", conn);
                    validarHorario.Parameters.AddWithValue("@fecha", fechaInput);
                    validarHorario.Parameters.AddWithValue("@hora", horaInput);
                    int existe = (int)validarHorario.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("La fecha y hora seleccionadas ya están ocupadas. Por favor elija otra.", "Horario no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Actualizar cliente
                    SqlCommand updateCliente = new SqlCommand(
                        "UPDATE Cliente SET nombre = @nombre, apellido = @apellido, telefono = @telefono, celular = @celular, direccion = @direccion WHERE id_cliente = @id", conn);

                    updateCliente.Parameters.AddWithValue("@nombre", nombre);
                    updateCliente.Parameters.AddWithValue("@apellido", apellido);
                    updateCliente.Parameters.AddWithValue("@telefono", telefono);
                    updateCliente.Parameters.AddWithValue("@celular", celular);
                    updateCliente.Parameters.AddWithValue("@direccion", direccion);
                    updateCliente.Parameters.AddWithValue("@id", cedula);
                    updateCliente.ExecuteNonQuery();

                    // Obtener nuevo ID de solicitud
                    SqlCommand getNextSolicitudId = new SqlCommand("SELECT ISNULL(MAX(id_solicitud), 0) + 1 FROM Solicitud", conn);
                    int id_solicitud = (int)getNextSolicitudId.ExecuteScalar();

                    // Insertar solicitud sin fecha ni hora
                    SqlCommand insertSolicitud = new SqlCommand(
                        "INSERT INTO Solicitud (id_solicitud, id_cliente, id_tecnico, id_computador, estado, requiere_repuesto, descripcion_extra, descripcion_problema) " +
                        "VALUES (@id_solicitud, @id_cliente, NULL, @id_computador, @estado, @requiere_repuesto, @descripcion_extra, @descripcion_problema)", conn);

                    insertSolicitud.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    insertSolicitud.Parameters.AddWithValue("@id_cliente", cedula);
                    insertSolicitud.Parameters.AddWithValue("@id_computador", idComputador);
                    insertSolicitud.Parameters.AddWithValue("@estado", "Pendiente");
                    insertSolicitud.Parameters.AddWithValue("@requiere_repuesto", requiereRepuesto);
                    insertSolicitud.Parameters.AddWithValue("@descripcion_extra", DBNull.Value);
                    insertSolicitud.Parameters.AddWithValue("@descripcion_problema", descripcionProblema);
                    insertSolicitud.ExecuteNonQuery();

                    // Insertar servicio asociado
                    SqlCommand insertSolicitudServicio = new SqlCommand(
                        "INSERT INTO SolicitudServicio (id_solicitud, id_servicio) VALUES (@id_solicitud, @id_servicio)", conn);
                    insertSolicitudServicio.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    insertSolicitudServicio.Parameters.AddWithValue("@id_servicio", servicioIdSeleccionado);
                    insertSolicitudServicio.ExecuteNonQuery();

                    // Obtener nuevo ID para domicilio
                    SqlCommand getNextDomicilioId = new SqlCommand("SELECT ISNULL(MAX(id_domicilio), 0) + 1 FROM Domicilio", conn);
                    int id_domicilio = (int)getNextDomicilioId.ExecuteScalar();

                    // Insertar domicilio
                    SqlCommand insertDomicilio = new SqlCommand(
                        "INSERT INTO Domicilio (id_domicilio, id_solicitud, direccion, fecha, hora) VALUES (@id_domicilio, @id_solicitud, @direccion, @fecha, @hora)", conn);

                    insertDomicilio.Parameters.AddWithValue("@id_domicilio", id_domicilio);
                    insertDomicilio.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    insertDomicilio.Parameters.AddWithValue("@direccion", direccion);
                    insertDomicilio.Parameters.AddWithValue("@fecha", fechaInput);
                    insertDomicilio.Parameters.AddWithValue("@hora", horaInput);
                    insertDomicilio.ExecuteNonQuery();
                }

                MessageBox.Show("Solicitud registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtboxCedulaCliente_TextChanged(object sender, EventArgs e)
        {
            string cedula = txtboxCedulaCliente.Text.Trim();

            // Verificar si hay exactamente 8 dígitos numéricos
            if (cedula.Length == 10 && cedula.All(char.IsDigit))
            {
                CargarDatosCliente(cedula);
                CargarComputadores(cedula);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            string seleccionado = cmbServicio.Text;

            if (seleccionado == "Mantenimiento")
                id_servicio = 1;
            else if (seleccionado == "Reparación")
                id_servicio = 2;
            else if (seleccionado == "Formateo e instalación de programas")
                id_servicio = 3;
            else
                id_servicio = 0; // Por si acaso no coincide

        }

        private void frmSolicitadCliente_Load_1(object sender, EventArgs e)
        {

        }
    }
}

    

