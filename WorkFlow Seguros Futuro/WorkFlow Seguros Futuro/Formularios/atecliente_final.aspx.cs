using Ext.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class atecliente_final : System.Web.UI.Page
    {
        string varcorrelativo;
        string varcod_area;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarArea();
        }
        protected void CargarArea()
        {



            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select * from area";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreMalla.DataSource = dataTable;
            this.StoreMalla.DataBind();
        }



        protected void CargarSolicitudes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select * from wf_seguimiento_95";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreSolic.DataSource = dataTable;
            this.StoreSolic.DataBind();
        }




        protected void PorArea(object sender, DirectEventArgs e)
        {
                StringBuilder result = new StringBuilder();
                result.Append("<b>Registros Seleccionados</b></br /><ul>");
                RowSelectionModel sm = this.GridPanelMalla.SelectionModel.Primary as RowSelectionModel;

                foreach (SelectedRow row in sm.SelectedRows)
                {

                    Actualizar_ClickPendiente(row.RecordID);
                    result.Append("<li> Correlativo" + row.RecordID + "</li>");

                }
            }
        



        protected void Actualizar_ClickPendiente(string cod_area)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select rtrim(correlativo) as correlativo,* from wf_seguimiento_95 where cod_area=@cod_area and estado='ATENCION AL CLIENTE'";


            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
           
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreSolic.DataSource = dataTable;
            this.StoreSolic.DataBind();
        }



        //protected void PorCorrelativo(object sender, DirectEventArgs e)
        //{
        //    StringBuilder result = new StringBuilder();
        //    result.Append("<b>Registros Seleccionados</b></br /><ul>");
        //    RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;
        //    foreach (SelectedRow row in sm.SelectedRows)
        //    {
        //        varcorrelativo = row.RecordID;
        //        VerGestion(row.RecordID);
        //        VerGestion_(row.RecordID);
        //        result.Append("<li> Corralativo" + row.RecordID + "</li>");

        //    }

        //}




        //protected void VerGestion(string correlativo)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string str = "select * from Gestion_ATCliente where correlativo=@correlativo order by cast(ngestion as int) asc";


        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();

        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = str;
        //    sqlCommand.CommandTimeout = 36000;
        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.ExecuteNonQuery();

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = sqlCommand;

        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    sqlConnection.Close();

        //    this.StoreGestion.DataSource = dataTable;
        //    this.StoreGestion.DataBind();
        //}

        //protected void Guardar(object sender, DirectEventArgs e)
        //{

        //    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand("[Guardar_Gestion]", connection);

        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandTimeout = 36000;
        //    sqlCommand.Parameters.AddWithValue("@correlativo", this.TextFieldCorrelativo.Text);
        //    sqlCommand.Parameters.AddWithValue("@asegurado", this.TextFieldAsegurado.Text);
        //    sqlCommand.Parameters.AddWithValue("@cod_area", this.TextFieldcod_area.Text);
        //    sqlCommand.Parameters.AddWithValue("@fecha", this.TextFieldFecha.Text);
        //    sqlCommand.Parameters.AddWithValue("@comentario", this.TextArea1.Text);
            
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = sqlCommand;
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    connection.Close();
        //}

        //protected void VerGestion_(string correlativo)
        //{
        //    string blanco;
        //    blanco = "";
        //    string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string str = "select rtrim(correlativo) as correlativo,*,getdate() as fechagestion_,'' as blanco from wf_seguimiento_95 where correlativo=@correlativo order by cast(correlativo as int) asc";


        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();

        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = str;
        //    sqlCommand.CommandTimeout = 36000;
        //    sqlCommand.Connection = sqlConnection;
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        this.TextFieldAsegurado.Text= sqlDataReader["asegurado"].ToString();
        //        this.TextFieldArea.Text = sqlDataReader["area"].ToString();
        //        this.TextFieldcod_area.Text = sqlDataReader["cod_area"].ToString();
        //        this.TextFieldCorrelativo.Text = sqlDataReader["correlativo"].ToString();
        //        this.TextFieldFecha.Text = sqlDataReader["fechagestion_"].ToString();
        //        this.TextArea1.Text = sqlDataReader["blanco"].ToString();
        //    }
        //    sqlDataReader.Close();
        //}

    }
}