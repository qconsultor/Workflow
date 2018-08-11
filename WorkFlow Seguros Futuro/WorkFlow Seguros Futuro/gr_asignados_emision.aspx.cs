using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Ext.Net;


namespace WorkFlow_Seguros_Futuro
{
    public partial class gr_asignados_emision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_chart = " Select us.nombre, Count(wf.asignado) as cantidad ";
            sql_chart += " from wf_seguimiento_95  wf ";
            sql_chart += " inner join dbo.Usuarios us on us.usuario=wf.asignado ";
            sql_chart += " where wf.area='EMISION' and asignado is not null group by asignado,us.nombre ";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_chart;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.Store1.DataSource = datatable;
            this.Store1.DataBind();


            Grid(null, null);
        }

        private void Grid(object sender, EventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "";


            sql_quejas_det += " Select us.nombre, Count(wf.asignado) as cantidad,wf.asignado   ";
            sql_quejas_det += "  from wf_seguimiento_95  wf  ";
            sql_quejas_det += "  inner join dbo.Usuarios us on us.usuario=wf.asignado ";
            sql_quejas_det += "  where wf.area='EMISION' and asignado is not null  ";
            sql_quejas_det += "  group by asignado,us.nombre,wf.asignado  ";


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

            this.Store2.DataSource = datatable;
            this.Store2.DataBind();

            //this.GridPanel1.Show();

        }

        [DirectMethod]
        public static string GetGrid(Dictionary<string, string> parameters)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string JsonRecord = parameters["id"];
            Dictionary<string, string>[] GridData = JSON.Deserialize<Dictionary<string, string>[]>(JsonRecord);


            string asignado;

            asignado = GridData[0]["asignado"];


            string sql_detalle = "";

            sql_detalle += " Select us.nombre,wf.correlativo,wf.plan_,wf.asegurado,wf.cantidadsolicitudes,CONVERT(date,wf.ingresado,101) ingresado,wf.estado, ";
            sql_detalle += " DATEDIFF(DAY,convert(date,ingresado,101),convert(date,getdate(),101)) dias  ";
            sql_detalle += "  from wf_seguimiento_95  wf  ";
            sql_detalle += "  inner join dbo.Usuarios us on us.usuario=wf.asignado ";
            sql_detalle += " where wf.area='EMISION' and wf.asignado=@asignado ";


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 36000;
            cmd.CommandText = sql_detalle;
            cmd.Parameters.AddWithValue("@asignado", asignado);
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
                                new ModelField("nombre"),
                                new ModelField("correlativo"),
                                new ModelField("plan_"),
                                new ModelField("asegurado"),
                                new ModelField("cantidadsolicitudes"),
                                new ModelField("ingresado"),
                                new ModelField("estado"),
                                new ModelField("dias"),
                                

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
                    new Column { Text = "Nombre",  DataIndex = "nombre",   Width=180},
                    new Column { Text = "Referencia",     DataIndex = "correlativo",      Width=100},
                    new Column { Text = "Plan",     DataIndex = "plan_",      Width=100},
                    new Column { Text = "Asegurado",     DataIndex = "asegurado",      Width=100},
                    new Column { Text = "Cant. Solicitudes",     DataIndex = "cantidadsolicitudes",      Width=100},
                    new Column { Text = "Fecha de Ingreso.",    DataIndex = "ingresado",       Width=100},
                    new Column { Text = "Tarea",  DataIndex = "estado",    Width=300},
                    new Column { Text = "Indicador en Dias",  DataIndex = "dias",   Width=150},
                    
              
                }



                },

                
            };
            return ComponentLoader.ToConfig(grid);
        }
    }
}
