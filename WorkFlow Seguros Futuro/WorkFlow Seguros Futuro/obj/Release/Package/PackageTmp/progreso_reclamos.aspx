<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="progreso_reclamos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.progreso_reclamos" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Consulta de Ejecucion de Solicitudes</title>
    <link href="/resources/css/examples.css" rel="stylesheet" /> 
    <script type="text/javascript">
        var tema = '<span style="color:{0};">{1}</span>';

        var cambiar = function (value) {
            return Ext.String.format(template, (value > 99) ? "green" : "black", value);
        };

     </script>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var dias = function (value) {

                if (value >= 0 && value <= 4) {
                    return Ext.String.format(template, "green", value);
                }
                else if (value >= 5 && value <= 6) {
                    return Ext.String.format(template, "yellow", value);

                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
         <script>
             var template = '<strong><span style="color:{0};">{1}</span></strong>';

             var recepcion = function (value) {

                 if (value >= 0 && value <= 0) {
                     return Ext.String.format(template, "green", value);
                 }
                 else {
                     return Ext.String.format(template, "red", value);
                 }
             };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var revision = function (value) {

                if (value >= 0 && value <= 0) {
                    return Ext.String.format(template, "green", value);
                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var liquidacion = function (value) {

                if (value >= 0 && value <= 1) {
                    return Ext.String.format(template, "green", value);
                }
                else if (value >= 2 && value <= 3) {
                    return Ext.String.format(template, "yellow", value);

                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var firma_coordinadora = function (value) {

                if (value >= 0 && value <= 2) {
                    return Ext.String.format(template, "green", value);
                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var firma_g_tecnica = function (value) {

                if (value >= 0 && value <= 0) {
                    return Ext.String.format(template, "green", value);
                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var firma_g_financiera = function (value) {

                if (value >= 0 && value <= 2) {
                    return Ext.String.format(template, "green", value);
                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>
         <script>
             var template = '<strong><span style="color:{0};">{1}</span></strong>';

             var emision_cheque = function (value) {

                 if (value >= 0 && value <= 2) {
                     return Ext.String.format(template, "green", value);
                 }
                 else {
                     return Ext.String.format(template, "red", value);
                 }
             };

    </script>
         <script>
             var template = '<strong><span style="color:{0};">{1}</span></strong>';

             var entrega_cheque = function (value) {

                 if (value >= 0 && value <= 2) {
                     return Ext.String.format(template, "green", value);
                 }
                 else {
                     return Ext.String.format(template, "red", value);
                 }
             };

    </script>
         <script>
             var template = '<strong><span style="color:{0};">{1}</span></strong>';

             var entrega_ate_cliente = function (value) {

                 if (value >= 0 && value <= 2) {
                     return Ext.String.format(template, "green", value);
                 }
                 else {
                     return Ext.String.format(template, "red", value);
                 }
             };

    </script>
        <script>
            var template = '<strong><span style="color:{0};">{1}</span></strong>';

            var fin = function (value) {

                if (value >= 0 && value <= 2) {
                    return Ext.String.format(template, "green", value);
                }
                else {
                    return Ext.String.format(template, "red", value);
                }
            };

    </script>

        <h1>Monitoreo Reclamos</h1>
       
        <%--<ext:GridPanel ID="GridPanel1" 
            runat="server" 
            Title="Avance por Area" 
            Width="620" 
            Height="220">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Model>
                        <ext:Model ID="Model1" runat="server">
                            <Fields>
                                 <ext:ModelField Name="Referencia" Type="Int" />
                                <ext:ModelField Name="Poliza" Type="string" />
                                <ext:ModelField Name="Asegurado" Type="string" />
                                <ext:ModelField Name="Index" Type="Int" />
                                <ext:ModelField Name="Porcentage" Type="Float" />
                                <ext:ModelField Name="UI" Type="string" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1" runat="server" DataIndex="Referencia" Text="Referencia" />
                    <ext:Column ID="Column2" runat="server" DataIndex="Poliza" Text="Poliza" />
                    <ext:Column ID="Column3" runat="server" DataIndex="Asegurado" Text="Asegurado"  Width="220"/>
                    <ext:Column ID="Column4" runat="server" DataIndex="Porcentage" Text="Puntos" />
                     <ext:ProgressBarColumn ID="ProgressBarColumn1" runat="server" DataIndex="Porcentage" Text="Ejecucion" UI="Danger" >
                     </ext:ProgressBarColumn>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>--%>
        <ext:GridPanel ID="GridPanel1" 
            runat="server" 
            Title="Avance por Area" 
             Layout="AutoLayout"  >
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Model>
                        <ext:Model ID="Model1" runat="server">
                            <Fields>
                                 <ext:ModelField Name="correlativo" Type="Int" />
                                <ext:ModelField Name="Poliza_Maestra" Type="string" />
                                <ext:ModelField Name="asegurado" Type="string" />
                                <ext:ModelField Name="Estado"  />
                                <ext:ModelField Name="Puntos"  />
                                <ext:ModelField Name="dias" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1" runat="server" DataIndex="correlativo" Text="Referencia" />
                    <ext:Column ID="Column2" runat="server" DataIndex="Poliza_Maestra" Text="Poliza" />
                    <ext:Column ID="Column3" runat="server" DataIndex="asegurado" Text="Asegurado"  Width="220"/>
                    <ext:Column ID="Column4" runat="server" DataIndex="Estado" Text="Estado" Width="220" />
                     <ext:ProgressBarColumn ID="ProgressBarColumn1" runat="server" DataIndex="Puntos" Text="Ejecucion" UI="Success"  >
                     </ext:ProgressBarColumn>
                    <ext:Column ID="Column5" runat="server" DataIndex="dias" Text="Indicador en dias" Width="350" >
                     <Renderer Fn="dias" />
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
                        <RowDblClick OnEvent="RealizarConsulta_Clickindicador">
                            <EventMask ShowMask="true" Msg="Procesando..." />
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="id" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>
                  <Plugins>
                     
                        <%--<ext:RowExpander ID="RowExpander2" runat="server" ExpandOnDblClick="true" SelectRowOnExpand="true" SingleExpand="false">
                            <Loader ID="Loader1" runat="server" DirectMethod="#{DirectMethods}.GetGrid" Mode="Component">
                                <LoadMask ShowMask="true" />
                                <Params>
                                    <%--#{GridPanelOfertas}.getRowsValues({selectedOnly:true})[0].cpoliza 
                                    <ext:Parameter Name="id" Value="#{GridPanel1}.getRowsValues({selectedOnly:true})" Encode="true" Mode="Raw" />
                                </Params>
                            </Loader>
                        </ext:RowExpander>--%>

                        <ext:GridFilters ID="GridFilters2" runat="server" />
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" HideRefresh="true"/>
                    </BottomBar>
        </ext:GridPanel>


        <ext:Window runat="server" ID="WindowModificacion" Title="Detalle de indicadores" Width="1500" Height="250" BodyPadding="10" Resizable="true"
            Closable="true" Layout="AutoLayout" Region="Center" TitleAlign="Center" Icon="UserGray" Modal="true" Maximizable="true"  AutoScroll="true" Hidden="true">
            <Items>
                <ext:TextField runat="server" ID="TextFieldCorre" Hidden="true" />
        <ext:GridPanel ID="GridPanel2" 
            runat="server" 
            Title="Avance por Area" 
             Layout="AutoLayout"  >
            <Store>
                <ext:Store ID="Store2" runat="server">
                    <Model>
                        <ext:Model ID="Model2" runat="server">
                            <Fields>
                                 <ext:ModelField Name="correlativo"  />
                                <ext:ModelField Name="recepcion" />
                                <ext:ModelField Name="revision" />
                                <ext:ModelField Name="liquidacion"  />
                                <ext:ModelField Name="firma_coordinadora"  />
                                <ext:ModelField Name="firma_g_tecnica" />
                                <ext:ModelField Name="firma_g_financiera" />
                                <ext:ModelField Name="emision_cheque" />
                                <ext:ModelField Name="entrega_cheque" />
                                <ext:ModelField Name="entrega_ate_cliente" />
                                <ext:ModelField Name="fin" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel2" runat="server">
                <Columns>
                    <ext:Column ID="Column6" runat="server" DataIndex="correlativo" Text="Referencia" Width="100" />
                    <ext:Column ID="Column7" runat="server" DataIndex="recepcion" Text="Recepcion" >
                        <Renderer Fn="recepcion" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column8" runat="server" DataIndex="revision" Text="Revision"  Width="80">
                        <Renderer Fn="revision" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column9" runat="server" DataIndex="liquidacion" Text="Liquidacion" Width="100" >
                        <Renderer Fn="liquidacion" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column10" runat="server" DataIndex="firma_coordinadora" Text="Fima Coordinadora" Width="135" >
                     <Renderer Fn="firma_coordinadora" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column11" runat="server" DataIndex="firma_g_tecnica" Text="Firma Gerencia Tecnica" Width="190" >
                     <Renderer Fn="firma_g_tecnica" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column12" runat="server" DataIndex="firma_g_financiera" Text="Firma Gerencia Financiera" Width="190" >
                     <Renderer Fn="firma_g_financiera" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column13" runat="server" DataIndex="emision_cheque" Text="Emision Cheque" Width="140">
                     <Renderer Fn="emision_cheque" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column14" runat="server" DataIndex="entrega_cheque" Text="Entrega Cheque" Width="140">
                     <Renderer Fn="entrega_cheque" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column15" runat="server" DataIndex="entrega_ate_cliente" Text="Atencion al Cliente" Width="160">
                     <Renderer Fn="entrega_ate_cliente" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                    <ext:Column ID="Column16" runat="server" DataIndex="fin" Text="Completado" Width="130">
                     <Renderer Fn="fin" />
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                </Columns>
            </ColumnModel>
                  
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" HideRefresh="true"/>
                    </BottomBar>
        </ext:GridPanel>
   </Items>
        </ext:Window>

    </form>
</body>
</html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>

