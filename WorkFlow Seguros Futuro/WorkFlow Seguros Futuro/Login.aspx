<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.WebForm1" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
     <ext:panel ID="Panel1" runat="server"  alt="imagen" class="auto-style1" longdesc="sia-productores" >
        
    </ext:panel>
    <title>Login - Sistema Integrado Administrativo </title>    
    <style type="text/css">
        .auto-style1 {
            width: 638px;
            height: 166px;
        }
    </style>
</head>
   
    
<body style="background-color: deepskyblue">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" Height="200" Icon="Lock" Title="Login" Draggable="false" Width="350" Modal="true" BodyPadding="5"
            Layout="Form" StyleSpec="background-color: transparent;">
            <Items>
                <ext:TextField ID="txtUsername" runat="server" FieldLabel="Usuario" AllowBlank="false"
                    EmptyText="Digite Usuario"/>
                <ext:TextField ID="txtPassword" runat="server" InputType="Password" FieldLabel="Password" AllowBlank="false" 
                    EmptyText="Digite Contraseña">
                    <DirectEvents>
                        <SpecialKey OnEvent="Login_Click" Before="return e.getKey() == Ext.EventObject.ENTER;">
                            <EventMask ShowMask="true" Msg="Verificando..." />
                        </SpecialKey>
                    </DirectEvents>
                </ext:TextField>
            </Items>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Login" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="Login_Click" Success="#{Window1}.close();">
                            <EventMask ShowMask="true" Msg="Verificando..." MinDelay="1000" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
