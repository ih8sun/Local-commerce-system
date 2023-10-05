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

using System.Data.SqlClient;


namespace Presentacion
{
    public partial class Frm_Facturacion : Form
    {



        private Entidad.Facturacion regActual;



        cnFacturacion lista_neg = new cnFacturacion();


        cnProducto listaproducto_neg = new cnProducto();



        cnCliente listacliente_neg = new cnCliente();



        public Frm_Facturacion()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            if (txtcantidad.Text == "" || txtcodigo_cliente.Text == "" || txtsubtotal.Text == "" || txtproducto.Text == "" || txtigv.Text == "" || cboforma.Text == "")
            {
                MessageBox.Show("Debe Ingresar los Datos", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var oEntidad = new Entidad.Facturacion();

                if (regActual != null)

                    oEntidad.iddocumento = regActual.iddocumento;

                oEntidad.iddocumento = txtfactura.Text.Trim();

                oEntidad.serie = txtserie.Text.Trim();
                oEntidad.fecha = txtfecha.Text.Trim();
                oEntidad.hora = txthora.Text.Trim();


                oEntidad.id_tipo_documento = cbodocumento.SelectedValue.ToString();

                oEntidad.codigo_cliente = txtcodigo_cliente.Text.Trim();
                oEntidad.id_usuario = cbousuario.SelectedValue.ToString();

                oEntidad.id_forma = cboforma.SelectedValue.ToString();
                oEntidad.observacion = txtobservacion.Text.Trim();

                oEntidad.subtotal = txtsubtotal.Text.Trim();
                oEntidad.igv = txtigv.Text.Trim();
                oEntidad.total = txttotal.Text.Trim();








                //try
                //{
                Negocio.cnFacturacion.Grabar(oEntidad);

                Detalle();

                MessageBox.Show("Asido Registrado La Venta de Facturacion  Correctamente", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //String variable = "";

                //variable = txtfactura.Text;


                //Form formularioB = new Frm_Reporte_Facturacion(variable);

                //formularioB.ShowDialog();






                limpiar();

                dgDatos.Rows.Clear();

                Button4.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = false;
                //autogenerar();


                Ultimo();



                //}
                //catch (Exception ex)
                //{
                //}
                //finally { oEntidad = null; }



            }





        }

        private void Button2_Click(object sender, EventArgs e)
        {


            double total = 0, subtotal = 0, igv;



            try
            {


                int Todo = dgDatos.RowCount;
                if (Todo >= 1)
                {
                    int Fil = dgDatos.CurrentRow.Index;

                    int cantidadEliminada = int.Parse(dgDatos.Rows[Fil].Cells[4].Value.ToString());


                    dgDatos.Rows.RemoveAt(dgDatos.CurrentRow.Index);

                    int stock = int.Parse(txtstock.Text);
                    stock += cantidadEliminada;
                    txtstock.Text = stock.ToString();
                }
                else
                {
                    MessageBox.Show("No Existe Ninguna Detalle!",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }


                //Método con el que recorreremos todas las filas de nuestro Datagridview
                foreach (DataGridViewRow row in dgDatos.Rows)
                {
                    //Aquí seleccionaremos la columna que contiene los datos numericos.
                    subtotal += Convert.ToDouble(row.Cells["importe"].Value);
                }

                //try
                //{
                total = total + subtotal;

                igv = subtotal * 0.18;

                subtotal = subtotal - igv;



                txtigv.Text = igv.ToString("0.00");
                txtsubtotal.Text = subtotal.ToString("0.00");

                txttotal.Text = total.ToString("0.00");


            }
            catch (Exception ex)
            {
            }



        }
        private void Detalle()
        {




            try
            {



                foreach (DataGridViewRow row in dgDatos.Rows)
                {


                    Negocio.cnDetalleFacturacion detalleventa_neg = new Negocio.cnDetalleFacturacion();


                    Entidad.DetalleFacturacion detalleventa_entidad = new Entidad.DetalleFacturacion();


                    detalleventa_entidad.Ids = txtfactura.Text;



                    detalleventa_entidad.Cod_Productos = Convert.ToString(row.Cells[1].Value.ToString());

                    detalleventa_entidad.Productos = Convert.ToString(row.Cells[2].Value.ToString());

                    detalleventa_entidad.Precios = Convert.ToString(row.Cells[3].Value.ToString());

                    detalleventa_entidad.Cantidads = Convert.ToString(row.Cells[4].Value.ToString());


                    detalleventa_entidad.Subtotals = Convert.ToString(row.Cells[5].Value.ToString());

                    detalleventa_neg.insert(detalleventa_entidad);


                }


            }
            catch (Exception)
            {

            }





        }
        private void limpiar()
        {


            txtmarca.Text = "";

            txtcategoria.Text = "";
            txtcodigo_cliente.Text = "";
            txtcliente.Text = "";

            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";

            cboforma.Text = "";
            txtobservacion.Text = "";

            txtimporte.Text = "";
            txtcantidad.Text = "";
            txtcodigoproducto.Text = "";

            txtcantidad.Text = "";
            txtigv.Text = "";
            txtsubtotal.Text = "";
            txttotal.Text = "";
            txtstock.Text = "";

            Button4.Enabled = false;
            Button3.Enabled = false;
            Button2.Enabled = false;
        }

        private void usuario()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_usuario();

            cbousuario.DataSource = dt;

            cbousuario.DisplayMember = "usuario";
            cbousuario.ValueMember = "id_usuario";



        }
        private void porcentaje()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_porcentaje();

            cboporcentaje.DataSource = dt;

            cboporcentaje.DisplayMember = "descripcion";




        }



        private void forma()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_forma();

            cboforma.DataSource = dt;

            cboforma.DisplayMember = "descripcion";
            cboforma.ValueMember = "id_forma";



        }
        private void documento()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_documento();

            cbodocumento.DataSource = dt;

            cbodocumento.DisplayMember = "tipo";
            cbodocumento.ValueMember = "id_tipo";



        }
        public void autogenerar()
        {





        }

        private void Ultimo()
        {
            cnFacturacion cnper = new cnFacturacion();
            List<Facturacion> per = cnper.UltimoEmp();
            foreach (Facturacion ma in per)
            {
                int codigo = 0;
                codigo = Convert.ToInt32(ma.Codigo);
                codigo = codigo + 1;
                if (codigo < 10)
                {
                    ma.Codigo = "000" + codigo.ToString();
                }
                if (codigo < 100 && codigo > 9)
                {
                    ma.Codigo = "00" + codigo.ToString();
                }
                if (codigo < 1000 && codigo > 99)
                {
                    ma.Codigo = "0" + codigo.ToString();
                }
                txtfactura.Text = ma.Codigo;
            }
        }


        private void Frm_Facturacion_Load(object sender, EventArgs e)
        {
            txthora.Text = System.DateTime.Now.ToLongTimeString();
            //autogenerar();
            Ultimo();

            porcentaje();


            forma();
            usuario();
            documento();

            cboforma.Text = "";

            panel1.Visible = false;
            panel2.Visible = false;

            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;


        }

        private bool VerificarProductoExistente(string codigoProducto)
        {
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == codigoProducto)
                {
                    return true;
                }
            }
            return false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int stock = int.Parse(txtstock.Text);
            int cantidad;

            if (!int.TryParse(txtcantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero mayor a 0", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad es mayor al stock", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double total = 0, porcentaje = 0, subtotal = 0, igv;
            porcentaje = Convert.ToDouble(cboporcentaje.Text);

            int rowEscribir = -1;
            // Recorremos todas las filas para verificar si el producto ya existe
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                // Si encontramos una fila con el mismo código de producto, actualizamos la cantidad
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == this.txtcodigoproducto.Text)
                {
                    int nuevaCantidad = int.Parse(row.Cells[4].Value.ToString()) + int.Parse(this.txtcantidad.Text);
                    // Verificamos que la nueva cantidad no exceda el stock
                    if (cantidad > stock)
                    {
                        MessageBox.Show("La cantidad es mayor al stocks", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Actualizamos la cantidad y el importe de la fila existente
                    row.Cells[4].Value = nuevaCantidad;
                    row.Cells[5].Value = (nuevaCantidad * double.Parse(this.txtprecio.Text)).ToString();
                    rowEscribir = row.Index;
                    break;
                }
            }

            // Si no encontramos una fila con el mismo código de producto, agregamos una nueva fila
            if (rowEscribir == -1)
            {
                rowEscribir = dgDatos.Rows.Count - 1;
                dgDatos.Rows.Add(1);
                dgDatos.Rows[rowEscribir].Cells[0].Value = this.txtfactura.Text;
                dgDatos.Rows[rowEscribir].Cells[1].Value = this.txtcodigoproducto.Text;
                dgDatos.Rows[rowEscribir].Cells[2].Value = this.txtproducto.Text;
                dgDatos.Rows[rowEscribir].Cells[3].Value = this.txtprecio.Text;
                dgDatos.Rows[rowEscribir].Cells[4].Value = this.txtcantidad.Text;
                dgDatos.Rows[rowEscribir].Cells[5].Value = this.txtimporte.Text;
            }

            // Actualizamos el stock restante
            stock -= cantidad;
            txtstock.Text = stock.ToString();

            // Recalculamos los totales
            subtotal = 0;
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells["importe"].Value);
            }
            total = total + subtotal;

            igv = subtotal * porcentaje / 100;

            subtotal = subtotal - igv;

            txtigv.Text = igv.ToString("0.00");
            txtsubtotal.Text = subtotal.ToString("0.00");
            txttotal.Text = total.ToString("0.00");

            Button4.Enabled = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir de Registro Facturacion ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {


                decimal a, b, total;




                a = decimal.Parse(txtprecio.Text);
                b = decimal.Parse(txtcantidad.Text);


                total = a * b;

                txtimporte.Text = total.ToString();


                Button2.Enabled = true;
                Button3.Enabled = true;
                Button4.Enabled = true;



            }
            catch (Exception)
            {

            }

        }
        private void listado_producto()
        {
            DataTable dt = new DataTable();
            String dato = textBox1.Text;
            dt = listaproducto_neg.Buscar(dato);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Estado = 'Activo'";
            DataTable dtFiltrado = dv.ToTable();

            grillaproducto.DataSource = dtFiltrado;

        }
        private void listado_cliente()
        {
            DataTable dt = new DataTable();
            String dato = txtconsultar.Text;
            dt = listacliente_neg.Buscar(dato);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Estado = 'Activo'";
            DataTable dtFiltrado = dv.ToTable();

            gdvCliente.DataSource = dtFiltrado;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listado_producto();

        }

        private void txtconsultar_TextChanged(object sender, EventArgs e)
        {
            listado_cliente();


        }

        private void grillaproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigoProducto = grillaproducto.CurrentRow.Cells["codigo"].Value.ToString();

            if (VerificarProductoExistente(codigoProducto))
            {

                MessageBox.Show("El producto ya ha sido agregado a la lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2.Visible = false;
                return;
            }

            txtcodigoproducto.Text = grillaproducto.CurrentRow.Cells["codigo"].Value.ToString();

            txtproducto.Text = grillaproducto.CurrentRow.Cells["producto"].Value.ToString();

            txtprecio.Text = grillaproducto.CurrentRow.Cells["precio_venta"].Value.ToString();

            txtstock.Text = grillaproducto.CurrentRow.Cells["stock"].Value.ToString();

            txtmarca.Text = grillaproducto.CurrentRow.Cells["marca"].Value.ToString();
            txtcategoria.Text = grillaproducto.CurrentRow.Cells["categoria"].Value.ToString();

            panel2.Visible = false;






        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            listado_producto();
            txtcantidad.Text = "";
            txtimporte.Text = "";

            textBox1.Text = "";



        }

        private void Button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listado_cliente();

            txtconsultar.Text = "";

        }

        private void gdvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo_cliente.Text = gdvCliente.CurrentRow.Cells["codigo"].Value.ToString();

            txtcliente.Text = gdvCliente.CurrentRow.Cells["cliente"].Value.ToString();

            txtdireccion.Text = gdvCliente.CurrentRow.Cells["direccion"].Value.ToString();
            txttelefono.Text = gdvCliente.CurrentRow.Cells["telefono"].Value.ToString();

            panel1.Visible = false;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcantidad.Text.Length == 10 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La cantidad solo puede tener hasta 10 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtobservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtobservacion.Text.Length == 50 && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("La observacion solo debe tener 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '/' && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '"' && e.KeyChar != '-' && e.KeyChar != '%')
            {
                // Si la tecla no es válida, indicar que no debe procesarse
                MessageBox.Show("Caracteres invalidos para observacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
