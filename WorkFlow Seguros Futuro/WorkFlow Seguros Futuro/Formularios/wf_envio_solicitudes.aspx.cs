using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class wf_envio_solicitudes : System.Web.UI.Page
    {

        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CargarHistorial(object sender, DirectEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select area,correlativo,asegurado,plan_,cantidadsolicitudes,che_envio,en_re_at,ref_en_re_at,che_recibido,f_desti from [dbo].[wf_seguimiento_95] where cod_area='01' and che_envio=0 order by cast(correlativo as int) ";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreMalla.DataSource = dataTable;
            this.StoreMalla.DataBind();
        }

        protected void histo(object sender, DirectEventArgs e)
        {
            CargarHistorial_("01", this.TextFieldNumero.Text);
        }

        protected void CargarHistorial_(String cod_area,String reffe)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select area,correlativo,asegurado,plan_,cantidadsolicitudes,che_envio,en_re_at,ref_en_re_at,che_recibido,f_desti from [dbo].[wf_seguimiento_95] where cod_area=@cod_area and ref_en_re_at=@reffe order by cast(correlativo as int) ";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Parameters.AddWithValue("@reffe", reffe);
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreMalla.DataSource = dataTable;
            this.StoreMalla.DataBind();
        }

        protected void Enviado(object sender, DirectEventArgs e)
        {
            if (this.TextFieldNumero.Text == "")
            {
                X.Msg.Alert("Notificación", "Digite # de Referencia y Fecha", new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }
                }).Show();
            }
            else
            {
                    StringBuilder result = new StringBuilder();
                result.Append("<b>Registros Seleccionados</b></br /><ul>");
                RowSelectionModel sm = this.GridPanelMalla.SelectionModel.Primary as RowSelectionModel;

                foreach (SelectedRow row in sm.SelectedRows)
                {
                    Actualizar_ClickPendiente(this.TextFieldNumero.Text, Convert.ToString(this.DateFieldFecha.SelectedDate), row.RecordID);
                    result.Append("<li> Corralativo" + row.RecordID + "</li>");

                }   

            }
        }

        

        protected void Actualizar_ClickPendiente(string referencia, string fecha, string correlativo)
        {

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("sp_ref_en_re_at_indicadores", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 36000;
                sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
                sqlCommand.Parameters.AddWithValue("@en_re_at", fecha);
                sqlCommand.Parameters.AddWithValue("@ref_en_re_at", referencia);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();
        }






        protected void recibido_AT(object sender, DirectEventArgs e)
        {
            if (this.TextFieldNumero.Text == "")
            {
                X.Msg.Alert("Notificación", "Digite # de Referencia y Fecha", new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }
                }).Show();
            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.Append("<b>Registros Seleccionados</b></br /><ul>");
                RowSelectionModel sm = this.GridPanelMalla.SelectionModel.Primary as RowSelectionModel;

                foreach (SelectedRow row in sm.SelectedRows)
                {
                    Actualizar_ClickPendiente_(this.DateFieldFecha.SelectedDate, row.RecordID,this.TextFieldNumero.Text);
                    result.Append("<li> Corralativo" + row.RecordID + "</li>");

                }

            }
        }



        protected void Actualizar_ClickPendiente_(DateTime fecha, string correlativo, string refef)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_ref_en_re_at_indicadores_recibido", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
            sqlCommand.Parameters.AddWithValue("@F_DESTI", fecha);
            sqlCommand.Parameters.AddWithValue("@refef", refef);
           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();
        }


        //protected void Imprimir_Click(object sender, DirectEventArgs e)
        //{

        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

        //    SqlConnection con = new SqlConnection(strCon);
        //    SqlCommand cmd = new SqlCommand("sp_reporte_sondeo_asistencia", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@del", this.DateFieldfechainicio.SelectedDate);
        //    cmd.Parameters.AddWithValue("@al", this.DateFieldfechafin.SelectedDate);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataTable datatable = new DataTable();
        //    da.Fill(datatable);

        //    ReportDocument crystalReport = new ReportDocument();
        //    crystalReport.Load(Server.MapPath("../Reportes/Informe_sondeo_asistencia2.rpt"));
        //    crystalReport.SetDataSource(datatable);
        //    crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Archivos/Informe_sondeo_asistencia2.pdf"));

        //    this.WindowSolicitudes.Show();

        //    string url;
        //    url = "~/Reporte_HTML/rpt_sondeo_asistencia.html";


        //    this.WindowSolicitudes.LoadContent(new ComponentLoader()
        //    {
        //        Url = url.ToString(),
        //        Mode = LoadMode.Frame,
        //        AutoLoad = true
        //    });

        //}
    
    }
}