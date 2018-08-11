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
//using System.Web.HttpException;

namespace WorkFlow_Seguros_Futuro
{
    public partial class ver_adjuntos_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("/files/");
        string[] files = System.IO.Directory.GetFiles(path,"*.pdf");

        List<object> data = new List<object>(files.Length);

        foreach (string fileName in files)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            
            data.Add(new { name = fi.Name,
                           url = "/files/" + fi.Name,
                           size = fi.Length,
                           lastmod = fi.LastAccessTime });
        }

        this.Store1.DataSource = data;
        this.Store1.DataBind();
        }

        //protected void Consultar_Click(object sender, DirectEventArgs e)
        //{
        //    string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["LN_ConnectionString"].ConnectionString;

        //    string sql_master = " select nombre, documento_identidad,nacionalidad,condicion,fecha_oficio,recibido,respuesta,oficio_circular,ente_fiscalizador,observacion ";
        //    sql_master += "  ,tipopersona,aka,nit,otra_info,contratante,estado_p,tpoliza,cumulo_prima,cumulo_suma_asegurada,CONVERT(CHAR(10),vigencia_de,103) vigencia_de,CONVERT(CHAR(10),vigencia_hasta,103) vigencia_hasta,nivel_riesgo    ";
        //    sql_master += " from Lista_negra ";
        //    sql_master += " Where condicion='Positivo' ";
        //    SqlConnection con = new SqlConnection(strCon);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con;
        //    sql_master += "  ";


        //    if (!String.IsNullOrEmpty(this.TextFieldNombre.Text))
        //    {
        //        //sql_master += " AND ad.cnpoliza like '%" + this.TextFieldCnpoliza.Text + "%'";
        //        sql_master += " WHERE nombre =@nombre ";
        //        cmd.Parameters.AddWithValue("@nombre", this.TextFieldNombre.Text);
        //    }

        //    if (!String.IsNullOrEmpty(this.TextFieldReferencia.Text))
        //    {
        //        sql_master += " WHERE referencia=@referencia ";
        //        cmd.Parameters.AddWithValue("@referencia", this.TextFieldReferencia.Text);
        //    }

        //    cmd.CommandTimeout = 3600000;
        //    cmd.CommandText = sql_master;
        //    SqlDataReader reader = cmd.ExecuteReader();


        //    while (reader.Read())
        //    {
        //        this.TextFieldNombreF.Text = (reader["nombre"].ToString());
        //        this.TextFieldDI.Text = (reader["documento_identidad"].ToString());
        //        this.TextFieldnacionalidad.Text = (reader["nacionalidad"].ToString());
        //        this.TextFieldIVigencia.Text = (reader["condicion"].ToString());
        //        this.DateFieldfechaoficio.Text = (reader["fecha_oficio"].ToString());
        //        this.DateFieldrecibido.Text = (reader["recibido"].ToString());
        //        this.DateFieldRespuesta.Text = (reader["respuesta"].ToString());
        //        this.TextFieldoficiocircular.Text = (reader["oficio_circular"].ToString());
        //        this.TextFieldPoliza.Text = (reader["ente_fiscalizador"].ToString());
        //        this.TextAreaCodigo.Text = (reader["observacion"].ToString());
        //        this.TextFieldaka.Text = (reader["aka"].ToString());
        //        this.TextFieldTpersona.Text = (reader["tipopersona"].ToString());
        //        this.TextFieldnit.Text = (reader["nit"].ToString());
        //        this.TextAreaotrainfo.Text = (reader["otra_info"].ToString());
        //        this.TextFieldtpoliza.Text = (reader["tpoliza"].ToString());
        //        this.TextFieldEstado.Text = (reader["estado_p"].ToString());
        //        this.TextFieldcprima.Text = (reader["cumulo_prima"].ToString());
        //        this.TextFieldcpasegurada.Text = (reader["cumulo_suma_asegurada"].ToString());
        //        this.DateField5.Text = (reader["vigencia_de"].ToString());
        //        this.DateField6.Text = (reader["vigencia_hasta"].ToString());
        //        this.TextField3.Text = (reader["nivel_riesgo"].ToString());
        //        ;




        //    }

        //    //Cargar_Grid_consulta(null, null);
        //}

    }

    
}