using System.Web;
using System.Data;

namespace WorkFlow_Seguros_Futuro
{
    /// <summary>
    /// Descripción breve de Manejador
    /// </summary>
    public class Manejador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["Registro"] != null)
            {
                DataTable tbRegistro = (DataTable)context.Session["Registro"];
                DataRow drRegistro = tbRegistro.Select(string.Format("codigo={0}", context.Request.QueryString["codigo"]))[0];
                byte[] imagen = (byte[])drRegistro["imagen"]; /*["imagen"]*/
                context.Response.ContentType = "image/jpg";
                HttpContext.Current.Response.ContentType = "application/pdf";
                //HttpContext.Current.Response.ContentType = "application/ms-word";
                //HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                context.Response.OutputStream.Write(imagen, 0, imagen.Length);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}