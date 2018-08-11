<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recepcion.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.recepcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Define la cabecera del documento HTML --%>
<head runat="server">
    <%-- meta datos http-equiv = "texto" - En ocasiones, reemplaza al atributo “name” y lo emplean los servidores para adaptar sus respuestas al documentoEste atributo se utiliza para indicar que el valor establecido por este metadato puede ser utilizado por el servidor al entregar la página al navegador del usuario. El siguiente metadato indica al servidor que el contenido de la página es código HTML y su codificación de caracteres es UTF-8:--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--  Zona de recursos enlazados (CSS, RSS, JavaScript) --%>
    <link href="~/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Zona de título -->
    <title>Recepcion</title>

    <%-- Establece de forma directa los estilos CSS de un elemento type = "tipo_de_contenido" - Permite "avisar" al navegador sobre el tipo de contenido que se enlaza (imágenes, archivos, etc.) para que pueda preparase en caso de que no entienda ese contenido--%>
    <%-- El atributo media hace referencia al medio para el que es válida la relación con el recurso enlazado. Los medios disponibles también están estandarizados, siendo los más comunes screen para los contenidos mostrados en pantalla, print para las impresoras y handheld para los dispositivos móviles. --%>
    <style type="text/css" media="print">
        @page {
            size: landscape;
        }

        @media print {
            body, html, #wrapper {
                width: 100%;
            }
        }
    </style>

</head>
<body>
    <%--<iframe src="imagen.aspx" width="250" height="250" scrolling="no" />--%>
    <form id="form1" runat="server">
        <%--<iframe src="imagen.aspx" width="250" height="250" scrolling="no" />--%>
        <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
        <ext:Store ID="StoreOrigen" runat="server">
            <Model>
                <ext:Model ID="ModelOrigen" runat="server">
                    <Fields>
                        <ext:ModelField Name="codigo" />
                        <ext:ModelField Name="descripcion" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel runat="server" Title="Recepcion" Region="West" Frame="true" Height="450" Layout="FormLayout" Collapsible="true">

                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" ID="ButtonGuardarUsu" Text="Guardar" Icon="ApplicationKey">
                                    <DirectEvents>
                                        <Click OnEvent="Guardar_Click">
                                            <%--  <Click OnEvent="btnUpload_Click"> --%>
                                            <EventMask ShowMask="true" Msg="Guardando..." />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" ID="Button2" Text="Transferir" Icon="ApplicationKey">
                                    <DirectEvents>
                                        <Click OnEvent="Actualizar">
                                            <%--  <Click OnEvent="btnUpload_Click"> --%>
                                            <EventMask ShowMask="true" Msg="Guardando..." />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                               <%-- <ext:Button runat="server" ID="ButtonConsultar" Text="Consultar" Icon="Find" OnClientClick="#{WindowConsulta}.show();">
                                </ext:Button>--%>
                                
                                 <ext:Button ID="Button1" runat="server" Text="Print" Icon="Printer">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:Panel runat="server" Flex="1" Layout="FormLayout" DefaultAnchor="75%" Border="false">
                            <Items>
                                <ext:TextField ID="TextFieldNombre" runat="server" FieldLabel="? Solicitud">
                                    <DirectEvents>
                                        <SpecialKey OnEvent="Consultar_Click" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                            <EventMask ShowMask="true" Msg="Verificando..." />
                                        </SpecialKey>
                                    </DirectEvents>
                                </ext:TextField>
                                <ext:TextField ID="TextFieldContador" runat="server" FieldLabel="No. Solicitud" ReadOnly="false" />

                                <ext:DateField runat="server" ID="DateFieldFechaA" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Fecha" DataIndex="fecha" />
                                <ext:ComboBox runat="server" ID="ComboBoxAreas" Width="500px" EmptyText="Digite Area" TypeAhead="false" PageSize="10"
                            FieldLabel="Area" DisplayField="area" ValueField="cod_area" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="Store2" runat="server">
                                    <Model>
                                        <ext:Model ID="Model3" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="cod_area"></ext:ModelField>
                                                <ext:ModelField Name="area"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl2" runat="server">
                                    <Html>
                                        <div class="search-item">
                       <h3><span>Area: </span>{area}</h3>
                       <b>Código: {cod_area}</b>
                      </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                           <%-- <DirectEvents>
                                <Select OnEvent="Grid_Buscador" />
                            </DirectEvents>--%>
                        </ext:ComboBox>
                                <ext:TextField runat="server" ID="TextFieldCooperativa" Width="300px" FieldLabel="Cooperativa" DataIndex="cooperativa" />
                                <ext:ComboBox runat="server" ID="ComboBoxPlan" Width="500px" EmptyText="Digite Plan" TypeAhead="false" PageSize="10"
                            FieldLabel="Plan de Seguro" DisplayField="nombre" ValueField="codigo" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="Storeplan" runat="server">
                                    <Model>
                                        <ext:Model ID="Model4" runat="server">
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
                       <h3><span>Plan: </span>{nombre}</h3>
                       <b>Código: {codigo}</b>
                      </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                           <%-- <DirectEvents>
                                <Select OnEvent="Grid_Buscador" />
                            </DirectEvents>--%>
                        </ext:ComboBox>
                                <ext:TextField runat="server" ID="TextFieldTipoPoliza" Width="300px" DataIndex="tipopoliza" FieldLabel="Tipo de Poliza" />
                                <ext:TextField runat="server" ID="TextField1" Width="300px" FieldLabel="Responsable" DataIndex="Responsable" />
                                <ext:TextField runat="server" ID="TextField2" Width="300px" FieldLabel="Nombre" DataIndex="identificacion" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Flex="1" Layout="FormLayout" DefaultAnchor="98%" Border="false">
                            <Items>
                                <ext:TextArea runat="server" ID="TextArea1" FieldLabel="Observaciones" DataIndex="observaciones" Flex="1" MarginSpec="0" AllowBlank="false" />
                                <ext:ComboBox runat="server" ID="ComboBox1" FieldLabel="Tipo de Solicitud" DataIndex="tsolicitud" Width="300px">
                                    <Items>
                                        <ext:ListItem Value="INDIVIDUAL" Text="INDIVIDUAL" />
                                        <ext:ListItem Value="COLECTIVA" Text="COLECTIVA" />
                                    </Items>
                                </ext:ComboBox>
                               <ext:ComboBox runat="server" ID="ComboBox2" FieldLabel="Tipo de Solicitud" DataIndex="tsolicitud" Width="300px">
                                    <Items>
                                        <ext:ListItem Value="Area Tecnica" Text="Area Tecnica" />
                                        
                                    </Items>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="Nombre" Width="300px" FieldLabel="Nombre del Adjunto" textbox="text1" />
                                <%--<ext:TextField runat="server" ID="TextFeildIdenti" Width="300px" FieldLabel="Nombre Quien Entrega" DataIndex="identificacion" />--%>
                                <%--<ext:FileUploadField runat="server" ID="FileUploadFieldArchivo" ButtonText="Buscar" Icon="Attach" Width="400px"></ext:FileUploadField>--%>
                                <%--<ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>

                                        <ext:Button runat="server" Text="Open window" ID="btnOpen">
                                            <Listeners>
                                                <Click Handler="newWindow({title: 'Window', height: 350, width: 760, minHeight: 380, minWidth: 760, modal: true}, '', 'window2');" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Panel ID="Panel1" runat="server" Height="350" Width="300" IDMode="Static">
                                            <Loader ID="Loader3" runat="server" Url="../files/318i TwinPower Turbo Luxury (1).pdf" Mode="Frame"></Loader>
                                        </ext:Panel>
                                    </Items>
                                </ext:Toolbar>--%>
                            </Items>
                        </ext:Panel>
                    </Items>

                </ext:Panel>
                <%--<ext:Panel ID="Panel3" runat="server" Title="Recepcion" Region="Center" Frame="true" Height="350" Layout="FormLayout" Collapsible="true" >--%>
                <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab" Title="Vista de solicitudes" Frame="true" Layout="AutoLayout" Region="Center" BodyPadding="5" >
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

                                        <%--<asp:HyperLink Visible="true"  ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("observaciones", "~/files/{0}") %>'
                                                    Text='<%# Eval("observaciones") %>' Target="myPDF">
                                                </asp:HyperLink>--%>
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="85" Header="Adjuntos" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="Attach">
                                        <Menu EnableScrolling="false">
                                            <Items>
                                                <ext:MenuCommand Text="Mostrar" Icon="Attach" Handler="#{WindowVisualizador}.show()">
                                                </ext:MenuCommand>
                                            </Items>
                                        </Menu>
                                        <ToolTip Text="<b><i>Mostrar Adjunto</i></b><br>" />
                                    </ext:GridCommand>
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
                    <Plugins>
                        <ext:RowExpander ID="RowExpander2" runat="server" ExpandOnDblClick="true" SelectRowOnExpand="true" SingleExpand="false">
                            <Loader ID="Loader1" runat="server" DirectMethod="#{DirectMethods}.GetGrid" Mode="Component">
                                <LoadMask ShowMask="true" />
                                <Params>
                                    <%--#{GridPanelOfertas}.getRowsValues({selectedOnly:true})[0].cpoliza --%>
                                    <ext:Parameter Name="id" Value="#{GridPanel1}.getRowsValues({selectedOnly:true})" Encode="true" Mode="Raw" />
                                </Params>
                            </Loader>
                        </ext:RowExpander>
                        <ext:GridFilters ID="GridFilters5" runat="server" />
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true"/>
                    </BottomBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel" runat="server" />
                    </SelectionModel>
                </ext:GridPanel>
                <ext:Panel ID="Panel2" IDMode="Static" runat="server" Title="Archivos" Region="South" Frame="true" Height="320" Layout="FormLayout" Collapsible="true"  AutoPostBack="true">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>

                                <%--<ext:Button runat="server" Text="Open window" ID="btnOpen1">
                                    <Listeners>
                                        <Click Handler="newWindow({title: 'Window', height: 350, width: 760, minHeight: 380, minWidth: 760, modal: true}, '', 'window2');" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Panel ID="Panel1" runat="server" Height="350" Width="300" IDMode="Static">
                                    <Loader ID="Loader3" runat="server" Url="../files/318i TwinPower Turbo Luxury (1).pdf" Mode="Frame"></Loader>
                                </ext:Panel>--%>

                            </Items>

                        </ext:Toolbar>
                    </TopBar>

                </ext:Panel>
            </Items>

        </ext:Viewport>


        <ext:Window runat="server" ID="WindowConsulta" Modal="true" Title="Búsqueda de Solicitudes Ingresadas" Icon="FolderDatabase" BodyStyle="background-color: #fff;" CloseAction="Hide" Closable="true" Width="750" Height="450" TitleAlign="Center" Hidden="true" Maximizable="true" Minimizable="true">
            <Items>
                <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="FormLayout">
                    <Items>
                        <ext:TextField runat="server" ID="TextFieldContadorB" FieldLabel="No. de Solicitud" DataIndex="correlativo" />
                    </Items>
                </ext:FieldContainer>
                <ext:GridPanel runat="server" ID="GridPanelBusqueda" Icon="Tab" Title="Búsqueda" Hidden="true">
                    <Store>
                        <ext:Store runat="server" ID="StoreBusqueda">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="n_mejora">
                                    <Fields>
                                        <ext:ModelField Name="correlativo" />
                                        <ext:ModelField Name="fecha" />
                                        <ext:ModelField Name="area" />
                                        <ext:ModelField Name="cooperativa" />
                                        <ext:ModelField Name="plan_" />
                                        <ext:ModelField Name="tipodepoliza" />
                                        <ext:ModelField Name="observaciones" />
                                        <ext:ModelField Name="asegurado" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" DataIndex="correlativo" Text="Correlativo" />
                            <ext:Column ID="Column2" runat="server" DataIndex="fecha" Text="Fecha de Recibido" />
                            <ext:Column ID="Column3" runat="server" DataIndex="area" Text="Area" />
                            <ext:Column ID="Column4" runat="server" DataIndex="cooperativa" Text="Cooperativa" />
                            <ext:Column ID="Column5" runat="server" DataIndex="plan_" Text="Plan de Seguro" />
                            <ext:Column ID="Column6" runat="server" DataIndex="tipodepoliza" Text="Tipo de Poliza">
                            </ext:Column>
                            <ext:Column ID="column7" runat="server" DataIndex="observaciones" Text="Observaciones" />
                            <ext:Column ID="Column8" runat="server" DataIndex="asegurado" Text="Nombre del Asegurado" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
        </ext:Window>
        <ext:Window runat="server" ID="WindowVisualizador" Title="Visualizador" Width="1050" Height="700" Icon="ReportDisk" Hidden="true" Modal="true" Draggable="true">
           <%-- <Loader ID="Loader2" runat="server" Url="../files/318i TwinPower Turbo Luxury (1).pdf" Mode="Frame" AutoLoad="true">--%>
             <Loader ID="Loader2" runat="server" Url="../ver_adjuntos_.aspx" Mode="Frame" AutoLoad="true">
                <%--<Loader  runat="server" Url="../files/CUADRO  1º  2015.htm" Mode="Frame" AutoLoad="true">--%>

                <LoadMask ShowMask="true" Msg="Cargando..." />
            </Loader>
        </ext:Window>

        <%--<form id="Form2" runat="server">--%>
        <%--<ext:ResourceManager ID="ResourceManager1" runat="server" />--%>
        <%--<ext:Button runat="server" Text="Open window" ID="btnOpen"><Listeners><Click Handler="newWindow({title: 'Window', height: 380, width: 760, minHeight: 380, minWidth: 760, modal: true}, '', 'window2');" /></Listeners></ext:Button>--%>
        <%--<ext:Panel ID="Panel1" runat="server" Height="400" Width="300"> <Loader ID="Loader3"  runat="server"  Url="../files/318i TwinPower Turbo Luxury (1).pdf" Mode="Frame"> </Loader> </ext:Panel>--%>

        <%--<iframe src="imagen.aspx" width="250" height="250" scrolling="no" />--%>
        <%--<iframe src="/ruta/documento.html" width="250" height="250" scrolling="no" />--%>
        <%--</form>--%>
    </form>
    <%--<ext:KeyMap ID="KeyMap1" runat="server" Target="={Ext.isGecko ? Ext.getDoc() : Ext.getBody()}">
        <Binding>
            <ext:KeyBinding Handler="#{North}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="R" />
                </Keys>
            </ext:KeyBinding>
            <ext:KeyBinding Handler="#{West}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="C" />
                </Keys>
            </ext:KeyBinding>
            <ext:KeyBinding Handler="#{East}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="A" />
                </Keys>
            </ext:KeyBinding>
            <ext:KeyBinding Handler="#{South}.toggleCollapse();">
                <Keys>
                    <ext:Key Code="S" />
                </Keys>
            </ext:KeyBinding>
        </Binding>
    </ext:KeyMap>--%>
</body>
</html>
