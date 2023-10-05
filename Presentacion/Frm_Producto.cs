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
    public partial class Frm_Producto : Form
    {


        private Entidad.Producto regActual;



        cnProducto lista_neg = new cnProducto();


        public Frm_Producto()
        {
            InitializeComponent();
        }
        private void limpiar()
        {

            txtcodigo.Text = "";
            txtconsultar.Text = "";

            txtcodigo.Text = "";
            txtproducto.Text = "";
            txtdescripcion.Text = "";

            txtcompra.Text = "";
            txtventa.Text = "";
            cboproveedor.Text = "";
            cbomarca.Text = "";
           cbocategoria.Text = "";
           txtfecha.Text = "";
           txtunidad.Text = "";
           txtstock.Text = "";
            txtestado.Text = "";

            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }
        private void listado()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = lista_neg.Buscar(dato);
            gdvCliente.DataSource = dt;

        }



        private void proveedor()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_proveedor();

            cboproveedor.DataSource = dt;

            cboproveedor.DisplayMember= "proveedor";
            cboproveedor.ValueMember = "id_proveedor";
      


        }

        private void marca()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_marca();

            cbomarca.DataSource = dt;

            cbomarca.DisplayMember = "marca";
            cbomarca.ValueMember = "id_marca";



        }

        private void categoria()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_categoria();

            cbocategoria.DataSource = dt;

            cbocategoria.DisplayMember = "categoria";
            cbocategoria.ValueMember = "id_categoria";



        }




        private void Frm_Producto_Load(object sender, EventArgs e)
        {
            listado();
            categoria();
                marca();
            proveedor();

            cbocategoria.Text = "";
            cbomarca .Text="";
            cboproveedor.Text = "";



            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var oEntidad = new Entidad.Producto();
            try
            {
                if (string.IsNullOrWhiteSpace(txtproducto.Text) || string.IsNullOrWhiteSpace(txtdescripcion.Text) || string.IsNullOrWhiteSpace(txtcompra.Text) || string.IsNullOrWhiteSpace(txtventa.Text) || string.IsNullOrWhiteSpace(txtstock.Text) || string.IsNullOrWhiteSpace(cbomarca.Text) || string.IsNullOrWhiteSpace(cbocategoria.Text) || string.IsNullOrWhiteSpace(cboproveedor.Text) || string.IsNullOrWhiteSpace(txtunidad.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtproducto.Text.Length < 3)
                {
                    MessageBox.Show("El producto tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtdescripcion.Text.Length < 10)
                {
                    MessageBox.Show("La descripcion tiene que tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtstock.Text == "0")
                {
                    MessageBox.Show("El valor del stock no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtunidad.Text.Length < 4)
                {
                    MessageBox.Show("La unidad de medida tiene que tener al menos 4 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtcompra.Text) == 0)
                {
                    MessageBox.Show("El valor de compra no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtventa.Text) == 0)
                {
                    MessageBox.Show("El valor de venta no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtcompra.Text) > Convert.ToDecimal(txtventa.Text))
                {
                    MessageBox.Show("El valor de compra no puede ser mayor al valor de venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (regActual != null)

                        oEntidad.idproducto = regActual.idproducto;

                    oEntidad.idproducto = txtcodigo.Text.Trim();

                    oEntidad.product = txtproducto.Text.Trim();
                    oEntidad.descripcion = txtdescripcion.Text.Trim();


                    oEntidad.compra = txtcompra.Text.Trim();
                    oEntidad.venta = txtventa.Text.Trim();

                    oEntidad.idproveedor = cboproveedor.SelectedValue.ToString();

                    oEntidad.unidad = txtunidad.Text.Trim();

                    oEntidad.stock = txtstock.Text.Trim();

                    oEntidad.idmarca = cbomarca.SelectedValue.ToString();

                    oEntidad.idcategoria = cbocategoria.SelectedValue.ToString();

                    oEntidad.fecha =  txtfecha.Text.Trim();
                    oEntidad.estado = txtestado.Text.Trim();


                    bool result = Negocio.cnProducto.Grabar(oEntidad, true);

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
                        MessageBox.Show("Ya existe un registro con el mismo nombre, descripcion, proveedor, marca y categoria", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var oEntidad = new Entidad.Producto();
            try
            {
                if (string.IsNullOrWhiteSpace(txtproducto.Text) || string.IsNullOrWhiteSpace(txtdescripcion.Text) || string.IsNullOrWhiteSpace(txtcompra.Text) || string.IsNullOrWhiteSpace(txtventa.Text) || string.IsNullOrWhiteSpace(txtstock.Text) || string.IsNullOrWhiteSpace(cbomarca.Text) || string.IsNullOrWhiteSpace(cbocategoria.Text) || string.IsNullOrWhiteSpace(cboproveedor.Text) || string.IsNullOrWhiteSpace(txtunidad.Text))
                {
                    MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtproducto.Text.Length < 3)
                {
                    MessageBox.Show("El producto tiene que tener al menos 3 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtdescripcion.Text.Length < 10)
                {
                    MessageBox.Show("La descripcion tiene que tener al menos 10 caracteres", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtstock.Text == "0")
                {
                    MessageBox.Show("El valor del stock no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtunidad.Text.Length < 4)
                {
                    MessageBox.Show("La unidad de medida tiene que tener al menos 4 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtcompra.Text) == 0)
                {
                    MessageBox.Show("El valor de compra no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtventa.Text) == 0)
                {
                    MessageBox.Show("El valor de venta no puede ser 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDecimal(txtcompra.Text) > Convert.ToDecimal(txtventa.Text))
                {
                    MessageBox.Show("El valor de compra no puede ser mayor al valor de venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (regActual != null)

                        oEntidad.idproducto = regActual.idproducto;

                    oEntidad.idproducto = txtcodigo.Text.Trim();

                    oEntidad.product = txtproducto.Text.Trim();
                    oEntidad.descripcion = txtdescripcion.Text.Trim();


                    oEntidad.compra = txtcompra.Text.Trim();
                    oEntidad.venta = txtventa.Text.Trim();

                    oEntidad.idproveedor = cboproveedor.SelectedValue.ToString();

                    oEntidad.unidad = txtunidad.Text.Trim();

                    oEntidad.stock = txtstock.Text.Trim();

                    oEntidad.idmarca = cbomarca.SelectedValue.ToString();

                    oEntidad.idcategoria = cbocategoria.SelectedValue.ToString();

                    oEntidad.fecha = txtfecha.Text.Trim();
                    oEntidad.estado = txtestado.Text.Trim();


                    bool result = Negocio.cnProducto.Grabar(oEntidad, false);

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
                        MessageBox.Show("Ya existe un registro con el mismo nombre, descripcion, proveedor, marca y categoria", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ya existe un registro con el mismo nombre, descripcion, proveedor, marca y categoria", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                oEntidad = null;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproducto.Text) || string.IsNullOrWhiteSpace(txtdescripcion.Text) || string.IsNullOrWhiteSpace(txtcompra.Text) || string.IsNullOrWhiteSpace(txtventa.Text) || string.IsNullOrWhiteSpace(txtstock.Text) || string.IsNullOrWhiteSpace(cbomarca.Text) || string.IsNullOrWhiteSpace(cbocategoria.Text) || string.IsNullOrWhiteSpace(cboproveedor.Text) || string.IsNullOrWhiteSpace(txtunidad.Text))
            {
                MessageBox.Show("Debe Consultar los Dato", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Producto();

                if (regActual != null)

                    oEntidad.idproducto = regActual.idproducto;

                oEntidad.idproducto = txtcodigo.Text.Trim();
                oEntidad.estado = txtestado.Text.Trim();



                try
                {
                    MessageBox.Show("Se cambio de estado", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Negocio.cnProducto.Cambiar(oEntidad);


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

            txtproducto.Text = gdvCliente.CurrentRow.Cells["producto"].Value.ToString();
            txtdescripcion.Text = gdvCliente.CurrentRow.Cells["descripcion"].Value.ToString();
            txtcompra.Text = gdvCliente.CurrentRow.Cells["precio_compra"].Value.ToString();
            txtventa.Text = gdvCliente.CurrentRow.Cells["precio_venta"].Value.ToString();
           cboproveedor.Text = gdvCliente.CurrentRow.Cells["proveedor"].Value.ToString();
            txtunidad.Text = gdvCliente.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtstock.Text = gdvCliente.CurrentRow.Cells["stock"].Value.ToString();

            cbomarca.Text = gdvCliente.CurrentRow.Cells["marca"].Value.ToString();
          cbocategoria.Text = gdvCliente.CurrentRow.Cells["categoria"].Value.ToString();
           txtfecha.Text = gdvCliente.CurrentRow.Cells["fecha"].Value.ToString();
            txtestado.Text = gdvCliente.CurrentRow.Cells["estado"].Value.ToString();



            Button3.Enabled = true;
            Button4.Enabled = true;
            Button2.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            listado();

            limpiar();
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }

        private void txtproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtproducto.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El producto solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtdescripcion.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La descripcion solo debe tener 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '#')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para descripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txtcompra.Text.Contains('.'))
            {
                MessageBox.Show("El valor ya contiene un punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (txtcompra.Text.Contains('.'))
            {
                string[] parts = txtcompra.Text.Split('.');
                if (parts[1].Length >= 2)
                {
                    MessageBox.Show("El valor decimal solo puede tener dos dígitos después del punto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }

            decimal valor;
            if (decimal.TryParse(txtcompra.Text + e.KeyChar, out valor))
            {
                if (valor > 99999999.99m)
                {
                    MessageBox.Show("El valor máximo permitido es 99,999,999.99", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void txtventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txtventa.Text.Contains('.'))
            {
                MessageBox.Show("El valor ya contiene un punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (txtventa.Text.Contains('.'))
            {
                string[] parts = txtventa.Text.Split('.');
                if (parts[1].Length >= 2)
                {
                    MessageBox.Show("El valor decimal solo puede tener dos dígitos después del punto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }

            decimal valor;
            if (decimal.TryParse(txtventa.Text + e.KeyChar, out valor))
            {
                if (valor > 99999999.99m)
                {
                    MessageBox.Show("El valor máximo permitido es 99,999,999.99", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void txtunidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtunidad.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La unidad solo debe tener 50 caracteres máximo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtstock.Text.Length == 10 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("El stock solo puede tener hasta 10 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        private void txtstock_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
