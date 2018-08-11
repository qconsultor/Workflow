<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gr_asignados_emision.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.gr_asignados_emision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bar Chart - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />

    <script>
        var saveChart = function (btn) {
            Ext.MessageBox.confirm('Confirm Download', 'Would you like to download the chart as an image?', function (choice) {
                if (choice === 'yes') {
                    btn.up('panel').down('chart').download();
                }
            });
        };
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
      <ext:Panel ID="Panel1" runat="server" Title="Control de Asignacion" Region="West" Frame="true" Width="650" Height="450"  Collapsible="true">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Pack="Center" Align="Stretch" />
            </LayoutConfig>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <ext:Button ID="Button2" runat="server"  Text="Save Chart" Icon="Disk" Handler="saveChart" />
                    </Items>
                </ext:Toolbar>
            </TopBar>

            <Items>
                <ext:CartesianChart
                    ID="Chart1" runat="server" FlipXY="true" InsetPadding="40" Height="500">
                    <AnimationConfig Duration="500" Easing="EaseOut" />
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="cantidad" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                   <Axes>
                        <ext:NumericAxis Fields="cantidad" Position="Bottom" Grid="true" Maximum="100">
                           
                        </ext:NumericAxis>

                        <ext:CategoryAxis  Fields="nombre"  Position="Left"  Grid="true" />
                    </Axes>

                    <Series>
                        <ext:BarSeries XField="nombre" YField="cantidad">
                           <StyleSpec>
                                <ext:SeriesSprite Opacity="0.8" MinGapWidth="10" />
                            </StyleSpec>
                            <HighlightConfig>
                                <ext:Sprite FillStyle="rgba(249, 204, 157, 1.0)" StrokeStyle="black" LineWidth="2" />
                            </HighlightConfig>
                            <Tooltip ID="Tooltip1" runat="server" TrackMouse="true" StyleSpec="background: #fff">
                                <Renderer Handler="toolTip.setHtml(record.get('nombre') + ': ' + record.get('cantidad') + '%');" />
                            </Tooltip>
                            <Label
                                Display="InsideEnd"
                                Field="cantidad" />
                        </ext:BarSeries>
                    </Series>
                </ext:CartesianChart>
            </Items>
        </ext:Panel>
        <ext:GridPanel runat="server" ID="GridPanel1" Icon="Tab" Title="CUADRO RESUMEN DE ACTIVIDADES" Frame="true" Layout="AutoLayout" Region="Center" BodyPadding="5" >
                    <Store>
                        <ext:Store runat="server" ID="Store2">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="nombre" />
                                        <ext:ModelField Name="cantidad" />
                                        <ext:ModelField Name="asignado" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                           <ext:Column ID="Column9" runat="server" DataIndex="nombre" Text="Asignado" Width="200px">
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                             <ext:Column ID="Column1" runat="server" DataIndex="asignado" Text="Asignado" Width="300px" Hidden="true">
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                            <ext:Column ID="Column10" runat="server" DataIndex="cantidad" Text="Cantidad" Width="700px">
                                <Filter>
                                    <ext:StringFilter />
                                </Filter>
                            </ext:Column>
                          </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:RowExpander ID="RowExpander2" runat="server" ExpandOnDblClick="true" SelectRowOnExpand="true" SingleExpand="false">
                            <Loader ID="Loader1" runat="server" DirectMethod="#{DirectMethods}.GetGrid" Mode="Component">
                                <LoadMask ShowMask="true" />
                                <Params>
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
                </Items>

        </ext:Viewport>
    </form>
</body>
</html>