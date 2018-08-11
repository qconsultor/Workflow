<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_maestro_imagenes.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_maestro_imagenes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   <style type="text/css">
        .auto-style4 {
           width: 278px;
       }
       .auto-style5 {
           height: 34px;
           width: 620px;
       }
       .auto-style6 {
           width: 1252px;
           height: 34px;
       }
       .auto-style14 {
           height: 5px;
           width: 620px;
       }
       .auto-style15 {
           width: 1252px;
           height: 5px;
       }
       .auto-style20 {
           width: 620px;
       }
       .auto-style21 {
           width: 1173px;
       }
       .auto-style22 {
           width: 1252px;
       }
    </style>  
   <link rel="stylesheet" type="text/css" href="zoom.css" media="screen" />

    
</head>
<body>

                    
    <form id="form1" class="formulariodemo" runat="server">
        <div align="center">
            <h2> WORKFLOW-  MAESTRO DE IMAGENES </h2>


            <table>
                <tr><td>

            <asp:Panel ID="panelRegistrar" runat="server" BackColor="#58FA82" Width="1000px">
                <table border="1">
                    <tr>
                        <td class="auto-style20">Correlativo:</td>
                        <td style="text-align: left" class="auto-style22">
                            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                        </td><td rowspan="5">
                            <asp:Panel ID="panel2" runat="server" BackColor="#58FA82" Width="300px">
                                
                                <table>
                                    <tr>
                                        <td  class="auto-style4">
                                            <asp:GridView ID="gridListado0" align="center"  runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridListado_PageIndexChanging" PageSize="3" OnSelectedIndexChanged="gridListado0_SelectedIndexChanged">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:BoundField DataField="codigo" HeaderText="Correlativo" />
                                                    <asp:BoundField DataField="codigocliente" HeaderText="Código Imagen" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Imagen" />
                                                    <asp:BoundField DataField="descripcion" HeaderText="Descripción Imagen" />
                                                    <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="Fecha Registro" />
                                                    <asp:TemplateField HeaderText="Imagen">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Imagen0" runat="server" class="zoom" Height="150px" ImageUrl='<%# Eval("codigo", "Manejador.ashx?codigo={0}") %>' Width="150px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Descargar">
                    <ItemTemplate>
                        <asp:HyperLink ID="descarga" runat="server" NavigateUrl='<%# Eval("codigo", "Manejador.ashx?codigo={0}") %>'>
                               <img src="../imagenes/download.gif" alt=""  style="border-width:0px;" Width="50px" Height="50px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
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
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">Nombre Imagen:</td>
                        <td style="text-align: left" class="auto-style22">
                            <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Descripción Imagen:</td>
                        <td style="text-align: left" class="auto-style15">
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">Fecha:</td>
                        <td style="text-align: left" class="auto-style22">
                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Imagen:</td>
                        <td class="auto-style6">
                            <asp:FileUpload ID="FileUpload" runat="server" Width="259px" />
                            <asp:Button ID="btnGuardar0" runat="server" OnClick="btnGuardar_Click" style="margin-top: 2px" Text="Agregar Imagen" Width="124px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Codigo de cliente"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Width="94px" style="margin-left: 66px"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Consultar" Width="141px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table> </asp:Panel>

                    </td></tr>
                </table>

            <asp:Panel ID="panelMostrar" runat="server" BackColor="#CCCCFF">
                <table>


                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="150px" />
                        </td>
                        <td style="text-align: center">
                            &nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridListado" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True"
                                OnPageIndexChanging="gridListado_PageIndexChanging" PageSize="5">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="Correlativo" />
                                     <asp:BoundField DataField="codigocliente" HeaderText="Código Imagen" />
                                     <asp:BoundField DataField="Nombre" HeaderText="Nombre Imagen" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripción Imagen" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha Registro" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Imagen">
                                        <ItemTemplate>
                                            <asp:Image ID="Imagen" class="zoom" runat="server" ImageUrl='<%# Eval("codigo", "Manejador.ashx?codigo={0}") %>'
                                                Width="50px" Height="50px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        <td style="text-align: center">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
