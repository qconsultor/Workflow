<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_envio_solicitudes.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Formularios.wf_envio_solicitudes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceManager1" />
        <div>
            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
                <Items>
                    <ext:Panel ID="Panel2" Region="North" runat="server" ColumnWidth="0.5" Layout="FormLayout" Width="600px" Border="false" DefaultAnchor="50%" AnchorHeight="50" MarginSpec="0 5 0 0">
                        <Items>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" FieldLabel="Del">
                                <Items>
                                    <ext:DateField ID="DateFieldDel" runat="server" LabelWidth="20" MarginSpec="0 5 0 0" />
                                    <ext:DateField ID="DateFieldAl" runat="server" FieldLabel="Al:" LabelWidth="20" MarginSpec="0 5 0 0" />
                                    <ext:Button runat="server" ID="ButtonIndicador" Text="Indicador" Icon="Printer" Region="Center">
                                    </ext:Button>
                                </Items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel1" runat="server" ColumnWidth="0.3" Layout="FormLayout" Width="200px" Border="false" DefaultAnchor="50%" AnchorHeight="50" Region="East">
                        <Items>
                            <ext:TextField runat="server" ID="TextFieldNumero" FieldLabel="#" AllowBlank="false">
                            </ext:TextField>
                            <ext:DateField ID="DateFieldFecha" runat="server" FieldLabel="Fecha" LabelWidth="20" MarginSpec="0 5 0 0" AllowBlank="false" />
                            <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout">
                                <Items>
                                    <ext:Button runat="server" ID="ButtoImprimir" Text="Imprimir" Icon="Printer">
                                        <DirectEvents>
                                            <Click OnEvent="histo">
                                                <EventMask ShowMask="true" Msg="Cargando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:Panel>


                    <ext:GridPanel ID="GridPanelMalla" runat="server" Collapsible="true" Region="Center" AnimCollapse="true"
                        Width="700px" Height="700px" Frame="false">
                        <Store>
                            <ext:Store ID="StoreMalla" runat="server">
                                <Model>
                                    <ext:Model ID="Model1" runat="server" IDProperty="correlativo">
                                        <Fields>
                                            <ext:ModelField Name="area" />
                                            <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="asegurado" />
                                            <ext:ModelField Name="plan_" />
                                            <ext:ModelField Name="cantidadsolicitudes" />
                                            <ext:ModelField Name="che_envio" Type="Boolean" />
                                            <ext:ModelField Name="en_re_at" />
                                            <ext:ModelField Name="ref_en_re_at" />
                                            <ext:ModelField Name="che_recibido" Type="Boolean" />
                                            <ext:ModelField Name="f_desti" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ID="Columnarea" runat="server" Text="Area" DataIndex="area" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Columncorrelativo" runat="server" Text="Correlativo" DataIndex="correlativo" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Columnasegurado" runat="server" Text="Nombre del Asegurado" DataIndex="asegurado" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>

                                <ext:Column ID="Columnplan" runat="server" Text="Plan de Seguro" DataIndex="plan_" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Columncantsol" runat="server" Text="Cantidad de Solicitudes" DataIndex="cantidadsolicitudes" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:CheckColumn ID="CheckColumenviado" runat="server" Text="Enviado" DataIndex="che_envio" Flex="1" Sortable="false" Editable="true">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:CheckColumn>
                                <ext:Column ID="Columnfechaenv" runat="server" Text="Fecha de Envio" DataIndex="en_re_at" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Columnref" runat="server" Text="Ref. de envio" DataIndex="ref_en_re_at" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:CheckColumn ID="CheckColumnrecibido" runat="server" Text="Recibido" DataIndex="che_recibido" Flex="1" Sortable="false" Editable="true">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:CheckColumn>
                                <ext:Column ID="Columndestino" runat="server" Text="Fecha de Recibido" DataIndex="f_desti" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi">
                            </ext:CheckboxSelectionModel>
                        </SelectionModel>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <ext:Button ID="Button4" runat="server" Text="Enviar" Icon="ArrowRight">
                                        <DirectEvents>
                                            <Click OnEvent="Enviado">
                                            </Click>
                                        </DirectEvents>
                                        <DirectEvents>
                                            <Click OnEvent="CargarHistorial">
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="Button1" runat="server" Text="Ver" Icon="Find">
                                        <DirectEvents>
                                            <Click OnEvent="CargarHistorial">
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>

                                    <ext:Button ID="RecibidoAT" runat="server" Text="Recibir" Icon="ArrowLeft" AlignTarget="Right">
                                        <DirectEvents>
                                            <Click OnEvent="recibido_AT">
                                            </Click>
                                        </DirectEvents>
                                        <DirectEvents>
                                            <Click OnEvent="histo">
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                    </ext:GridPanel>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
