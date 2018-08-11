<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firma.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.firma" %>

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
    <form id="form2" runat="server">
        <ext:Hidden ID="HiddenData" runat="server" />
   <%-- <ext:Panel runat="server" ID="PanelPrincipal" Title="Reclamos"  Layout="TableLayout" TitleAlign="Center" Theme="Neptune" Icon="Vcard" Height="115" Region="North">
                    <Items>--%>
                 <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab"  Layout="FitLayout" Title="FIRMAS">
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
                                        <ext:ModelField Name="Poliza_Maestra" />
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
                            <ext:Column ID="Column5" runat="server" DataIndex="Poliza_Maestra" Text="Poliza" Width="150px">
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

                        <ext:ComboBox runat="server" ID="ComboBox1" Width="500px" TypeAhead="false" PageSize="10"
                            FieldLabel="Tareas de Fin" DisplayField="paso" ValueField="paso" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="Store2" runat="server">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server">
                                            <Fields>
                                                
                                                <ext:ModelField Name="paso"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl2" runat="server">
                                    <Html>
                                        <div class="search-item">
                       <h3><span>Tarea: </span>{paso}</h3>
                       
                      </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                            <DirectEvents>
                                <Select OnEvent="ocultar" />
                            </DirectEvents>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="ComboBox3" FieldLabel="Conformidad" DataIndex="qa" Width="300px">
                                    <Items>
                                        <ext:ListItem Value="NO CONFORMIDAD" Text="NO CONFORMIDAD"/>
                                    </Items>
                               </ext:ComboBox> 
                        <ext:TextArea runat="server" ID="TextArea1" FieldLabel="Observaciones" DataIndex="observaciones" Flex="1" MarginSpec="0" AllowBlank="false" />
                         <ext:ComboBox runat="server" ID="ComboBox4" Width="500px" TypeAhead="false" PageSize="10"
                            FieldLabel="Asignar Tecnico" DisplayField="nombre" ValueField="usuario" TriggerAction="Query" QueryMode="Local" Hidden="true">
                            <Store>
                                <ext:Store ID="Store3" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="usuario"></ext:ModelField>
                                                <ext:ModelField Name="nombre"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl3" runat="server">
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
                             <ext:ComboBox runat="server" ID="ComboBox2" FieldLabel="Area" DataIndex="area" Width="300px">
                                    <Items>
                                        <ext:ListItem Value="Emisiones" Text="Emisiones"/>
                                        <ext:ListItem Value="ATENCION AL CLIENTE" Text="ATENCION AL CLIENTE"/>
                                    </Items>
                               </ext:ComboBox> 
                              <%-- <ext:DateField ID="DateField1" runat="server" Format="dd/MM/yyyy" FieldLabel="Fecha de documentacion completa" DataIndex="f_docompleta" Width="300px" IDMode="Static"  />
                               <ext:DateField ID="DateField2" runat="server" Format="dd/MM/yyyy" FieldLabel="Fecha de emision" DataIndex="f_emision" Width="300px" IDMode="Static" />
                               <ext:DateField ID="DateField3" runat="server" Format="dd/MM/yyyy" FieldLabel="Fecha entrega de firmas" DataIndex="f_e_firmas" Width="300px" IDMode="Static" />
                               <ext:DateField ID="DateField4" runat="server" Format="dd/MM/yyyy" FieldLabel="Fecha atencion al cliente" DataIndex="f_ate_cliente" Width="300px" IDMode="Static" />--%>
                                                                     
                                       
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button3" runat="server" Text="Expediente" Icon="FolderAdd" OnClientClick="#{Window1}.show();">
                                <DirectEvents>
                                 <Click OnEvent="TransferirParametros" />
                               </DirectEvents>
                        </ext:Button>
                         <ext:Button ID="Button1" runat="server" Text="Guardar" Icon="DiskBlackMagnify">
                            <DirectEvents>
                                <Click OnEvent="Verificador" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="Button2" runat="server" Text="Transferir" Icon="Transmit">
                            <DirectEvents>
                                <Click OnEvent="Actualizar_ClickPendiente" />
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>

        <ext:Window runat="server" ID="Window1" Hidden="true" Height="450px" Width="800px" Title="Consulta Expediente" Resizable="true"  Maximizable="true"  AutoScroll="true" TitleAlign="Center" Icon="Report">
            <Loader ID="Loader2" runat="server"  url="consulta_wf.aspx?Valor+ Valor; #{Window1}.getLoader().load({url:url});"  Mode="Frame" AutoLoad="true">
                
            </Loader>
        </ext:Window>

             <%--</Items>

        </ext:Panel>--%>
        <ext:Hidden ID="HiddenSesion" runat="server" />
        <ext:TextField runat="server" ID="TextFieldUSuario" Hidden="true" ></ext:TextField>
    </form>
</body>
</html>

