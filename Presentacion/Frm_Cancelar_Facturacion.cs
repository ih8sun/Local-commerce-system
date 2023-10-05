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
    public partial class Frm_Cancelar_Facturacion : Form
    {

        private Entidad.Facturacion regActual;


        public Frm_Cancelar_Facturacion()
        {
            InitializeComponent();
        }

        private void Frm_Cancelar_Facturacion_Load(object sender, EventArgs e)
        {
            Button4.Enabled = false;
        }

        private void Detalle_cancelar()
        {


            if (txtcodigo.Text == "")
            {
                MessageBox.Show("Debe Ingresar N° Facturacion", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Facturacion();

                if (regActual != null)

                    oEntidad.iddocumento = regActual.iddocumento;

                oEntidad.iddocumento = txtcodigo.Text.Trim();





                bool facturaEncontrada = Negocio.cnFacturacion.Cancelar_Detalle_Facturacion(oEntidad);

                if (facturaEncontrada)
                {
                    MessageBox.Show("Detalle de facturación cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La factura ingresada no se encuentra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }





            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
             try
                {



                if (txtcodigo.Text == "")
                {
                MessageBox.Show("Debe Ingresar N° Facturacion", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                 }
                 else
                    {
                    var oEntidad = new Entidad.Facturacion();

                     if (regActual != null)

                    oEntidad.iddocumento = regActual.iddocumento;

                     oEntidad.iddocumento = txtcodigo.Text.Trim();



                    bool facturaEncontrada = Negocio.cnFacturacion.Cancelar_Detalle_Facturacion(oEntidad);

                    if (facturaEncontrada)
                    {
                        Negocio.cnFacturacion.Cancelar_Facturacion(oEntidad);
                        MessageBox.Show("Se ha cancelado la venta de facturación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcodigo.Text = "";
                        Button4.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("La factura ingresada no se encuentra", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }

             }
             catch (Exception ex)
             {
             }





        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro Cancelacion ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

            Button4.Enabled = true;
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcodigo.Text.Length == 4 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El numero solo puede tener hasta 4 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
