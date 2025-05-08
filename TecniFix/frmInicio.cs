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
    public partial class frmInicio: Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDirigirInicioSesion_Click(object sender, EventArgs e)
        {
            frmInicioSesion loginForm = new frmInicioSesion();
            loginForm.Show();
            this.Hide(); // Oculta el formulario actual
        }

        private void btnDirigirRegistroUsuario_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario loginForm = new frmRegistroUsuario();
            loginForm.Show();
            this.Hide(); // Oculta el formulario actual
        }
    }
}

