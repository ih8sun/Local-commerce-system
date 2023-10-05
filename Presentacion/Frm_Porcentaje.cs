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
    public partial class Frm_Porcentaje : Form
    {

        cnPorcentaje lista_neg = new cnPorcentaje();

        private Entidad.Porcentaje regActual;



        private void limpiar()
        {

            txtcodigo.Text = "";
          
            txtdescripcion.Text = "";

            Button2.Enabled = true;
            Button3.Enabled = false;
        
        }



        public Frm_Porcentaje()
        {
            InitializeComponent();
        }
        private void listado()
        {
            DataTable dt = new DataTable();

            String dato ="" ;


            dt = lista_neg.Buscar(dato);
            gdvCliente.DataSource = dt;

        }
        private void Frm_Porcentaje_Load(object sender, EventArgs e)
        {
            listado();

            Button2.Enabled = true;
            Button3.Enabled = false;
         
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listado();

            limpiar();
            Button2.Enabled = true;
            Button3.Enabled = false;
        
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Porcentaje();

                if (regActual != null)

                    oEntidad.idcodigo = regActual.idcodigo;

                oEntidad.idcodigo = txtcodigo.Text.Trim();
                oEntidad.nombres = txtdescripcion.Text.Trim();

                try
                {
                    Negocio.cnPorcentaje.Grabar(oEntidad);



                    MessageBox.Show("Datos Registrados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                }
                finally { oEntidad = null; }
                listado();
                limpiar();
                Button2.Enabled = true;
                Button3.Enabled = false;
         

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Porcentaje();

                if (regActual != null)

                    oEntidad.idcodigo = regActual.idcodigo;

                oEntidad.idcodigo = txtcodigo.Text.Trim();
                oEntidad.nombres = txtdescripcion.Text.Trim();

                try
                {
                    Negocio.cnPorcentaje.Grabar(oEntidad);



                    MessageBox.Show("Datos Modificados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                }
                finally { oEntidad = null; }
                listado();
                limpiar();
                Button2.Enabled = true;
                Button3.Enabled = false;
      

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro Porcentaje ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = gdvCliente.CurrentRow.Cells["codigo"].Value.ToString();
            txtdescripcion.Text = gdvCliente.CurrentRow.Cells["porcentaje"].Value.ToString();


            Button3.Enabled = true;
    
            Button2.Enabled = false;
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
