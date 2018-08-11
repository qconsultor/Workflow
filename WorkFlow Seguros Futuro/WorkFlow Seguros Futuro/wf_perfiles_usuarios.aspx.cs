using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Ext.Net;
//using ClosedXML.Excel;
using System.Text;

namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_perfiles_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCorrelativo();
            Cargar_Grid(null, null);
            CargarCombos();
            CargarCorrelativoModulo();
            Cargar_Grid_modulo(null, null);
            CargarCombosPermisos_modulos();
            CargarCombosPermisos();
            Cargar_Grid_Permisos(null, null);
            Cargar_Grid_Listado(null, null);
            CargarArea();

        }

        protected void Guardar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strCon);

                SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 46000;
                cmd.Parameters.AddWithValue("@codigo", this.TextFieldCusuario.Text);
                cmd.Parameters.AddWithValue("@nombre", this.TextFieldNombres.Text);
                cmd.Parameters.AddWithValue("@usuario", this.TextFieldUsuario.Text);
                cmd.Parameters.AddWithValue("@contrase", this.TextFieldTContra.Text);
                cmd.Parameters.AddWithValue("@estado", this.TextFieldEstado.Text);
                cmd.Parameters.AddWithValue("@area", this.ComboBox3.SelectedItem.Text);


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                con.Close();



                Cargar_Grid(null, null);


                X.Msg.Confirm("Confirmación", "Datos han sido guardados exitosamente", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();

            }
            catch (Exception ex)
            {
                X.Msg.Confirm("Error", ex.ToString(), new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();
            }



            Response.Redirect("wf_perfiles_usuarios.aspx");
        }



        private void CargarCorrelativo()
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(codigo),0) +1 codigo FROM dbo.Usuarios", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextFieldCusuario.Text = (reader["codigo"].ToString());

            }

        }

        protected void Cargar_Grid(object sender, EventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";

            sql_detalle += " select * from Usuarios ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_detalle;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store4.DataSource = datatable;
            this.Store4.DataBind();
        }



        protected void Guardar_ClickModulo(object sender, DirectEventArgs e)
        {
            try
            {
                string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strCon);

                SqlCommand cmd = new SqlCommand("sp_InsertarModulo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 46000;
                cmd.Parameters.AddWithValue("@cod_rol", this.TextField1.Text);
                cmd.Parameters.AddWithValue("@cod_modulo", this.TextField2.Text);
                cmd.Parameters.AddWithValue("@modulo", this.TextField3.Text);
                cmd.Parameters.AddWithValue("@vigente", this.TextField4.Text);
                cmd.Parameters.AddWithValue("@cusuario", this.ComboBoxCoop.SelectedItem.Value);


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                con.Close();



                //Cargar_Grid_modulo(null, null);


                X.Msg.Confirm("Confirmación", "Datos han sido guardados exitosamente", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();

            }
            catch (Exception ex)
            {
                X.Msg.Confirm("Error", ex.ToString(), new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();
            }



            Response.Redirect("wf_perfiles_usuarios.aspx");

        }



        private void CargarCorrelativoModulo()
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(cod_rol),0) +1 codigo_rol, ISNULL(MAX(cod_modulo),0) +1 codigo_modulo FROM master_modulo", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextField1.Text = (reader["codigo_rol"].ToString());
                this.TextField2.Text = (reader["codigo_modulo"].ToString());

            }

        }

        protected void Cargar_Grid_modulo(object sender, EventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";

            sql_detalle += " select * from master_modulo ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_detalle;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store1.DataSource = datatable;
            this.Store1.DataBind();
        }

        private void CargarCombos()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_combo = "SELECT codigo,nombre FROM dbo.Usuarios WHERE estado='V' ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = sql_combo;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.StoreCoop.DataSource = datatable;
            this.StoreCoop.DataBind();
        }

        private void CargarArea()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_combo = "SELECT cod_area,area FROM dbo.Maestro_areas ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = sql_combo;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store7.DataSource = datatable;
            this.Store7.DataBind();
        }

        protected void Guardar_ClickPermisos(object sender, DirectEventArgs e)
        {
            try
            {
                string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strCon);

                SqlCommand cmd = new SqlCommand("sp_InsertarPermisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 46000;
                cmd.Parameters.AddWithValue("@cod_usuario", this.ComboBox1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@cod_rol", this.TextField5.Text);
                cmd.Parameters.AddWithValue("@cod_modulo", this.ComboBox2.SelectedItem.Value);

                if (this.Radio5.Checked)
                {
                    cmd.Parameters.Add("@permiso", SqlDbType.Float, 1, "permiso").Value = 1;

                }

                else if (this.Radio6.Checked)
                {
                    cmd.Parameters.Add("@permiso", SqlDbType.Float, 1, "permiso").Value = 0;
                }


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                con.Close();



                //Cargar_Grid_modulo(null, null);


                X.Msg.Confirm("Confirmación", "Datos han sido guardados exitosamente", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();

            }
            catch (Exception ex)
            {
                X.Msg.Confirm("Error", ex.ToString(), new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"
                    }
                }).Show();
            }



            Response.Redirect("wf_perfiles_usuarios.aspx");
        }



        private void CargarCorrelativoPermisos()
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(cod_rol),0) +1 codigo_rol, ISNULL(MAX(cod_modulo),0) +1 codigo_modulo FROM dbo.master_modulo", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextField1.Text = (reader["codigo_rol"].ToString());
                this.TextField2.Text = (reader["codigo_modulo"].ToString());

            }

        }

        protected void Cargar_Grid_Permisos(object sender, EventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";

            sql_detalle += " select * from master_permisos ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_detalle;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store3.DataSource = datatable;
            this.Store3.DataBind();
        }

        private void CargarCombosPermisos()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_combo = "SELECT codigo,nombre FROM dbo.Usuarios WHERE estado='V' ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = sql_combo;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store2.DataSource = datatable;
            this.Store2.DataBind();

        }

        private void CargarCombosPermisos_modulos()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_combo = "Select cod_modulo,modulo from master_modulo";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 5600000;
            cmd.CommandText = sql_combo;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store5.DataSource = datatable;
            this.Store5.DataBind();
        }


        protected void Generar_Click(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select cod_rol, modulo,* from master_modulo where cod_modulo=@modulo ", con);
            cmd.Parameters.AddWithValue("@modulo", this.ComboBox2.SelectedItem.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextField5.Text = (reader["cod_rol"].ToString());

            }

        }


        protected void Cargar_Grid_Listado(object sender, EventArgs e)
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            string sql_detalle = "";

            sql_detalle += " select * from vw_permisos ";

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql_detalle;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            con.Close();

            this.Store6.DataSource = datatable;
            this.Store6.DataBind();
        }


    }
}