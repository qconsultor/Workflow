<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requisitos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.requisitos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
<body style="width: 1543px">
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Neptune" />
        <ext:Store ID="StoreOrigen" runat="server">
            <Model>
                <ext:Model ID="ModelOrigen" runat="server">
                    <Fields>
                        <ext:ModelField Name="codigo" />
                        <ext:ModelField Name="nombre" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:Viewport ID="Viewport1" runat="server" Layout="AutoLayout">

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
            <Items>

                <ext:Panel runat="server" ID="Panel1" Layout="HBoxLayout" Region="North">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button runat="server" ID="ButtonGuardarrequisitos" Text="Guardar" Icon="ApplicationKey">
                                    <DirectEvents>
                                        <Click OnEvent="Guardar_Click_requi">
                                            <%--  <Click OnEvent="btnUpload_Click"> --%>
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
                                <ext:TextField runat="server" ID="Textfieldcodigo" FieldLabel="Codigo Check List" DataIndex="codigo" Flex="1" MarginSpec="0" AllowBlank="false" />
                                <ext:TextField runat="server" ID="Textfieldnombre" FieldLabel="Nombre Check List" DataIndex="nombre" Flex="1" MarginSpec="0" AllowBlank="false" />
                                 <ext:ComboBox runat="server" ID="ComboBoxArea" Width="500px" TypeAhead="false" PageSize="10"
                            FieldLabel="Area" DisplayField="req_nombre" ValueField="req_cod" TriggerAction="Query" QueryMode="Local">
                            <Store>
                                <ext:Store ID="StorePasos" runat="server">
                                    <Model>
                                        <ext:Model ID="Model4" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="req_cod"></ext:ModelField>
                                                <ext:ModelField Name="req_nombre"></ext:ModelField>
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ListConfig LoadingText="Buscando...">
                                <ItemTpl ID="ItemTpl1" runat="server">
                                    <Html>
                                        <div class="search-item">
                       <h3><span>Tarea: </span>{req_nombre}</h3>
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
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" Flex="1" Layout="FormLayout" DefaultAnchor="98%" Border="false">
                            <Items>
                                <ext:FileUploadField runat="server" ID="FileUploadFieldArchivo" ButtonText="Buscar" Icon="Attach" Width="400px"></ext:FileUploadField>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel5" runat="server" Region="Center" Frame="true" MarginSpec="0 5 0 5" Height="800px">
                    <Items>

                        <ext:ComboBox runat="server" ID="ComboBoxRequisitos" FieldLabel="Requisito" ValueField="desc_" DisplayField="descripcion">
                            <Store>
                                <ext:Store runat="server" ID="StoreRequis">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="codigo" />
                                                <ext:ModelField Name="descripcion" />
                                                <ext:ModelField Name="desc_" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Select Handler="#{Textfieldreq_nombre}.setValue(this.value);" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="Textfieldreq_cod" FieldLabel="Codigo Requisito" DataIndex="req_cod" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfieldreq_nombre" FieldLabel="Nombre Requisito" DataIndex="req_nombre" Flex="1" AllowBlank="false" />
                        <ext:TextField runat="server" ID="Textfieldnecesario" FieldLabel="Check" DataIndex="necesario" Flex="1" AllowBlank="false" />
                        <ext:Button runat="server" ID="Button2" Text="Guardar Requisito para este Check list " Icon="ApplicationKey">
                            <DirectEvents>
                                <Click OnEvent="Guardar_Click_sp_Check_list_detalle">
                                    <%--  <Click OnEvent="btnUpload_Click"> --%>
                                    <EventMask ShowMask="true" Msg="Guardando..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
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
        </ext:Viewport>
        <ext:Window runat="server" ID="WindowConsulta" Modal="true" Title="Búsqueda en Maestro de Requisitos" Icon="FolderDatabase" BodyStyle="background-color: #fff;" CloseAction="Hide" Closable="true" Width="750" Height="550" TitleAlign="Center" Hidden="true" Maximizable="true" Minimizable="true">
            <Items>
                <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="FormLayout">
                    <Items>
                        <ext:TextField runat="server" ID="Textfieldcodigo_buscar" FieldLabel="No. de requisito" DataIndex="codigo" />
                    </Items>
                </ext:FieldContainer>

                <ext:GridPanel runat="server" ID="GridPanelBusqueda" Icon="Tab" Title="Búsqueda" Hidden="true">
                    <Store>
                        <ext:Store runat="server" ID="StoreBusqueda">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
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
                            <ext:Column ID="Column1" runat="server" DataIndex="codigo" Text="Codigo" />
                            <ext:Column ID="Column2" runat="server" DataIndex="nombre" Text="nombre" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>

        </ext:Window>

    </form>
</body>
</html>
