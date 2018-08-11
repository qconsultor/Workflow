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
using System.Text;

namespace WorkFlow_Seguros_Futuro.Formularios
{
    public partial class wf_recepcionreclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos_();
            ButtonGuardar.Disabled = true;
            this.TextFieldCodigoISO.Disabled = true;
        }
        protected void CargarDatos(String correlativo, String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select correlativo,codigo,req_nombre,descripcion,ISNULL(necesario,0) necesario,llave from [dbo].[check_list_detalle_recpcion] where correlativo=@correlativo and cod_area=@cod_area order by codigo";

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

                    DateFieldFechaRecibido.SelectedDate = (DateTime)sqlDataReader["fecha"];
                    ComboBoxAsesores.Text = sqlDataReader["cooperativa"].ToString();
                    TextFieldNombre.Text = sqlDataReader["identificacion"].ToString();
                    TextFieldNombre.Text = sqlDataReader["asegurado"].ToString();
                    this.DateFieldFechaIngreso.SelectedDate = (DateTime)sqlDataReader["ingresado"];
                    TextFieldResponsable.Text = sqlDataReader["sus_atec"].ToString();
                    TextFieldEntrego.Text = sqlDataReader["entrego"].ToString();
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

            CargarDatos(this.TextFieldCorrelativo.Text, ComboBoxArea.SelectedItem.Value);

        }


        protected void GuardarDatos_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("sp_seguimiento_reclamos_95_web", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 36000;
                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@area", ComboBoxArea.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@fecha", DateFieldFechaRecibido.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@cooperativa", ComboBoxAsesores.SelectedItem.Text);
                sqlCommand.Parameters.AddWithValue("@identificacion", TextFieldNombre.Text);
                sqlCommand.Parameters.AddWithValue("@asegurado", TextFieldNombre.Text);
                sqlCommand.Parameters.AddWithValue("@observaciones", this.TextAreaObservaciones.Text);
                sqlCommand.Parameters.AddWithValue("@ingresado", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@fecha_destino", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@sus_atec", TextFieldResponsable.Text);
                sqlCommand.Parameters.AddWithValue("@nplaca", this.TextFieldPlaca.Text);
                sqlCommand.Parameters.AddWithValue("@entrego", TextFieldEntrego.Text);
                sqlCommand.Parameters.AddWithValue("@tipodoc", this.TextFieldTipoDoc.Text);
                sqlCommand.Parameters.AddWithValue("@solic", "");
                sqlCommand.Parameters.AddWithValue("@cod_coop", SqlDbType.Decimal.Equals(ComboBoxAsesores.SelectedItem.Value));
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
                sqlCommand.Parameters.AddWithValue("@requisito", this.ComboBoxRequisitos.SelectedItem.Text);

                if (this.ComboBoxCausas.SelectedItem.Text == null)
                {
                    sqlCommand.Parameters.AddWithValue("@causa", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@causa", this.ComboBoxCausas.SelectedItem.Text);
                }
                if (this.ComboBoxPlanes.SelectedItem.Text == null)
                {
                    sqlCommand.Parameters.AddWithValue("@planes", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@planes", this.ComboBoxPlanes.SelectedItem.Text);
                }
                if (this.ComboBoxRequisitos.SelectedItem.Value == null)
                {
                    sqlCommand.Parameters.AddWithValue("@cod_requisito", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@cod_requisito", this.ComboBoxRequisitos.SelectedItem.Value);
                }


                if (this.ComboBoxCausas.SelectedItem.Value == null)
                {
                    sqlCommand.Parameters.AddWithValue("@cod_causa", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@cod_causa", this.ComboBoxCausas.SelectedItem.Value);
                }
                if (this.ComboBoxPlanes.SelectedItem.Value == null)
                {
                    sqlCommand.Parameters.AddWithValue("@cod_planes", "");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@cod_planes", this.ComboBoxPlanes.SelectedItem.Value);
                }
               
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
            Cargarasesores();
        }
        protected void CargarArea()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo,rtrim(nombre) as descripcion FROM dbo.area where codigo in ('02','03')";
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

        //protected void CargarTipoSolicitud()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string str = "select codigo,nombre as descripcion from tiposolicitud";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = str;

        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.ExecuteNonQuery();

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = sqlCommand;

        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    sqlConnection.Close();

        //    this.StoreTipoSolicitud.DataSource = dataTable;
        //    this.StoreTipoSolicitud.DataBind();
        //}

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

        protected void eleccion()
        {
            if (this.ComboBoxArea.SelectedItem.Text=="RECLAMOS VIDA")
            {
                requisitos_vida();
                this.ComboBoxCausas.Disabled = false;
                this.ComboBoxPlanes.Disabled = false;
                this.TextFieldPlaca.Disabled = true;

            }
            else
            {
                RequisitosDaños();
                this.ComboBoxCausas.Visible= false;
                this.ComboBoxPlanes.Visible = false;
                this.TextFieldPlaca.Disabled = false;
            }
        }


        protected void CargarRequisito(String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo , rtrim(nombre) AS descripcion FROM dbo.check_list_encabezado where cod_area=@cod_area and requisito='REQUISITOS'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreRequisitos.DataSource = dataTable;
            this.StoreRequisitos.DataBind();
        #endregion
        }

        protected void requisitos_vida()
        {
            CargarRequisito(this.ComboBoxArea.SelectedItem.Value);
            CargarCausas(this.ComboBoxArea.SelectedItem.Value);
            CargarPlanes(this.ComboBoxArea.SelectedItem.Value);
        }

        protected void CargarCausas(String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo , rtrim(nombre) AS descripcion FROM dbo.check_list_encabezado where cod_area=@cod_area and requisito='CAUSAS'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreCausas.DataSource = dataTable;
            this.StoreCausas.DataBind();
        }
        protected void CargarPlanes(String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo , rtrim(nombre) AS descripcion FROM dbo.check_list_encabezado where cod_area=@cod_area and requisito='PLANES'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StorePlanes.DataSource = dataTable;
            this.StorePlanes.DataBind();
        }

        protected void CargarDaños(String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "SELECT codigo , rtrim(nombre) AS descripcion FROM dbo.check_list_encabezado where cod_area=@cod_area";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreRequisitos.DataSource = dataTable;
            this.StoreRequisitos.DataBind();
        }

        protected void RequisitosDaños()
        {
            CargarDaños(this.ComboBoxArea.SelectedItem.Value);
        }

        //protected void CargarTipoOperacion()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string str = "SELECT codigo, rtrim(nombre) as descripcion FROM dbo.Tipooperacion";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = str;

        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.ExecuteNonQuery();

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = sqlCommand;

        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    sqlConnection.Close();

        //    this.StoreTipoOperacion.DataSource = dataTable;
        //    this.StoreTipoOperacion.DataBind();
        //}

        //protected void CargarTipoDocumento()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string str = "SELECT codigo, rtrim(nombre) as descripcion FROM dbo.tipodocumento";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = str;

        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.ExecuteNonQuery();

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = sqlCommand;

        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    sqlConnection.Close();

        //    this.StoreTipoDoc.DataSource = dataTable;
        //    this.StoreTipoDoc.DataBind();
        //}
        protected void CargarHistorial(String cod_area)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string str = "select top 10 fecha,correlativo,cooperativa,asegurado,entrego,plan_,poliza,tsolicitud,observaciones,cantidadsolicitudes,fecha_destino from [dbo].[wf_seguimiento_95] where cod_area=@cod_area order by CAST(correlativo AS int) desc";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = str;
            sqlCommand.Parameters.AddWithValue("@cod_area", cod_area);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            this.StoreMalla.DataSource = dataTable;
            this.StoreMalla.DataBind();

            eleccion();
        }

        protected void Historial(object sender, DirectEventArgs e)
        {

            CargarHistorial(this.ComboBoxArea.SelectedItem.Value);

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
                    ComboBoxAsesores.Text = sqlDataReader["blanco"].ToString();
                    TextFieldNombre.Text = sqlDataReader["blanco"].ToString();
                    TextFieldResponsable.Text = sqlDataReader["blanco"].ToString();
                    TextFieldEntrego.Text = sqlDataReader["blanco"].ToString();
                    TextFieldEstado.Text = sqlDataReader["blanco"].ToString();
                    TextFieldPuntos.Text = sqlDataReader["blanco"].ToString();
                    this.TextFieldDUI.Text = sqlDataReader["blanco"].ToString();
                    this.TextAreaObservaciones.Text = sqlDataReader["blanco"].ToString();
                    this.TextFieldcantSolicitudes.Text = sqlDataReader["blanco"].ToString();
                    this.ComboBoxCausas.Text= sqlDataReader["blanco"].ToString();
                    this.ComboBoxRequisitos.Text = sqlDataReader["blanco"].ToString();
                    this.ComboBoxPlanes.Text = sqlDataReader["blanco"].ToString();


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
            string pdfPath = "file://172.16.2.219/sf_par/adquisiciones/WORKFLOW/pruebas_scaner/" + NameAreA + "_" + namePDF + ".pdf";


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
                ComboBoxAsesores.Text = blanco;
                TextFieldNombre.Text = blanco;
                TextFieldResponsable.Text = blanco;
                TextFieldEntrego.Text = blanco;
                TextFieldEstado.Text = blanco;
                TextFieldPuntos.Text = blanco;
                this.TextFieldDUI.Text = blanco;
               this.TextAreaObservaciones.Text = blanco;
                this.TextFieldcantSolicitudes.Text = blanco;
                this.ComboBoxCausas.Text = blanco;
                this.ComboBoxPlanes.Text = blanco;
                this.ComboBoxRequisitos.Text = blanco;
                
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

        protected void AgregarRequisito(object sender, DirectEventArgs e)
        {
           
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("sp_adicionar_requisito", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 36000;
                sqlCommand.Parameters.AddWithValue("@cod_area", ComboBoxArea.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@correlativo", TextFieldCorrelativo.Text);
                sqlCommand.Parameters.AddWithValue("@req_cod","1111");
                sqlCommand.Parameters.AddWithValue("@req_nombre", this.TextFieldReqNew.Text);
                sqlCommand.Parameters.AddWithValue("@llave", this.TextFieldllave.Text);
                sqlCommand.Parameters.AddWithValue("@fec_nac", DateFieldFechaIngreso.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@nombre", "");
                sqlCommand.Parameters.AddWithValue("@Descripcion", "");
                sqlCommand.Parameters.AddWithValue("@ubicacion", "");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                this.TextFieldReqNew.Text = "";

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

        protected void checke(object sender, DirectEventArgs e)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<b>Registros Seleccionados</b></br /><ul>");
            RowSelectionModel sm = this.GridPanelUno.SelectionModel.Primary as RowSelectionModel;

            foreach (SelectedRow row in sm.SelectedRows)
            {
                Actualizar_ClickPendiente(this.TextFieldCorrelativo.Text, row.RecordID);
                result.Append("<li> Correlativo" + row.RecordID + "</li>");

            }

            result.Append("</ul>");


            X.Msg.Alert("Notificación", result.ToString(), new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();

        }
        //protected void Actualizar_ClickPendiente(string correlativo, string codigo)
        //{
        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
        //    string sql = "";

        //    sql += " if EXISTS (select * from check_list_detalle_recpcion where necesario=1) update check_list_detalle_recpcion set necesario=1 where correlativo=@correlativo and codigo=@codigo else  update check_list_detalle_recpcion set necesario=0 where correlativo=@correlativo and codigo=@codigo";
        //    // sql += " update ejecucion set entrega=getdate() where correlativo=@correlativo  ";
        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sql.ToString();
        //    cmd.Connection = con;
        //    //cmd.Parameters.AddWithValue("@correlativo", this.TextFieldCodigo.Text);NULL
        //    //cmd.Parameters.AddWithValue("@asignado", this.ComboBoxPasos.SelectedItem.Value);
        //    cmd.Parameters.AddWithValue("@correlativo", correlativo);
        //    cmd.Parameters.AddWithValue("@codigo", codigo);


        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();
        //    con.Close();

        //}


        protected void Actualizar_ClickPendiente(string correlativo, string codigo)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_actualiza_cheque", connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = 36000;
            sqlCommand.Parameters.AddWithValue("@correlativo", correlativo);
            sqlCommand.Parameters.AddWithValue("@codigo", codigo);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();

            this.TextFieldReqNew.Text = "";

            X.Msg.Alert("Notificación", "Datos guardados satisfactoriamente", new MessageBoxButtonsConfig()
            {
                Ok = new MessageBoxButtonConfig()
                {
                    Text = "Ok"
                }
            }).Show();

        }
    }

}