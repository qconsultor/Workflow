<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_controlAcceso.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_controlAcceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
</head>
    <%--<script>
        var saveData = function () {
            App.HiddenData.setValue(Ext.encode(App.GridPanel1.getRowsValues({ selectedOnly: false })));
        };
    </script>--%>
<body>
    <form id="form2" runat="server">
        <ext:Hidden ID="HiddenData" runat="server" />
  <%-- <ext:Panel runat="server" ID="PanelPrincipal" Title="Control Accesos"  Layout="TableLayout" TitleAlign="Center" Theme="Neptune" Icon="Vcard" Height="115" Region="North">
                    <Items>--%>
                         <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:DateField runat="server" ID="DateFieldfechainicio" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Del" DataIndex="fecha" />
                         <ext:DateField runat="server" ID="DateFieldfechafin" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Al" DataIndex="fecha" />
                      
                        <ext:Button ID="ButtonAceptar" runat="server" Text="Buscar"  Icon="Find" IDMode="Static" >
                          <DirectEvents>
                              <Click OnEvent="Grid"/>
                          </DirectEvents>
                        </ext:Button>
                   
                     </Items>

                </ext:FieldContainer>
                
                 <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab"  Layout="FitLayout" Title="ACCESOS">
                      
                    <Store>
                        <ext:Store runat="server" ID="Store1">
                            <Model>
                                <ext:Model ID="Model2" runat="server" IDProperty="correlativo">
                                    <Fields>
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="usuario" />
                                        <ext:ModelField Name="aplicacion" />
                                        <ext:ModelField Name="fecha" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:Column ID="Column9" runat="server" DataIndex="nombre" Text="Nombre" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column10" runat="server" DataIndex="usuario" Text="Usuario" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column11" runat="server" DataIndex="aplicacion" Text="Aplicacion" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column12" runat="server" DataIndex="fecha" Text="Fecha" Width="150px">
                                 <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                  
                     <Plugins>
                      <ext:GridFilters ID="GridFilters2" runat="server" />
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" AutoScroll="true" HideRefresh="true"/>
                    </BottomBar>
                    </ext:GridPanel>

             <%--</Items>

        </ext:Panel>--%>
    </form>
</body>
</html>
