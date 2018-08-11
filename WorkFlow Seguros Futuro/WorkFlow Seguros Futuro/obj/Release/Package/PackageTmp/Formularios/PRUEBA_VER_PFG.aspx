<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Formularios/PRUEBA_VER_PFG.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Formularios.PRUEBA_VER_PFG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .pdfContainer {
            position: absolute;
            overflow: hidden;
            width: 100%;
            height: 100%;
        }

            .pdfContainer iframe {
                min-width: 100%;
                min-height: 100%;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
                <Items>
                    <ext:Panel runat="server" ID="PanelNorte" Region="North" BodyPadding="5" Split="true" Layout="HBoxLayout">
                        <TopBar>
                            <ext:Toolbar ID="Panel_buttons" runat="server">
                                <Items>
                                    <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout" DefaultAnchor="98%">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="ComboBoxArea" FieldLabel="Area" DisplayField="descripcion" ValueField="codigo" LabelWidth="30" MarginSpec="0 5 0 0">
                                                <Store>
                                                    <ext:Store runat="server" ID="StoreArea">
                                                        <Model>
                                                            <ext:Model ID="Model3" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="codigo" />
                                                                    <ext:ModelField Name="descripcion" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>
                                            <ext:TextField ID="Correlativo" FieldLabel="Correlativo" runat="server" MarginSpec="0 5 0 0" LabelWidth="70">
                                                <DirectEvents>
                                                    <SpecialKey OnEvent="Guardar_buscar" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                                        <EventMask ShowMask="true" Msg="Buscando..." />
                                                    </SpecialKey>
                                                </DirectEvents>
                                            </ext:TextField>
                                            <ext:ComboBox runat="server" ID="ComboBox1" FieldLabel="Doc." DisplayField="name" LabelWidth="30" MarginSpec="0 5 0 0">
                                                <Store>
                                                    <ext:Store runat="server" ID="Store1">
                                                        <Model>
                                                            <ext:Model ID="Model1" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="name" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>
                                            <ext:Button ID="Button2" runat="server" Text="PDF" Icon="PageWhiteAcrobat">
                                                <DirectEvents>
                                                    <Click OnEvent="mostrarPDF">
                                                    </Click>
                                                </DirectEvents>
                                                <Listeners>
                                                    <Click Handler="#{Portlet1}.show();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:FieldContainer>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                    </ext:Panel>
                    <ext:Portal
                        ID="Portal1"
                        runat="server"
                        Border="false"
                        BodyStyle="background-color: transparent;"
                        Region="Center">
                        <Items>
                            <ext:PortalColumn ID="PortalColumn1"
                                runat="server"
                                ColumnWidth="1.0"
                                ColunmHeight="1.0"
                                SingleExpand="false"
                                Region="Center">

                                <Items>
                                    <ext:Portlet
                                        ID="Portlet1"
                                        runat="server"
                                        Title="Solicitud"
                                        Height="1000"                                       
                                        Region="Center"
                                        Frame="True"
                                        BodyPadding="0">
                                        <Loader ID="Loader2" runat="server" Url="" Mode="Frame">
                                            <LoadMask ShowMask="true" />
                                        </Loader>
                                    </ext:Portlet>
                                </Items>
                            </ext:PortalColumn>
                        </Items>
                    </ext:Portal>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
