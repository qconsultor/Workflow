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
using System.Drawing;
using System.Text; // StringBuilder

namespace WorkFlow_Seguros_Futuro
{
    public partial class lista_adjuntos : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
            
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                string path = Server.MapPath("~/files");
                string[] files = System.IO.Directory.GetFiles(path);

                List<object> data = new List<object>(files.Length);

                foreach (string fileName in files)
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(fileName);

                    data.Add(new
                    {
                        name = file.Name,
                        url = "~/files/" + file.Name,
                        size = file.Length,
                        lastmod = file.LastAccessTime
                    });
                }

                Store store = this.GridPanel1.GetStore();

                store.DataSource = data;
                store.DataBind();
            }
        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (SelectedRow row in this.RowSelectionModel1.SelectedRows)
            {
                sb.AppendFormat("RecordID: {0}&nbsp;&nbsp;&nbsp;&nbsp;Row index: {1}<br/>", row.RecordID, row.RowIndex);
            }

            this.Label1.Html = sb.ToString();
        }

        protected void Clear_Click(object sender, DirectEventArgs e)
        {
            this.GridPanel1.GetSelectionModel().ClearSelection();
        }

        protected void Add_Click(object sender, DirectEventArgs e)
        {
            this.GridPanel1.GetSelectionModel().Select((object)"zack.jpg", true);
        }

        protected void SubmitSelection(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            Dictionary<string, string>[] images = JSON.Deserialize<Dictionary<string, string>[]>(json);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing=\"15\">");
            bool addText = true;

            foreach (Dictionary<string, string> row in images)
            {
                if (addText)
                {
                    sb.Append("<tr>");

                    foreach (KeyValuePair<string, string> keyValuePair in row)
                    {
                        sb.AppendFormat("<td style=\"white-space:nowrap;font-weight:bold;\">{0}</td>", keyValuePair.Key);
                    }

                    sb.Append("</tr>");

                    addText = false;
                }

                sb.Append("<tr>");

                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    sb.AppendFormat("<td style=\"white-space:nowrap;\">{0}</td>", keyValuePair.Value);
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");
            this.Label1.Html = sb.ToString();
        }
    }
}