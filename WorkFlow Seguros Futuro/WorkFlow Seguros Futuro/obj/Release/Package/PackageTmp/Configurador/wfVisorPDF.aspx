<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfVisorPDF.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Configurador.wfVisorPDF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <ext:ResourceManager runat="server" />
            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
                <Items>
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
                                        Height="700"
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
