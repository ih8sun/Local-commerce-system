using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Data.SqlClient;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Presentacion
{
    public partial class Frm_Reporte_Compras : Form
    {
        public Frm_Reporte_Compras()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_Compras_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe Ingresar N° Compra ", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {


                ParameterField param = new ParameterField();

                param.ParameterFieldName = "@id_compra";

                ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();


                discreteValue.Value = textBox1.Text;
                param.CurrentValues.Add(discreteValue);


                ParameterFields paramFiels = new ParameterFields();

                paramFiels.Add(param);


                crystalReportViewer1.ParameterFieldInfo = paramFiels;

                Frm_VInforme_Compras report = new Frm_VInforme_Compras();



                crystalReportViewer1.ReportSource = report;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 4 && e.KeyChar != (char)Keys.Back)
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
