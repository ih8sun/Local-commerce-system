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

    public partial class Frm_Consulta_Cliente : Form
    {



        private Entidad.Facturacion regActual;


        cnFacturacion lista_neg = new cnFacturacion();


        public Frm_Consulta_Cliente()
        {
            InitializeComponent();
        }

        private void listado()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = lista_neg.Buscar_cliente(dato);
            gdvCliente.DataSource = dt;

        }

        private void forma()
        {
            DataTable dt = new DataTable();
            String dato = cboforma.Text;
            dt = lista_neg.Buscar_forma(dato);
            gdvCliente.DataSource = dt;

        }



        private void Frm_Consulta_Cliente_Load(object sender, EventArgs e)
        {
            listado();


        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            listado();

            cboforma.Text = "";


        }

        private void cboforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            forma();

            txtconsultar.Text = "";

        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtfactura.Text = gdvCliente.CurrentRow.Cells["numero"].Value.ToString();

        }

        private void Button3_Click(object sender, EventArgs e)
        {




            if (txtfactura.Text == "")
            {
                MessageBox.Show("Debe Seleccionar N° Facturacion ", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Facturacion();

                if (regActual != null)




                    oEntidad.iddocumento = regActual.iddocumento;

                oEntidad.iddocumento = txtfactura.Text.Trim();


                oEntidad.id_forma = txtforma.Text.Trim();
                oEntidad.observacion =  txtobservacion.Text.Trim();

              
                Negocio.cnFacturacion.Actualizar(oEntidad);

          

                MessageBox.Show("Asido Actualizado El Credito a Cancelado su Facturacion", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                



            }

        }
    }
}
