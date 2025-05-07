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
    public partial class frmDetalleServicioCliente: Form
    {
        public frmDetalleServicioCliente()
        {
            InitializeComponent();
        }

        private void frmDetalleServicioCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'db_TecniFixDataSet.Solicitud' Puede moverla o quitarla según sea necesario.
            this.solicitudTableAdapter.Fill(this.db_TecniFixDataSet.Solicitud);

        }
    }
}
