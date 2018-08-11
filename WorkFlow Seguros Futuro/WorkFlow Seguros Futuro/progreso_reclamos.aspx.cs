//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
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
using System.Configuration;
using System.Drawing;
using System.Text; // StringBuilder

namespace WorkFlow_Seguros_Futuro
{
    public partial class progreso_reclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Buscar_Click(null, null);


        }

        protected void Buscar_Click(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            sql += "    select wf.correlativo,wf.asegurado, wf.Estado,(wf.Puntos *0.01) Puntos,case when area ='RECEPCION' then DATEDIFF(DAY,convert(date,ingresado,101),convert(date,getdate(),101)) ";
            sql += "    when area ='RECLAMOS' then DATEDIFF(DAY,convert(date,ingresado,101),convert(date,getdate(),101)) ";
            sql += "     when area ='ATENCION AL CLIENTE' then DATEDIFF(DAY,convert(date,ingresado,101),convert(date,f_rec_cliente,101)) ";
            sql += "     when Estado ='COMPLETADO' then DATEDIFF(DAY,convert(date,ingresado,101),convert(date,f_rec_cliente,101)) end as dias  ";
            sql += "     from wf_seguimiento_95 wf ";
            sql += " 	  where cod_area=02 ";

            //if (this.TextFieldContadorB.Text.Length > 0)
            //{
            //    sql += " AND correlativo=@correlativo";
            //    cmd.Parameters.AddWithValue("@correlativo", this.TextFieldContadorB.Text);
            //}

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            //this.Store1.Show();
            this.Store1.DataSource = datatable;
            this.Store1.DataBind();

        }
        //[DirectMethod]
        //public static string GetGrid(Dictionary<string, string> parameters)
        //{

        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string JsonRecord = parameters["id"];
        //    Dictionary<string, string>[] GridData = JSON.Deserialize<Dictionary<string, string>[]>(JsonRecord);


        //    string correlativo;

        //    correlativo = GridData[0]["correlativo"];


        //    string sql_detalle = "";

        //    sql_detalle += " select wf.correlativo, case when ej.recepcion is null then DATEDIFF(DAY,convert(date,ej.ingreso,101),convert(date,getdate(),101))  ";
        //    sql_detalle += " else DATEDIFF(DAY,convert(date,ej.ingreso,101),convert(date,ej.recepcion,101)) end as recepcion,  ";
        //    sql_detalle += " case when ej.analisis is null then DATEDIFF(DAY,convert(date,ej.recepcion,101),convert(date,getdate(),101)) when ej.analisis is null and ej.recepcion is null then 0  ";
        //    sql_detalle += "  else DATEDIFF(DAY,convert(date,ej.recepcion,101),convert(date,ej.analisis,101)) end as analisis, ";
        //    sql_detalle += " case when ej.emision is null then DATEDIFF(DAY,convert(date,ej.analisis,101),convert(date,getdate(),101)) when ej.emision is null and ej.analisis is null then 0  ";
        //    sql_detalle += " else DATEDIFF(DAY,convert(date,ej.analisis,101),convert(date,ej.emision,101)) end as emision,  ";
        //    sql_detalle += " case when ej.firmas is null then DATEDIFF(DAY,convert(date,ej.emision,101),convert(date,getdate(),101)) when ej.firmas is null and ej.emision is null then 0   ";
        //    sql_detalle += "  else DATEDIFF(DAY,convert(date,ej.emision,101),convert(date,ej.firmas,101)) end as firmas, ";
        //    sql_detalle += "  case when ej.entrega is null then DATEDIFF(DAY,convert(date,ej.firmas,101),convert(date,getdate(),101)) when ej.entrega is null and ej.firmas is null then 0 ";
        //    sql_detalle += "  else DATEDIFF(DAY,convert(date,ej.firmas,101),convert(date,ej.entrega,101)) end as entrega, ";
        //    sql_detalle += " case when ej.atencion_cliente is null then DATEDIFF(DAY,convert(date,ej.entrega,101),convert(date,getdate(),101)) when ej.atencion_cliente is null and ej.entrega is null then 0  ";
        //    sql_detalle += " else DATEDIFF(DAY,convert(date,ej.entrega,101),convert(date,ej.atencion_cliente,101)) end as atencion_cliente,  ";
        //    sql_detalle += " case  when ej.completado is null then  0  ";
        //    sql_detalle += " else DATEDIFF(DAY,convert(date,ej.ingreso,101),convert(date,ej.completado,101)) end as completado  ";
        //    sql_detalle += "  from wf_seguimiento_95 wf ";
        //    sql_detalle += " inner join dbo. ejecucion ej on  ej.correlativo=wf.correlativo  ";
        //    sql_detalle += " where wf.correlativo = @correlativo  ";


        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandTimeout = 36000;
        //    cmd.CommandText = sql_detalle;
        //    cmd.Parameters.AddWithValue("@correlativo", correlativo);
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataTable datatable = new DataTable();
        //    da.Fill(datatable);

        //    con.Close();

        //    GridPanel grid = new GridPanel
        //    {
        //        Layout = "AutoLayout",
        //        RowLines = true,
        //        EnableColumnHide = false,
        //        Store = 
        //    { 

        //        new Store 
        //        { 
        //            Model = {

        //                new Model {

        //                    Fields = 
        //                    {
        //                        new ModelField("correlativo"),
        //                        new ModelField("recepcion"),
        //                        new ModelField("analisis"),
        //                        new ModelField("emision"),
        //                        new ModelField("firmas"),
        //                        new ModelField("entrega"),
        //                        new ModelField("atencion_cliente"),
        //                        new ModelField("completado")

        //                    }
        //                }
        //            },
        //            DataSource = datatable
        //        }
        //    },
        //        ColumnModel =
        //        {
        //            Columns = 
        //        { 
        //            new Column { Text = "correlativo",  DataIndex = "correlativo",   Width=100 },
        //            new Column { Text = "Recepcion",     DataIndex = "recepcion",      Width=100},
        //            new Column { Text = "Analisis",    DataIndex = "analisis",       Width=100},
        //            new Column { Text = "Emision",  DataIndex = "emision",    Width=100},
        //            new Column { Text = "Firmas",  DataIndex = "firmas",   Width=100},
        //            new Column { Text = "Entrega",  DataIndex = "entrega",   Width=100},
        //            new Column { Text = "Atencion al Cliente",  DataIndex = "atencion_cliente",   Width=180},
        //            new Column { Text = "Completado",  DataIndex = "completado",   Width=100},
                    
              
        //        }



        //        },

        //    };

        //    return ComponentLoader.ToConfig(grid);
        //}

        protected void Indicador(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            sql_detalle += "     select correlativo, case when recepcion is null then DATEDIFF(DAY,convert(date,inicio,101),convert(date,getdate(),101)) ";
            sql_detalle += "     else DATEDIFF(DAY,convert(date,inicio,101),convert(date,recepcion,101)) end as recepcion,  ";
            sql_detalle += "    case when revision is null then DATEDIFF(DAY,convert(date,recepcion,101),convert(date,getdate(),101)) ";
            sql_detalle += "    when revision is null and recepcion is null then 0 ";
            sql_detalle += "      else DATEDIFF(DAY,convert(date,recepcion,101),convert(date,revision,101)) end as revision, ";
            sql_detalle += "     case when liquidacion is null then DATEDIFF(DAY,convert(date,revision,101),convert(date,getdate(),101)) ";
            sql_detalle += "    when revision is null and liquidacion is null then 0 ";
            sql_detalle += "     else DATEDIFF(DAY,convert(date,revision,103),convert(date,liquidacion,103)) end as liquidacion, ";
            sql_detalle += "     case when firma_coordinadora is null then DATEDIFF(DAY,convert(date,liquidacion,101),convert(date,getdate(),101)) ";
            sql_detalle += "    when firma_coordinadora is null and liquidacion is null then 0 ";
            sql_detalle += "      else DATEDIFF(DAY,convert(date,liquidacion,101),convert(date,firma_coordinadora,101)) end as firma_coordinadora, ";
            sql_detalle += "      case when firma_g_tecnica is null then DATEDIFF(DAY,convert(date,firma_coordinadora,101),convert(date,getdate(),101)) ";
            sql_detalle += "		 when firma_g_tecnica is null and firma_coordinadora is null then 0 ";
            sql_detalle += "      else DATEDIFF(DAY,convert(date,firma_coordinadora,101),convert(date,firma_g_tecnica,101)) end as firma_g_tecnica, ";
            sql_detalle += "	case when firma_g_financiera is null then DATEDIFF(DAY,convert(date,firma_g_tecnica,101),convert(date,getdate(),101)) ";
            sql_detalle += "    when firma_g_financiera is null and firma_g_tecnica is null then 0 ";
            sql_detalle += "    else DATEDIFF(DAY,convert(date,firma_g_tecnica,101),convert(date,firma_g_financiera,101)) end as firma_g_financiera,  ";
            sql_detalle += "	   case when emision_cheque is null then DATEDIFF(DAY,convert(date,firma_g_financiera,101),convert(date,getdate(),101)) ";
            sql_detalle += "	    when emision_cheque is null and firma_g_financiera is null then 0 ";
            sql_detalle += "      else DATEDIFF(DAY,convert(date,firma_g_financiera,101),convert(date,emision_cheque,101)) end as emision_cheque, ";
            sql_detalle += "	   case when entrega_cheque is null then DATEDIFF(DAY,convert(date,emision_cheque,101),convert(date,getdate(),101)) ";
            sql_detalle += "	    when entrega_cheque is null and emision_cheque is null then 0 ";
            sql_detalle += "       else DATEDIFF(DAY,convert(date,emision_cheque,101),convert(date,entrega_cheque,101)) end as entrega_cheque, ";
            sql_detalle += "	   case when entrega_ate_cliente is null then DATEDIFF(DAY,convert(date,entrega_cheque,101),convert(date,getdate(),101)) ";
            sql_detalle += "	    when entrega_ate_cliente is null and entrega_cheque is null then 0 ";
            sql_detalle += "       else DATEDIFF(DAY,convert(date,entrega_cheque,101),convert(date,entrega_ate_cliente,101)) end as entrega_ate_cliente, ";
            sql_detalle += "	   case  when fin is null then  0 ";
            sql_detalle += "      else DATEDIFF(DAY,convert(date,inicio,101),convert(date,fin,101)) end as completado   ";
            sql_detalle += "      from ejecucion_reclamos ";
            sql_detalle += "     where correlativo = @correlativo   ";  
            //if (this.TextFieldContadorB.Text.Length > 0)
            //{
            //    sql += " AND correlativo=@correlativo";
            //    cmd.Parameters.AddWithValue("@correlativo", this.TextFieldContadorB.Text);
            //}

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            cmd.CommandText = sql_detalle;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCorre.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            //this.Store1.Show();
            this.Store2.DataSource = datatable;
            this.Store2.DataBind();

            this.ResourceManager1.AddScript("#{WindowModificacion}.show()");

        }

        protected void RealizarConsulta_Clickindicador(object sender, DirectEventArgs e)
        {
            string JsonRecord = e.ExtraParams["id"];
            string correlativo;
            Dictionary<string, string>[] GridData = JSON.Deserialize<Dictionary<string, string>[]>(JsonRecord);

            if (GridData.Length > 1 | GridData.Length == 0)
            {
                X.Msg.Confirm("Confirmación", "Seleccione un registro", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();

                return;
            }

            correlativo = GridData[0]["correlativo"];




            this.TextFieldCorre.Text = correlativo.ToString();



            Indicador(null, null);

        }

    }
}