using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Ext.Net;
using System.Dynamic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class Prueba_de_reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos_();
            ButtonGuardar.Disabled = true;
        }
        protected void CargarDatos(String correlativo, String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select correlativo,codigo,req_nombre,descripcion,ISNULL(necesario,0) necesario,llave from [dbo].[check_list_detalle_recpcion] where correlativo=@correlativo and cod_area=@cod_area";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreUno.DataSource = dataTable;
            this.StoreUno.DataBind();
        }

        protected void BuscarDatos_enter(object sender, DirectEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC dbo.[sp_consultar_solicitudes] @correlativo, @area", connection);

                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@area", ComboBoxArea.Value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    ComboBoxTipoOperacion.Text = sqlDataReader["tipodepoliza"].ToString();
                    DateFieldFechaRecibido.SelectedDate = (DateTime)sqlDataReader["fecha"];
                    ComboBoxAsesores.Text = sqlDataReader["cooperativa"].ToString();
                    TextFieldNombre.Text = sqlDataReader["identificacion"].ToString();
                    ComboBoxPlanSeguro.Text = sqlDataReader["plan_"].ToString();
                    TextFieldNombre.Text = sqlDataReader["asegurado"].ToString();
                    ComboBoxTipoSolicitud.Text = sqlDataReader["tsolicitud"].ToString();
                    this.DateFieldFechaIngreso.SelectedDate = (DateTime)sqlDataReader["ingresado"];
                    TextFieldResponsable.Text = sqlDataReader["sus_atec"].ToString();
                    TextFieldPoliza.Text = sqlDataReader["poliza"].ToString();
                    TextFieldEntrego.Text = sqlDataReader["entrego"].ToString();
                    ComboBoxTipoDoc.Text = sqlDataReader["tipodoc"].ToString();
                    TextFieldEstado.Text = sqlDataReader["estado"].ToString();
                    TextFieldPuntos.Text = sqlDataReader["puntos"].ToString();
                    this.TextFieldDUI.Text = sqlDataReader["Dui"].ToString();
                    this.TextFieldHoraIngreso.Text = sqlDataReader["hora_e"].ToString();
                    this.TextFieldHoraRecibido.Text = sqlDataReader["hora_r"].ToString();
                    this.TextAreaObservaciones.Text = sqlDataReader["observaciones"].ToString();
                    this.TextFieldcantSolicitudes.Text = sqlDataReader["cantidadsolicitudes"].ToString();

                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {


                throw;
            }

        }



        protected void Guardar_buscar(object sender, DirectEventArgs e)
        {

            CargarDatos(this.TextFieldCorrelativo.Text,this.ComboBoxArea.SelectedItem.Value);

        }


        protected void GuardarDatos_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("sp_seguimiento_recepcion_95_web", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 36000;
                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@area", ComboBoxArea.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@tipodepoliza", ComboBoxTipoOperacion.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@fecha", DateFieldFechaRecibido.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@cooperativa", ComboBoxAsesores.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@identificacion", TextFieldNombre.Text);
                sqlCommand.Parameters.AddWithValue("@plan", ComboBoxPlanSeguro.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@asegurado", TextFieldNombre.Text);
                sqlCommand.Parameters.AddWithValue("@observaciones", this.TextAreaObservaciones.Text);
                sqlCommand.Parameters.AddWithValue("@tsolicitud", ComboBoxTipoSolicitud.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@ingresado", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@fecha_destino", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@sus_atec", TextFieldResponsable.Text);
                sqlCommand.Parameters.AddWithValue("@poliza", TextFieldPoliza.Text);
                sqlCommand.Parameters.AddWithValue("@entrego", TextFieldEntrego.Text);
                sqlCommand.Parameters.AddWithValue("@tipodoc", ComboBoxTipoDoc.Text);
                sqlCommand.Parameters.AddWithValue("@solic", "");
                sqlCommand.Parameters.AddWithValue("@cod_coop", SqlDbType.Decimal.Equals(ComboBoxAsesores.SelectedItem.Value));
                sqlCommand.Parameters.AddWithValue("@p_codigo", ComboBoxPlanSeguro.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@cod_operacion", ComboBoxTipoSolicitud.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@cod_area", ComboBoxArea.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@estado", "RECEPCIÓN");
                sqlCommand.Parameters.AddWithValue("@puntos", SqlDbType.Decimal.Equals(TextFieldPuntos.Text));
                sqlCommand.Parameters.AddWithValue("@estado_tiempo", "ABIERTO");
                sqlCommand.Parameters.AddWithValue("@estado_envio", "ENVIO-E");
                sqlCommand.Parameters.AddWithValue("@dui", this.TextFieldDUI.Text);
                sqlCommand.Parameters.AddWithValue("@hora_e", this.TextFieldHoraIngreso.Text);
                sqlCommand.Parameters.AddWithValue("@hora_r", this.TextFieldHoraRecibido.Text);
                sqlCommand.Parameters.AddWithValue("@Generado_mod", 1);
                sqlCommand.Parameters.AddWithValue("@cant_solicitudes", this.TextFieldcantSolicitudes.Text);
                sqlCommand.Parameters.AddWithValue("@cod_iso", this.TextFieldCodigoISO.Text);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                X.Msg.Alert("Notificación", "Datos guardados satisfactoriamente", new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }
                }).Show();
            }
            catch (Exception ex)
            {


                X.Msg.Alert("Excepción", "Se genero un error al guardar los datos. Mas info:" + ex.ToString(), new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }

                }).Show();
                throw;
            }
            ButtonGuardar.Disabled = true;

        }
        #region DatosGenerales

        protected void CargarDatos_()
        {
            CargarArea();
            CargarTipoSolicitud();
            Cargarasesores();
            CargarPlanSeguro();
            CargarTipoOperacion();
            CargarTipoDocumento();
            CargarHistorial();
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

        protected void CargarTipoSolicitud()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select codigo,nombre as descripcion from tiposolicitud";
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

            this.StoreTipoSolicitud.DataSource = dataTable;
            this.StoreTipoSolicitud.DataBind();
        }

        protected void Cargarasesores()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT cdisprod as codigo , rtrim(productor) as descripcion FROM dbo.asesores";
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

            this.StoreAsesores.DataSource = dataTable;
            this.StoreAsesores.DataBind();
        }

        protected void CargarPlanSeguro()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo , rtrim(nombre) AS descripcion FROM dbo.check_list_encabezado";
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

            this.StorePlanSeguro.DataSource = dataTable;
            this.StorePlanSeguro.DataBind();
        #endregion

        }

        protected void CargarTipoOperacion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo, rtrim(nombre) as descripcion FROM dbo.Tipooperacion";
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

            this.StoreTipoOperacion.DataSource = dataTable;
            this.StoreTipoOperacion.DataBind();
        }

        protected void CargarTipoDocumento()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo, rtrim(nombre) as descripcion FROM dbo.tipodocumento";
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

            this.StoreTipoDoc.DataSource = dataTable;
            this.StoreTipoDoc.DataBind();
        }
        protected void CargarHistorial()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select top 10 fecha,correlativo,cooperativa,asegurado,entrego,plan_,poliza,tsolicitud,observaciones,cantidadsolicitudes,fecha_destino from [dbo].[wf_seguimiento_95] where cod_area='01' order by correlativo desc";

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

            this.StoreMalla.DataSource = dataTable;
            this.StoreMalla.DataBind();
        }


        protected void Nuevo_click(object sender, DirectEventArgs e)
        {
            this.ButtonGuardar.Disabled = false;
            try
            {

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC [dbo].[sp_Nueva_solicitud] @cod_area", connection);

                sqlCommand.Parameters.AddWithValue("@cod_area", ComboBoxArea.Value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    TextFieldCorrelativo.Text = sqlDataReader["corre"].ToString();
                    DateFieldFechaIngreso.SelectedDate = (DateTime)sqlDataReader["fecha"];
                    DateFieldFechaRecibido.SelectedDate = (DateTime)sqlDataReader["fecha"];
                    TextFieldHoraRecibido.Text = sqlDataReader["hora"].ToString();
                    TextFieldHoraIngreso.Text = sqlDataReader["hora"].ToString();
                    ComboBoxTipoOperacion.Text = sqlDataReader["blanco"].ToString();
                    ComboBoxAsesores.Text = sqlDataReader["blanco"].ToString();
                    TextFieldNombre.Text = sqlDataReader["blanco"].ToString();
                    ComboBoxPlanSeguro.Text = sqlDataReader["blanco"].ToString();
                    ComboBoxTipoSolicitud.Text = sqlDataReader["blanco"].ToString();
                    TextFieldResponsable.Text = sqlDataReader["blanco"].ToString();
                    TextFieldPoliza.Text = sqlDataReader["blanco"].ToString();
                    TextFieldEntrego.Text = sqlDataReader["blanco"].ToString();
                    ComboBoxTipoDoc.Text = sqlDataReader["blanco"].ToString();
                    TextFieldEstado.Text = sqlDataReader["blanco"].ToString();
                    TextFieldPuntos.Text = sqlDataReader["blanco"].ToString();
                    this.TextFieldDUI.Text = sqlDataReader["blanco"].ToString();
                    this.TextAreaObservaciones.Text = sqlDataReader["blanco"].ToString();
                    this.TextFieldcantSolicitudes.Text = sqlDataReader["blanco"].ToString();

                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void combo_click(object sender, DirectEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC [dbo].[sp_Nueva_solicitud] @area", connection);

                sqlCommand.Parameters.AddWithValue("@area", ComboBoxArea.Value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    TextFieldCorrelativo.Text = sqlDataReader["corre"].ToString();
                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void combo_click_codigoiso(object sender, DirectEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC [dbo].[sp_codigoiso] @area", connection);

                sqlCommand.Parameters.AddWithValue("@area", ComboBoxArea.Value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    this.TextFieldCodigoISO.Text = sqlDataReader["descripcion"].ToString();
                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            /*String NameAreA;
            NameAreA = this.ComboBoxArea.SelectedItem.Text;

            String namePDF;
            namePDF = this.TextFieldCorrelativo.Text;

            //Response.Redirect("../files/" + NameAreA + "_" + namePDF + ".pdf", true);

            string pdfPath = "file://172.16.2.219/sf_par/adquisiciones/WORKFLOW/pruebas_scaner/";
            Process.Start(pdfPath+NameAreA+"_"+namePDF+".pdf");*/
            string NameAreA;
            NameAreA = this.ComboBoxArea.SelectedItem.Text;

            string namePDF;
            namePDF = this.TextFieldCorrelativo.Text;
            string pdfPath = "~/Reportes/Entrega_ATecnica.rpt";


            this.windowPDF.LoadContent(new ComponentLoader()
            {
                //Url = "MaestroRequisitos.aspx",
                Url = "../Configurador/wfVisorPDF.aspx?path=" + pdfPath,
                Mode = LoadMode.Frame,
                AutoLoad = true,
                LoadMask = { ShowMask = true, Msg = "Cargando..." }

            });

        }




        protected void Ubicacion_Click(object sender, DirectEventArgs e)
        {

            string fileName;

            fileName = FileUploadPDF.PostedFile.FileName;


            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("sp_Check_list_detalle_recepcion", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 36000;
                sqlCommand.Parameters.AddWithValue("@cod_area", ComboBoxArea.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@req_cod", ComboBoxPlanSeguro.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@req_nombre", ComboBoxPlanSeguro.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@llave", TextFieldllave.Text);
                sqlCommand.Parameters.AddWithValue("@fec_nac", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@nombre", fileName);
                sqlCommand.Parameters.AddWithValue("@Descripcion", TextFieldWObservacion.Text);
                sqlCommand.Parameters.AddWithValue("@ubicacion", "file://172.16.2.229/files/" + TextFieldCorrelativo.Text + "/" + System.IO.Path.GetFileName(FileUploadPDF.FileName));

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                X.Msg.Alert("Notificación", "Datos guardados satisfactoriamente", new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }
                }).Show();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Excepción", "Se genero un error al guardar los datos. Mas info:" + ex.ToString(), new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }

                }).Show();
                throw;
            }
        }

        protected void EliminarDatos(object sender, DirectEventArgs e)
        {
            try
            {
                String blanco;
                blanco = "";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("EXEC dbo.[sp_eliminar_solicitudes] @correlativo, @cod_area", connection);

                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@cod_area", ComboBoxArea.Value);
                sqlCommand.CommandTimeout = 36000;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                }
                ComboBoxTipoOperacion.Text = blanco;
                ComboBoxAsesores.Text = blanco;
                TextFieldNombre.Text = blanco;
                ComboBoxPlanSeguro.Text = blanco;
                ComboBoxTipoSolicitud.Text = blanco;
                TextFieldResponsable.Text = blanco;
                TextFieldPoliza.Text = blanco;
                TextFieldEntrego.Text = blanco;
                ComboBoxTipoDoc.Text = blanco;
                TextFieldEstado.Text = blanco;
                TextFieldPuntos.Text = blanco;
                this.TextFieldDUI.Text = blanco;
                this.TextAreaObservaciones.Text = blanco;
                this.TextFieldcantSolicitudes.Text = blanco;

                sqlDataReader.Close();
                X.Msg.Alert("Notificación", "Datos eliminados satisfactoriamente", new MessageBoxButtonsConfig()
                {
                    Ok = new MessageBoxButtonConfig()
                    {
                        Text = "Ok"
                    }
                }).Show();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

}