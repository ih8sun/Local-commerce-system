using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class Frm_Consulta_Proveedor : Form
    {


        cnCompras lista_neg = new cnCompras();



        public Frm_Consulta_Proveedor()
        {
            InitializeComponent();
        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            listado();
        }

        private void listado()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = lista_neg.Buscar_cliente(dato);
            gdvCliente.DataSource = dt;

        }


        private void Frm_Consulta_Proveedor_Load(object sender, EventArgs e)
        {
            listado();
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
    }
}
