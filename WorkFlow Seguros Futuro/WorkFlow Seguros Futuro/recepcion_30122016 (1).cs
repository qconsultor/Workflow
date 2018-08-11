//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Ext.Net;
//using System.Data;
//using System.Data.SqlClient;
//using System.Xml;
//using System.IO;
//using System.Configuration;
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

namespace WorkFlow_Seguros_Futuro
{
    public partial class recepcion : System.Web.UI.Page
    {
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid(null,null);
            CargarCorrelativo();
        }

        protected void Guardar_Click(object sender, DirectEventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            //string archivo = "";


            //if (FileUploadFieldArchivo.HasFile)
            //{
            //    string FileName = Path.GetFileName(FileUploadFieldArchivo.PostedFile.FileName);
            //    string Extension = Path.GetExtension(FileUploadFieldArchivo.PostedFile.FileName);
            //    string FolderPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];

            //    string FilePath = Server.MapPath(FolderPath + FileName);
            //    FileUploadFieldArchivo.PostedFile.SaveAs(FilePath);

            //    archivo = FolderPath + FileName;
            //}
            //else
            //{
            //    archivo = "0";
            //}


            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("sp_seguimiento_recepcion", con);// Este es el nombre del SP en la base
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            cmd.Parameters.AddWithValue("@tipodepoliza", this.TextFieldTipoPoliza.Text);
            cmd.Parameters.AddWithValue("@area", this.ComboArea.Text);
            cmd.Parameters.AddWithValue("@plan", this.TextFieldPlan_.Text);
            cmd.Parameters.AddWithValue("@cooperativa", this.TextFieldCooperativa.Text);
            cmd.Parameters.AddWithValue("@fecha", this.DateFieldFechaA.SelectedDate);
            cmd.Parameters.AddWithValue("@observaciones", this.TextArea1.Text);
            cmd.Parameters.AddWithValue("@tsolicitud", this.ComboBox1.SelectedItem.Value);//La variable @tsolicitud se declara desde el Procedimiento Almacenado
            //cmd.Parameters.AddWithValue("@imagen", this.FileUploadFieldArchivo.FileBytes);
            //cmd.Parameters.AddWithValue("@nombre", this.Nombre.Text);
            //cmd.Parameters.AddWithValue("@identificacion", this.TextFeildIdenti.Text);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();



            X.Msg.Alert("Notificación", "Datos han sido guardados", new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

            System.Threading.Thread.Sleep(8000);
            

          Response.Redirect("recepcion.aspx");
            

        }

        private void Grid(object sender, EventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            sql_quejas_det += "Select * from wf_seguimiento_95";
            

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

        [DirectMethod]
        public static string GetGrid(Dictionary<string, string> parameters)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string JsonRecord = parameters["id"];
            Dictionary<string, string>[] GridData = JSON.Deserialize<Dictionary<string, string>[]>(JsonRecord);


            string correlativo;

            correlativo = GridData[0]["correlativo"];


            string sql_detalle = "";

            sql_detalle += " SELECT det.correlativo,det.cod_area,det.req_cod,det.req_nombre,det.descripcion ";
            sql_detalle += " FROM dbo.wf_seguimiento_95 AS re  ";
            sql_detalle += " INNER JOIN dbo.check_list_detalle_recpcion AS det ON det.correlativo = @correlativo ";
            sql_detalle += " Where re.correlativo = det.correlativo ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 36000;
            cmd.CommandText = sql_detalle;
            cmd.Parameters.AddWithValue("@correlativo", correlativo);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            GridPanel grid = new GridPanel
            {
                Layout = "FitLayout",
                RowLines = true,
                EnableColumnHide = false,
                Store = 
            { 

                new Store 
                { 
                    Model = {

                        new Model {

                            Fields = 
                            {
                                new ModelField("correlativo"),
                                new ModelField("cod_area"),
                                new ModelField("req_cod"),
                                new ModelField("req_nombre"),
                                new ModelField("descripcion"),

                            }
                        }
                    },
                    DataSource = datatable
                }
            },
                ColumnModel =
                {
                    Columns = 
                { 
                    new Column { Text = "correlativo",  DataIndex = "correlativo",   Width=100},
                    new Column { Text = "cod_area",     DataIndex = "cod_area",      Width=100},
                    new Column { Text = "req. Cod.",    DataIndex = "req_cod",       Width=100},
                    new Column { Text = "Req. Nombre",  DataIndex = "req_nombre",    Width=300},
                    new Column { Text = "descripcion",  DataIndex = "descripcion",   Width=300},
              
                }



                },

                Listeners =
                {
                    //ItemDblClick = { Handler = "Ext.net.Notification.show({iconCls  : 'icon-information',pinEvent :'click',title:record.data.descripcion});" }
                    ItemDblClick = {Handler = "#{Panel2}.getLoader().load({url: 'imagen.aspx'});"} 
                    //ItemDblClick = {Handler = "var url_descrip = record.data.descripcion; #{Panel2}.getLoader().load({url: url_descrip });"}
                    //ItemDblClick = { Handler = "Ext.net.Notification.show({iconCls  : 'icon-information',pinEvent :'click',title:record.data.descripcion});" }
                    //ItemDblClick = { Handler = "#{Panel2}.{Toolbar1}.{Panel1}.getLoader().Url = '../files/PROPUESTA.PDF'" }
                    //ItemDblClick = { Handler = "Ext.net.Notification.show({iconCls  : 'icon-information',pinEvent :'click',title:record.data.descripcion});" }
                    //ItemDblClick = { Handler = "#{Ext:Panel#Panel2}.{Topbar}.{Ext:Toolbar#Toolbar1}.{Items}.{Ext:Panel#Panel1}.{Ext:Loader#Loader3}.Url = '../files/PROPUESTA.PDF');" }
                    //ItemDblClick = { Handler = "#{Panel2}.{Topbar}.{Toolbar1}.{Items}.{Panel1}.{Loader3}.Url:record.data.descripcion);" }
                    //ItemDblClick = { Handler = "#{WindowVisualizador}.getLoader().url = '../files/318i TwinPower Turbo Luxury (1).pdf')" }
                    //ItemDblClick = { Handler = "#{Loader3}.show('Url=../files/318i TwinPower Turbo Luxury (1).pdf')" },
                    //ItemDblClick = { Handler = "record.data.descripcion" },

                }

            };

            return ComponentLoader.ToConfig(grid);
        }


        private void LimpiarControles()
        {
            //this.combobox1.selecteditem.text = "";
            //this.textfielddepartamento.text = "";
            //this.textfieldemisor.text = "";
            //this.textarea1.text = "";
            //this.textfieldresponsable.text = "";
            //this.datefieldfechaa.selecteddate = new datetime();
            //this.textfieldcausa.text = "";






        }

        private void CargarCorrelativo()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(correlativo) + 1 as correlativo from wf_seguimiento_95", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextFieldContador.Text = (reader["correlativo"].ToString());

            }
            reader.Close();
        }

        protected void Buscar_Click(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            sql += " SELECT * from dbo.wf_seguimiento_95 where 1=1 ";

            if (this.TextFieldContadorB.Text.Length > 0)
            {
                sql += " AND correlativo=@correlativo";
                cmd.Parameters.AddWithValue("@correlativo", this.TextFieldContadorB.Text);
            }

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

            this.GridPanelBusqueda.Show();
            this.StoreBusqueda.DataSource = datatable;
            this.StoreBusqueda.DataBind();

        }





        private void norma()
        {

            string sql_origen = "SELECT codigo, rtrim(descripcion) descripcion FROM norma_iso ";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_origen;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.StoreOrigen.DataSource = datatable;
            this.StoreOrigen.DataBind();
        }



        //protected void Buscar_ClickA(object sender, DirectEventArgs e)
        //{

        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string sql = "";



        //    sql += "select adjunto from control_solicitudes where n_mejora=@n_mejora";

        //    SqlCommand cmd = new SqlCommand(strCon);

        //    cmd.Parameters.Add("@n_mejora", this.TextFieldContadorB.Text);

        //    DataTable datatable = GetData(cmd);

        //    //  if (datatable != null)
        //    //  {

        //    Byte[] bytes = (Byte[])datatable.Rows[0]["adjunto"];

        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();

        //    // }



        //}




        private DataTable GetData(SqlCommand cmd)
        {

            DataTable datatable = new DataTable();
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            da.SelectCommand = cmd;


            // da.Fill(datatable);

            return datatable;

            con.Close();
            da.Dispose();
            con.Dispose();


        }

        private void download(DataTable datatable)
        {

            Byte[] bytes = (Byte[])datatable.Rows[0]["adjunto"];

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }


        //private static void ReadFilestream(SqlConnectionStringBuilder connStringBuilder)
        //{
        //    using (SqlConnection connection = new SqlConnection(connStringBuilder.ToString()))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("select adjunto from control_solicitudes where n_mejora=@n_mejora", connection);

        //        SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        //        command.Transaction = tran;

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                // Get the pointer for the file
        //                string path = reader.GetString(0);
        //                byte[] transactionContext = reader.GetSqlBytes(1).Buffer;

        //                // Create the SqlFileStream
        //             //   using (Stream fileStream = new SqlFileStream(path, transactionContext, FileAccess.Read, FileOptions.SequentialScan, allocationSize: 0))
        //                {
        //                    // Read the contents as bytes and write them to the console
        //                    for (long index = 0; index < fileStream.Length; index++)
        //                    {
        //                        Console.WriteLine(fileStream.ReadByte());
        //                    }
        //                }
        //            }
        //        }
        //        tran.Commit();
        //    }
        //}



    }

}

