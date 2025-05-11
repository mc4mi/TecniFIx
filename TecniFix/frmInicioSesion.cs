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
    public partial class frmInicioSesion: Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
            cmbTipoUsuario.Items.AddRange(new string[] { "Cliente", "Técnico", "Administrador" });
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Botón de Volver al inicio
        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            frmInicio inicioForm = new frmInicio();
            inicioForm.Show();
            this.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de texto y el combo box
            string cedula = txtboxCedula.Text.Trim();
            string contrasena = txtboxContraseña.Text.Trim();
            string tipoUsuario = cmbTipoUsuario.Text;

            // Validar que los campos no estén vacío
            if (string.IsNullOrWhiteSpace(tipoUsuario))
            {
                MessageBox.Show("Seleccione un tipo de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cédula y la contraseña no estén vacías

            if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Ingrese la cédula y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cédula contenga solo dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(cedula, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe contener solo dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la cédula tenga 10 dígitos
            if (cedula.Length != 10)
            {
                MessageBox.Show("La cédula debe tener 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que la contraseña tenga al menos 8 caracteres
            if (contrasena.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el tipo de usuario esté seleccionado
            if (string.IsNullOrWhiteSpace(tipoUsuario))
            {
                MessageBox.Show("Seleccione un tipo de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Determinar la tabla según el tipo de usuario
            string tabla = "";

            if (tipoUsuario == "Cliente")
                tabla = "Cliente";
            else if (tipoUsuario == "Técnico")
                tabla = "Tecnico";
            else if (tipoUsuario == "Administrador")
                tabla = "Administrador";
            else
            {
                MessageBox.Show("Seleccione un tipo de usuario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = $"SELECT COUNT(*) FROM {tabla} WHERE cedula = @cedula AND contrasena = @contrasena";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    int existe = (int)cmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        Form destino;

                        if (tipoUsuario == "Cliente")
                            destino = new frmMenuCliente();
                        else if (tipoUsuario == "Técnico")
                            destino = new frmMenuTecnico();
                        else
                            destino = new frmMenuAdministrador();

                        destino.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Cédula o contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}

        

