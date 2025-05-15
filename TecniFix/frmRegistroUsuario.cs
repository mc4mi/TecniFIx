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
    public partial class frmRegistroUsuario: Form
    {
        public frmRegistroUsuario()
        {
            InitializeComponent();
            cmbTipoUsuario.Items.AddRange(new string[] { "Cliente", "Técnico", "Administrador" });
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            // Obtener los valores de los campos de texto
            // Obtener los valores del formulario
            string nombre = txtboxNombre.Text.Trim();
            string apellido = txtboxApellido.Text.Trim();
            string correo = txtboxCorreo.Text.Trim();
            string contraseña = txtboxContraseña.Text.Trim();
            string telefono = txtboxTelefono.Text.Trim();
            string celular = txtboxCelular.Text.Trim();
            string idUsuario = txtboxCedula.Text.Trim(); // cédula ahora usada como ID
            string codigo = txtboxCodigo.Text.Trim();
            string tipoUsuario = cmbTipoUsuario.SelectedItem?.ToString();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(celular) ||
                string.IsNullOrWhiteSpace(idUsuario))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                frmInicio volverInicio = new frmInicio();
                volverInicio.Show();
                this.Close();
                return;
            }

            // Validar que el correo tenga un formato válido
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la contraseña tenga al menos 8 caracteres
            if (contraseña.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el teléfono y celular contengan solo dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d+$") || !System.Text.RegularExpressions.Regex.IsMatch(celular, @"^\d+$"))
            {
                MessageBox.Show("El teléfono y el celular deben contener solo dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cédula contenga solo dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(idUsuario, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe contener solo dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cédula tenga 10 dígitos
            if (idUsuario.Length != 10)
            {
                MessageBox.Show("La cédula debe tener 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el tipo de usuario esté seleccionado
            if (string.IsNullOrWhiteSpace(tipoUsuario))
            {
                MessageBox.Show("Debe seleccionar un tipo de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el tipo de usuario sea uno de los permitidos
            if (tipoUsuario != "Cliente" && tipoUsuario != "Técnico" && tipoUsuario != "Administrador")
            {
                MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el código sea obligatorio solo para Técnico y Administrador
            if ((tipoUsuario == "Técnico" || tipoUsuario == "Administrador") && string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El campo código es obligatorio para técnicos y administradores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar los datos en la base de datos
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string verificarQuery = "";
                    string insertQuery = "";
                    SqlCommand cmd;

                    if (tipoUsuario == "Cliente")
                    {
                        verificarQuery = "SELECT COUNT(*) FROM Cliente WHERE correo = @correo OR id_cliente = @id";
                        cmd = new SqlCommand(verificarQuery, conn);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        int existe = (int)cmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un cliente registrado con este correo o cédula.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        insertQuery = "INSERT INTO Cliente (id_cliente, nombre, apellido, correo, contrasena, telefono, celular) " +
                                      "VALUES (@id, @nombre, @apellido, @correo, @contrasena, @telefono, @celular)";
                    }
                    else if (tipoUsuario == "Técnico")
                    {
                        verificarQuery = "SELECT COUNT(*) FROM Tecnico WHERE correo = @correo OR id_tecnico = @id";
                        cmd = new SqlCommand(verificarQuery, conn);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        int existe = (int)cmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un técnico registrado con este correo o cédula.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        insertQuery = "INSERT INTO Tecnico (id_tecnico, nombre, apellido, correo, contrasena, telefono, celular, codigo) " +
                                      "VALUES (@id, @nombre, @apellido, @correo, @contrasena, @telefono, @celular, @codigo)";
                    }
                    else if (tipoUsuario == "Administrador")
                    {
                        verificarQuery = "SELECT COUNT(*) FROM Administrador WHERE correo = @correo OR id_admin = @id";
                        cmd = new SqlCommand(verificarQuery, conn);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        int existe = (int)cmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un administrador registrado con este correo o cédula.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        insertQuery = "INSERT INTO Administrador (id_admin, nombre, apellido, correo, contrasena, telefono, celular, codigo) " +
                                      "VALUES (@id, @nombre, @apellido, @correo, @contrasena, @telefono, @celular, @codigo)";
                    }

                    // Ejecutar el INSERT
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@celular", celular);
                    if (tipoUsuario != "Cliente")
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                    }

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show($"Registro exitoso como {tipoUsuario}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Función de devolver al inicio para iniciar sesión después de guardar los datos
            frmInicio inicioFormFinal = new frmInicio();
            inicioFormFinal.Show();
            this.Close();
     
        }



        private void txtboxNombre_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoUsuario = cmbTipoUsuario.SelectedItem.ToString();

            bool mostrar = (tipoUsuario == "Técnico" || tipoUsuario == "Administrador");

            lbCodigo.Visible = mostrar;
            txtboxCodigo.Visible = mostrar;
        }
    }
}
