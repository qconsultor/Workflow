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
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;


namespace WorkFlow_Seguros_Futuro
{
    public partial class imagen : System.Web.UI.Page
    {

        public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }


        private void convertirword()
        {

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            wordApp.Visible = false;


            object filename = @"C:\Users\raul\Documents\Visual Studio 2012\Projects\WorkFlow Seguros Futuro\WorkFlow Seguros Futuro\files\" + FileUpload.FileName; // input

            object newFileName = Server.MapPath("~/files/" + Path.GetFileNameWithoutExtension(FileUpload.FileName) + ".pdf"); // output
            object missing = System.Type.Missing;

            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing);

            object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;




            doc.SaveAs(ref newFileName, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            doc.Close(ref missing, ref missing, ref missing);

            wordApp.Quit(ref missing, ref missing, ref missing);

        }

        private void convertirexcel()
        {

            Microsoft.Office.Interop.Excel.Application word = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkBook = null;


            string paramSourceBookPath = @"C:\Users\raul\Documents\Visual Studio 2012\Projects\WorkFlow Seguros Futuro\WorkFlow Seguros Futuro\files\" + FileUpload.FileName;
            object paramMissing = Type.Missing;

            string paramExportFilePath = Server.MapPath("~/files/" + Path.GetFileNameWithoutExtension(FileUpload.FileName) + ".pdf");
            XlFixedFormatType paramExportFormat = XlFixedFormatType.xlTypePDF;
            XlFixedFormatQuality paramExportQuality =
                XlFixedFormatQuality.xlQualityStandard;
            bool paramOpenAfterPublish = false;
            bool paramIncludeDocProps = true;
            bool paramIgnorePrintAreas = true;
            object paramFromPage = Type.Missing;
            object paramToPage = Type.Missing;


            try
            {

                excelWorkBook = word.Workbooks.Open(paramSourceBookPath,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing);


                if (excelWorkBook != null)
                    excelWorkBook.ExportAsFixedFormat(paramExportFormat,
                        paramExportFilePath, paramExportQuality,
                        paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
                        paramToPage, paramOpenAfterPublish,
                        paramMissing);
            }
            catch (Exception ex)
            {
                // agregar mensaje de error 
            }
            finally
            {

                if (excelWorkBook != null)
                {
                    excelWorkBook.Close(false, paramMissing, paramMissing);
                    excelWorkBook = null;
                }


                if (word != null)
                {
                    word.Quit();
                    word = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
                panelRegistrar.Visible = true;
                panelMostrar.Visible = true;
                ListarRegistro();
            }

            if ((this.Request.QueryString["codigoente"] != null))
            {
                VerPDF(this.Request.QueryString["codigoente"].ToString());
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
                case ".xlsX":
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
                    string filename = Nombre;
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
                        //SIA_ConnectionString
                        using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
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

                        //var doc1 = new Document();
                        //string path = Server.MapPath("/files/");
                        //PdfWriter.GetInstance(doc1, new FileStream(path + "Doc1.pdf", FileMode.Create));
                        //doc1.Open();
                        //doc1.Add(new Paragraph("My first PDF"));
                        //doc1.Close();

                        //var doc1 = new Document();
                        //string path = Server.MapPath("/files/");
                        //PdfWriter.GetInstance(doc1, new FileStream(path + "Doc1.pdf", FileMode.Create));
                        //doc1.Open();
                        //doc1.Add(new Paragraph("My first PDF"));
                        //doc1.Close();
                        //////
                        //int j = 0;
                        //foreach (Microsoft.Office.Interop.Word.Page p in pane.Pages)
                        //{
                        //    var bits = p.EnhMetaFileBits;
                        //    var target = path1 + j.ToString() + "_image.doc";
                        //    try
                        //    {
                        //        using (var ms = new MemoryStream((byte[])(bits)))
                        //        {
                        //            var image = System.Drawing.Image.FromStream(ms);
                        //            var pngTarget = Path.ChangeExtension(target, "png");
                        //            image.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
                        //        }
                        //    }
                        //    catch (System.Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    j++;
                        //}
                        //////
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

            
if (Path.GetExtension(FileUpload.FileName)==".xls" )
            {
            convertirexcel();
             }
            
            else if (Path.GetExtension(FileUpload.FileName)==".xlsx" )
            
            {
                convertirexcel();
            }

            else
            {
          convertirword();

            }
        }
        private void ListarRegistro()
        {
            try
            {
                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
                using (SqlDataAdapter da = new SqlDataAdapter("usp_Listar_Registro", conexi))
                {


                    System.Data.DataTable tbRegistro = new System.Data.DataTable();
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
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
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

        protected void VerPDF(string codigoente)
        {
            TextBox3.Text = codigoente;
            string textoCmd = "SELECT llave,descripcion,Nombre,convert(varchar(10),fecha,103) fecha FROM registro WHERE llave = " + codigoente;
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
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
                        TextBox1.Text = reader.GetString(0);
                        txtDescripcion.Text = reader.GetString(1);
                        txtFecha.Text = reader.GetString(3);


                    }
                    conexi.Close();
                }


                myPDF.Attributes.Add("src", "~/files/" + Label3.Text);

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

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))

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


       // public string var { get; set; }
    }

    class mos
    {
    }

    
}