<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_recepcionreclamos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.Formularios.wf_recepcionreclamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceManager" />
        <div>

            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
                <Items>
                    <ext:Panel runat="server" ID="PanelNorte" Region="North" BodyPadding="5" Split="true" Layout="HBoxLayout">
                        <TopBar>
                            <ext:Toolbar ID="Panel_buttons" runat="server">
                                <Items>
                                    <ext:Button runat="server" ID="ButtonNuevo" Icon="new" Text="Nuevo">
                                        <DirectEvents>
                                            <Click OnEvent="Nuevo_click">
                                                <Confirmation ConfirmRequest="true" Title="Confirmación!" Message="Desea Crear una nueva Solicitud?" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button runat="server" ID="ButtonGuardar" Icon="Disk" Text="Guardar">
                                        <DirectEvents>
                                            <Click OnEvent="GuardarDatos_Click">
                                                <Confirmation Title="Confirmacion" Message="Esta seguro de guardar los datos?" />
                                                <EventMask ShowMask="true" Msg="Procesando..." />
                                            </Click>
                                            <Click OnEvent="Historial">
                                                <Confirmation Title="Confirmacion" Message="Esta seguro de guardar los datos?" />
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button runat="server" ID="ButtonBuscar" Icon="Find" Text="Buscar">
                                        <DirectEvents>
                                            <Click OnEvent="Guardar_buscar">
                                                <Confirmation ConfirmRequest="true" Title="Confirmación!" Message="Desea Consultar esta Solicitud?" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <%--<ext:Button ID="Button2" runat="server" Text="PDF" Icon="PageWhiteAcrobat">
                                        <DirectEvents>
                                            <Click OnEvent="Button1_Click" Method="GET">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>--%>
                                    <ext:Button ID="Button2" runat="server" Text="PDF" Icon="PageWhiteAcrobat">
                                        <DirectEvents>
                                            <Click OnEvent="Button1_Click">
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="#{windowPDF}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="ver" runat="server" Text="Eliminar" Icon="Delete">
                                        <DirectEvents>
                                            <Click OnEvent="EliminarDatos">
                                                <Confirmation ConfirmRequest="true" Title="Confirmación!" Message="Desea Eliminar esta Solicitud?" />
                                                <EventMask ShowMask="true" Msg="Eliminando..." />
                                            </Click>
                                            <Click OnEvent="Historial">
                                                <Confirmation ConfirmRequest="true" Title="Confirmación!" Message="Desea Eliminar esta Solicitud?" />
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>

                                        </DirectEvents>
                                        <DirectEvents>
                                            <Click OnEvent="Page_Load">
                                                <EventMask ShowMask="true" Msg="Actualizando..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:TextField runat="server" ID="TextFieldCodigoISO" Enabled="false" FieldLabel="Codigo ISO:" LabelWidth="63" />

                                    <%--                                    <ext:TextField
                                        ID="PasswordField"
                                        runat="server"
                                        LabelWidth="600"
                                        AnchorHorizontal="100%">
                                        <Plugins>
                                            <ext:PasswordMask ID="PasswordMask1" runat="server" />

                                            <ext:CapsLockDetector ID="CapsLockDetector1" runat="server">
                                                <Listeners>
                                                    <CapsLockOn Handler="#{PasswordField}.showIndicator({iconCls : '#validate});" />
                                                </Listeners>
                                            </ext:CapsLockDetector>
                                        </Plugins>
                                    </ext:TextField>--%>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Padding="5" />
                        </LayoutConfig>
                        <Items>
                            <ext:Panel ID="Panel1" runat="server" Flex="1" Layout="ColumnLayout" Border="false">
                                <Items>
                                    <ext:Panel ID="Panel2" runat="server" ColumnWidth="0.5" Layout="FormLayout" Width="150px" Border="false" DefaultAnchor="98%">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="ComboBoxArea" FieldLabel="Area" DisplayField="descripcion" ValueField="codigo">
                                                <DirectEvents>
                                                    <Select OnEvent="combo_click">
                                                    </Select>
                                                </DirectEvents>
                                                <DirectEvents>
                                                    <Select OnEvent="Historial">
                                                    </Select>
                                                </DirectEvents>
                                                <DirectEvents>
                                                    <Select OnEvent="combo_click_codigoiso">
                                                    </Select>
                                                </DirectEvents>
                                                <Store>
                                                    <ext:Store runat="server" ID="StoreArea">
                                                        <Model>
                                                            <ext:Model ID="Model3" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="codigo" />
                                                                    <ext:ModelField Name="descripcion" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>
                                            <ext:TextField runat="server" ID="TextFieldCorrelativo" FieldLabel="Correlativo">
                                                <DirectEvents>
                                                    <SpecialKey OnEvent="Guardar_buscar" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                                        <EventMask ShowMask="true" Msg="Buscando..." />
                                                    </SpecialKey>
                                                    <SpecialKey OnEvent="BuscarDatos_enter" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                                        <EventMask ShowMask="true" Msg="Buscando..." />
                                                    </SpecialKey>
                                                </DirectEvents>
                                            </ext:TextField>
                                            <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout" DefaultAnchor="98%" FieldLabel="Fecha Ingreso">
                                                <Items>
                                                    <ext:DateField runat="server" ID="DateFieldFechaIngreso" Format="dd/MM/yyyy" MarginSpec="0 5 0 0" ReadOnly="true" />
                                                    <ext:DisplayField ID="DisplayFieldHora" Text="-" runat="server" Cls="dot-label" MarginSpec="0 5 0 0" />
                                                    <ext:TextField ID="TextFieldHoraIngreso" Text="12:18:05" runat="server" ReadOnly="true" />
                                                </Items>
                                            </ext:FieldContainer>
                                            <ext:FieldContainer ID="FieldContainer2" runat="server" Layout="HBoxLayout" DefaultAnchor="98%" FieldLabel="Fecha Recibido">
                                                <Items>
                                                    <ext:DateField runat="server" ID="DateFieldFechaRecibido" Format="dd/MM/yyyy" MarginSpec="0 5 0 0" />
                                                    <ext:DisplayField ID="DisplayField1" Text="-" runat="server" Cls="dot-label" MarginSpec="0 5 0 0" />
                                                    <ext:TextField ID="TextFieldHoraRecibido" Text="12:18:05" runat="server" />
                                                </Items>
                                            </ext:FieldContainer>
                                            <ext:TextField runat="server" FieldLabel="Nombre" ID="TextFieldNombre" />
                                            <%--                                            <ext:ComboBox runat="server" ID="ComboBoxTipoSolicitud" FieldLabel="Tipo Solicitud" DisplayField="descripcion" ValueField="codigo">
                                                <Store>
                                                    <ext:Store runat="server" ID="StoreTipoSolicitud">
                                                        <Model>
                                                            <ext:Model ID="Model1" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="codigo" />
                                                                    <ext:ModelField Name="descripcion" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>--%>
                                            <ext:TextField runat="server" FieldLabel="N° Placa" ID="TextFieldPlaca" />
                                            <ext:TextField runat="server" FieldLabel="Entrego" ID="TextFieldEntrego" />
                                            <ext:TextField runat="server" FieldLabel="DUI" ID="TextFieldDUI" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="Panel3" runat="server" ColumnWidth="0.5" Layout="FormLayout" Border="false" Width="150" DefaultAnchor="98%">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="ComboBoxAsesores" Width="200px" FieldLabel="Coop/Asesores" DisplayField="descripcion" ValueField="codigo">
                                                <Store>
                                                    <ext:Store runat="server" ID="StoreAsesores">
                                                        <Model>
                                                            <ext:Model ID="Model2" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="codigo" />
                                                                    <ext:ModelField Name="descripcion" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>
                                            <%-- <ext:ComboBox runat="server" ID="ComboBoxPlanSeguro" Width="200px" FieldLabel="Plan de Seguro" DisplayField="descripcion" ValueField="codigo">
                                                <Store>
                                                    <ext:Store runat="server" ID="StorePlanSeguro">
                                                        <Model>
                                                            <ext:Model ID="Model4" runat="server">
                                                                <Fields>
                                                                    <ext:ModelField Name="codigo" />
                                                                    <ext:ModelField Name="descripcion" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>--%>
                                            <ext:ComboBox runat="server" ID="ComboBoxRequisitos" FieldLabel="Requisitos"
                                                DisplayField="descripcion" ValueField="codigo" QueryMode="Local">
                                                <Store>
                                                    <ext:Store ID="StoreRequisitos" runat="server">
                                                        <Model>
                                                            <ext:Model ID="Model4" runat="server" IDProperty="Value">
                                                                <Fields>
                                                                    <ext:ModelField Name="descripcion" />
                                                                    <ext:ModelField Name="codigo" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" QTip="Remove selected" />
                                                </Triggers>
                                                <Listeners>
                                                    <TriggerClick Handler="this.removeByValue(this.getValue());
                                                        this.clearValue();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ComboBox runat="server" ID="ComboBoxCausas" FieldLabel="Causas"
                                                DisplayField="descripcion" ValueField="codigo" QueryMode="Local">
                                                <Store>
                                                    <ext:Store ID="StoreCausas" runat="server">
                                                        <Model>
                                                            <ext:Model ID="Model9" runat="server" IDProperty="Value">
                                                                <Fields>
                                                                    <ext:ModelField Name="descripcion" />
                                                                    <ext:ModelField Name="codigo" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" QTip="Remove selected" />
                                                </Triggers>
                                                <Listeners>
                                                    <TriggerClick Handler="this.removeByValue(this.getValue());
                                                        this.clearValue();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ComboBox runat="server" ID="ComboBoxPlanes" FieldLabel="Planes"
                                                DisplayField="descripcion" ValueField="codigo" QueryMode="Local">
                                                <Store>
                                                    <ext:Store ID="StorePlanes" runat="server">
                                                        <Model>
                                                            <ext:Model ID="Model10" runat="server" IDProperty="Value">
                                                                <Fields>
                                                                    <ext:ModelField Name="descripcion" />
                                                                    <ext:ModelField Name="codigo" />
                                                                </Fields>
                                                            </ext:Model>
                                                        </Model>
                                                    </ext:Store>
                                                </Store>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" QTip="Remove selected" />
                                                </Triggers>
                                                <Listeners>
                                                    <TriggerClick Handler="this.removeByValue(this.getValue());
                                                        this.clearValue();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:TextField runat="server" FieldLabel="Tipo Doc." ID="TextFieldTipoDoc" />
                                            <ext:TextField runat="server" FieldLabel="Responsable" ID="TextFieldResponsable" />
                                            <ext:TextArea runat="server" FieldLabel="Observaciones" ID="TextAreaObservaciones" />
                                            <ext:FieldContainer ID="FieldContainer3" runat="server" Layout="HBoxLayout" FieldLabel="Estado">
                                                <Items>
                                                    <ext:TextField ID="TextFieldEstado" Anchor="75%" runat="server" MarginSpec="0 5 0 0" />
                                                    <ext:TextField ID="TextFieldPuntos" Anchor="23%" runat="server" MarginSpec="0 5 0 0" Disabled="true" />
                                                    <ext:TextField ID="TextFieldcantSolicitudes" FieldLabel="Cant. Solicitudes" Large="23%" runat="server" MarginSpec="0 5 0 0" />
                                                </Items>
                                            </ext:FieldContainer>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:Panel>
                        </Items>

                    </ext:Panel>
                    <ext:GridPanel ID="GridPanelMalla" runat="server" Collapsible="true" Region="Center" AnimCollapse="true"
                        DisableSelection="true" Width="700px" Height="700px" Frame="false">
                        <Store>
                            <ext:Store ID="StoreMalla" runat="server">
                                <Model>
                                    <ext:Model ID="Model7" runat="server" IDProperty="xcliente">
                                        <Fields>
                                            <ext:ModelField Name="fecha" />
                                            <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="cooperativa" />
                                            <ext:ModelField Name="asegurado" />
                                            <ext:ModelField Name="entrego" />
                                            <ext:ModelField Name="plan_" />
                                            <ext:ModelField Name="poliza" />
                                            <ext:ModelField Name="tsolicitud" />
                                            <ext:ModelField Name="observaciones" />
                                            <ext:ModelField Name="cantidadsolicitudes" />
                                            <ext:ModelField Name="fecha_destino" />

                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ID="Column1" runat="server" Text="F. Recibido Recepción" DataIndex="fecha" Flex="1" Sortable="false" />
                                <ext:Column ID="Column2" runat="server" Text="Correlativo" DataIndex="correlativo" Flex="1" Sortable="false" />
                                <ext:Column ID="Column3" runat="server" Text="Tomador" DataIndex="cooperativa" Flex="1" Sortable="false" />
                                <ext:Column ID="Column4" runat="server" Text="Asegurado" DataIndex="asegurado" Flex="1" Sortable="false" />
                                <ext:Column ID="Column5" runat="server" Text="Entregado Por" DataIndex="entrego" Flex="1" Sortable="false" />
                                <ext:Column ID="Column6" runat="server" Text="Nombre Plan" DataIndex="plan_" Flex="1" Sortable="false" />
                                <ext:Column ID="Column7" runat="server" Text="Póliza" DataIndex="poliza" Flex="1" Sortable="false" />
                                <ext:Column ID="Column8" runat="server" Text="Tipo Solicitud" DataIndex="tsolicitud" Flex="1" Sortable="false" />
                                <ext:Column ID="Column9" runat="server" Text="Observaciones" DataIndex="observaciones" Flex="1" Sortable="false" />
                                <ext:Column ID="Column10" runat="server" Text="Cantidad Solicitudes" DataIndex="cantidadsolicitudes" Flex="1" Sortable="false" />
                                <ext:Column ID="Column11" runat="server" Text="Fecha Entrega" DataIndex="fecha_destino" Flex="1" Sortable="false" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                    <ext:GridPanel ID="GridPanelUno" runat="server" Collapsible="true" Region="South" AnimCollapse="true" Collapsed="true"
                        Width="700px" Height="350px" Frame="false">
                        <Store>
                            <ext:Store ID="StoreUno" runat="server">
                                <Model>
                                    <ext:Model ID="Model8" runat="server" IDProperty="codigo">
                                        <Fields>
                                            <ext:ModelField Name="correlativo" />
                                            <ext:ModelField Name="codigo" />
                                            <ext:ModelField Name="req_nombre" />
                                            <ext:ModelField Name="descripcion" />
                                            <ext:ModelField Name="necesario" />
                                            <ext:ModelField Name="llave" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column ID="Column12" runat="server" Text="Correlativo" DataIndex="correlativo" Flex="1" Sortable="false" Width="50px">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>

                                <ext:Column ID="Column13" runat="server" Text="Plan" DataIndex="codigo" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="Column14" runat="server" Text="Requisito" DataIndex="req_nombre" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:CheckColumn ID="CheckColumn1" runat="server" Text="Check" DataIndex="necesario">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:CheckColumn>
                                <ext:Column ID="Column15" runat="server" Text="Descripción" DataIndex="descripcion" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                                <ext:Column ID="llave" runat="server" Text="Llave" DataIndex="llave" Flex="1" Sortable="false">
                                    <Filter>
                                        <ext:StringFilter />
                                    </Filter>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <ext:Button ID="Button4" runat="server" Text="Completo" Icon="Accept">
                                        <DirectEvents>
                                            <Click OnEvent="checke">
                                            </Click>
                                        </DirectEvents>
                                        <DirectEvents>
                                            <Click OnEvent="Guardar_buscar">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" SingleExpand="false">
                                <Component>
                                    <ext:FormPanel ID="FormPanel1" runat="server" BodyPadding="6" Height="180" Border="false" DefaultAnchor="-5" Cls="white-footer">
                                        <Items>
                                            <ext:FieldContainer ID="FieldContainer4" runat="server" Layout="HBoxLayout">
                                                <Items>
                                                    <ext:TextField ID="TextFieldWPoliza" runat="server" FieldLabel="Correlativo" DataIndex="correlativo" IDMode="Static" MarginSpec="0 3 0 0" />
                                                    <ext:TextField ID="TextFieldWRamo" runat="server" FieldLabel="Plan" DataIndex="plan_" IDMode="Static" MarginSpec="0 3 0 0" />
                                                    <ext:TextField ID="TextFieldllave" runat="server" FieldLabel="Llave" DataIndex="llave" IDMode="Static" MarginSpec="0 3 0 0" />
                                                    <ext:TextField ID="TextFieldnArchivo" runat="server" FieldLabel="Archivo" IDMode="Static" MarginSpec="0 3 0 0" />
                                                </Items>
                                            </ext:FieldContainer>
                                            <ext:TextField ID="TextFieldWObservacion" runat="server" FieldLabel="Observación"
                                                Note="<b><i>Observaciones:</i></b></br>Campo para digitar las observaciones realizadas sobre la póliza"
                                                IDMode="Static" DataIndex="observacion">
                                            </ext:TextField>
                                            <ext:FileUploadField runat="server" ID="FileUploadPDF" FieldLabel="Cargar PDF's" IDMode="Static">
                                            </ext:FileUploadField>
                                        </Items>
                                        <Buttons>
                                            <ext:Button ID="Button1" runat="server" Text="Guardar" Icon="DiskDownload" IDMode="Static">
                                                <DirectEvents>
                                                    <Click OnEvent="Ubicacion_Click">
                                                        <EventMask ShowMask="true" Msg="Guardando..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Buttons>
                                        <Listeners>
                                            <AfterRender Handler="this.getForm().loadRecord(this.record);" />
                                        </Listeners>
                                    </ext:FormPanel>
                                </Component>
                            </ext:RowExpander>
                        </Plugins>
                        <FooterBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:FieldContainer ID="FieldContainer5" runat="server" Layout="HBoxLayout">
                                        <Items>
                                            <ext:TextField runat="server" ID="TextFieldReqNew" FieldLabel="Nombre" Width="500px" MarginSpec="0 3 0 0" />
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                            <ext:Button ID="Button3"
                                                runat="server"
                                                Text="Agregar"
                                                Icon="New">

                                                <DirectEvents>
                                                    <Click OnEvent="AgregarRequisito" />
                                                </DirectEvents>
                                                <DirectEvents>
                                                    <Click OnEvent="Guardar_buscar">
                                                        <EventMask ShowMask="true" Msg="Adicionando..." />
                                                    </Click>

                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:FieldContainer>
                                </Items>
                            </ext:Toolbar>
                        </FooterBar>
                    </ext:GridPanel>

                </Items>
            </ext:Viewport>

            <ext:Window ID="windowPDF" runat="server" Title="Visor de PDF" Hidden="true" Width="1200px" Height="570px">
                <Loader ID="Loader1" runat="server" Url="../Configurador/configurador.html" Mode="Frame" AutoLoad="true">
                </Loader>
            </ext:Window>
        </div>
    </form>
</body>
</html>
