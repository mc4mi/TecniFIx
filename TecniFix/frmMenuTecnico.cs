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
    public partial class frmMenuTecnico: Form
    {
        private Form currentFormularioHijo;
        public frmMenuTecnico()
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

        private void frmMenuCliente_Load(object sender, EventArgs e)
        {
            picBienvenidaTecnico = new PictureBox();
            picBienvenidaTecnico.Image = Properties.Resources.bienvenidaTecnico;
            picBienvenidaTecnico.SizeMode = PictureBoxSizeMode.StretchImage;
            picBienvenidaTecnico.Dock = DockStyle.Fill;
            pnlInicio.Controls.Add(picBienvenidaTecnico);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            pnlInicio.Controls.Add(picBienvenidaTecnico);
        }

        private void btnGestionServicios_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmGestionServiciosTecnico());
        }

        private void btnProgramacionServicios_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmProgramacionServiciosTecnico());
        }

        private void btnDetalleServicio_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmDetallesServicioTecnico());
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
