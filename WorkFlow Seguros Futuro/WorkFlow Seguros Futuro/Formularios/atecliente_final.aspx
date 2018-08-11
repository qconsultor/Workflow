<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="atecliente_final.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Formularios.atecliente_final" %>

<%@ Import Namespace="Ext.Net.Utilities" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Associations - Ext.Net Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />

</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div>
            <ext:Viewport ID="Viewport" runat="server" Layout="BorderLayout">
                <Items>
                    <ext:GridPanel ID="GridPanelMalla" runat="server" Region="North"
                        MinWidth="225"
                        MaxWidth="400" Frame="false" Reference="GridPanelMalla">
                        <Store>
                            <ext:Store ID="StoreMalla" runat="server">
                                <Model>
                                    <ext:Model ID="Model1" runat="server" IDProperty="codigo">
                                        <Fields>
                                            <ext:ModelField Name="codigo" />
                                            <ext:ModelField Name="nombre" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ID="Columnarea" runat="server" Text="Codigo" DataIndex="codigo" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Columncorrelativo" runat="server" Text="Area" DataIndex="nombre" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                <DirectEvents>
                                    <Select OnEvent="PorArea" />
                                </DirectEvents>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                    </ext:GridPanel>

                    <ext:GridPanel ID="GridPanel1" runat="server" Collapsible="true" Region="Center"
                        Width="700px" Height="700px" Frame="false">
                        <Store>
                            <ext:Store ID="StoreSolic" runat="server">
                                <Model>
                                    <ext:Model ID="Model2" runat="server" IDProperty="correlativo">
                                        <Fields>
                                            <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="asegurado" />
                                            <ext:ModelField Name="cod_area" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column ID="Column1" runat="server" Text="Codigo" DataIndex="correlativo" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column2" runat="server" Text="Area" DataIndex="asegurado" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                <DirectEvents>
                                    <Select OnEvent="PorArea" />
                                </DirectEvents>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                    </ext:GridPanel>
<%--                    <ext:GridPanel ID="GridPanel2" runat="server" Collapsible="true" Region="East"
                        Width="700px" Height="700px" Frame="false">
                        <Store>
                            <ext:Store ID="StoreGestion" runat="server">
                                <Model>
                                    <ext:Model ID="Model3" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="asegurado" />
                                            <ext:ModelField Name="fecha" />
                                            <ext:ModelField Name="Comentario" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel3" runat="server">
                            <Columns>
                                <ext:Column ID="Column3" runat="server" Text="Correlativo" DataIndex="correlativo" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column4" runat="server" Text="Asegurado" DataIndex="asegurado" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column5" runat="server" Text="Fecha Gestión" DataIndex="fecha" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column6" runat="server" Text="Comentarios" DataIndex="Comentario" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>--%>
                    <%--  <ext:FormPanel ID="FormPanel1"
                        runat="server"
                        Title="Gestion"
                        Frame="true"
                        Height="400"
                        Width="400"
                        Border="false"
                        BodyPadding="10"
                        DefaultAnchor="100%" Region="Center">
                        <FieldDefaults
                            LabelAlign="Top"
                            LabelWidth="100"
                            LabelStyle="font-weight:bold;" />
                        <Defaults>
                            <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                        </Defaults>
                        <Items>
                            <ext:FieldContainer runat="server" ID="FieldContainer1" FieldLabel="Correlativo">
                                <Items>
                                    <ext:TextField ID="TextFieldCorrelativo" runat="server" ReadOnly="true"></ext:TextField>
                                </Items>
                            </ext:FieldContainer>
                            <ext:TextField ID="TextFieldAsegurado" runat="server" FieldLabel="Asegurado" ReadOnly="true"></ext:TextField>
                            <ext:FieldContainer runat="server" ID="FieldContainer2" FieldLabel="Area" Layout="HBoxLayout">
                                <Items>
                                    <ext:TextField ID="TextFieldArea" runat="server" MarginSpec="0 4 0 0" ReadOnly="true"></ext:TextField>
                                    <ext:TextField ID="TextFieldcod_area" runat="server" Width="40" ReadOnly="true"></ext:TextField>
                                </Items>
                            </ext:FieldContainer>
                            <ext:TextField ID="TextFieldFecha" runat="server" FieldLabel="Fecha Gestión" ReadOnly="true"></ext:TextField>
                            <ext:TextArea ID="TextArea1"
                                runat="server"
                                FieldLabel="Comentario"
                                Flex="1"
                                MarginSpec="0" />
                            <ext:Button runat="server" ID="ButtonGuardar" Text="Guardar" Icon="Accept"
                                Width="100" Handler="Ext.Msg.info({ui: 'success', title: 'Guardado', html: 'Se ha realizado Correctamente', iconCls: '#Accept'});">
                                <DirectEvents>
                                    <Click OnEvent="Guardar">
                                    </Click>
                                </DirectEvents>
                                <DirectEvents>
                                    <Click OnEvent="PorCorrelativo">
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                        <Buttons>
                            <ext:Button ID="Button1" runat="server" Text="Informacion Completa" Icon="Accept">
         <DirectEvents>
                                    <Click OnEvent="LoadData" />
                                </DirectEvents>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>--%>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
