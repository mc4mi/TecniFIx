using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecniFix
{
    public partial class frmMenuAdministrador: Form
    {
        private Form currentFormularioHijo;
        public frmMenuAdministrador()
        {
            InitializeComponent();
        }

        [DllImport("User32,DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32,DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void abrirFormularioHijo(Form formHijo)
        {
            if (currentFormularioHijo != null)
            {
                currentFormularioHijo.Close();
            }
            currentFormularioHijo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlInicio.Controls.Add(formHijo);
            pnlInicio.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
        private void frmMenuAdministrador_Load(object sender, EventArgs e)
        {
            picBienvenidaAdministrador = new PictureBox();
            picBienvenidaAdministrador.Image = Properties.Resources.bienvenida;
            picBienvenidaAdministrador.SizeMode = PictureBoxSizeMode.StretchImage;
            picBienvenidaAdministrador.Dock = DockStyle.Fill;
            pnlInicio.Controls.Add(picBienvenidaAdministrador);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (currentFormularioHijo != null)
            {
                currentFormularioHijo.Close();
                pnlInicio.Controls.Clear();
                currentFormularioHijo = null;
            }

            // Restaurar imagen de bienvenida u otros controles
            pnlInicio.Controls.Add(picBienvenidaAdministrador);
        }

        private void btnSolicitudesGestionadas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmSolicitudesGestionadasAdministrador());
        }

        private void btnVerificarPrecios_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmVerificarPreciosAdministrador());
        }

        private void btnEnviarFactura_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmEnviarFacturaAdministrador());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de inicio de sesión nuevamente
            frmInicio frmInicio = new frmInicio();
            frmInicio.Show();

            // Cerrar el formulario actual (el menú del cliente, técnico o administrador)
            this.Hide();
        }
    }
}
