<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregar_usuarios.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.agregar_usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:Window ID="Window1"  runat="server"  Icon="UserSuit" Title="Mantenedor Usuarios" Border="false" Width="500"  Height="240" BodyPadding="10" Resizable="false" Closable="false" Layout="Fit">
            <Items>
                <ext:FormPanel runat="server" ID="FormPanelUsuarios" Icon="UserKey"  Layout="VBoxLayout" Width="500px" Height="500px" Region="Center">
                    <Items>
                        <ext:TextField ID="TextFieldCodigo" runat="server" Width="300px" FieldLabel="Codigo" />
                        <ext:TextField runat="server" ID="TextFieldUsuario" Width="300px" EmptyText="Digite Usuario" FieldLabel="Usuario" />
                        <ext:TextField runat="server" ID="TextFieldContrasena" Width="300px" EmptyText="Digite Contrasena" InputType="Password" FieldLabel="Contrasena"/>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="ButtonGuardarUsu" Text="Guardar" Icon="UserAdd">
                            <DirectEvents>
                                <Click OnEvent="Guardar_Click">
                                    <EventMask ShowMask="true" Msg="Guardando..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>      
            </Items>
            </ext:Window>
    </form>
</body>
</html>
