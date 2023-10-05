using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Frm_Vendedor : Form
    {
        public Frm_Vendedor()
        {
            InitializeComponent();
        }

        private void registroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_Cliente abrir = new Frm_Cliente();

            abrir.Show();
        }

        private void generarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Facturacion abrir = new Frm_Facturacion();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Facturacion abrir = new Frm_Reporte_Facturacion();

            abrir.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Sistema ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }
    }
}
