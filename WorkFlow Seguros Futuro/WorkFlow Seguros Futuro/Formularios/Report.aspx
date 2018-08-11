<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Formularios.Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:FormPanel ID="FormPanelPrincipal" runat="server" Region="North" Title="Informe de Sondeo de Asistencia" Border="true">
                <Items>
                    <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout">
                        <Items>
                            <ext:DateField runat="server" ID="DateFieldfechainicio" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Del" DataIndex="fecha" />
                            <ext:DateField runat="server" ID="DateFieldfechafin" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Al" DataIndex="fecha" />
                        </Items>
                    </ext:FieldContainer>
                </Items>
                <Buttons>
                    <ext:Button ID="ButtonAceptar" runat="server" Text="Imprimir" Icon="Printer">
                        <DirectEvents>
                            <Click OnEvent="Imprimir_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>

            <ext:Window runat="server" ID="WindowSolicitudes" Hidden="true" Height="450px" Width="800px" Title="Informe de Sondeos" TitleAlign="Center" Icon="Report">
                <Loader ID="Loader2" runat="server" Url="../Reporte_HTML/Reporte.html" Mode="Frame" AutoLoad="true"></Loader>
            </ext:Window>

        </div>
    </form>
</body>
</html>
