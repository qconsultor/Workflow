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
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using Microsoft.Office.Interop.Word;
//using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;



namespace WorkFlow_Seguros_Futuro
{
    public partial class consulta_wf : System.Web.UI.Page
    {
        private SqlConnection cone_;
        private System.Data.DataTable dataTabla;
        private SqlConnection conexii;
        private object correlativo;
        private object cod_area;
        private object id11;
        private object id21;

        public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }


        //private void convertirword()
        //{

        //    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

        //    wordApp.Visible = false;


        //    object filename = @"C:\Users\raul\Documents\Visual Studio 2012\Projects\WorkFlow Seguros Futuro\WorkFlow Seguros Futuro\files\" + FileUpload.FileName; // input

        //    object newFileName = Server.MapPath("~/files/" + Path.GetFileNameWithoutExtension(FileUpload.FileName) + ".pdf"); // output
        //    object missing = System.Type.Missing;

        //    Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
        //                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
        //                   ref missing, ref missing, ref missing);

        //    object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;




        //    doc.SaveAs(ref newFileName, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
        //                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

        //    doc.Close(ref missing, ref missing, ref missing);

        //    wordApp.Quit(ref missing, ref missing, ref missing);

        //}

        //private void convertirexcel()
        //{

        //    Microsoft.Office.Interop.Excel.Application word = new Microsoft.Office.Interop.Excel.Application();
        //    Workbook excelWorkBook = null;


        //    string paramSourceBookPath = @"C:\Users\raul\Documents\Visual Studio 2012\Projects\WorkFlow Seguros Futuro\WorkFlow Seguros Futuro\files\" + FileUpload.FileName;
        //    object paramMissing = Type.Missing;

        //    string paramExportFilePath = Server.MapPath("~/files/" + Path.GetFileNameWithoutExtension(FileUpload.FileName) + ".pdf");
        //    XlFixedFormatType paramExportFormat = XlFixedFormatType.xlTypePDF;
        //    XlFixedFormatQuality paramExportQuality =
        //        XlFixedFormatQuality.xlQualityStandard;
        //    bool paramOpenAfterPublish = false;
        //    bool paramIncludeDocProps = true;
        //    bool paramIgnorePrintAreas = true;
        //    object paramFromPage = Type.Missing;
        //    object paramToPage = Type.Missing;


        //    try
        //    {

        //        excelWorkBook = word.Workbooks.Open(paramSourceBookPath,
        //            paramMissing, paramMissing, paramMissing, paramMissing,
        //            paramMissing, paramMissing, paramMissing, paramMissing,
        //            paramMissing, paramMissing, paramMissing, paramMissing,
        //            paramMissing, paramMissing);


        //        if (excelWorkBook != null)
        //            excelWorkBook.ExportAsFixedFormat(paramExportFormat,
        //                paramExportFilePath, paramExportQuality,
        //                paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
        //                paramToPage, paramOpenAfterPublish,
        //                paramMissing);
        //    }
        //    catch (Exception ex)
        //    {
        //        // agregar mensaje de error 
        //    }
        //    finally
        //    {

        //        if (excelWorkBook != null)
        //        {
        //            excelWorkBook.Close(false, paramMissing, paramMissing);
        //            excelWorkBook = null;
        //        }


        //        if (word != null)
        //        {
        //            word.Quit();
        //            word = null;
        //        }

        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TextBox1.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
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
            //TextBox1.Text = "";

            //TextBox3.Text = "";
            //txtDescripcion.Text = "";
            //txtFecha.Text = "";

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
                case ".doc":
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


        private void ListarRegistro()
        {
            try
            {
                //    //SQL = "SELECT * FROM registro WHERE  correlativo =@correlativo  AND  cod_area=@cod_area";
                //    SQL = "SELECT * FROM registro WHERE  correlativo ='-40'  AND  cod_area='01'";
                //    using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
                //    using (SqlDataAdapter da = new SqlDataAdapter(SQL, conexi))
                //    {


                //        System.Data.DataTable tbRegistro = new System.Data.DataTable();
                //        da.Fill(tbRegistro);
                //        gridListado.DataSource = tbRegistro;
                //        gridListado.DataBind();
                //        Session["Registro"] = tbRegistro;
                //    }
                //}
                string id1;
                string id2;
                if (String.IsNullOrEmpty(this.TextBox1.Text))
                {
                    id1 = TextBox1.Text; id2 = TextBox3.Text;
                    SQL = "SELECT * FROM registro WHERE  correlativo ='-40'  AND  cod_area='01'";
                }
                if (!String.IsNullOrEmpty(this.TextBox1.Text))
                {
                    id1 = TextBox1.Text; id2 = TextBox3.Text;
                    SQL = "SELECT * FROM registro WHERE  cod_area =" + id1 + "  AND correlativo =" + id2;
                }
                //if (!String.IsNullOrEmpty(this.TextBox1.Text))
                //{
                //    sql_master += " And correlativo=@correlativo ";
                //    cmd.Parameters.AddWithValue("@correlativo", this.TextBox1.Text);
                //}


                using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
                using (SqlDataAdapter da = new SqlDataAdapter(SQL, conexi))
                {
                    System.Data.DataTable tbRegistro = new System.Data.DataTable();
                    da.Fill(tbRegistro);
                    gridListado.DataSource = tbRegistro;
                    gridListado.DataBind();
                    Session["Registro"] = tbRegistro;
                }
            }
            finally
            {
                //    cmd.Dispose();
                //    pl.MySQLConn.Close();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            panelRegistrar.Visible = true;
            panelMostrar.Visible = true;
            panel2.Visible = false;
            ListarRegistro();
            //TextBox3.Text = "";
            //lblMensaje.Text = "";
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
                //lblMensaje.Text = ex.Message.ToString();
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    string textoCmd = "SELECT codigo,codigocliente,Nombre,descripcion,fecha,ubicacion,tipo FROM registro WHERE codigocliente = " + TextBox3.Text;
        //    using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
        //    using (SqlDataAdapter da = new SqlDataAdapter(textoCmd, conexi))
        //    using (SqlCommand comando = new SqlCommand(textoCmd, conexi))
        //    {

        //        // obtener extension de base de datos

        //        conexi.Open();
        //        SqlDataReader reader = comando.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {

        //                Label3.Text = reader.GetString(2);



        //            }
        //            conexi.Close();
        //        }





        //        myPDF.Attributes.Add("src", "~/files/" + Label3.Text);


        //        // hasta aqui

        //    }


        //}

        protected void VerPDF(string codigoente)
        {
            //TextBox3.Text = codigoente;
            //string textoCmd = "SELECT llave,descripcion,Nombre,convert(varchar(10),fecha,103) fecha FROM registro WHERE llave = " + codigoente;
            string textoCmd = "SELECT llave,descripcion,Nombre,convert(varchar(10),fecha,103) fecha,ubicacion FROM registro WHERE  (cod_area = '01') AND (correlativo = '41') ";
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

                        //Label3.Text = reader.GetString(2);
                        //TextBox1.Text = reader.GetString(0);
                        //txtDescripcion.Text = reader.GetString(1);
                        //txtFecha.Text = reader.GetString(3);


                    }
                    conexi.Close();
                }


                //myPDF.Attributes.Add("src", "~/files/" + Label3.Text);

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

        protected void Button4_Click(object sender, EventArgs e)
        {


        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string id11;
            string id21;
            id11 = TextBox1.Text; id21 = TextBox3.Text;
            CargarData();
        }

        private void CargarData()
        //{
        //    SQL = "SELECT * FROM registro WHERE  cod_area=@id11  AND  correlativo=@id21";   
        //    SqlCommand   comando = new SqlCommand(SQL, conexi);
        //    comando.Parameters.Clear();
        //    comando.Parameters.AddWithValue("@id11", id11);
        //    comando.Parameters.AddWithValue("@id21", id21);
        //    SqlDataAdapter dataAdaptador  = new SqlDataAdapter(comando);
        //    dataAdaptador.Fill(dataTabla);
        //    gridListado.Visible = true;
        //    gridListado.DataSource = dataTabla;
        //    gridListado.DataBind();
        //}
        {
            string id1;
            string id2;
            id1 = TextBox1.Text; id2 = TextBox3.Text;
            SQL = "SELECT * FROM registro WHERE  cod_area =" + id1 + "  AND correlativo =" + id2;
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter(SQL, conexi))
            {
                System.Data.DataTable tbRegistro = new System.Data.DataTable();
                da.Fill(tbRegistro);
                gridListado.DataSource = tbRegistro;
                gridListado.DataBind();
                Session["Registro"] = tbRegistro;
            }


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



                    //lblMensaje.Text = "Archivo Eliminado Correctamente.";


                }
                catch (Exception ex)
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                    //lblMensaje.Text = ex.Message.ToString();
                }
            panelMostrar.Visible = true;
            ListarRegistro();

        }


        // public string var { get; set; }

        public string SQL { get; set; }

        public SqlConnection conexi { get; set; }
    }

    //class mos
    //{
    //}


}