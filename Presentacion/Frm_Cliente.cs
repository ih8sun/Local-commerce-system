using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;



using Entidad;
using Negocio;



namespace Presentacion
{
     


    public partial class Frm_Cliente : Form
    {



        

        private Entidad.Cliente regActual;



        cnCliente lista_neg = new cnCliente();



        public Frm_Cliente()
        {
            InitializeComponent();
        }
      
        private void Frm_Cliente_Load(object sender, EventArgs e)
        {
            listado();
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button6.Enabled = false;
        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtconsultar.Text = "";

            txtcodigo.Text = "";
            txtcedula.Text = "";
            txtcliente.Text = "";
            txtrazon.Text = "";

            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtemail.Text = "";
            txtruc.Text = "";
            txtestado.Text = "";


            Button2.Enabled = true;
            Button3.Enabled = false;
            Button6.Enabled = false;
        }
        private void listado()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = lista_neg.Buscar(dato);
            gdvCliente.DataSource = dt;

        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            listado();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var oEntidad = new Entidad.Cliente();
            try
            {
                if (string.IsNullOrWhiteSpace(txtcliente.Text) || string.IsNullOrWhiteSpace(txtrazon.Text) || string.IsNullOrWhiteSpace(txttelefono.Text) || string.IsNullOrWhiteSpace(txtcedula.Text) || string.IsNullOrWhiteSpace(txtruc.Text) || string.IsNullOrWhiteSpace(txtdireccion.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcedula.Text.Length < 8)
                {
                    MessageBox.Show("La cedula tiene que tener 8 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtruc.Text.Length < 11)
                {
                    MessageBox.Show("El RUC tiene que tener 11 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txttelefono.Text.Length < 9)
                {
                    MessageBox.Show("El telefono tiene que tener 9 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsValidEmail(txtemail.Text))
                {
                    MessageBox.Show("Debe ingresar un email válido", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtemail.Text.Length < 10)
                {
                    MessageBox.Show("El email debe tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcliente.Text.Length < 3)
                {
                    MessageBox.Show("El cliente debe de tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtrazon.Text.Length < 3)
                {
                    MessageBox.Show("La razon debe de tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txttelefono.Text[0] != '9')
                {
                    MessageBox.Show("El telefono debe empezar con el número 9", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtdireccion.Text.Length < 10)
                {
                    MessageBox.Show("La direccion debe de tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   
                    if (regActual != null)
                        oEntidad.idcliente = regActual.idcliente;

                    oEntidad.idcliente = txtcodigo.Text.Trim();
                    oEntidad.cedula = txtcedula.Text.Trim();
                    oEntidad.nombres = txtcliente.Text.Trim();
                    oEntidad.razon = txtrazon.Text.Trim();
                    oEntidad.direccion = txtdireccion.Text.Trim();
                    oEntidad.telefono = txttelefono.Text.Trim();
                    oEntidad.email = txtemail.Text.Trim();
                    oEntidad.ruc = txtruc.Text.Trim();
                    oEntidad.estado = txtestado.Text.Trim();

                    bool result = Negocio.cnCliente.Grabar(oEntidad, true);

                    if (result)
                    { 
                        MessageBox.Show("Datos Registrados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listado();
                        limpiar();
                        Button2.Enabled = true;
                        Button3.Enabled = false;
                        Button6.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un registro con la misma cédula y/o teléfono y/o RUC", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool IsValidEmail(string email)
        {
            // Expresión regular para validar el formato de correo electrónico
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);

            // Devuelve verdadero si el valor ingresado coincide con el formato de correo electrónico válido
            return regex.IsMatch(email);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            listado();

            limpiar();
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button6.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var oEntidad = new Entidad.Cliente();
            try
            {
                if (string.IsNullOrWhiteSpace(txtcliente.Text) || string.IsNullOrWhiteSpace(txtrazon.Text) || string.IsNullOrWhiteSpace(txttelefono.Text) || string.IsNullOrWhiteSpace(txtcedula.Text) || string.IsNullOrWhiteSpace(txtruc.Text) || string.IsNullOrWhiteSpace(txtdireccion.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcedula.Text.Length < 8)
                {
                    MessageBox.Show("La cedula tiene que tener 8 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtruc.Text.Length < 11)
                {
                    MessageBox.Show("El RUC tiene que tener 11 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txttelefono.Text.Length < 9)
                {
                    MessageBox.Show("El telefono tiene que tener 9 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsValidEmail(txtemail.Text))
                {
                    MessageBox.Show("Debe ingresar un email válido", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtemail.Text.Length < 10)
                {
                    MessageBox.Show("El email debe tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtcliente.Text.Length < 3)
                {
                    MessageBox.Show("El cliente debe de tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtrazon.Text.Length < 3)
                {
                    MessageBox.Show("La razon debe de tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txttelefono.Text[0] != '9')
                {
                    MessageBox.Show("El telefono debe empezar con el número 9", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtdireccion.Text.Length < 10)
                {
                    MessageBox.Show("La direccion debe de tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (regActual != null)
                        oEntidad.idcliente = regActual.idcliente;

                    oEntidad.idcliente = txtcodigo.Text.Trim();
                    oEntidad.cedula = txtcedula.Text.Trim();
                    oEntidad.nombres = txtcliente.Text.Trim();
                    oEntidad.razon = txtrazon.Text.Trim();
                    oEntidad.direccion = txtdireccion.Text.Trim();
                    oEntidad.telefono = txttelefono.Text.Trim();
                    oEntidad.email = txtemail.Text.Trim();
                    oEntidad.ruc = txtruc.Text.Trim();
                    oEntidad.estado = txtestado.Text.Trim();

                    bool result = Negocio.cnCliente.Grabar(oEntidad, false);

                    if (result)
                    {
                        MessageBox.Show("Datos Registrados Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listado();
                        limpiar();
                        Button2.Enabled = true;
                        Button3.Enabled = false;
                        Button6.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un registro con la misma cédula y/o razon social y/o teléfono y/o RUC", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ya existe un registro con la misma cédula y/o razon social y/o teléfono y/o RUC", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                oEntidad = null;
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcliente.Text) || string.IsNullOrWhiteSpace(txtrazon.Text) || string.IsNullOrWhiteSpace(txttelefono.Text) || string.IsNullOrWhiteSpace(txtcedula.Text) || string.IsNullOrWhiteSpace(txtruc.Text) || string.IsNullOrWhiteSpace(txtdireccion.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Debe Consultar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Cliente();

                if (regActual != null)

                    oEntidad.idcliente = regActual.idcliente;

                oEntidad.idcliente = txtcodigo.Text.Trim();
                oEntidad.estado = txtestado.Text.Trim();


                try
                {
                    MessageBox.Show("Se cambio de estado", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Negocio.cnCliente.Cambiar(oEntidad);





                }
                catch (Exception ex)
                {
                }
                finally { oEntidad = null; }
                listado();
                limpiar();
                Button2.Enabled = true;
                Button3.Enabled = false;
                Button6.Enabled = false;
            }
        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = gdvCliente.CurrentRow.Cells["codigo"].Value.ToString();
            txtcedula.Text = gdvCliente.CurrentRow.Cells["cedula"].Value.ToString();
            txtcliente.Text = gdvCliente.CurrentRow.Cells["cliente"].Value.ToString();
            txtrazon.Text = gdvCliente.CurrentRow.Cells["razon_social"].Value.ToString();

            txtdireccion.Text = gdvCliente.CurrentRow.Cells["direccion"].Value.ToString();
            txttelefono.Text = gdvCliente.CurrentRow.Cells["telefono"].Value.ToString();
            txtemail.Text = gdvCliente.CurrentRow.Cells["email"].Value.ToString();
            txtruc.Text = gdvCliente.CurrentRow.Cells["ruc"].Value.ToString();
            txtestado.Text = gdvCliente.CurrentRow.Cells["estado"].Value.ToString();


            Button3.Enabled = true;
            Button2.Enabled = false;
            Button6.Enabled = true;
        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcliente.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El cliente solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (txtcedula.Text.Length == 8 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La cédula solo debe tener 8 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (txtruc.Text.Length == 11 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El ruc solo debe tener 11 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es una letra, número, @, punto o retroceso
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para email", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (txtemail.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El email solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (txttelefono.Text.Length == 9 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El telefono debe de tener solo 9 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtdireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtdireccion.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La direccion solo debe tener 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != ',')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para direccion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtrazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtrazon.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La razon social solo debe tener 50 caracteres como máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '&')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para la razon social", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
