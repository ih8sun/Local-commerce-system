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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Presentacion
{
    public partial class Frm_Reporte_Marca : Form
    {


        private Entidad.Producto regActual;



        cnProducto lista_neg = new cnProducto();


        public Frm_Reporte_Marca()
        {
            InitializeComponent();
        }
        private void marca()
        {
            DataTable dt = new DataTable();

            dt = lista_neg.Listar_marca();

            cbomarca.DataSource = dt;

            cbomarca.DisplayMember = "marca";
        


        }
        private void Frm_Reporte_Marca_Load(object sender, EventArgs e)
        {
            marca();
            cbomarca.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ParameterField param = new ParameterField();

            param.ParameterFieldName = "@marca";

            ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();


            discreteValue.Value = cbomarca.Text;
            param.CurrentValues.Add(discreteValue);


            ParameterFields paramFiels = new ParameterFields();

            paramFiels.Add(param);


            crystalReportViewer1.ParameterFieldInfo = paramFiels;


            Frm_VInforme_Marca report = new Frm_VInforme_Marca();



            crystalReportViewer1.ReportSource = report;
        }
    }
}
