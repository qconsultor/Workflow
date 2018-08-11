<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imagen.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.imagen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="funciones.js"></script>
    <script type="text/javascript">
        function ValidNum(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 46);
        }
    </script>
    <style>
        .boton {
            background-color: #1883ba;
            background-image: -webkit-linear-gradient(rgba(41, 150, 47, .8), rgba(45, 194, 52, .2));
            background-image: -moz-linear-gradient(rgba(41, 150, 47, .8), rgba(45, 194, 52, .2));
            background-image: -o-linear-gradient(rgba(41, 150, 47, .8), rgba(45, 194, 52, .2));
            background-image: linear-gradient(rgba(41, 150, 47, .8), rgba(45, 194, 52, .2));
            -ms-border-radius: 8px;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            color: #fff;
            display: inline-block;
            font-family: ‘Pacifico’, Arial, sans-serif;
            font-size: 15px;
            line-height: 1;
            padding: 15px 25px;
            text-decoration: none;
            text-shadow: 0 -1px 1px rgba(25, 123, 29, .7);
        }


        .textbox {
            border: 1px solid #DBE1EB;
            font-size: 15px;
            font-family: Arial, Verdana;
            padding-left: 7px;
            padding-right: 7px;
            padding-top: 10px;
            padding-bottom: 10px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            -o-border-radius: 4px;
            background: #FFFFFF;
            background: linear-gradient(left, #FFFFFF, #F7F9FA);
            background: -moz-linear-gradient(left, #FFFFFF, #F7F9FA);
            background: -webkit-linear-gradient(left, #FFFFFF, #F7F9FA);
            background: -o-linear-gradient(left, #FFFFFF, #F7F9FA);
            color: #2E3133;
        }

            .textbox:focus {
                color: #2E3133;
                border-color: #FBFFAD;
            }

        .auto-style4 {
            width: 663px;
        }

        #myPDF {
            margin-left: 0px;
            width: 468px;
            margin-right: 4px;
            height: 492px;
        }

        .auto-style15 {
            width: 44px;
        }

        .auto-style20 {
            height: 169px;
        }

        .auto-style21 {
            height: 45px;
        }

        .auto-style27 {
            width: 2258px;
        }
        .auto-style30 {
            height: 490px;
            width: 1534px;
        }
        .auto-style31 {
            width: 361px;
        }
        .auto-style33 {
            width: 299px;
        }
        .auto-style41 {
            width: 879px;
        }
        .auto-style42 {
            width: 1059px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="zoom.css" media="screen" />



</head>
<body>


    <form id="form1" class="" runat="server">
        <div align="center" style="height: 516px; width: 1658px">
            <%--<h2>WORKFLOW-  CONSULTA DE ADJUNTOS </h2>--%>


            <table border="1" dir="ltr" style="height: 504px; width: 1414px; margin-right: 0px">
                <tr>
                    <td class="auto-style27">
                        <asp:Panel ID="panelRegistrar" runat="server" BackColor="#CCFFCC" Width="1594px" Height="509px">
                            <table border="1" class="auto-style30">
                                <tr>
                                    <td class="auto-style15">
                                        <asp:Label ID="Label9" class="textbox" runat="server" Text="Correlativo" Width="150px"></asp:Label>
                                    </td>
                                    <td style="text-align: left" class="auto-style42">
                                        <left><asp:TextBox ID="TextBox1" runat="server" class="textbox" Width="200px"></asp:TextBox></left>
                                    </td>
                                    <td rowspan="6" class="auto-style33">
<asp:Panel ID="panel2" runat="server" BackColor="#CCFFCC" Height="489px" Width="568px">
                                                    <%--<div>--%>
                                                    <%--<iframe id="myPDF" runat="server" frameborder="0" name="myPDF" src="previa.html" transparency="transparency"></iframe>--%>
                                                    <%--</div>--%>

                                                    <asp:GridView ID="gridListado" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo" ForeColor="#333333" GridLines="None" Height="292px" OnPageIndexChanging="gridListado_PageIndexChanging" OnRowDeleting="gridListado_RowDeleting" OnSelectedIndexChanged="gridListado_SelectedIndexChanged1" PageSize="5" Width="550px" style="margin-top: 0px">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:BoundField DataField="codigo" HeaderText="Correlativo" />
                                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Imagen" Visible="false" />
                                                            <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="Fecha Registro" />
                                                            <asp:TemplateField HeaderText="Descargar" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="nombre" runat="server" NavigateUrl='<%# Eval("Nombre", "~/files/{0}") %>' Target="myPDF" Text='<%# Eval("Nombre") %>' Visible="true">
                                                                </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="nombre" HeaderText="DESCRIPCION" />
                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerSettings Visible="False" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                    
                                                </asp:Panel>
                                       
                                    </td>

                                     <td rowspan="6" class="auto-style31">
                                       <asp:Panel ID="panel50" runat="server" BackColor="#2dc234" Width="480px" Height="503px" style="margin-right: 0px">
                                       
                                                <iframe id="myPDF" runat="server" frameborder="0" name="myPDF" src="previa.html" transparency="transparency"></iframe>
                                               
                                        </asp:Panel>
                                       
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style15">
                                        <asp:Label ID="Label7" class="textbox" runat="server" Text="Descripcion de Imagen " Width="150px"></asp:Label></td>
                                    <td style="text-align: left" class="auto-style42">
                                        <left><asp:TextBox ID="txtDescripcion" class="textbox" runat="server" Width="200px"></asp:TextBox></left>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">
                                        <asp:Label ID="Label6" class="textbox" runat="server" Text="Fecha" Width="150px"></asp:Label></td>
                                    <td style="text-align: left" class="auto-style42">
                                        <left> <asp:TextBox ID="txtFecha" runat="server" class="textbox" TextMode="Date" Width="200px"></asp:TextBox></left>
                                    </td>
                                </tr>
                                <tr>
                                    <%--<td class="auto-style15">&nbsp;</td>
                                    <td class="auto-style8">
                                        &nbsp;</td>--%>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center" class="auto-style21">
                                         <asp:Label ID="Label5" runat="server" class="textbox" Text="Imagen" Width="71px" Height="16px"></asp:Label>
                                        <asp:FileUpload ID="FileUpload" runat="server"  class="textbox" Width="240px" />
                                        <asp:Button ID="btnGuardar0" runat="server" class="boton" Height="49px" OnClick="btnGuardar_Click" Style="margin-top: 2px" Text="Agregar" Width="112px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style20">
                                       <asp:Label ID="Label1" runat="server" align="left" class="textbox" Text="Codigo de cliente" Width="138px"></asp:Label>
                                        <asp:TextBox ID="TextBox3" runat="server" class="textbox" Style="margin-left: 20px" Width="100px"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" class="boton" Height="49px" OnClick="Button1_Click" Style="margin-left: 0px" Text="Consultar" Width="141px" />
                                        <br />
                                        <asp:Button ID="btnNuevo" runat="server" class="boton" Height="49px" OnClick="btnNuevo_Click" Text="Nuevo" Width="140px" />
                                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                                         <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>
                                        
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                    </td>
                </tr>
            </table>

            <br />

            <asp:Panel ID="panelMostrar" runat="server" BackColor="#CCCCFF" Height="16px" Width="1536px">
                <table style="width: 800px">


                    <tr>
                        <td style="text-align: center" class="auto-style4">
                            <br />
                            <br />
                        </td>


                    </tr>

                    <tr>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>

                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
