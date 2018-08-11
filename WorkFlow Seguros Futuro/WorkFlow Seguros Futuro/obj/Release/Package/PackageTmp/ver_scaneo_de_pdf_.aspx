<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ver_scaneo_de_pdf_.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.ver_scaneo_de_pdf_" %>

<!doctype html>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 3.2//EN">--%>
<html>
<head>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">
    <script src="https://code.jquery.com/jquery-1.11.3.min.js"></script>
    <script src="https://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>

    <meta charset="utf-8">
    <script type="text/javascript" src="<%=ResolveClientUrl("~/js/pdf.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveClientUrl("~/js/browser.js")%>"></script>
    <script type="text/javascript">
    </script>

    <title>Seguros Futuro WorkFlow</title>
    <script src="Scripts/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-tooltip/jquery.tooltip.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="https://code.jquery.com/jslib/jquery-1.9.1.js"></script>--%>
    <%--<script src="Scripts/jquery.tooltip.min.js"></script>--%>
    <script type="text/javascript">
        function InitializeToolTip() {
            $(".grilla").tooltip({
                track: true,
                delay: 250,
                showURL: false,
                fade: 100,
                bodyHandler: function () {
                    return $($(this).next().html());
                    //return $($(this));
                    //javascript: alert(this);
                    //loadPages(this)
                },
                showURL: false
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            InitializeToolTip();
        })
    </script>
    <style type="text/css">
            #tooltip {
            position: absolute;
            z-index: 3000;
            border: 1px solid #111;
            background: url(/Imagenes/1.gif);
            padding: 5px;
            color: White;
            border-radius: 10px;
            width: 350px;
            border: 0px;
            font-size: 18px;
            }

            #tooltip h3, #tooltip div {
                margin: 0;
            }
    </style>

    <%--<link rel="stylesheet" type="text/css" href="zoom.css" media="screen" />
    <link href="themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-1.10.2.js"></script>--%>

</head>
<body>

<%--<iframe http://docs.google.com/gview? src="file://172.16.2.229/files/2832/2832-0001.pdf" id="myFrame" width="500" marginwidth="0" height="500" marginheight="0" align="middle" scrolling="auto"></iframe>--%>
<%--<button onclick="loadPages()">Click Me</button>
<button onclick="loadPages1()">Click Me</button>
<button onclick="loadPages2()">Click Me</button>--%>
<script>
    function loadPages(value) {
        var loc = value;
        document.getElementById('myFrame').setAttribute('url', loc);
    }
    function loadPages1() {
        var loc = "file://172.16.2.229/files/5171/5171-0001.pdf";
        document.getElementById('myFrame').setAttribute('url', loc);
        //javascript: alert(document.documentMode);
    }
    function loadPages2() {
        var loc = "file://172.16.2.229/files/5170/5170-0001.pdf";
        document.getElementById('myFrame').setAttribute('url', loc);
        //javascript: alert(document.documentMode);
    }
</script>

<form id="form1" runat="server">
    <div data-role="page" id="pageone">
    <div data-role="panel" id="myPanel"> 
        <h2>Buscar por ??::</h2>
        <%--<p>You can close the panel by clicking outside the panel, pressing the Esc key or by swiping.</p>--%>
        <asp:Label ID="Label1" runat="server" align="left" class="textbox" Text="Codigo de Area" Width="138px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" class="textbox" Style="margin-left: 20px" Width="100px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" align="left" class="textbox" Text="Correlativo" Width="138px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" class="textbox" Style="margin-left: 20px" Width="100px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" class="boton" Height="49px" OnClick="Button3_Click" Style="margin-left: 0px" Text="Consultar" Width="141px" />
        <%--<asp:Button ID="Button1" runat="server" class="boton" Height="49px" OnClick="Button4_Click" Style="margin-left: 0px" Text="exe" Width="141px" />--%>
    </div> 

    <div data-role="header">
    <%--<h1>Page Header</h1>--%>
    <div data-role="main" class="ui-content">
        <%--<p>Click on the button below to open the Panel.</p>--%>
        <a href="#myPanel" class="ui-btn ui-btn-inline ui-corner-all ui-shadow">Buscar</a>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <%--<asp:Label ID="Label3" runat="server" align="left" class="textbox" Text=".." Width="138px"></asp:Label>--%>
        <%--<asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>--%>
    </div>
    <table>
                <tr>
                    <td style="background-image: url('Imagenes/1.gif'); text-align: center; font-weight: 700; font-size: x-large; color: #FFFFFF;">
                        <strong>Consulta de Solicitudes(WF) Emision Reclamos Atencion al Cliente
                            <%--<iframe src="file://172.16.2.229/files/2832/2832-0001.pdf" id="myFrame" width="800" marginwidth="0" height="500" marginheight="0" align="middle" scrolling="auto"></iframe>--%>  
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td style="background-image: url('Imagenes/2.gif')">
                        <asp:GridView ID="GridDatosRegistro" AutoGenerateColumns="False" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridDatosRegistro_PageIndexChanging"  PageSize="5" OnSelectedIndexChanged="GridDatosRegistro_SelectedIndexChanged1" Width="738px" Style="margin-top: 0px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Ubicacion/pdf">
                                    <ItemStyle Width="300px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                           <%--<a href="#" onclick="loadPages('<%# Eval("ubicacion")%>')" class="grilla">--%>
                                           <a href="#" onclick="loadPages('<%# Eval("ubicacion")%>')" >
                                               <%# Eval("ubicacion")%>
                                        </a>

                                        <div id="tooltip" style="display: none ;">
                                            <table>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Nombres:</b>&nbsp;</td>
                                                    <td><%# Eval("nombre")%></td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Descripcion:</b>&nbsp;</td>
                                                    <td><%# Eval("descripcion")%></td>
                                                </tr>
                                                <%--<tr>
                                                    <td style="white-space: nowrap;"><b>Teléfono:</b>&nbsp;</td>
                                                    <td><%# Eval("telefono")%></td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Correo:</b>&nbsp;</td>
                                                    <td><%# Eval("correo")%></td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Cargo:</b>&nbsp;</td>
                                                    <td><%# Eval("cargo")%></td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Estado:</b>&nbsp;</td>
                                                    <td><%# Eval("estado")%></td>
                                                </tr>--%>
                                                <tr>
                                                    <td style="white-space: nowrap;"><b>Fecha:</b>&nbsp;</td>
                                                    <td><%# Eval("fecha")%></td>
                                                </tr>
                                                <%--<iframe src="file://172.16.2.229/files/2832/2832-0001.pdf" id="myFrame" width="800" marginwidth="0" height="500" marginheight="0" align="middle" scrolling="auto"></iframe>--%>  
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Nombre" DataField="nombre">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripcion" DataField="descripcion">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha" DataField="fecha">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="False" />
                                <asp:BoundField DataField="correo" HeaderText="Correo" Visible="False" />
                                <asp:BoundField DataField="estado" HeaderText="Estado" Visible="False" />
                                <asp:BoundField DataField="cargo" HeaderText="Cargo" Visible="False" />--%>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="background-image: url('Imagenes/1.gif')">&nbsp;
                    </td>
                </tr>
              <%--<iframe src="file://172.16.2.229/files/2832/2832-0001.pdf" id="myFrame" width="800" marginwidth="0" height="500" marginheight="0" align="middle" scrolling="auto"></iframe>--%>  
  </table>
    </div>

    <%--<div data-role="main" class="ui-content">
        <%--<p>Click on the button below to open the Panel.</p>
        <a href="#myPanel" class="ui-btn ui-btn-inline ui-corner-all ui-shadow">Buscar</a>
    </div>--%>

    <div data-role="footer">
        <h1>Archivos Adjuntos</h1>
        <iframe http://docs.google.com/gview? url="file://172.16.2.229/files/2832/2832-0001.pdf" target="Blank_" id="myFrame" width="1600" marginwidth="0" height="500" marginheight="0" align="middle" scrolling="auto" frameborder="0"></iframe>
    </div> 
    </div> 


 
</form>
</body>
</html>