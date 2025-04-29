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
    public partial class TecniFix: Form
    {
        private Form currentFormularioHijo;
        public TecniFix()
        {
            InitializeComponent();
        }

        [DllImport("User32,DLL",EntryPoint = "ReleaseCapture")]
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
            picBienvenida = new PictureBox();
            picBienvenida.Image = Properties.Resources.bienvenida;
            picBienvenida.SizeMode = PictureBoxSizeMode.StretchImage;
            picBienvenida.Dock = DockStyle.Fill;
            pnlInicio.Controls.Add(picBienvenida);
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
            pnlInicio.Controls.Add(picBienvenida);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnInformación_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmInformacionCliente());
        }

        private void bbtnRegistrarComputador_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmRegistrarDispositivoCliente());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmSolicitadCliente());
        }

        private void btnDetalleServicio_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmDetalleServicioCliente());
        }
    }
}
