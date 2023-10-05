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
    public partial class Frm_Reporte_Factuarcion_Fecha : Form
    {
        public Frm_Reporte_Factuarcion_Fecha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            ParameterField param = new ParameterField();

            param.ParameterFieldName = "@fecha";

            ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();


            discreteValue.Value = dtfecha.Text;
            param.CurrentValues.Add(discreteValue);


            ParameterFields paramFiels = new ParameterFields();

            paramFiels.Add(param);


            crystalReportViewer1.ParameterFieldInfo = paramFiels;


            Frm_VInforme_Facturacion_Fecha report = new Frm_VInforme_Facturacion_Fecha();



            crystalReportViewer1.ReportSource = report;
        }
    }
}
