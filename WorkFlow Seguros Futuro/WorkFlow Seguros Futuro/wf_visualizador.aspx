<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_visualizador.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_visualizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <ext:ResourceManager runat="server" ID="ResourceManager1" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:Viewport runat="server" ID="ViewPortPrinci" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" ID="PanelPrincipal" Region="North">
                <Items>
                     <ext:GridPanel ID="GridPanel1" runat="server" Title="Gestiones" Layout="AbsoluteLayout">
                        <Store>
                            <ext:Store runat="server" ID="Store1">
                                <Model>
                                    <ext:Model ID="Model2" runat="server">
                                        <Fields>
                                             <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="fecha" />
                                            <ext:ModelField Name="area" />
                                            <ext:ModelField Name="cooperativa" />
                                            <ext:ModelField Name="plan_" />
                                            <ext:ModelField Name="tipodepoliza" />
                                            <ext:ModelField Name="observaciones" />
                                            <ext:ModelField Name="asegurado" />
                                            <ext:ModelField Name="imagen" />
                                            <ext:ModelField Name="tsolicitud" />
                                            <ext:ModelField Name="adjunto" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="85" Header="Mostrar" Align="Center">
                                    <Commands>
                                        <%--<ext:GridCommand Icon="ApplicationViewColumns">
                                            <Menu EnableScrolling="false">
                                                <Items>
                                                    <ext:MenuCommand Text="Mostrar" Icon="LinkBreak" Handler="#{PanelSide}.show()" >
                                                    </ext:MenuCommand>
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="<b><i>Mostrar Detalle de Gestión de Cobros</i></b><br>" />
                                        </ext:GridCommand>--%>
                                    </Commands>
                                </ext:CommandColumn>
                                <ext:Column ID="Column9" runat="server" DataIndex="correlativo" Text="Correlativo" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column10" runat="server" DataIndex="fecha" Text="Fecha de Recibido" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column11" runat="server" DataIndex="area" Text="Area" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column12" runat="server" DataIndex="cooperativa" Text="Cooperativa" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column13" runat="server" DataIndex="plan_" Text="Plan de Seguro" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column14" runat="server" DataIndex="tipodepoliza" Text="Tipo de Poliza" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column17" runat="server" DataIndex="tsolicitud" Text="Tipo de Solicitud" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="column15" runat="server" DataIndex="observaciones" Text="Observaciones" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column16" runat="server" DataIndex="asegurado" Text="Nombre del Asegurado" Width="150px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column18" runat="server" Text="Archivo" Width="150px">
                                </ext:Column>
                                <%--<ext:ImageCommandColumn ID="ImageCommandColumn1" runat="server" DataIndex="imagen" Text="Imagen" />--%>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
           <%-- <ext:Panel runat="server" ID="Panelside" Title="Visualizador" Width="670" Hidden="true" Region="East" Icon="ReportDisk">
                <Loader ID="Loader1" runat="server" Url="previa.html" Mode="Frame" AutoLoad="true"/>
            </ext:Panel>--%>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
