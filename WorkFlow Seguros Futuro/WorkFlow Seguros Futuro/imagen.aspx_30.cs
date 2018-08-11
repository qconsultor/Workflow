//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
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
    public partial class imagen : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
                panelRegistrar.Visible = true;
                panelMostrar.Visible = true;
                ListarRegistro();


            }
        }
        private void borrar()
        {
            TextBox1.Text = "";

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
                case ".bmp":
                case ".gif":
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
                string nombrecompleto = string.Empty;

                if (TextBox1.Text != "" && txtDescripcion.Text != "" && txtFecha.Text != "" && FileUpload.HasFile)
                {
                    Nombre = FileUpload.FileName;

                    if (FileUpload.HasFile)
                    {

                        string fullPath = Path.Combine(Server.MapPath("~/files"), FileUpload.FileName);
                        FileUpload.SaveAs(fullPath);
                    }




                    Extension = Path.GetExtension(Nombre);

                    // guardar extension

                    Label2.Text = Path.GetExtension(Extension);




                    if (ValidarExtension(Extension))
                    {

                        using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                        using (SqlCommand cmd = new SqlCommand("usp_Guardar_Registro", conexi))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("codigocliente", TextBox1.Text.ToUpper());
                            cmd.Parameters.AddWithValue("Nombre", Path.GetFileName(Nombre));
                            cmd.Parameters.AddWithValue("descripcion", txtDescripcion.Text.ToUpper());
                            cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(txtFecha.Text.ToUpper()));
                            cmd.Parameters.AddWithValue("ubicacion", Label1.Text.ToUpper());
                            cmd.Parameters.AddWithValue("extension", Label2.Text.ToUpper());
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
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                using (SqlDataAdapter da = new SqlDataAdapter("usp_Listar_Registro", conexi))
                {


                    DataTable tbRegistro = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tbRegistro);
                    gridListado.DataSource = tbRegistro;
                    gridListado.DataBind();
                    Session["Registro"] = tbRegistro;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            panelRegistrar.Visible = true;
            panelMostrar.Visible = true;
            panel2.Visible = false;
            ListarRegistro();
            TextBox3.Text = "";
            lblMensaje.Text = "";
        }
        protected void gridListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridListado.PageIndex = e.NewPageIndex;
                gridListado.DataBind();
                ListarRegistro();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string textoCmd = "SELECT codigo,codigocliente,Nombre,descripcion,fecha,ubicacion,tipo FROM registro WHERE codigocliente = " + TextBox3.Text;
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter(textoCmd, conexi))
            using (SqlCommand comando = new SqlCommand(textoCmd, conexi))
            {

                // obtener extension de base de datos

                conexi.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Label3.Text = reader.GetString(2);



                    }
                    conexi.Close();
                }





                myPDF.Attributes.Add("src", "~/files/" + Label3.Text);


                // hasta aqui








            }


        }

        protected void gridListado0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridListado_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {



        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gridListado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))

                try
                {
                    SqlCommand cmd = new SqlCommand("usp_imagenes_eliminar", cnx);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Cod", SqlDbType.Int).Value = gridListado.DataKeys[e.RowIndex].Value;
                    }
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();


                    gridListado.EditIndex = -1;

                    gridListado.DataBind();



                    lblMensaje.Text = "Archivo Eliminado Correctamente.";


                }
                catch (Exception ex)
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                    lblMensaje.Text = ex.Message.ToString();
                }
            panelMostrar.Visible = true;
            ListarRegistro();

        }

    }

    class mos
    {
    }
}