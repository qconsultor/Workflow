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
using System.Text;


namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_controlAcceso : System.Web.UI.Page
    {
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Grid(null, null);
            //Cargar_Combo_pasos();
            
        }

        protected void Grid(object sender, DirectEventArgs e)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;

            string sql_quejas_det = "select * from Control_accesos where fecha >=@del and fecha<=@al  ";

           

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50000;
            cmd.CommandText = sql_quejas_det;

            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@del", this.DateFieldfechainicio.SelectedDate);
            cmd.Parameters.AddWithValue("@al", this.DateFieldfechafin.SelectedDate);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();

            this.Store1.DataSource = datatable;
            this.Store1.DataBind();

            this.GridPanel1.Show();

        }
        
    }
}
       