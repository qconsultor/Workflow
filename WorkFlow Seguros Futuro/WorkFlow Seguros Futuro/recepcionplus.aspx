<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recepcionplus.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.recepcionplus" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style type="text/css" media="print">
        @page {
            size: landscape;
        }

        @media print {
            body, html, #wrapper {
                width: 100%;
            }
        }
    </style>
</head>
<%--<head id="Head1" runat="server">
    <title>KeyMap Toggling BorderLayout Regions - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" /> 
</head>--%>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel 
                ID="North" 
                runat="server" 
                Title="Recepcion" 
                Region="North" 
                Frame="true" 
                Height="300" 
                Collapsible="true"/>                                  
            <ext:Panel 
                ID="West" 
                runat="server" 
                Title="Correlativos" 
                Region="West" 
                Frame="true" 
                Width="200" 
                Collapsible="true" 
                />
            <ext:Panel ID="Panel1" runat="server" Region="Center" BodyPadding="5">
                <Content>
                    <ul>
                        <li>If keys are not working then click on center area</li>
                        <li>NORTH toggle: N</li>
                        <li>WEST toggle: W</li>
                        <li>EAST toggle: E</li>
                        <li>SOUTH toggle: S</li>
                    </ul>
                </Content>
            </ext:Panel>
            <ext:Panel 
                ID="East" 
                runat="server" 
                Title="Adjuntos" 
                Region="East" 
                Frame="true" 
                Width="200" 
                Collapsible="true" 
                />
            <ext:Panel 
                ID="South" 
                runat="server" 
                Title="South" 
                Region="South" 
                Frame="true" 
                Height="200" 
                Collapsible="true" 
                />
        </Items>
    </ext:Viewport>
    
    <ext:KeyMap ID="KeyMap1" runat="server" Target="={Ext.isGecko ? Ext.getDoc() : Ext.getBody()}">        
        <Binding>
                <ext:KeyBinding Handler="#{North}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="R" />
                </Keys>
            </ext:KeyBinding>    
        
            <ext:KeyBinding Handler="#{West}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="C" />
                </Keys>
            </ext:KeyBinding>
        
            <ext:KeyBinding Handler="#{East}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="A" />
                </Keys>
            </ext:KeyBinding>
        
            <ext:KeyBinding Handler="#{South}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="S" />
                </Keys>
            </ext:KeyBinding>
        </Binding>        
    </ext:KeyMap>
</body>
</html>
