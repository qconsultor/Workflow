using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using Ext.Net;
using System.Xml;
using System.IO;
using System.Configuration;
using System.ComponentModel;

namespace WorkFlow_Seguros_Futuro
{
    public partial class CONSULTA_POR_AREA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack && ThemeSelector.SelectedItems.Count > 0)
                {
                    ListItem themeItem = ThemeSelector.SelectedItem;

                        switch (themeItem.Value)
                        {
                            case "0":
                                this.ResourceManager1.Theme = Ext.Net.Theme.Default;
                                break;
                            case "1":
                                this.ResourceManager1.Theme = Ext.Net.Theme.Gray;
                                break;
                            case "2":
                                this.ResourceManager1.Theme = Ext.Net.Theme.Neptune;
                                break;
                        }
                }
        }            
    }
}