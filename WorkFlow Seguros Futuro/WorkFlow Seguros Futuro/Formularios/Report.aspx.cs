using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Imprimir_Click(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("reporte_reclamos_reporte", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fdesde", this.DateFieldfechainicio.SelectedDate);
            cmd.Parameters.AddWithValue("@fhasta", this.DateFieldfechafin.SelectedDate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("../Reportes/Indicadores.rpt"));
            crystalReport.SetDataSource(datatable);
            crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Reportes/indicadores.pdf"));

            this.WindowSolicitudes.Show();

            string url;
            url = "~/Reporte_HTML/Reporte.html";


            this.WindowSolicitudes.LoadContent(new ComponentLoader()
            {
                Url = url.ToString(),
                Mode = LoadMode.Frame,
                AutoLoad = true
            });

        }






    }
}