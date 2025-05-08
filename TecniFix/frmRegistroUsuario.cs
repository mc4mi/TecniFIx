using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecniFix
{
    public partial class frmRegistroUsuario: Form
    {
        public frmRegistroUsuario()
        {
            InitializeComponent();
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
            frmInicio inicioForm = new frmInicio();
            inicioForm.Show();
            this.Close();
        }

        
        private void txtboxNombre_TextChanged(object sender, EventArgs e)
        {
 
        }
    }
}
