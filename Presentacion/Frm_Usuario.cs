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
    public partial class Frm_Usuario : Form
    {

        cnUsuario lista_neg = new cnUsuario();

        private Entidad.Usuario regActual;


        public Frm_Usuario()
        {
            InitializeComponent();
        }
        private void listado()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = lista_neg.Buscar(dato);
            gdvCliente.DataSource = dt;

        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtconsultar.Text = "";
            txtusuario.Text = "";
            txtnombre.Text = "";

            cbocargo.Text = "";
            txtcontraseña.Text = "";
            txtestado.Text = "";


            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }

        private void categoria()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_cargo();

            cbocargo.DataSource = dt;

            cbocargo.DisplayMember = "cargo";
            cbocargo.ValueMember = "id_cargo";



        }

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {

            listado();

            categoria();

            cbocargo.Text = "";


            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listado();

            limpiar();
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var oEntidad = new Entidad.Usuario();
            try
            {
                if (string.IsNullOrWhiteSpace(txtusuario.Text) || string.IsNullOrWhiteSpace(txtcontraseña.Text) || string.IsNullOrWhiteSpace(cbocargo.Text) || string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtnombre.Text.Length < 3 )
                {
                    MessageBox.Show("El nombre tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtusuario.Text.Length < 3)
                {
                    MessageBox.Show("El usuario tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcontraseña.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña tiene que tener al menos 6 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (regActual != null)

                        oEntidad.idcodigo = regActual.idcodigo;

                    oEntidad.idcodigo = txtcodigo.Text.Trim();
                    oEntidad.nombrecompleto = txtnombre.Text.Trim();
                    oEntidad.nombres = txtusuario.Text.Trim();

                    oEntidad.contraseña = txtcontraseña.Text.Trim();

                    oEntidad.cargo = cbocargo.SelectedValue.ToString();
                    oEntidad.estado = txtestado.Text.Trim();

                   bool result = Negocio.cnUsuario.Grabar(oEntidad, true);

                    if (result)
                    {
                        MessageBox.Show("Datos Registrados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listado();
                        limpiar();
                        Button2.Enabled = true;
                        Button3.Enabled = false;
                        Button4.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un registro con los mismos datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                oEntidad = null; 
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var oEntidad = new Entidad.Usuario();
            try
            {
                if (string.IsNullOrWhiteSpace(txtusuario.Text) || string.IsNullOrWhiteSpace(txtcontraseña.Text) || string.IsNullOrWhiteSpace(cbocargo.Text) || string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtnombre.Text.Length < 3)
                {
                    MessageBox.Show("El nombre tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtusuario.Text.Length < 3)
                {
                    MessageBox.Show("El usuario tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcontraseña.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña tiene que tener al menos 6 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (regActual != null)

                        oEntidad.idcodigo = regActual.idcodigo;

                    oEntidad.idcodigo = txtcodigo.Text.Trim();
                    oEntidad.nombrecompleto = txtnombre.Text.Trim();
                    oEntidad.nombres = txtusuario.Text.Trim();

                    oEntidad.contraseña = txtcontraseña.Text.Trim();

                    oEntidad.cargo = cbocargo.SelectedValue.ToString();
                    oEntidad.estado = txtestado.Text.Trim();

                    bool result = Negocio.cnUsuario.Grabar(oEntidad, false);

                    if (result)
                    {
                        MessageBox.Show("Datos Modificados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listado();
                        limpiar();
                        Button2.Enabled = true;
                        Button3.Enabled = false;
                        Button4.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un registro con los mismos datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ya existe un registro con los mismos datos", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                oEntidad = null;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusuario.Text) || string.IsNullOrWhiteSpace(txtcontraseña.Text) || string.IsNullOrWhiteSpace(cbocargo.Text) || string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Debe Consultar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Usuario();

                if (regActual != null)

                    oEntidad.idcodigo = regActual.idcodigo;

                oEntidad.idcodigo = txtcodigo.Text.Trim();
                oEntidad.nombrecompleto = txtnombre.Text.Trim();
                oEntidad.nombres = txtusuario.Text.Trim();

                oEntidad.contraseña = txtcontraseña.Text.Trim();

                oEntidad.cargo = cbocargo.SelectedValue.ToString();
                oEntidad.estado = txtestado.Text.Trim();


                try
                {
                    MessageBox.Show("Se cambio de estado", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Negocio.cnUsuario.Cambiar(oEntidad);

                }
                catch (Exception ex)
                {
                }
                finally { oEntidad = null; }
                listado();
                limpiar();
                Button2.Enabled = true;
                Button3.Enabled = false;
                Button4.Enabled = false;


            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            listado();
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = gdvCliente.CurrentRow.Cells["codigo"].Value.ToString();
            txtusuario.Text = gdvCliente.CurrentRow.Cells["usuario"].Value.ToString();
            txtnombre.Text = gdvCliente.CurrentRow.Cells["nombrecompleto"].Value.ToString();

            txtcontraseña.Text = gdvCliente.CurrentRow.Cells["contraseña"].Value.ToString();
            cbocargo.Text = gdvCliente.CurrentRow.Cells["cargo"].Value.ToString();
            txtestado.Text= gdvCliente.CurrentRow.Cells["estado"].Value.ToString();


            Button4.Enabled = true;
            Button3.Enabled = true;
            Button2.Enabled = false;
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtnombre.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El nombre solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtusuario.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El usuario solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcontraseña.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La contraseña solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && e.KeyChar != '\b')
            {
                MessageBox.Show("La contraseña solo puede contener letras, números y caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
