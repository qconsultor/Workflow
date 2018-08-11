using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
//using System.Configuration;
namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_maestro_imagenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelRegistrar.Visible = true;
                panelMostrar.Visible = true;
                ListarRegistro();
            }
        }
        private void borrar()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
        }
        private Boolean ValidarExtension(string sExtension)
        {
            Boolean verif = false;
            switch (sExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                case ".pdf":
                case ".docx":
                case ".xls":
                    verif = true;
                    break;
                default:
                    verif = false;
                    break;
            }
            return verif;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Extension = string.Empty;
                string Nombre = string.Empty;

                if (TextBox1.Text != "" && TextBox2.Text != "" && txtDescripcion.Text != "" && txtFecha.Text != "" && FileUpload.HasFile)
                {
                    Nombre = FileUpload.FileName;
                    Extension = Path.GetExtension(Nombre);

                    if (ValidarExtension(Extension))
                    {
                        using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
                        using (SqlCommand cmd = new SqlCommand("stp_Guardar_Registro", conexi))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("codigocliente", TextBox1.Text.ToUpper());
                            cmd.Parameters.AddWithValue("Nombre", TextBox2.Text.ToUpper());
                            //cmd.Parameters.AddWithValue("ubicacion", Nombre);//
                            cmd.Parameters.AddWithValue("descripcion", txtDescripcion.Text.ToUpper());
                            cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(txtFecha.Text.ToUpper()));
                            cmd.Parameters.AddWithValue("imagen", FileUpload.FileBytes);

                            cmd.Parameters.AddWithValue("ubicacion", Label1.Text.ToUpper());

                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                        //Mostrar el panel de Registros
                        borrar();
                        panel2.Visible = true;
                        panelMostrar.Visible = true;
                        panelRegistrar.Visible = true;
                        ListarRegistro();
                        Response.Write("<script>alert('Registro insertado con exito');</script>");

                    }
                    else
                    {
                        lblMensaje.Text = "El archivo no es de tipo imagen.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Datos Incorrectos.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
            }
        }
        private void ListarRegistro()
        {
            try
            {
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
                using (SqlDataAdapter da = new SqlDataAdapter("stp_Listar_Registro", conexi))
                {
                    DataTable tbRegistro = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tbRegistro);
                    gridListado.DataSource = tbRegistro;
                    gridListado.DataBind();
                    Session["Registro"] = tbRegistro;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            panelRegistrar.Visible = true;
            panelMostrar.Visible = true;
            panel2.Visible = false;
            ListarRegistro();
            TextBox3.Text = "";
        }
        protected void gridListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridListado.PageIndex = e.NewPageIndex;
                gridListado.DataBind();
                ListarRegistro();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string textoCmd = "SELECT codigo,codigocliente,Nombre,descripcion,fecha,imagen FROM registro WHERE codigocliente = " + TextBox3.Text;
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter(textoCmd, conexi))
            {

                gridListado0.Columns[0].Visible = false;
                gridListado0.Columns[1].Visible = false;
                gridListado0.Columns[2].Visible = false;
                gridListado0.Columns[3].Visible = false;
                gridListado0.Columns[4].Visible = false;


                gridListado.Columns[0].Visible = false;
                gridListado.Columns[1].Visible = false;
                gridListado.Columns[2].Visible = false;
                gridListado.Columns[3].Visible = false;
                gridListado.Columns[4].Visible = false;
                gridListado.Columns[5].Visible = false;

                DataTable tbRegistro = new DataTable();

                da.Fill(tbRegistro);
                gridListado0.DataSource = tbRegistro;
                gridListado0.DataBind();
                Session["Registro"] = tbRegistro;

                TextBox3.Text = "";

                panel2.Visible = true;
                panelMostrar.Visible = true;

            }
        }

        protected void gridListado0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}