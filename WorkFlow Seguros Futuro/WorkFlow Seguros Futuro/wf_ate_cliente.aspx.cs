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
    public partial class wf_ate_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid(null,null);
        }

        private void Grid(object sender, EventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            sql_quejas_det += "Select * from wf_seguimiento_95 where area = 'ATENCION AL CLIENTE'";


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

        protected void RealizarConsulta_Click(object sender, DirectEventArgs e)
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
           


            this.TextFieldCodigo.Text = correlativo.ToString();
            Cargar_Combo_pasos();

            this.ResourceManager.AddScript("#{WindowModificacion}.show()");

        }

        protected void Actualizar_Click(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += "update wf_seguimiento_95 set f_ate_cliente=@f_ate_cliente where correlativo=@correlativo ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            
            //cmd.Parameters.Add("@f_ate_cliente", SqlDbType.Date, 10, "f_ate_cliente").Value = (this.DateField4.SelectedValue == null ? DBNull.Value : this.DateField4.SelectedValue);



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
            Response.Redirect("wf_ate_cliente.aspx");
            this.ResourceManager.AddScript("#{TextFieldCodigo}.getForm().reset();");
            this.ResourceManager.AddScript("#{GridPanel1}.getForm().reset();");



        }

        protected void Cargar_Combo_pasos()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " select req_cod,RTRIM(req_nombre) req_nombre from Check_list_detalle_porcentaje where area like '%ATENCION AL CLI%' and correlativo=@correlativo and necesario is null ";
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
            sql += " update check_list_detalle_porcentaje set necesario=1 where correlativo=@correlativo and req_cod=@req_cod ";
            sql += " update wf_seguimiento_95 set Estado='COMPLETADO',f_ate_cliente=getdate(),f_reci_atc=getdate(), Puntos=(select sum(puntos) from Check_list_detalle_porcentaje where necesario=1 and correlativo=@correlativo) where correlativo=@correlativo";
            sql += " update ejecucion set atencion_cliente=getdate(), completado=getdate() where correlativo=@correlativo  ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@req_cod", this.ComboBoxPasos.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@req_nombre", this.ComboBoxPasos.SelectedItem.Text);


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