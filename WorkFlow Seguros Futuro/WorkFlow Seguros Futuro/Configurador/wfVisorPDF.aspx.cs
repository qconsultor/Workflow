using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace WorkFlow_Seguros_Futuro.Configurador
{
    public partial class wfVisorPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pdf;

            pdf = Request.QueryString["path"];
            mostrarPDF(pdf);
        }

        void mostrarPDF(string path)
        {
            this.Portlet1.LoadContent(new ComponentLoader()
            {
                //Url = "MaestroRequisitos.aspx",
                Url = path,
                Mode = LoadMode.Frame,
                AutoLoad = true,
                LoadMask = { ShowMask = true, Msg = "Cargando..." }

            });
        }
    }
}