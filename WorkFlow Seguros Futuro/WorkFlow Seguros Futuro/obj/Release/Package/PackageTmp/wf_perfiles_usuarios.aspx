<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_perfiles_usuarios.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_perfiles_usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <script>
        var template = '<strong><span style="color:{0};">{1}</span></strong>';

        var dias = function (value) {

            if (value >= 0 && value <= 10) {
                return Ext.String.format(template, "green", value);
            }
            else if (value >= 11 && value <= 20) {
                return Ext.String.format(template, "amarillo", value);
            }
            else {
                return Ext.String.format(template, "red", value);
            }
        };

    </script>
    <script>
        var saveData = function () {
            App.HiddenData.setValue(Ext.encode(App.GridPanelRed.getRowsValues({ selectedOnly: false })));
        };
    </script>
    <script>
        var saveData1 = function () {
            App.Hidden1.setValue(Ext.encode(App.GridPanel2.getRowsValues({ selectedOnly: false })));
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:Hidden ID="HiddenData" runat="server" />
        <ext:Hidden ID="Hidden1" runat="server" />
        <ext:Hidden ID="Hidden2" runat="server" />
        <ext:Hidden runat="server" ID="HiddenCproces" />
        <ext:Hidden runat="server" ID="HiddenCliente" />
                                   
                <ext:TabPanel ID="TabPanel1" runat="server" Layout="AbsoluteLayout" >
                    <Defaults>
                    <ext:Parameter Name="bodyPadding" Value="10" Mode="Raw" />
                    <ext:Parameter Name="autoScroll" Value="true" Mode="Raw" />
                </Defaults>
            <Items>
                <ext:Panel ID="Panel2" runat="server" Title="Usuarios"   Layout="AutoLayout">
                    <Items>  
                        <ext:Panel ID="Panel4" runat="server" Layout="FormLayout" DefaultAnchor="98%"  Border="false" Width="300" >
                        <Items>
                            <ext:TextField ID="TextFieldCusuario" runat="server" StyleSpec="font-family: Arial Black;" FieldLabel="Codigo de Usuario"  />
                            <ext:TextField ID="TextFieldNombres" runat="server"  FieldLabel="Nombre"  /> 
                            <ext:ComboBox runat="server" ID="ComboBox3" Width="450px" EmptyText="Seleccione Area" TypeAhead="false" PageSize="10"
                            FieldLabel="Area" DisplayField="area" ValueField="cod_area" TriggerAction="Query" QueryMode="Local" MarginSpec="0 3 5 5">
                             <Store>
                                 <ext:Store ID="Store7" runat="server">
                                   <Model>
                                      <ext:Model ID="Model4" runat="server">
                                        <Fields>
                                           <ext:ModelField Name="cod_area"></ext:ModelField>
                                          <ext:ModelField Name="area"></ext:ModelField>
                                        </Fields>
                                  </ext:Model>
                                </Model>
                           </ext:Store>
                    </Store>
                    <ListConfig LoadingText="Buscando...">
                        <ItemTpl ID="ItemTpl4" runat="server">
                            <Html>
                                <div class="search-item">
							        <h3><span></span>{area}</h3>
						        </div>
                            </Html>
                        </ItemTpl>
                    </ListConfig>
                    </ext:ComboBox>
                            <ext:TextField ID="TextFieldUsuario" runat="server" FieldLabel="Usuario" />
                            <ext:TextField ID="TextFieldTContra" runat="server" FieldLabel="Contraseña" InputType="Password" />
                            <ext:TextField ID="TextFieldEstado" runat="server" FieldLabel="Estado" Text="V" />
                            </Items>
                    </ext:Panel> 
                        
                        <ext:Button ID="Button2" runat="server" Text="Agregar" TextAlign="Center" Region="West" Icon="ApplicationFormAdd">
                        <DirectEvents>
                                <Click OnEvent="Guardar_Click" />
                            </DirectEvents>
                </ext:Button>
                <ext:GridPanel runat="server" ID="GridPanel4" Region="Center" Border="False" Layout="FitLayout">
                <Store> 
                    <ext:Store runat="server" ID="Store4">
                     <Fields>
                       <ext:ModelField Name="codigo" />
                       <ext:ModelField Name="nombre" />
                       <ext:ModelField Name="area" />
                       <ext:ModelField Name="usuario" />
                       <ext:ModelField Name="contrasena" />
                       <ext:ModelField Name="estado" />
                       </Fields>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column ID="Column54" runat="server" Text="Codigo" DataIndex="codigo" />
                        <ext:Column ID="Column62" runat="server" Text="Nombre" DataIndex="nombre" Width="300" />
                        <ext:Column ID="Column17" runat="server" Text="Area" DataIndex="area" Width="300" />
                        <ext:Column ID="Column3" runat="server" Text="Usuario" DataIndex="usuario" Width="300" />
                        <%--<ext:Column ID="Column4" runat="server" Text="Contraseña" DataIndex="contrasena" Width="300" />--%>
                        <ext:Column ID="Column5" runat="server" Text="Estado" DataIndex="estado" Width="300" />
                     </Columns>
                </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar5" runat="server" HideRefresh="true"/>
                    </BottomBar>
            </ext:GridPanel> 
                        </Items>
                </ext:Panel>
                <ext:Panel ID="Panel3" runat="server" Title="Modulos" Layout="AutoLayout">
                    <Items>
                        <ext:Panel ID="Panel5" runat="server" Layout="FormLayout" DefaultAnchor="98%"  Border="false" Width="300" >
                        <Items>
                        <ext:TextField ID="TextField1" runat="server" StyleSpec="font-family: Arial Black;" FieldLabel="Codigo de Rol"  />
                            <ext:TextField ID="TextField2" runat="server"  FieldLabel="Codigo de Modulo"  /> 
                            <ext:TextField ID="TextField3" runat="server" FieldLabel="Modulo" />
                            <ext:TextField ID="TextField4" runat="server" FieldLabel="Vigencia" Text="V" />
                            <ext:ComboBox runat="server" ID="ComboBoxCoop" Width="450px" EmptyText="Seleccione Usuario" TypeAhead="false" PageSize="10"
                            FieldLabel="Servicios" DisplayField="nombre" ValueField="codigo" TriggerAction="Query" QueryMode="Local" MarginSpec="0 3 5 5">
                    <Store>
                        <ext:Store ID="StoreCoop" runat="server">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="codigo"></ext:ModelField>
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
							        <h3><span></span>{nombre}</h3>
						        </div>
                            </Html>
                        </ItemTpl>
                    </ListConfig>
                    <%--<DirectEvents>
                        <Select OnEvent="Generar_Click" />
                    </DirectEvents>--%>
                </ext:ComboBox>
                            </Items>
                    </ext:Panel> 
                        
                        <ext:Button ID="Button1" runat="server" Text="Agregar" TextAlign="Center" Region="West" Icon="ApplicationFormAdd">
                            <DirectEvents>
                                <Click OnEvent="Guardar_ClickModulo" />
                            </DirectEvents>
                </ext:Button>
                <ext:GridPanel runat="server" ID="GridPanel1" Region="Center" Border="False" Layout="FitLayout">
                <Store> 
                    <ext:Store runat="server" ID="Store1">
                     <Fields>
                       <ext:ModelField Name="cod_rol" />
                       <ext:ModelField Name="cod_modulo" />
                       <ext:ModelField Name="modulo" />
                        <ext:ModelField Name="cusuario" />
                       <ext:ModelField Name="vigente" />
                       </Fields>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column ID="Column1" runat="server" Text="codigo Rol" DataIndex="cod_rol" />
                        <ext:Column ID="Column2" runat="server" Text="Codigo Modulo" DataIndex="cod_modulo" Width="300" />
                        <ext:Column ID="Column6" runat="server" Text="Modulo" DataIndex="modulo" Width="300" />
                        <ext:Column ID="Column8" runat="server" Text="Usuario" DataIndex="cusuario" Width="300" />
                        <ext:Column ID="Column7" runat="server" Text="vigencia" DataIndex="vigencia" Width="300" />
                 </Columns>
                </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true"/>
                    </BottomBar>
            </ext:GridPanel> 
                        </Items>
                </ext:Panel>
               <%-- <ext:Panel ID="Panel10" runat="server" Title="Roles" Layout="AutoLayout">
                    <Items>
                       
                            </Items>
                </ext:Panel>--%>
                  <ext:Panel ID="Panel11" runat="server" Title="Permisos" Layout="AutoLayout">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" Layout="FormLayout" DefaultAnchor="98%"  Border="false" Width="300" >
                        <Items>
                             <ext:ComboBox runat="server" ID="ComboBox1" Width="450px" EmptyText="Seleccione Usuario" TypeAhead="false" PageSize="10"
                            FieldLabel="Servicios" DisplayField="nombre" ValueField="codigo" TriggerAction="Query" QueryMode="Local" MarginSpec="0 3 5 5">
                           <Store>
                             <ext:Store ID="Store2" runat="server">
                                  <Model>
                                      <ext:Model ID="Model1" runat="server">
                                         <Fields>
                                           <ext:ModelField Name="codigo"></ext:ModelField>
                                            <ext:ModelField Name="nombre"></ext:ModelField>
                                       </Fields>
                                    </ext:Model>
                               </Model>
                           </ext:Store>
                    </Store>
                    <ListConfig LoadingText="Buscando...">
                        <ItemTpl ID="ItemTpl2" runat="server">
                            <Html>
                                <div class="search-item">
							        <h3><span></span>{nombre}</h3>
						        </div>
                            </Html>
                        </ItemTpl>
                    </ListConfig>
                    <%--<DirectEvents>
                        <Select OnEvent="Generar_Click" />
                    </DirectEvents>--%>
                </ext:ComboBox>
                            <ext:ComboBox runat="server" ID="ComboBox2" Width="450px" EmptyText="Seleccione Modulo" TypeAhead="false" PageSize="10"
                            FieldLabel="Modulo" DisplayField="modulo" ValueField="cod_modulo" TriggerAction="Query" QueryMode="Local" MarginSpec="0 3 5 5">
                           <Store>
                             <ext:Store ID="Store5" runat="server">
                                  <Model>
                                      <ext:Model ID="Model3" runat="server">
                                         <Fields>
                                           <ext:ModelField Name="cod_modulo"></ext:ModelField>
                                            <ext:ModelField Name="modulo"></ext:ModelField>
                                       </Fields>
                                    </ext:Model>
                               </Model>
                           </ext:Store>
                    </Store>
                   <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl3" runat="server">
                                    <Html>
                                        <div class="search-item">
							                <h3><span>Modulo: </span>{modulo}</h3>
							                <b>Código: {cod_modulo}</b>
						        </div>
                            </Html>
                        </ItemTpl>
                    </ListConfig>
                    <DirectEvents>
                        <Select OnEvent="Generar_Click" />
                    </DirectEvents>
                </ext:ComboBox>
                        <ext:TextField ID="TextField5" runat="server" StyleSpec="font-family: Arial Black;" FieldLabel="Codigo de Rol"  />
                        <ext:Label runat="server" ID="LabelPregunta" Text="Permisos" />
                       <ext:RadioGroup ID="RadioGroup2"  runat="server" Anchor="none">
                            <LayoutConfig>
                                <ext:CheckboxGroupLayoutConfig AutoFlex="false" />
                            </LayoutConfig>
                            <Defaults>
                                <ext:Parameter Name="name" Value="ccType" />
                                <ext:Parameter Name="style" Value="margin-right:15px;" />
                            </Defaults>
                            <Items>
                                <ext:Radio ID="Radio5" runat="server" InputValue="1" BoxLabel="SI"  Checked="true" />
                                <ext:Radio ID="Radio6" runat="server" InputValue="0" BoxLabel="NO" />
                            </Items>
                        </ext:RadioGroup>
                           
                            </Items>
                    </ext:Panel> 
                        
                        <ext:Button ID="Button3" runat="server" Text="Agregar" TextAlign="Center" Region="West" Icon="ApplicationFormAdd">
                            <DirectEvents>
                                <Click OnEvent="Guardar_ClickPermisos" />
                            </DirectEvents>
                </ext:Button>
                <ext:GridPanel runat="server" ID="GridPanel2" Region="Center" Border="False" Layout="FitLayout">
                <Store> 
                    <ext:Store runat="server" ID="Store3">
                     <Fields>
                         <ext:ModelField Name="cod_usuario" />
                       <ext:ModelField Name="cod_rol" />
                       <ext:ModelField Name="cod_modulo" />
                       <ext:ModelField Name="modulo" />
                       <ext:ModelField Name="permiso" />
                       </Fields>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column ID="Column12" runat="server" Text="Codigo de Usuario" DataIndex="cod_usuario" Width="300" />
                        <ext:Column ID="Column9" runat="server" Text="codigo Rol" DataIndex="cod_rol" />
                        <ext:Column ID="Column10" runat="server" Text="Codigo Modulo" DataIndex="cod_modulo" Width="300" />
                        <ext:Column ID="Column11" runat="server" Text="Permiso" DataIndex="permiso" Width="300" />
                      </Columns>
                </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true"/>
                    </BottomBar>
            </ext:GridPanel> 
                </Items>
                </ext:Panel>
                <ext:Panel ID="Panel12" runat="server" Title="Listado" Layout="AutoLayout">
                    <Items>
                         <ext:Label runat="server" ID="Label1" Text="1 = Si tiene Permiso;  " />
                        
                         <ext:Label runat="server" ID="Label2" Text="     0 = No tiene permiso" />
                        <ext:GridPanel runat="server" ID="GridPanel3" Region="Center" Border="False" Layout="FitLayout">
                <Store> 
                    <ext:Store runat="server" ID="Store6">
                     <Fields>
                         <ext:ModelField Name="usuario" />
                       <ext:ModelField Name="rol" />
                       <ext:ModelField Name="modulo" />
                       <ext:ModelField Name="permiso" />
                       </Fields>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column ID="Column13" runat="server" Text="Nombre" DataIndex="usuario" Width="300" />
                        <ext:Column ID="Column14" runat="server" Text="Rol" DataIndex="rol" />
                        <ext:Column ID="Column15" runat="server" Text="Modulo" DataIndex="modulo" Width="300" />
                        <ext:Column ID="Column16" runat="server" Text="Permiso" DataIndex="permiso" Width="300" />
                      </Columns>
                </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar3" runat="server" HideRefresh="true"/>
                    </BottomBar>
            </ext:GridPanel>
                    </Items>
                    </ext:Panel>
                  </Items>
        </ext:TabPanel>
        <ext:Window runat="server" ID="WindowAgregar" Title="Agregar" Width="600" Height="600" BodyPadding="10" Resizable="true"
            Closable="true" Layout="AutoLayout" TitleAlign="Center" Icon="UserGray" Modal="true" Maximizable="true"  AutoScroll="true" Hidden="true">
            <Items>
                <ext:FormPanel ID="FormPanel3" runat="server" Border="false" Frame="true" BodyStyle="background-color: transparent" AutoScroll="true" Layout="FormLayout">
                    <Items>
                        <ext:TextField ID="TextField12" runat="server"  ReadOnly="false" Disabled="false" Width="100px" FieldLabel="Correlativo" />
                        <ext:TextField ID="TextField13" runat="server" Disabled="false" Width="500px" FieldLabel="Contratante"  />
                        <ext:ComboBox ID="ComboBox7" runat="server" FieldLabel="Tipo de Poliza" FieldStyle="text-transform: uppercase" Width="500px" >
                            <Items>
                                <ext:ListItem Value="Vida" Text="Vida" />
                                <ext:ListItem Value="Daños" Text="Daños" />
                                <ext:ListItem Value="Fianzas" Text="Fianzas" />
                                
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox ID="ComboBox8" runat="server" FieldLabel="Estado" FieldStyle="text-transform: uppercase" Width="500px" >
                            <Items>
                                <ext:ListItem Value="Vigente" Text="Vigente" />
                                <ext:ListItem Value="Cancelado" Text="Cancelado" />
                                <ext:ListItem Value="No Vigente" Text="No Vigente" />
                                
                            </Items>
                        </ext:ComboBox>
                         <ext:ComboBox ID="ComboBox9" runat="server" FieldLabel="Nivel de Riesgo" FieldStyle="text-transform: uppercase" Width="500px"  >
                            <Items>
                                <ext:ListItem Value="Alto" Text="Alto" />
                                <ext:ListItem Value="Medio" Text="Medio" />
                                <ext:ListItem Value="Bajo" Text="Bajo" />
                                
                            </Items>
                        </ext:ComboBox>
                        
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button7" runat="server" Text="Guardar" Icon="DiskBlackMagnify">
                       <%--     <DirectEvents>
                                <Click OnEvent="Guardar_Click_Agregar" />
                            </DirectEvents>--%>
                        </ext:Button>
                        <ext:Button ID="Button8" runat="server" Text="Agregar" Icon="Add">
                          <%--  <DirectEvents>
                                <Click OnEvent="Limpiar" />
                            </DirectEvents>--%>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>

 
    </form>
</body>
</html>