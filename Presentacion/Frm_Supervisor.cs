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
    public partial class Frm_Supervisor : Form
    {
        public Frm_Supervisor()
        {
            InitializeComponent();
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

        private void reporrtesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Producto_Stock abrir = new Frm_Reporte_Producto_Stock();

            abrir.Show();
        }

        private void porFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Factuarcion_Fecha abrir = new Frm_Reporte_Factuarcion_Fecha();

            abrir.Show();
        }

        private void porFechasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Compras_Fecha abrir = new Frm_Reporte_Compras_Fecha();

            abrir.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Marca abrir = new Frm_Reporte_Marca();

            abrir.Show();
        }
    }
}
