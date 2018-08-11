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

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class reclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx", true);
            }
            else
            {
                this.TextFieldUSuario.Text = Session["usuario"].ToString();

            }
           Grid(null, null);
            //System.Diagnostics.Process.Start("\\SF_PAR\adquisiciones\adquisiciones_net.exe");
        }

        private void Grid(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";

            sql_quejas_det += " SELECT re.correlativo,re.fecha_destino,re.area,re.cooperativa,re.plan_,poliza,re.tipodepoliza,re.observaciones,re.asegurado,re.estado_tiempo, ";
            sql_quejas_det += " CONVERT(date,re.f_e_firmas,101) f_e_firmas, CONVERT(date,re.f_ate_cliente,101) f_ate_cliente,CONVERT(date,re.f_docompleta,101) f_docompleta,re.nautorizacion ";
            sql_quejas_det += " FROM wf_seguimiento_95 AS re  ";
            sql_quejas_det += " Where  cod_area in ('02','03') and estado<>'ATENCION AL CLIENTE' and asignado=@asignado and 1=1 order by cast(correlativo as int) ";
            // 

            //sql_quejas_det += " SELECT distinct re.correlativo,re.fecha_destino,re.area,re.cooperativa,re.plan_,re.tipodepoliza,LI.Poliza_Maestra,re.poliza,re.asegurado,re.estado_tiempo,CONVERT(date,LI.Fecha_Emision,103) as f_emision, ";
            //sql_quejas_det += " CONVERT(date,re.f_e_firmas,101) f_e_firmas, CONVERT(date,re.f_ate_cliente,101) f_ate_cliente,CONVERT(date,re.f_docompleta,101) f_docompleta,re.nautorizacion ";
            //sql_quejas_det += " FROM wf_seguimiento_95 AS re  ";
            //sql_quejas_det += " LEFT JOIN LINKED.FUTUROSIS_DAT.dbo.vw_controldocumental_wf AS LI ON LI.ControlDocumental  = re.correlativo COLLATE Modern_Spanish_CI_AS ";
            //sql_quejas_det += " Where  cod_area in ('02','03') and estado<>'ATENCION AL CLIENTE' and asignado=@asignado and 1=1 order by cast(correlativo as int) ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50000;
            cmd.CommandText = sql_quejas_det;


            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@asignado", this.TextFieldUSuario.Text);
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
            string correlativo, area, tipo_wf, f_docompleta, f_emision, f_e_firmas, f_ate_cliente, estado_tiempo, nautori;
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
            estado_tiempo = GridData[0]["estado_tiempo"];


            this.TextFieldCodigo.Text = correlativo.ToString();
            this.ComboBox2.Text = area.ToString();
            this.ComboBox4.Text = estado_tiempo.ToString();
            //this.ComboBox1.Text = tipo_wf.ToString();
            //this.DateField1.Text = f_docompleta.ToString();
            //this.DateField2.Text = f_emision.ToString();
            //this.DateField3.Text = f_e_firmas.ToString();
            //this.DateField4.Text = f_ate_cliente.ToString();;
            Cargar_Combo_pasos();
            Cargar_Combo_pasosFin();
            Cargar_Combo_Asignar();
            GridComentarios(null,null);
            //Mostrar(null,null);
            //System.Threading.Thread.Sleep(3600);
            this.ResourceManager.AddScript("#{WindowModificacion}.show()");
            

        }

        private void GridComentarios(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";

            sql_quejas_det += " select correlativo,usuario,fecha,comentarios from wf_comentarios where correlativo=@correlativo ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50000;
            cmd.CommandText = sql_quejas_det;


            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.Store4.DataSource = datatable;
            this.Store4.DataBind();

            this.GridPanel2.Show();

        }

        protected void Cargar_Combo_pasos()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " select paso from ejecucion_reclamos_ where inicio is null and correlativo=@correlativo order by codigo";
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
        protected void Cargar_Combo_pasosFin()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " select paso from ejecucion_reclamos_ where fin is null and correlativo=@correlativo order by codigo";
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

            this.Store2.DataSource = datatable;
            this.Store2.DataBind();
        }

        protected void TransferirParametros(object sender, DirectEventArgs e)
        {

            String Valor = this.TextFieldCodigo.Text;

           // Response.Redirect("webform2.aspx?Valor=" + Valor);
                  
        
       }

        protected void Verificador(object sender, DirectEventArgs e)
        {

            if (!String.IsNullOrEmpty(this.ComboBox1.Text))
            {
                Actualizar_Click(null,null);
            }
            if (!String.IsNullOrEmpty(this.ComboBoxPasos.Text))
            {
                Actualizar_Inicio(null,null);
            }

            //Response.Redirect("emision.aspx", true);
            this.ComboBoxPasos.Text = "";
            this.ComboBox1.Text = "";
            Cargar_Combo_pasos();
            Cargar_Combo_pasosFin();
            Cargar_Combo_Asignar();
        }

        protected void ocultar(object sender, DirectEventArgs e)
        {
            if (this.ComboBoxPasos.SelectedItem.Text == "FIRMA")
            {
                this.ComboBox3.Show();
                
                this.ComboBox1.Hide();

            }
            else
            {
                this.ComboBox3.Hide();
                

            }
           
        }

        protected void Cargar_Combo_Asignar()
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

            this.Store3.DataSource = datatable;
            this.Store3.DataBind();
        }

        protected void Actualizar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("sp_Modificar_progreso_Reclamos_", con);// Este es el nombre del SP en la base
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 36000;
                cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
                cmd.Parameters.AddWithValue("@autori", this.ComboBox5.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@req_cod", this.ComboBoxPasos.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@req_nombre", this.ComboBox1.SelectedItem.Text);

                if (this.ComboBox2.Text == "RECLAMOS VIDA")
                {
                    cmd.Parameters.AddWithValue("@cod_area", "02");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cod_area","03");
                }
               

                //cmd.Parameters.AddWithValue("@area1", this.ComboBox2.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                da.Fill(datatable);

                con.Close();
                X.Msg.Confirm("Confirmación", "Datos han sido guardados exitosamente", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();


            }
            catch (Exception ex)
            {
                X.Msg.Confirm("Error", ex.ToString(), new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();

                
            }
        }
        protected void Actualizar_ClickPendiente(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update wf_seguimiento_95 set area=@area, f_rec_cliente=getdate(), Estado='ATENCION AL CLIENTE' where correlativo=@correlativo ";
            //sql += " update ejecucion_reclamos_ set entrega=getdate() where correlativo=@correlativo  ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@area", this.ComboBox2.SelectedItem.Text);
           

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();


            Response.Redirect("~/Formularios/reclamos.aspx");



            X.Msg.Alert("Notificación", "Los datos han sido guardados", new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

            //System.Threading.Thread.Sleep(3600);
            
        }

        protected void Actualizar_Inicio(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update ejecucion_reclamos_ set inicio=getdate() where paso=@req_nombre and correlativo=@correlativo and cod_area=@cod_area";
            //sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";

            
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.ComboBoxPasos.SelectedItem.Text == "FIRMA")
            {
                sql += " update wf_seguimiento_95 set Asignado=@asignado where correlativo=@correlativo ";
                cmd.Parameters.AddWithValue("@asignado", this.ComboBox3.SelectedItem.Value);
            }
            

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@req_nombre", this.ComboBoxPasos.SelectedItem.Text);
            if (this.ComboBox2.Text == "RECLAMOS VIDA")
            {
                cmd.Parameters.AddWithValue("@cod_area", "02");
            }
            else
            {
                cmd.Parameters.AddWithValue("@cod_area", "03");
            }
          
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

         //   System.Threading.Thread.Sleep(3600);
           

        }





        protected void Pausa(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update wf_seguimiento_95 set f_rec_cliente=ingresado, estado_tiempo='PAUSA' where correlativo=@correlativo ";
            sql += " Insert into wf_comentarios (correlativo,comentarios,fecha,usuario) Values (@correlativo,@comentarios,getdate(),@usuario) ";
            //sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@comentarios", this.TextAreaComentarios.Text);
            cmd.Parameters.AddWithValue("@usuario", this.TextFieldUSuario.Text);

            //cmd.Parameters.Add("@origen", SqlDbType.NVarChar, 50, "origen").Value = (this.ComboBoxOrigen.SelectedItem.Value == null ? DBNull.Value.ToString() : this.ComboBoxOrigen.SelectedItem.Value);

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

            //   System.Threading.Thread.Sleep(3600);

            GridComentarios(null, null);
            this.TextAreaComentarios.Text = "";
            this.ComboBox4.Text = "PAUSA";

            
        }

        protected void Play(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update wf_seguimiento_95 set f_rec_cliente=getdate(), ingresado=getdate(), estado_tiempo='ABIERTO' where correlativo=@correlativo ";
            sql += " Insert into wf_comentarios (correlativo,comentarios,fecha,usuario) Values (@correlativo,@comentarios,getdate(),@usuario) ";
            //sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@comentarios", this.TextAreaComentarios.Text);
            cmd.Parameters.AddWithValue("@usuario", this.TextFieldUSuario.Text);

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

            GridComentarios(null, null);
            this.TextAreaComentarios.Text = "";
            this.ComboBox4.Text = "Abierto";

            //   System.Threading.Thread.Sleep(3600);


        }

        //protected void Mostrar(object sender, DirectEventArgs e)
        //{
        //    if (this.ComboBox4.SelectedItem.Text == "Pausa")
        //    {
        //        this.Button5.Hide();

        //        this.Button4.Show();

        //    }
        //    else if (this.ComboBox4.SelectedItem.Text == "Abierto")
        //    {
        //        this.Button5.Show();

        //        this.Button4.Hide();

        //    }
        //    else if (this.ComboBox4.SelectedItem.Text == "RECHAZADA")
        //    {
        //        this.Button5.Hide();

        //        this.Button4.Show();

        //    }

        //}



    }
}