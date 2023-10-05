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
    public partial class Frm_Login : Form
    {


        Entidad.Login_Entidad obje = new Entidad.Login_Entidad();

        Negocio.Login_Neg objn = new Negocio.Login_Neg();


        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            obje.usuario = txtusuario.Text;
            obje.contraseña = txtcontraseña.Text;
            obje.cargo = cbocargo.Text;
            dt = objn.N_login(obje);
            if (dt.Rows.Count > 0)
            {
                string estado = dt.Rows[0]["estado"].ToString();


                if (estado == "Activo")
                {
                    if (this.cbocargo.Text == "Administrador")
                    {
                        obje.usuario = dt.Rows[0][1].ToString();
                        obje.contraseña = dt.Rows[0][2].ToString();
                        obje.cargo = dt.Rows[0][3].ToString();

                        this.Hide();

                        Frm_Menu_Principal abrir = new Frm_Menu_Principal();
                        abrir.Show();
                    }
                    else if (this.cbocargo.Text == "Supervisor")
                    {
                        obje.usuario = dt.Rows[0][1].ToString();
                        obje.contraseña = dt.Rows[0][2].ToString();
                        obje.cargo = dt.Rows[0][3].ToString();

                        this.Hide();

                        Frm_Supervisor abrir = new Frm_Supervisor();
                        abrir.Show();
                    }
                    else if (this.cbocargo.Text == "Vendedor")
                    {
                        obje.usuario = dt.Rows[0][1].ToString();
                        obje.contraseña = dt.Rows[0][2].ToString();
                        obje.cargo = dt.Rows[0][3].ToString();

                        this.Hide();

                        Frm_Vendedor abrir = new Frm_Vendedor();
                        abrir.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Los datos que ingreso son incorrectos o la cuenta esta inactiva", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Login ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }
    }
}
