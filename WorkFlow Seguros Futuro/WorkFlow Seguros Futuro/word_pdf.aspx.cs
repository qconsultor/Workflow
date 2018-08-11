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

//Install-Package iTextSharp-LGPL
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WorkFlow_Seguros_Futuro
{
    public partial class word_pdf : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            var doc1 = new Document();
            //use a variable to let my code fit across the page...
            string path = Server.MapPath("/files/");
            PdfWriter.GetInstance(doc1, new FileStream(path + "Doc1.pdf", FileMode.Create));
            doc1.Open();
            doc1.Add(new Paragraph("My first PDF"));
            doc1.Close();
        }
    }
}