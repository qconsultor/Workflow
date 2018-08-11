<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaestroRequisitos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.MaestroRequisitos" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Maestro de Requisitos</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />
    <style>
        .icon-exclamation {
            padding-left: 25px !important;
            background: url(/icons/exclamation-png/ext.axd) no-repeat 3px 0px !important;
        }
        
        .icon-accept {
            padding-left: 25px !important;
            background: url(/icons/accept-png/ext.axd) no-repeat 3px 0px !important;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Panel ID="Panel1" 
            runat="server" 
            Layout="FitLayout" 
            Width="600" 
            Height="250">
            <Items>
                <ext:FormPanel 
                    ID="FormPanel1" 
                    runat="server" 
                    Title="Maestro de Requisitos (Todos son Necesarios)"
                    BodyPadding="5"                     
                    ButtonAlign="Right"
                    Layout="Column">
                    <Items>
                        <ext:Panel ID="Panel2" 
                            runat="server" 
                            Border="false" 
                            Header="false" 
                            ColumnWidth=".5" 
                            Layout="Form" 
                            LabelAlign="Top">
                            <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                            </Defaults>
                            <Items>
                                <ext:TextField ID="TextField1" runat="server" FieldLabel="First Name" AnchorHorizontal="92%" />
                                <ext:TextField ID="TextField2" runat="server" FieldLabel="Company" AnchorHorizontal="92%" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" Border="false" Layout="Form" ColumnWidth=".5" LabelAlign="Top">
                            <Defaults>
                                <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                <ext:Parameter Name="MsgTarget" Value="side" />
                            </Defaults>
                            <Items>
                                <ext:TextField ID="TextField3" runat="server" FieldLabel="Last Name" AnchorHorizontal="92%" />
                                <ext:TextField ID="TextField4" runat="server" FieldLabel="Email" Vtype="email" AnchorHorizontal="92%" />
                            </Items>
                        </ext:Panel>
                    </Items>
                    <BottomBar>
                        <ext:StatusBar ID="StatusBar1" runat="server" />
                    </BottomBar>
                    <Listeners>
                        <ValidityChange Handler="this.dockedItems.get(1).setStatus({
                                                     text : valid ? 'Datos Correctos' : 'Faltan Datos', 
                                                     iconCls: valid ? 'icon-accept' : 'icon-exclamation'
                                                 });
                                                 #{Button1}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button
                    ID="Button1"
                    runat="server" 
                    Text="Guardar"  
                    Disabled="true"
                    FormBind="true">
                    <Listeners>
                        <Click Handler="if (#{FormPanel1}.getForm().isValid()) {Ext.Msg.alert('Submit', 'Saved!');}else{Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'FormPanel is incorrecto', buttons:Ext.Msg.OK});}" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Cancelar" />
            </Buttons>
        </ext:Panel>        
    </form>
</body>
</html>
