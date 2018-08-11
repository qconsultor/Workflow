<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_maestro_porcentaje.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_maestro_porcentaje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
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
    <style type="text/css">
        #myPDF {
            margin-left: 0px;
            width: 331px;
            margin-right: 41px;
        }

        #form1 {
            width: 1550px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">

<%--        
        <ext:Store ID="StoreOrigen" runat="server">
            <Model>
                <ext:Model ID="ModelOrigen" runat="server">
                    <Fields>
                        <ext:ModelField Name="codigo" />
                        <ext:ModelField Name="nombre" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>--%>

       <%--<ext:Viewport ID="Viewport1" runat="server" Layout="AutoLayout">--%>
           
            <%--<Items>
                <ext:Panel ID="Panel4"
                    runat="server"
                    Border="false"
                    Header="false"
                    ColumnWidth=".5"
                    Layout="Form"
                    LabelAlign="Top">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="TextField1" runat="server" FieldLabel="First Name" AnchorHorizontal="92%" />
                        <ext:TextField ID="TextField2" runat="server" FieldLabel="Company" AnchorHorizontal="92%" />
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel6" runat="server" Border="false" Layout="Form" ColumnWidth=".5" LabelAlign="Top">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="TextField3" runat="server" FieldLabel="Last Name" AnchorHorizontal="92%" />
                        <ext:TextField ID="TextField4" runat="server" FieldLabel="Email" Vtype="email" AnchorHorizontal="92%" />
                    </Items>
                </ext:Panel>
            </Items>--%>
            <%--<Items>--%>

                <ext:Panel runat="server" ID="Panel1" Layout="HBoxLayout" Region="North">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button runat="server" ID="ButtonGuardarrequisitos" Text="Guardar" Icon="ApplicationKey">
                                    <DirectEvents>
                                        <Click OnEvent="Guardar_Click_requi">
                                        <EventMask ShowMask="true" Msg="Guardando..." />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" ID="ButtonConsultar" Text="Consultar" Icon="Find" OnClientClick="#{WindowConsulta}.show();">
                                </ext:Button>
                                <ext:Button ID="Button1" runat="server" Text="Print" Icon="Printer">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:Panel ID="Panel2" runat="server" Flex="1" Layout="FormLayout" DefaultAnchor="75%" Border="false">
                            <Items>
                                <%--<ext:TextField runat="server" ID="Textfieldcodigo" FieldLabel="Co" DataIndex="codigo" Flex="1" MarginSpec="0" AllowBlank="false" />--%>
                                <%--<ext:TextField runat="server" ID="Textfieldnombre" FieldLabel="Nombre de paso" DataIndex="nombre" Flex="1" MarginSpec="0" AllowBlank="false" />--%>
                                <ext:ComboBox runat="server" ID="ComboBoxBuscador" Width="500px" EmptyText="Digite Ente" TypeAhead="false" PageSize="10"
                            FieldLabel="Buscador" DisplayField="nombre" ValueField="codigo" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="StoreBuscador" runat="server">
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
                       <h3><span>Paso: </span>{nombre}</h3>
                       <b>Código de Paso: {codigo}</b>
                      </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                           <%-- <DirectEvents>
                                <Select OnEvent="Grid_Buscador" />
                            </DirectEvents>--%>
                        </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" Flex="1" Layout="FormLayout" DefaultAnchor="98%" Border="false">
                            <Items>
                               <ext:Button runat="server" ID="Button3" Text="Buscar" Icon="ApplicationKey">
                                    <DirectEvents>
                                        <Click OnEvent="Grid_Buscador">
                                            <%--  <Click OnEvent="btnUpload_Click"> --%>
                                            <EventMask ShowMask="true" Msg="Guardando..." />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button> 
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel5" runat="server" Region="Center" Frame="true" MarginSpec="0 5 0 5" Height="200px">
                    <Items>
                        <ext:ComboBox runat="server" ID="ComboBoxRequisitos" FieldLabel="Paso" ValueField="req_codigo" DisplayField="req_nombre">
                            <Store>
                                <ext:Store runat="server" ID="StoreRequis">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="req_codigo" />
                                                <ext:ModelField Name="req_nombre" />
                                                
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                             <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl2" runat="server">
                                    <Html>
                                        <div class="search-item">
                           <h3><span>Paso: </span>{req_nombre}</h3>
                          <b>Código: {req_codigo}</b>
                          </div>
                                    </Html>
                                </ItemTpl>
                            </ListConfig>
                            <DirectEvents>
                                <Select OnEvent="Generar_Click" />
                            </DirectEvents>
                           <%-- <Listeners>
                                <Select Handler="#{Textfieldreq_cod}.setValue(this.value);" />
                                <Select Handler="#{Textfieldreq_nombre}.setValue(this.DisplayField);" />
                            </Listeners>--%>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="Textfieldreq_cod" FieldLabel="Codigo del Paso" DataIndex="req_codigo" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfieldreq_nombre" FieldLabel="Nombre Paso" DataIndex="req_nombre" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfield1" FieldLabel="Area" DataIndex="area" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfield2" FieldLabel="Puntos" DataIndex="cant_pasos" Flex="1" AllowBlank="false" />
                        <ext:Button runat="server" ID="Button2" Text="Guardar Requisito para este Check list " Icon="ApplicationKey">
                            <DirectEvents>
                                <Click OnEvent="Guardar_Click_sp_Check_list_detalle">
                                    <%--  <Click OnEvent="btnUpload_Click"> --%>
                                    <EventMask ShowMask="true" Msg="Guardando..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        </Items>
                    </ext:Panel>
                        <ext:TabPanel ID="TabPanel1" runat="server" Layout="FormLayout" >
                    <Defaults>
                    <ext:Parameter Name="bodyPadding" Value="10" Mode="Raw" />
                    <ext:Parameter Name="autoScroll" Value="true" Mode="Raw" />
                </Defaults>
            <Items>
                <ext:Panel ID="Panel4" runat="server" Title="Busqueda"   Layout="FormLayout">
                    <Items>  
        <ext:GridPanel runat="server" ID="GridPanelBuscador" Region="Center" Border="False" Layout="FitLayout">
                <Store> 
                    <ext:Store runat="server" ID="StoreBuscador1">
                        <Fields>
                            <ext:ModelField Name="codigo" />
                            <ext:ModelField Name="req_cod" />
                            <ext:ModelField Name="req_nombre" />
                            <ext:ModelField Name="area" />
                            <ext:ModelField Name="cant_pasos" />
                            
                            
                            </Fields>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column ID="Column3" runat="server" Text="Codigo" DataIndex="codigo" />
                        <ext:Column ID="Column4" runat="server" Text="Req. Codigo" DataIndex="req_cod" Width="300" />
                        <ext:Column ID="Column6" runat="server" Text="req. Nombre" DataIndex="req_nombre" Width="300" />
                        <ext:Column ID="Column5" runat="server" Text="Area" DataIndex="area" Width="300" />
                        <ext:Column ID="Column45" runat="server" Text="Pasos" DataIndex="cant_pasos" Width="300" />
                    </Columns>
                </ColumnModel>
            <%--<Plugins>
                        <ext:RowExpander ID="RowExpander1" runat="server" ExpandOnDblClick="true" SelectRowOnExpand="true" SingleExpand="false">
                            <Loader ID="Loader1" runat="server" DirectMethod="#{DirectMethods}.GetGrid" Mode="Component"> 
                                <LoadMask ShowMask="true" />
                                <Params>
                                    <%--#{GridPanelOfertas}.getRowsValues({selectedOnly:true})[0].cpoliza 
                                    <ext:Parameter Name="id" Value="#{GridPanelRed}.getRowsValues({selectedOnly:true})" Encode="true" Mode="Raw" />
                                </Params>
                            </Loader>
                        </ext:RowExpander>
                        <ext:GridFilters ID="GridFilters1" runat="server" />
                    </Plugins>--%>
            <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                    </SelectionModel>
                    <DirectEvents>
                        <RowDblClick OnEvent="RealizarConsulta">
                            <EventMask ShowMask="true" Msg="Procesando..." />
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="id" Value="Ext.encode(#{GridPanelBuscador}.getRowsValues({selectedOnly:true}))" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>
                   <Plugins>
                        <ext:GridFilters ID="GridFilters2" runat="server" />
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true"/>
                    </BottomBar>
                   <TopBar>
                        <ext:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <%--<ext:Button ID="Button5" runat="server" Text="Exportar a Excel" Icon="PageExcel" AutoPostBack="true" OnClick="ToExcel">
                                    <Listeners>
                                        <Click Fn="saveData" />
                                    </Listeners>
                                </ext:Button>--%>
                            </Items>
                    </ext:Toolbar>
                    </TopBar>
            </ext:GridPanel>
                         </Items>
                </ext:Panel>    
                <ext:Panel ID="Panel6" runat="server" Title="Vista General" Layout="FitLayout">
                    <Items>
                        <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab" Title="Vista de Requisitos - Check List" Border="false" Height="650px">
                            <Store>
                                <ext:Store runat="server" ID="Store1">
                                    <Model>
                                        <ext:Model ID="Model2" runat="server" IDProperty="codigo">
                                            <Fields>
                                                <ext:ModelField Name="codigo" />
                                                <ext:ModelField Name="nombre" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column ID="Column9" runat="server" DataIndex="codigo" Text="Codigo" Width="150px">
                                        <Filter>
                                            <ext:StringFilter />
                                        </Filter>
                                    </ext:Column>
                                    <ext:Column ID="Column10" runat="server" DataIndex="nombre" Text="nombre de check list" Width="1000px">
                                        <Filter>
                                            <ext:StringFilter />
                                        </Filter>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <Plugins>
                                <ext:RowExpander ID="RowExpander2" runat="server" ExpandOnDblClick="true" SelectRowOnExpand="true" SingleExpand="false">
                                    <Loader ID="Loader2" runat="server" DirectMethod="#{DirectMethods}.GetGrid" Mode="Component">
                                        <LoadMask ShowMask="true" />
                                        <Params>
                                            <%--#{GridPanelOfertas}.getRowsValues({selectedOnly:true})[0].cpoliza --%>
                                            <ext:Parameter Name="id" Value="#{GridPanel1}.getRowsValues({selectedOnly:true})" Encode="true" Mode="Raw" />
                                        </Params>
                                    </Loader>
                                </ext:RowExpander>
                                <ext:GridFilters ID="GridFilters5" runat="server" />
                            </Plugins>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel" runat="server" />
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true" />
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
                </Items>
        </ext:TabPanel>
                        
            <%--</Items>
        </ext:Viewport>--%>
        <ext:Window runat="server" ID="WindowConsulta" Modal="true" Title="Búsqueda en Maestro de Requisitos" Icon="FolderDatabase" 
            BodyStyle="background-color: #fff;" CloseAction="Hide" Closable="true" Width="750" Height="550" TitleAlign="Center" 
            Hidden="true" Maximizable="true" Minimizable="true" IDMode="Static">
            <Items>
                <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="FormLayout">
                    <Items>
                        <ext:TextField runat="server" ID="Textfieldcodigo" FieldLabel="Codigo" DataIndex="codigo" />
                        <ext:TextField runat="server" ID="Textfield3" FieldLabel="Codigo del Paso" DataIndex="req_cod" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfield4" FieldLabel="Nombre Paso" DataIndex="req_nombre" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfield5" FieldLabel="Area" DataIndex="area" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfield6" FieldLabel="Puntos" DataIndex="cant_pasos" Flex="1" AllowBlank="false" />
                    </Items>
                </ext:FieldContainer>
               <ext:Button runat="server" ID="Button4" Text="Guardar" Icon="ApplicationKey">
                            <DirectEvents>
                                <Click OnEvent="Actualizar_ClickPendiente">
                                    <%--  <Click OnEvent="btnUpload_Click"> --%>
                                    <EventMask ShowMask="true" Msg="Guardando..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
