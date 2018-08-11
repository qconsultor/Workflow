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
using System.IO;
using System.Text;

namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_entrega_p_AC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid(null, null);
            
        }

        private void Grid(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            sql_quejas_det += " SELECT re.correlativo,re.fecha,re.area,re.cooperativa,re.plan_,re.tipodepoliza,re.observaciones,re.asegurado, ";
            sql_quejas_det += " CONVERT(date,re.f_e_firmas,101) f_e_firmas, CONVERT(date,re.f_ate_cliente,101) f_ate_cliente,CONVERT(date,re.f_docompleta,101) f_docompleta ";
            sql_quejas_det += " FROM wf_seguimiento_95 AS re  ";
            sql_quejas_det += " Where  area ='EMISION' and estado_envio='ENVIO' and 1=1";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50000;
            cmd.CommandText = sql_quejas_det;


            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.Store1.DataSource = datatable;
            this.Store1.DataBind();

            this.GridPanel1.Show();

        }



        private void CargarCorrelativo()
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(correlativo),0) +1 correlativo FROM dbo.wf_seguimiento_95", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextFieldCodigo.Text = (reader["correlativo"].ToString());
            }

        }

        protected void RealizarConsulta_Click(object sender, DirectEventArgs e)
        {
            //string JsonRecord = e.ExtraParams["id"];
            //string correlativo;
            //Dictionary<string, string>[] GridData = JSON.Deserialize<Dictionary<string, string>[]>(JsonRecord);

            //if (GridData.Length > 1 | GridData.Length == 0)
            //{
            //    X.Msg.Confirm("Confirmación", "Seleccione un registro", new MessageBoxButtonsConfig
            //    {

            //        Ok = new MessageBoxButtonConfig
            //        {
            //            Text = "Ok"
            //        }
            //    }).Show();

            //    return;
            //}

            //correlativo = GridData[0]["correlativo"];
            //this.TextFieldCodigo.Text = correlativo.ToString();
            //System.Threading.Thread.Sleep(3600);
            //Cargar_Combo_pasos();
            this.ResourceManager.AddScript("#{WindowModificacion}.show()");


        }

       

        protected void Actualizar_ClickPendiente(string asignado, string correlativo)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update wf_seguimiento_95 set estado_envio='ATC',ref_en_re_at=@referencia,f_desti=getdate(), area='ATENCION AL CLIENTE' where correlativo=@correlativo ";
            // sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            //cmd.Parameters.AddWithValue("@asignado", this.ComboBoxPasos.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@correlativo", correlativo);
            cmd.Parameters.AddWithValue("@referencia", asignado);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            X.Msg.Alert("Notificación", ToString(), new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

            Response.Redirect("wf_entrega_p_AC.aspx");


        }

        protected void Actualizar_Click(object sender, DirectEventArgs e)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<b>Registros Seleccionados</b></br /><ul>");
            RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;

            foreach (SelectedRow row in sm.SelectedRows)
            {
                Actualizar_ClickPendiente(this.TextFieldCorrelativo.Text, row.RecordID);
                result.Append("<li> Corralativo de envio" + row.RecordID + "</li>");

            }

            result.Append("</ul>");


            X.Msg.Alert("Notificación", result.ToString(), new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

            Response.Redirect("wf_seguimiento_emision.aspx");

        }

    }
}