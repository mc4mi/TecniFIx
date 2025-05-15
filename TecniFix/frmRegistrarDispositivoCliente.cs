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
    public partial class frmRegistrarDispositivoCliente : Form
    {
        public frmRegistrarDispositivoCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            

            //Guardar en la base de datos
            // Obtener los valores de los campos de texto
            string id_cliente = txtboxCedulaCliente.Text.Trim();  // Este campo ahora representa id_cliente
            string marca = txtboxMarca.Text.Trim();
            string modelo = txtboxModelo.Text.Trim();
            string procesador = txtboxProcesador.Text.Trim();
            string ram = txtboxRam.Text.Trim();
            string almacenamiento = txtboxAlmacenamiento.Text.Trim();
            string tiempoUso = txtboxTiempoUso.Text.Trim();
            string numeroSerieStr = txtboxNumeroSerie.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(id_cliente) || string.IsNullOrWhiteSpace(marca) ||
                string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(procesador) ||
                string.IsNullOrWhiteSpace(ram) || string.IsNullOrWhiteSpace(almacenamiento) ||
                string.IsNullOrWhiteSpace(tiempoUso) || string.IsNullOrWhiteSpace(numeroSerieStr))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que id_cliente y número de serie sean numéricos
            if (!int.TryParse(id_cliente, out int idCliente) || !int.TryParse(numeroSerieStr, out int numeroSerie))
            {
                MessageBox.Show("La identificación del cliente y el número de serie deben ser números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar RAM y almacenamiento sean números
            if (!int.TryParse(ram, out int ramInt) || !int.TryParse(almacenamiento, out int almacenamientoInt))
            {
                MessageBox.Show("La RAM y el almacenamiento deben ser números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar valores positivos
            if (idCliente <= 0 || numeroSerie <= 0 || ramInt <= 0 || almacenamientoInt <= 0)
            {
                MessageBox.Show("Todos los valores numéricos deben ser positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Verificar que el id_cliente existe en la base de datos
                    string queryCheckCliente = "SELECT COUNT(*) FROM Cliente WHERE id_cliente = @id_cliente";
                    SqlCommand cmdCheck = new SqlCommand(queryCheckCliente, conn);
                    cmdCheck.Parameters.AddWithValue("@id_cliente", idCliente);

                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("No existe un cliente con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Si existe, proceder a insertar
                    string insertCompu = "INSERT INTO Computador (id_computador, id_cliente, marca, modelo, procesador, ram, almacenamiento, tiempo_uso) " +
                                         "VALUES (@id_computador, @id_cliente, @marca, @modelo, @procesador, @ram, @almacenamiento, @tiempo_uso)";

                    SqlCommand cmdInsert = new SqlCommand(insertCompu, conn);
                    cmdInsert.Parameters.AddWithValue("@id_computador", numeroSerie);
                    cmdInsert.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmdInsert.Parameters.AddWithValue("@marca", marca);
                    cmdInsert.Parameters.AddWithValue("@modelo", modelo);
                    cmdInsert.Parameters.AddWithValue("@procesador", procesador);
                    cmdInsert.Parameters.AddWithValue("@ram", ramInt);
                    cmdInsert.Parameters.AddWithValue("@almacenamiento", almacenamientoInt);
                    cmdInsert.Parameters.AddWithValue("@tiempo_uso", tiempoUso);

                    int resultado = cmdInsert.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Dispositivo registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el dispositivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar el dispositivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

    

