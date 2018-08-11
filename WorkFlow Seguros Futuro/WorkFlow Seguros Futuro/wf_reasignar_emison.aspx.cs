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

namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_reasignar_emison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid(null, null);

        }

        private void Grid(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            //sql_quejas_det += " SELECT re.correlativo,re.fecha,re.area,re.cooperativa,re.plan_,re.tipodepoliza,re.observaciones,re.asegurado, ";
            //sql_quejas_det += " CONVERT(date,re.f_e_firmas,101) f_e_firmas, CONVERT(date,re.f_ate_cliente,101) f_ate_cliente,CONVERT(date,re.f_docompleta,101) f_docompleta, re.Asignado ";
            //sql_quejas_det += " FROM wf_seguimiento_95 AS re  ";
           
            //sql_quejas_det += " Where  area ='EMISION' and asignado is not null and 1=1";

            sql_quejas_det += " SELECT re.correlativo,re.fecha,re.area,re.cooperativa,re.plan_,re.tipodepoliza,LI.Poliza_Maestra,re.observaciones,re.asegurado,CONVERT(date,LI.Fecha_Emision,103) as f_emision, ";
            sql_quejas_det += " CONVERT(date,re.f_e_firmas,101) f_e_firmas, CONVERT(date,re.f_ate_cliente,101) f_ate_cliente,CONVERT(date,re.f_docompleta,101) f_docompleta, re.Asignado ";
            sql_quejas_det += " FROM wf_seguimiento_95 AS re  ";
            sql_quejas_det += " LEFT JOIN LINKED.FUTUROSIS_DAT.dbo.vw_controldocumental_wf AS LI ON LI.ControlDocumental  = re.correlativo COLLATE Modern_Spanish_CI_AS ";
            sql_quejas_det += " Where  area ='EMISION' and asignado is not null and 1=1";


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
            string JsonRecord = e.ExtraParams["id"];
            string correlativo, area, tipo_wf, f_docompleta, f_emision, f_e_firmas, f_ate_cliente;
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
            area = GridData[0]["area"];
            tipo_wf = GridData[0]["tipo_wf"] = String.Empty;
            f_docompleta = GridData[0]["f_docompleta"] = String.Empty;
            f_emision = GridData[0]["f_emision"] = String.Empty;
            f_e_firmas = GridData[0]["f_e_firmas"] = String.Empty;
            f_ate_cliente = GridData[0]["f_ate_cliente"] = String.Empty;



            this.TextFieldCodigo.Text = correlativo.ToString();
            //this.ComboBox2.Text = area.ToString();
            //this.ComboBox1.Text = tipo_wf.ToString();
            //this.DateField1.Text = f_docompleta.ToString();
            //this.DateField2.Text = f_emision.ToString();
            //this.DateField3.Text = f_e_firmas.ToString();
            //this.DateField4.Text = f_ate_cliente.ToString();
            Cargar_Combo_pasos();
            System.Threading.Thread.Sleep(3600);
            this.ResourceManager.AddScript("#{WindowModificacion}.show()");


        }

        protected void Cargar_Combo_pasos()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " select usuario,nombre from Usuarios where area='Area Tecnica' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.StorePasos.DataSource = datatable;
            this.StorePasos.DataBind();
        }

        protected void Actualizar_ClickPendiente(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update wf_seguimiento_95 set asignado=@asignado where correlativo=@correlativo ";
            // sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@asignado", this.ComboBoxPasos.SelectedItem.Value);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();




            X.Msg.Alert("Notificación", "Los datos han sido guardados", new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

            System.Threading.Thread.Sleep(3600);

        }


    }
}