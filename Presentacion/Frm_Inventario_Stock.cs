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
    public partial class Frm_Inventario_Stock : Form
    {

        private Entidad.Producto regActual;



        cnProducto lista_neg = new cnProducto();

        public Frm_Inventario_Stock()
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
            dt = lista_neg.Buscarr(dato);
            gdvCliente.DataSource = dt;


            double sumatoria = 0;
 
            foreach (DataGridViewRow row in gdvCliente.Rows)
            {
              
                sumatoria += Convert.ToDouble(row.Cells["stock"].Value);
            }
      

            txtsubtotal.Text = sumatoria.ToString("");



        }


        public void   condicion()

        {
             //gridview   rowdatabound

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    int stock = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stock").Tostring());
            //    if (stock <= 20)
            //    {

            //        e.Row.ForeColor = System.Drawing.Color.Red;

            //    }

            //    else
            //    {

            //        e.Row.ForeColor = System.Drawing.Color.Red;
            //    }

            //}

           

        }
        private void Frm_Inventario_Stock_Load(object sender, EventArgs e)
        {
            listado();


            condicion();








        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gdvCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (this.gdvCliente.Columns[e.ColumnIndex].Name == "Stock")
            {

                if (Convert.ToInt32(e.Value) <= 20)
                {

                    e.CellStyle.ForeColor = Color.Red;

                    e.CellStyle.BackColor = Color.Yellow;

                }
            }
                }
        
    }
}
