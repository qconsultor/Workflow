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
    public partial class requisitos : System.Web.UI.Page
    {
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid_requi(null,null);
            CargarCorrelativo_requi();
            Cargar_Combo();
        }
        protected void Guardar_Click_requi(object sender, DirectEventArgs e)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("sp_seguimiento_requisitos", con);// Este es el nombre del SP en la base
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo.Text);
            cmd.Parameters.AddWithValue("@nombre", this.Textfieldnombre.Text);
            


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
            SqlCommand cmd = new SqlCommand("sp_Check_list_detalle", con);// Este es el nombre del SP en la base
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo.Text);
            cmd.Parameters.AddWithValue("@req_cod", this.ComboBoxRequisitos.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@req_nombre", this.Textfieldreq_nombre.Text);
            cmd.Parameters.AddWithValue("@necesario", this.Textfieldnecesario.Text);
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


            Response.Redirect("requisitos.aspx");


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

            sql_detalle += "  SELECT det.codigo, det.req_cod,det.req_nombre,det.necesario ";
            sql_detalle += " FROM dbo.requisitos AS re  ";
            sql_detalle += " INNER JOIN dbo.Check_list_detalle AS det ON det.codigo = @codigo ";
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
                                new ModelField("necesario"),
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
                    new Column { Text = "codigo", DataIndex = "codigo", Width=300},
                    new Column { Text = "req. Cod.", DataIndex = "req_cod", Width=300},
                    new Column { Text = "Req. Nombre", DataIndex = "req_nombre", Width=300},
                    new CheckColumn { Text = "Necesario", DataIndex = "necesario",   },
                   
                }

                 

                }

            };

            return ComponentLoader.ToConfig(grid);
        }




        private void CargarCorrelativo_requi()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(codigo) + 1 as codigo from requisitos", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.Textfieldcodigo_buscar.Text = (reader["codigo"].ToString());

            }
            reader.Close();
        }
        protected void Buscar_Click_requi(object sender, DirectEventArgs e)
        {

            string sql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            sql += " SELECT * from dbo.requisitos where 1=1 ";

            if (this.Textfieldcodigo_buscar.Text.Length > 0)
            {
                sql += " AND codigo=@codigo";
                cmd.Parameters.AddWithValue("@codigo", this.Textfieldcodigo_buscar.Text);
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

        protected void Cargar_Combo()
        {
            string sql = "";
            sql += "SELECT req_codigo codigo, req_codigo + ' - ' +  RTRIM(req_nombre) descripcion, req_nombre desc_ FROM dbo.maestrosrequisitos ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            cmd.CommandText= sql.ToString();
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

        }
    }
