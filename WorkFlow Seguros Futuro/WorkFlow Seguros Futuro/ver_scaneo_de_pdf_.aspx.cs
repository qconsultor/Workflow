using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace WorkFlow_Seguros_Futuro
{
    public partial class ver_scaneo_de_pdf_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarRegistro();
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
                    GridDatosRegistro.DataSource = tbRegistro;
                    GridDatosRegistro.DataBind();
                    Session["Registro"] = tbRegistro;
                }
            }
            catch (Exception)
            {
                throw;
            }
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
            SQL = "SELECT codigo,codigocliente,Nombre, descripcion, fecha, ubicacion FROM registro WHERE nombre <> '' and cod_area =" + "'" + id1 + "'" + "  AND correlativo =" + "'" + id2 + "'";
            using (SqlConnection conexi = new SqlConnection(ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ToString()))
            using (SqlDataAdapter da = new SqlDataAdapter(SQL, conexi))
            {
                try
                {
                    System.Data.DataTable tbRegistro = new System.Data.DataTable();
                    da.Fill(tbRegistro);
                    GridDatosRegistro.DataSource = tbRegistro;
                    GridDatosRegistro.DataBind();
                    Session["Registro"] = tbRegistro;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message.ToString();
                }
            }
            //TextBox1.Text = "";
            //TextBox3.Text = "";

        }

        protected void GridDatosRegistro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridDatosRegistro.PageIndex = e.NewPageIndex;
                GridDatosRegistro.DataBind();
                //ListarRegistro();
                CargarData();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridDatosRegistro0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridDatosRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridDatosRegistro_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        public string SQL { get; set; }

    }
}