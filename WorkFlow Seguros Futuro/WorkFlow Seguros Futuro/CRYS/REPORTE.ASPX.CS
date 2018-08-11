using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace Web_DesktopApplication.Informes
{
    public partial class wf_rpt_sondeo_asistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Imprimir_Click(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("sp_reporte_sondeo_asistencia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@del", this.DateFieldfechainicio.SelectedDate);
            cmd.Parameters.AddWithValue("@al", this.DateFieldfechafin.SelectedDate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("../Reportes/Informe_sondeo_asistencia2.rpt"));
            crystalReport.SetDataSource(datatable);
            crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Archivos/Informe_sondeo_asistencia2.pdf"));

            this.WindowSolicitudes.Show();

            string url;
            url = "~/Reporte_HTML/rpt_sondeo_asistencia.html";


            this.WindowSolicitudes.LoadContent(new ComponentLoader()
            {
                Url = url.ToString(),
                Mode = LoadMode.Frame,
                AutoLoad = true
            });

        }
    }
}