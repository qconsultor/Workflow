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
    public partial class wf_vista_reclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Grid(null, null);
        }

        private void Grid(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            sql_quejas_det += "Select * from wf_seguimiento_95 where area = 'Reclamos'";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
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

        //protected void Actualizar_Click(object sender, DirectEventArgs e)
        //{

        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string sql = "";
        //    sql += "update wf_seguimiento_95 set f_docompleta=@f_docompleta,f_emision=@f_emision,f_e_firmas=@f_e_firmas,f_ate_cliente=@f_ate_cliente,tipo_wf=@tipo_wf,area=@area where correlativo=@correlativo";
        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sql.ToString();
        //    cmd.Connection = con;
        //    cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
        //    cmd.Parameters.AddWithValue("@tipo_wf", this.ComboBox1.SelectedItem.Text);
        //    cmd.Parameters.Add("@area", SqlDbType.NVarChar, 150, "area").Value = (this.ComboBox2.SelectedItem.Value == null ? DBNull.Value.ToString() : this.ComboBox2.SelectedItem.Value);
        //    cmd.Parameters.Add("@f_docompleta", SqlDbType.Date, 10, "F_docompleta").Value = (this.DateField1.SelectedValue == null ? DBNull.Value.ToString() : this.DateField1.SelectedValue);
        //    cmd.Parameters.Add("@f_emision", SqlDbType.Date, 10, "f_emision").Value = (this.DateField2.SelectedValue == null ? DBNull.Value : this.DateField2.SelectedValue);
        //    cmd.Parameters.Add("@f_e_firmas", SqlDbType.Date, 10, "f_e_firmas").Value = (this.DateField3.SelectedValue == null ? DBNull.Value : this.DateField3.SelectedValue);
        //    cmd.Parameters.Add("@f_ate_cliente", SqlDbType.Date, 10, "f_ate_cliente").Value = (this.DateField4.SelectedValue == null ? DBNull.Value : this.DateField4.SelectedValue);



        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();
        //    con.Close();




        //    X.Msg.Alert("Notificación", "Los datos han sido guardados", new MessageBoxButtonsConfig
        //    {

        //        Ok = new MessageBoxButtonConfig
        //        {
        //            Text = "Ok"

        //        }
        //    }).Show();
        //    Response.Redirect("wf_reclamos.aspx");
        //    this.ResourceManager.AddScript("#{TextFieldCodigo}.getForm().reset();");
        //    this.ResourceManager.AddScript("#{GridPanel1}.getForm().reset();");



        //}

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
            string correlativo, area;
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
            



            this.TextFieldCodigo.Text = correlativo.ToString();
            Cargar_Combo_pasos();
            this.ResourceManager.AddScript("#{WindowModificacion}.show()");

        }

        protected void Cargar_Combo_pasos()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " select usuario,nombre from Usuarios where area='RECLAMOS' ";
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