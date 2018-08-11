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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, DirectEventArgs e)
        {

            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(strcon);
            SqlCommand com = new SqlCommand("CheckUser", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@usuario", txtUsername.Text);
            SqlParameter p2 = new SqlParameter("@contrasena", txtPassword.Text);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();

            if (rd.HasRows)
            {

                rd.Read();
                X.Msg.Alert("Notificación", "Bienvenido", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"

                    }
                }).Show();

                Session["usuario"] = txtUsername.Text;
                Response.Redirect("wf_principal.aspx");

            }



            else
            {

                X.Msg.Alert("Notificación", "Usuario y Contrasena Incorrecto", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"

                    }
                }).Show();



            }

        }
    }
}