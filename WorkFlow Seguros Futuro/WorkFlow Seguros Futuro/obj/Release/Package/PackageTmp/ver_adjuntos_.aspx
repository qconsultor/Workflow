<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ver_adjuntos_.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.ver_adjuntos_" %>


<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>DataView with Paging - Ext.NET Examples</title>

    <link href="/resources/css/examples.css" rel="stylesheet" />

    <ext:XScript ID="XScript1" runat="server">
        <script>
            var prepareData = function (data) {
                data.shortName = Ext.util.Format.ellipsis(data.name, 15);
                data.sizeString = Ext.util.Format.fileSize(data.size);
                data.dateString = Ext.Date.format(data.lastmod, "m/d/Y g:i a");

                return data;
            };
            
            var selectionChanged = function (dv,nodes) {
                var l = nodes.length,
                    s = l != 1 ? 's' : '';

			    #{ImagePanel}.setTitle('Ver Archivos Adjuntos (' + l + ' Item' + s + ' seleccionado)');
            };
        </script>
    </ext:XScript>

    <style>
        .images-view .x-panel-body {
            background: white;
            font: 11px Arial, Helvetica, sans-serif;
        }

        .images-view .thumb {
            background: #dddddd;
            padding: 3px;
        }

            .images-view .thumb img {
                height: 100px;
                width: 100px;
            }

        .images-view .thumb-wrap {
            float: left;
            margin: 4px;
            margin-right: 0;
            padding: 5px;
            text-align: center;
        }

            .images-view .thumb-wrap span {
                display: block;
                overflow: hidden;
                text-align: center;
            }

        .images-view .x-view-over {
            border: 1px solid #dddddd;
            background: #efefef url(~/files/row-over.gif) repeat-x left top;
            padding: 4px;
        }

        .images-view .x-item-selected {
            background: #eff5fb url(~/files/selected.gif) no-repeat right bottom;
            border: 1px solid #99bbe8;
            padding: 4px;
        }

            .images-view .x-item-selected .thumb {
                background: transparent;
            }

        .images-view .loading-indicator {
            font-size: 11px;
            background-image: url(~/files/loading.gif);
            background-repeat: no-repeat;
            background-position: left;
            padding-left: 40px;
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">

        <center><h1>ADJUNTOS POR SOLICITUD</h1></center>

        <center><div><iframe id="myPDF" name="myPDF" aling="middle"  frameborder="0" width="1000" height="350"></iframe></div></center>
        <%--<iframe name="vipracing" src="http://vipracing.info/channel/opcion-9/frame" width="653" height="410" scrolling="no"></iframe>--%>
        <%--<iframe name="imagen" src="imagen.aspx/frame" width="1653" height="350" scrolling="no"></iframe>--%>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />


        <center> <ext:Panel
            runat="server"
            ID="ImagePanel"
            Cls="images-view"
            Frame="true"
            Width="435"
            Collapsible="false"
            Title="Vista de Archivos Adjuntos (0 items seleccionados)">
            <Items>
                <ext:DataView ID="DataView1"
                    runat="server"
                    MultiSelect="true"
                    OverItemCls="x-view-over"
                    TrackOver="true"
                    ItemSelector="div.thumb-wrap"
                    EmptyText="No images to display">
                    <Store>
                        <ext:Store ID="Store1" runat="server" PageSize="3">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="name" />
                                        <ext:ModelField Name="url" />
                                        <ext:ModelField Name="size" Type="Int" />
                                        <ext:ModelField Name="lastmod" Type="Date" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Tpl ID="Tpl1" runat="server">
                        <Html>
                            <tpl for=".">
								<div class="thumb-wrap" id="{name}">
									<div class="thumb"><a href="{url}" target="myPDF"><img src="/files/adob.jpg" title="{name}"></a></div>
									<span class="x-editable">{shortName}</span>
								</div>
							</tpl>
                            <div class="x-clear"></div>
                        </Html>
                    </Tpl>
                    <PrepareData Fn="prepareData" />
                    <Listeners>
                        <SelectionChange Fn="selectionChanged" />
                    </Listeners>
                </ext:DataView>
            </Items>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" StoreID="Store1" HideRefresh="true" />
            </BottomBar>
        </ext:Panel></center>
        <%--<ext:Panel runat="server" ID="PanelPrincipal" Title="Lista Negra" TitleAlign="Center" Theme="Neptune" Icon="Vcard" Layout="HBoxLayout" Height="115" Region="North">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="FormLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Width="500">
                    <Items>
                        <ext:TextField ID="TextFieldNombre" runat="server" FieldLabel="Nombre">
                            <DirectEvents>
                                <SpecialKey OnEvent="Consultar_Click" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                    <EventMask ShowMask="true" Msg="Verificando..." />
                                </SpecialKey>
                            </DirectEvents>
                        </ext:TextField>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel9" runat="server" Layout="FormLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Width="500">
                    <Items>
                        <ext:TextField ID="TextFieldReferencia" runat="server" FieldLabel="Referencia">
                            <DirectEvents>
                                <SpecialKey OnEvent="Consultar_Click" Before="return e.getKey() == Ext.EventObject.ENTER;">
                                    <EventMask ShowMask="true" Msg="Verificando..." />
                                </SpecialKey>
                            </DirectEvents>
                        </ext:TextField>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>--%>
        <%--<ext:Panel runat="server" ID="Panel8" BodyStyle="background-color: transparent"
            TitleAlign="Left" Icon="Vcard" Layout="HBoxLayout" Height="310" Border="False" Region="North" Collapsed="false"
            Collapsible="true">
            <Items>
                <ext:Panel ID="Panel4" runat="server" Layout="FormLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Height="600" Width="550">
                    <Items>
                        <ext:TextField ID="TextFieldNombreF" runat="server" StyleSpec="font-family: Arial Black;" FieldLabel="Nombre" ReadOnly="true" />
                        <ext:TextField ID="TextFieldDI" runat="server" FieldLabel="Documento Identidad" ReadOnly="true" />
                        <ext:TextField ID="TextFieldnacionalidad" runat="server" FieldLabel="Nacionalidad" DataIndex="nacionalidad" ReadOnly="true" />
                        <ext:TextField ID="TextFieldaka" runat="server" FieldLabel="A.K.A." DataIndex="aka" ReadOnly="true" />
                        <ext:TextField ID="TextFieldTpersona" runat="server" FieldLabel="Tipo Persona" DataIndex="tipopersona" ReadOnly="true" />
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel6" runat="server" Layout="FormLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Height="600" Width="400">
                    <Items>
                        <ext:TextField ID="TextFieldnit" runat="server" FieldLabel="NIT" DataIndex="nit" ReadOnly="true" />
                        <ext:TextArea ID="TextAreaotrainfo" runat="server" FieldLabel="Otra Informacion" ReadOnly="true" />
                        <ext:TextField ID="TextFieldIVigencia" runat="server" FieldLabel="Condicion" ReadOnly="true" />
                        <ext:DateField runat="server" ID="DateFieldfechaoficio" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Fecha de Oficio" DataIndex="fecha_oficio" />
                        <ext:DateField runat="server" ID="DateFieldrecibido" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Recibido" DataIndex="recibido" />
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel5" runat="server" Layout="FormLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Height="600" Width="500">
                    <Items>
                        <ext:TextField ID="TextFieldtpoliza" runat="server" FieldLabel="Tipo Poliza" ReadOnly="true" />
                        <ext:TextField ID="TextFieldEstado" runat="server" FieldLabel="Estado" ReadOnly="true" />
                        <ext:TextField ID="TextFieldcprima" runat="server" FieldLabel="Cumulo Prima" ReadOnly="true" />
                        <ext:TextField ID="TextFieldcpasegurada" runat="server" FieldLabel="Cumulo Prima Asegurada" ReadOnly="true" />
                        <ext:DateField runat="server" ID="DateFieldRespuesta" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Respuesta" DataIndex="respuesta" />
                        <ext:TextField ID="TextFieldoficiocircular" runat="server" FieldLabel="Oficio Circular" ReadOnly="true" />
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel7" runat="server" Layout="AutoLayout" DefaultAnchor="98%" LabelWidth="80" Border="false" Height="600" Width="800">
                    <Items>
                        <ext:DateField runat="server" ID="DateField5" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Vigencia de" DataIndex="vigencia_de" />
                        <ext:DateField runat="server" ID="DateField6" Width="300px" Format="dd/MM/yyyy" EmptyText="Ingrese Fecha:" FieldLabel="Vigencia Hasta" DataIndex="vigencia_hasta" />
                        <ext:TextField ID="TextField3" runat="server" FieldLabel="Nivel de Riesgo" ReadOnly="true" />
                        <ext:TextField ID="TextFieldPoliza" runat="server" FieldLabel="Ente Fiscalizador" ReadOnly="true" />
                        <ext:TextArea ID="TextAreaCodigo" runat="server" FieldLabel="Observacion" ReadOnly="true" />
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>--%>
    </form>
</body>
</html>

