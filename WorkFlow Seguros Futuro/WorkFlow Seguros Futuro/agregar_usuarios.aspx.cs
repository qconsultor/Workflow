using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Ext.Net;

namespace WorkFlow_Seguros_Futuro
{
    public partial class agregar_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarCorrelativo();

        }


        protected void Guardar_Click(object sender, DirectEventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("manto_Usuarios", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 36000;
            //cmd.Parameters.AddWithValue("",);
            cmd.Parameters.AddWithValue("@codigo", this.TextFieldCodigo.Text);
            cmd.Parameters.AddWithValue("@usuario", this.TextFieldUsuario.Text);
            cmd.Parameters.AddWithValue("@contrasena", this.TextFieldContrasena.Text);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();



            X.Msg.Alert("Notificación", "Datos han sido guardados", new MessageBoxButtonsConfig
            {

                Ok = new MessageBoxButtonConfig
                {
                    Text = "Ok"

                }
            }).Show();


        }


        private void CargarCorrelativo()
        {

            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(codigo) +1 codigo FROM dbo.Usuarios", con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.TextFieldCodigo.Text = (reader["codigo"].ToString());
            }

        }
    }
}
