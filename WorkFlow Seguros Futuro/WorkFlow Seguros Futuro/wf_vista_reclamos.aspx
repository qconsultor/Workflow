<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_vista_reclamos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_vista_reclamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
</head>
    <script>
        var saveData = function () {
            App.HiddenData.setValue(Ext.encode(App.GridPanel1.getRowsValues({ selectedOnly: false })));
        };
    </script>
<body>
    <form id="form1" runat="server">
        <ext:Hidden ID="HiddenData" runat="server" />
   <%-- <ext:Panel runat="server" ID="PanelPrincipal" Title="Reclamos"  Layout="TableLayout" TitleAlign="Center" Theme="Neptune" Icon="Vcard" Height="115" Region="North">
                    <Items>--%>
                 <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab"  Layout="FitLayout" Title="Vista de Reclamos">
                    <Store>
                        <ext:Store runat="server" ID="Store1">
                            <Model>
                                <ext:Model ID="Model2" runat="server" >
                                    <Fields>
                                        <ext:ModelField Name="correlativo" />
                                        <ext:ModelField Name="fecha" />
                                        <ext:ModelField Name="area" />
                                        <ext:ModelField Name="cooperativa" />
                                        <ext:ModelField Name="plan_" />
                                        <ext:ModelField Name="tipodepoliza" />
                                        <ext:ModelField Name="observaciones"/>
                                        <ext:ModelField Name="asegurado"/>
                                        <ext:ModelField Name="f_docompleta"/>
                                        <ext:ModelField Name="f_emision"/>
                                        <ext:ModelField Name="f_e_firmas"/>
                                        <ext:ModelField Name="f_ate_cliente"/>
                                 </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
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
                            <ext:Column ID="Column1" runat="server" DataIndex="f_docompleta" Text="Fecha de Documentacion Completa" Width="100px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server" DataIndex="f_emision" Text="Fecha de Emision" Width="100px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column3" runat="server" DataIndex="f_e_firmas" Text="Fecha de Entrega de Firmas" Width="100px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column4" runat="server" DataIndex="f_ate_cliente" Text="Fecha de Entrega Atencion al Cliente" Width="100px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            
                        </Columns>
                    </ColumnModel>
                      <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel" runat="server" />
                    </SelectionModel>
                    <DirectEvents>
                        <RowDblClick OnEvent="RealizarConsulta_Click">
                            <EventMask ShowMask="true" Msg="Procesando..." />
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="id" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>
                     <Plugins>
                      <ext:GridFilters ID="GridFilters2" runat="server" />

                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" AutoScroll="true" HideRefresh="true"/>
                    </BottomBar>
                    

                    </ext:GridPanel>
                 <ext:Window runat="server" ID="WindowModificacion" Title="Modificacion" Width="600" Height="350" BodyPadding="10" Resizable="true"
            Closable="true" Layout="AutoLayout" Region="Center" TitleAlign="Center" Icon="UserGray" Modal="true" Maximizable="true"  AutoScroll="true" Hidden="true">
            <Items>
                <ext:FormPanel ID="FormPanel2" runat="server" Border="false" Frame="true" BodyStyle="background-color: transparent" AutoScroll="true" Layout="FormLayout">
                    <Items>
                        <ext:TextField ID="TextFieldCodigo" runat="server"  FieldLabel="Correlativo" DataIndex="correlativo"/>
                             <%--<ext:ComboBox ID="ComboBox1" runat="server" FieldLabel="Tipo de Worflow" DataIndex="tipo_wf" Width="300px" IDMode="Static">
                                            
                             </ext:ComboBox>--%>

                        <ext:ComboBox runat="server" ID="ComboBoxPasos" Width="500px" TypeAhead="false" PageSize="10"
                            FieldLabel="Asignar Tecnico" DisplayField="nombre" ValueField="usuario" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="StorePasos" runat="server">
                                    <Model>
                                        <ext:Model ID="Model4" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="usuario"></ext:ModelField>
                                                <ext:ModelField Name="nombre"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl1" runat="server">
                                    <Html>
                                        <div class="search-item">
                       <h3><span>Tarea: </span>{nombre}</h3>
                       <b>Código: {req_cod}</b>
                      </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                           <%-- <DirectEvents>
                                <Select OnEvent="Grid_Buscador" />
                            </DirectEvents>--%>
                        </ext:ComboBox>
                                           
                                       
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button1" runat="server" Text="Asignar Tecnico" Icon="ControlAdd">
                            <DirectEvents>
                                <Click OnEvent="Actualizar_ClickPendiente" />
                            </DirectEvents>
                        </ext:Button>
                        
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>

             <%--</Items>

        </ext:Panel>--%>
         
    </form>
</body>
</html>
