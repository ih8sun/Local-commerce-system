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
    public partial class Frm_Menu_Principal : Form
    {
        public Frm_Menu_Principal()
        {
            InitializeComponent();
        }

        private void acercaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Acerca abrir = new Frm_Acerca();

            abrir.Show();
        }

        private void registroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cliente abrir = new Frm_Cliente();

            abrir.Show();
        }

        private void Frm_Menu_Principal_Load(object sender, EventArgs e)
        {

        }

        private void registroProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Producto abrir = new Frm_Producto();

            abrir.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Marca abrir = new Frm_Marca();

            abrir.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Categoria abrir = new Frm_Categoria();

            abrir.Show();
        }

        private void registroProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Proveedor abrir = new Frm_Proveedor();

            abrir.Show();
        }

        private void registroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Usuario abrir = new Frm_Usuario();

            abrir.Show();
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cargo abrir = new Frm_Cargo();

            abrir.Show();
        }

        private void registroTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Tipo abrir = new Frm_Tipo();

            abrir.Show();
        }

        private void generarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Facturacion abrir = new Frm_Facturacion();

            abrir.Show();
        }

        private void stockInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_Inventario_Stock abrir = new Frm_Inventario_Stock();

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

        private void reporrtesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Producto_Stock abrir = new Frm_Reporte_Producto_Stock();

            abrir.Show();



        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Facturacion abrir = new Frm_Reporte_Facturacion();

            abrir.Show();
        }

        private void consultarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consulta_Cliente abrir = new Frm_Consulta_Cliente();

            abrir.Show();
        }

        private void porFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_Reporte_Factuarcion_Fecha abrir = new Frm_Reporte_Factuarcion_Fecha ();

            abrir.Show();


        }

        private void registrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Compras abrir = new Frm_Compras();

            abrir.Show();
        }

        private void marcaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Marca abrir = new Frm_Reporte_Marca();

            abrir.Show();
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consulta_Proveedor abrir = new Frm_Consulta_Proveedor();

            abrir.Show();
        }

        private void porcentajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Porcentaje abrir = new Frm_Porcentaje();

            abrir.Show();
        }

        private void imprimirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Compras abrir = new Frm_Reporte_Compras();

            abrir.Show();
        }

        private void porFechasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Compras_Fecha abrir = new Frm_Reporte_Compras_Fecha();

            abrir.Show();
        }

        private void cancelarFacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cancelar_Facturacion abrir = new Frm_Cancelar_Facturacion();

            abrir.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Frm_Cliente abrir = new Frm_Cliente();

            abrir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Producto abrir = new Frm_Producto();

            abrir.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Proveedor abrir = new Frm_Proveedor();

            abrir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Tipo abrir = new Frm_Tipo();

            abrir.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Frm_Inventario_Stock abrir = new Frm_Inventario_Stock();

            abrir.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm_Compras abrir = new Frm_Compras();

            abrir.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Facturacion abrir = new Frm_Facturacion();

            abrir.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Facturacion abrir = new Frm_Reporte_Facturacion();

            abrir.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Factuarcion_Fecha abrir = new Frm_Reporte_Factuarcion_Fecha();

            abrir.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Frm_Usuario abrir = new Frm_Usuario();

            abrir.Show();
        }

        private void button9_Click(object sender, EventArgs e)
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
