using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class PRUEBA_VER_PFG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarArea();
        }

        protected void mostrarPDF(object sender, EventArgs e)
        {

            string carp;
            carp = this.Correlativo.Text;
            string archivo;
            archivo = this.ComboBox1.SelectedItem.Text;
            string path;
            path = "file://172.16.2.229/files/"+carp+"/"+archivo;


            this.Portlet1.LoadContent(new ComponentLoader()
            {
                //Url = "MaestroRequisitos.aspx",
                Url = path,
                Mode = LoadMode.Frame,
                AutoLoad = true,
                LoadMask = { ShowMask = true, Msg = "Cargando..." }

            });
        }

        protected void CargarArea()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo,rtrim(nombre) as descripcion FROM dbo.area";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreArea.DataSource = dataTable;
            this.StoreArea.DataBind();
        }

        protected void CargarDatos(String correlativo, String area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select rtrim(nombre) as name from [dbo].[check_list_detalle_recpcion] where correlativo=@correlativo and cod_area=@cod_area";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
            sqlCommand.Parameters.AddWithValue("@cod_area", area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.Store1.DataSource = dataTable;
            this.Store1.DataBind();
        }

        protected void Guardar_buscar(object sender, DirectEventArgs e)
        {

            CargarDatos(this.Correlativo.Text, this.ComboBoxArea.SelectedItem.Value);

        }
    }
}