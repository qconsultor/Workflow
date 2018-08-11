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
    public partial class wf_maestro_porcentaje : System.Web.UI.Page
    {
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid_requi(null, null);
            //CargarCorrelativo_requi();
            Cargar_Combo();
            CargarBuscador();
        }
        protected void Guardar_Click_requi(object sender, DirectEventArgs e)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("sp_seguimiento_requisitos", con);// Este es el nombre del SP en la base
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            //cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo.Text);
            cmd.Parameters.AddWithValue("@nombre", this.ComboBoxBuscador.SelectedItem.Value);



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


            Response.Redirect("requisitos.aspx");


        }

        protected void Guardar_Click_sp_Check_list_detalle(object sender, DirectEventArgs e)
        {

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("sp_Maestro_Porcentaje_detalle", con);// Este es el nombre del SP en la base
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            cmd.Parameters.AddWithValue("@codigo", this.ComboBoxBuscador.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@req_cod", this.Textfieldreq_cod.Text);
            cmd.Parameters.AddWithValue("@req_nombre", this.Textfieldreq_nombre.Text);
            cmd.Parameters.AddWithValue("@area", this.Textfield1.Text);
            cmd.Parameters.AddWithValue("@cant_pasos", this.Textfield2.Text);
            //codigo,req_cod,req_nombre,necesario

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


            Response.Redirect("wf_maestro_porcentaje.aspx");


        }

        private void Grid_requi(object sender, EventArgs e)
        {
            string sql_quejas_det_req = "";


            sql_quejas_det_req += "Select * from requisitos";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_quejas_det_req;

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


            string codigo;

            codigo = GridData[0]["codigo"];


            string sql_detalle = "";

            sql_detalle += "   SELECT det.codigo, det.req_cod,det.req_nombre,det.area,det.cant_pasos ";
            sql_detalle += " FROM dbo.requisitos AS re  ";
            sql_detalle += " INNER JOIN dbo.Maestro_Porcentaje_detalle AS det ON det.codigo = @codigo ";
            sql_detalle += " Where re.codigo = det.codigo ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 36000;
            cmd.CommandText = sql_detalle;
            cmd.Parameters.AddWithValue("@codigo", codigo);
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
                ID= "GridPanelConsulta",
                EnableColumnHide = false,
                Store = 
              
            { 

                new Store 
                { 
                    Model = {

                        new Model {

                            Fields = 
                            {
                                new ModelField("codigo"),
                                new ModelField("req_cod"),
                                new ModelField("req_nombre"),
                                new ModelField("area"),
                                new ModelField("cant_pasos"),
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
                    new Column { Text = "codigo", DataIndex = "codigo", Width=100},
                    new Column { Text = "req. Cod.", DataIndex = "req_cod", Width=100},
                    new Column { Text = "Req. Nombre", DataIndex = "req_nombre", Width=300},
                    new Column { Text = "Area", DataIndex = "area", Width=150},
                    new Column { Text = "Puntos", DataIndex = "cant_pasos", Width=85},
                   
                   
                }



                },

                //Listeners =
                //{
               
                //    //ItemDblClick = { Handler = "var codente = record.data.llave; var url = 'imagen.aspx?codigoente=' + codente; #{Panel2}.getLoader().load({url:url});" },
                //    //ItemDblClick = { Handler = "#{WindowConsulta}.show()" }
                //     ItemDblClick = { Handler = " OnEvent=RealizarConsulta, Ext.encode(#{GridPanelConsulta}.getRowsValues({selectedOnly:true})" }
                //    //ItemDblClick = { Handler = "Ext.net.Notification.show({iconCls  : 'icon-information',pinEvent :'click',title:'123'});" }
                    
                    
                //}



            };

            return ComponentLoader.ToConfig(grid);
        }

        protected void RealizarConsulta(object sender, DirectEventArgs e)
        {
            string JsonRecord = e.ExtraParams["id"];
            string codigo,req_cod,req_nombre;

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


            codigo = GridData[0]["codigo"];
            req_cod = GridData[0]["req_cod"];
            req_nombre = GridData[0]["req_nombre"];




            this.Textfieldcodigo.Text = codigo.ToString();
            this.Textfield3.Text = req_cod.ToString();
            this.Textfield4.Text = req_nombre.ToString();
            



                this.ResourceManager.AddScript("#{WindowConsulta}.show()");

           

        }


        //private void CargarCorrelativo_requi()
        //{
        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select max(codigo) + 1 as codigo from requisitos", con);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        this.Textfieldcodigo_buscar.Text = (reader["codigo"].ToString());

        //    }
        //    reader.Close();
        //}
        //protected void Buscar_Click_requi(object sender, DirectEventArgs e)
        //{

        //    string sql = "";

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;

        //    sql += " SELECT * from dbo.requisitos where 1=1 ";

        //    if (this.Textfieldcodigo_buscar.Text.Length > 0)
        //    {
        //        sql += " AND codigo=@codigo";
        //        cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo_buscar.Text);
        //    }

        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    cmd.CommandText = sql;
        //    cmd.Connection = con;
        //    cmd.ExecuteNonQuery();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    DataTable datatable = new DataTable();
        //    da.Fill(datatable);
        //    con.Close();

        //    this.GridPanelBusqueda.Show();
        //    this.StoreBusqueda.DataSource = datatable;
        //    this.StoreBusqueda.DataBind();

        //}

        protected void Cargar_Combo()
        {
            string sql = "";
            sql += " select * from maestrospasos ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.StoreRequis.DataSource = datatable;
            this.StoreRequis.DataBind();
        }

        protected void Generar_Click(object sender, DirectEventArgs e)
        {
           
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT req_codigo,req_nombre FROM dbo.maestrospasos where req_codigo=@req_codigo ", con);
            cmd.Parameters.AddWithValue("@req_codigo", this.ComboBoxRequisitos.SelectedItem.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.Textfieldreq_cod.Text = (reader["req_codigo"].ToString());
                this.Textfieldreq_nombre.Text = (reader["req_nombre"].ToString());
                //this.TextFieldDireccion.Text = (reader["req_"].ToString());
                //this.TextFieldRegistro.Text = (reader["CDV_CLI"].ToString());
            }

        }

        private void CargarBuscador()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_combo = " select * from requisitos ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_combo;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.StoreBuscador.DataSource = datatable;
            this.StoreBuscador.DataBind();
        }

        protected void Grid_Buscador(object sender, EventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";


            sql_detalle += "  SELECT det.codigo, det.req_cod,det.req_nombre,det.area,det.cant_pasos ";
            sql_detalle += " FROM dbo.requisitos AS re ";
            sql_detalle += " INNER JOIN dbo.Maestro_Porcentaje_detalle AS det ON det.codigo =@codigo ";
            sql_detalle += " Where re.codigo = det.codigo ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_detalle;
            cmd.Parameters.AddWithValue("@codigo", this.ComboBoxBuscador.SelectedItem.Value);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.StoreBuscador1.DataSource = datatable;
            this.StoreBuscador1.DataBind();

            

        }

        protected void Actualizar_ClickPendiente(object sender, DirectEventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql = "";
            sql += " update Maestro_Porcentaje_detalle set area=@area, cant_pasos=@cant_pasos where codigo=@codigo and req_cod=@req_cod ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql.ToString();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo.Text);
            cmd.Parameters.AddWithValue("@req_cod", this.Textfield3.Text);
            cmd.Parameters.AddWithValue("@area", this.Textfield5.Text);
            cmd.Parameters.AddWithValue("@cant_pasos", this.Textfield6.Text);
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
