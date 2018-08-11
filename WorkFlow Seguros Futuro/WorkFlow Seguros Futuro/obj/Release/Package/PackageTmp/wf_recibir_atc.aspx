<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_recibir_atc.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_recibir_atc" %>

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
        <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:TextField ID="TextFieldCodigo" runat="server"  FieldLabel="Correlativo" DataIndex="correlativo" Hidden="true"/>
                         <ext:DateField runat="server" ID="DateFieldfechainicio" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Del" DataIndex="fecha" />
                         <ext:DateField runat="server" ID="DateFieldfechafin" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Al" DataIndex="fecha" />
                        </Items>
                </ext:FieldContainer>
                 <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab"  Layout="FitLayout" Title="SEGUIMIENTO EMISION">
                    <Store>
                        <ext:Store runat="server" ID="Store1">
                            <Model>
                                <ext:Model ID="Model2" runat="server" IDProperty="correlativo">
                                    <Fields>
                                        <ext:ModelField Name="correlativo" />
                                        <ext:ModelField Name="area" />
                                        <ext:ModelField Name="asegurado"/>
                                        <ext:ModelField Name="plan_" />
                                        <ext:ModelField Name="f_desti" />
                                        <ext:ModelField Name=" ref_en_re_at" />                                      
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
                            <ext:Column ID="Column11" runat="server" DataIndex="area" Text="Area" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column16" runat="server" DataIndex="asegurado" Text="Nombre del Asegurado" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column13" runat="server" DataIndex="plan_" Text="Plan de Seguro" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server" DataIndex="f_desti" Text="Envio Recepcion AC" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column3" runat="server" DataIndex=" ref_en_re_at" Text="Referencia de Envio" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                      <SelectionModel>
                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server"/>
                          
                    </SelectionModel>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="ButtonAceptar" runat="server" Text="Buscar" Icon="Find">
                            <DirectEvents>
                               <%-- <Click OnEvent="ButtonAceptar_Click" />--%>
                            </DirectEvents>
                        </ext:Button>
                                <ext:Button ID="Button2" runat="server" Text="<b>Recibir...</b>" Icon="FolderPage">
                                    <DirectEvents>
                                        <Click OnEvent="Actualizar_Click">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button> 
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <%--<DirectEvents>
                        <RowDblClick OnEvent="RealizarConsulta_Click">
                            <EventMask ShowMask="true" Msg="Procesando..." />
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="id" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>--%>
                     <Plugins>
                      <ext:GridFilters ID="GridFilters2" runat="server" />
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" AutoScroll="true" HideRefresh="true"/>
                    </BottomBar>
                    </ext:GridPanel>
                 <%--<ext:Window runat="server" ID="WindowModificacion" Title="Modificacion" Width="600" Height="600" BodyPadding="10" Resizable="true"
            Closable="true" Layout="AutoLayout" Region="Center" TitleAlign="Center" Icon="UserGray" Modal="true" Maximizable="true"  AutoScroll="true" Hidden="true">
            <Items>
                <ext:FormPanel ID="FormPanel2" runat="server" Border="false" Frame="true" BodyStyle="background-color: transparent" AutoScroll="true" Layout="FormLayout">
                    <Items>
                        <ext:TextField ID="TextFieldCodigo" runat="server"  FieldLabel="Correlativo" DataIndex="correlativo" Hidden="true"/>
                             <%--<ext:ComboBox ID="ComboBox1" runat="server" FieldLabel="Tipo de Worflow" DataIndex="tipo_wf" Width="300px" IDMode="Static">
                                            
                             </ext:ComboBox>
                        <ext:TextField runat="server" ID="TextFieldCorrelativo" FieldLabel="Correlativo" >
                            <Plugins>
                        <ext:InputMask ID="InputMask1" runat="server" Mask="99/99/9999-99" Placeholder="#" AlwaysShow="true" />
                            </Plugins>
                    </ext:TextField>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button1" runat="server" Text="" Icon="ControlAdd">
                            <DirectEvents>
                                <Click OnEvent="Actualizar_Click" />
                            </DirectEvents>
                        </ext:Button>
                        
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>--%>

             <%--</Items>

        </ext:Panel>--%>
    </form>
</body>
</html>

