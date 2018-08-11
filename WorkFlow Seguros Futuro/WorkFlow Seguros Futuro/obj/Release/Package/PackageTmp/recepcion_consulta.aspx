<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recepcion_consulta.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.recepcion_consulta" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Locking, Cell Editing Summary Grid - Ext.NET Examples</title>
    
    <link href="/resources/css/examples.css" rel="stylesheet" />
   
    <style>
        .x-grid-body .x-grid-cell-Cost {
            background-color : #f1f2f4;
        }
         
        .x-grid-row-summary .x-grid-cell-Cost .x-grid-cell-inner{
            background-color : #e1e2e4;
        }    

        .task .x-grid-cell-inner {
            padding-left: 15px;
        }

        .x-grid-row-summary .x-grid-cell-inner {
            font-weight: bold;
            font-size: 11px;
            background-color : #f1f2f4;
        } 
    </style>

    <script>
        var showSummary = true;

        var totalCost = function (records) {
            var i = 0,
                length = records.length,
                total = 0,
                record;

            for (; i < length; ++i) {
                record = records[i];
                total += record.get('Estimate') * record.get('Rate');
            }
            return total;
        };

        var toggleSummary = function (b) {
            showSummary = !showSummary;
            var grid = b.up('gridpanel'),
                view = grid.lockedGrid.getView();
            view.getFeature('group').toggleSummaryRow(showSummary);
            view.refresh();
            view = grid.normalGrid.getView();
            view.getFeature('group').toggleSummaryRow(showSummary);
            view.refresh();
        };
    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <h1>Locking, Cell Editing Summary Grid Example</h1>
        <p>It is not possible to lock or unlock <i>all</i> columns using the user interface. Each side, locked or unlocked must always contain at least one column.</p>

        <ext:ResourceManager ID="ResourceManager1" runat="server"/>        
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            Frame="true"            
            Title="Sponsored Projects"                         
            Icon="ApplicationViewColumns"
            Width="800"
            Height="450">
            <Store>
                <ext:Store ID="Store1" runat="server" GroupField="Name">
                    <Sorters>
                        <ext:DataSorter Property="Due" Direction="ASC" />
                    </Sorters>
                    <Model>
                        <ext:Model ID="Model1" runat="server" IDProperty="TaskID">
                            <Fields>
                                <ext:ModelField Name="ProjectID" Type="Int" />
                                <ext:ModelField Name="Name" />
                                <ext:ModelField Name="TaskID" Type="Int" />
                                <ext:ModelField Name="Description" />
                                <ext:ModelField Name="Estimate" Type="Int" />
                                <ext:ModelField Name="Rate" Type="Float" />
                                <ext:ModelField Name="Cost" Type="Float" />
                                <ext:ModelField Name="Due" Type="Date" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <Plugins>
                <ext:CellEditing ID="CellEditing1" runat="server" ClicksToEdit="1" />
            </Plugins>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="Column1"                        
                        runat="server"
                        Locked="true"
                        TdCls="task"
                        Text="Task"                       
                        Sortable="true"
                        DataIndex="Description"
                        Hideable="false"
                        SummaryType="Count"
                        Width="300">
                        <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' Tasks)' : '(1 Task)');" />                            
                    </ext:Column>
                     
                    <ext:Column ID="Column2" runat="server" Text="Project" DataIndex="Name" Width="180" />
                     
                    <ext:DateColumn ID="DateColumn1"
                        runat="server"
                        Width="130"
                        Text="Due Date"
                        Sortable="true"
                        DataIndex="Due"
                        SummaryType="Max"
                        Format="MM/dd/yyyy">
                        <Editor>
                            <ext:DateField ID="DateField1" runat="server" Format="MM/dd/yyyy" />
                        </Editor>
                    </ext:DateColumn>
 
                    <ext:Column ID="Column3"
                        runat="server"  
                        Width="130"
                        Text="Estimate"
                        Sortable="true"
                        DataIndex="Estimate"
                        SummaryType="Sum">
                        <Renderer Handler="return value +' hours';" />
                        <Editor>
                            <ext:NumberField ID="NumberField1" 
                                runat="server" 
                                AllowBlank="false" 
                                MinValue="0" 
                                StyleSpec="text-align:left" />
                        </Editor>
                    </ext:Column>
                     
                    <ext:Column ID="Column4"
                        runat="server"
                        Width="130"
                        Text="Rate"
                        Sortable="true"
                        DataIndex="Rate"
                        SummaryType="Average">
                        <Renderer Format="UsMoney" />
                        <SummaryRenderer Fn="Ext.util.Format.usMoney" />
                         <Editor>
                            <ext:NumberField ID="NumberField2" 
                                runat="server" 
                                AllowBlank="false" 
                                MinValue="0" 
                                StyleSpec="text-align:left" />
                        </Editor>
                    </ext:Column>
                     
                    <ext:Column
                        runat="server"
                        Width="130"
                        ID="Cost"
                        Text="Cost"
                        Sortable="false"
                        Groupable="false"
                        DataIndex="Cost"
                        CustomSummaryType="totalCost">
                        <Renderer Handler="return Ext.util.Format.usMoney(record.data.Estimate * record.data.Rate);" />
                        <SummaryRenderer Fn="Ext.util.Format.usMoney" />
                    </ext:Column>
                </Columns>                
            </ColumnModel>           
            <Features>               
                <ext:GroupingSummary 
                    ID="group" 
                    runat="server" 
                    GroupHeaderTplString="{name}" 
                    HideGroupedHeader="true" 
                    EnableGroupingMenu="false" />                   
            </Features>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button1" 
                            runat="server" 
                            Text="Toggle" 
                            ToolTip="Toggle the visibility of summary row" 
                            EnableToggle="true" 
                            Pressed="true">
                            <Listeners>
                                <Click Fn="toggleSummary" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <SelectionModel>
                <ext:CellSelectionModel ID="CellSelectionModel1" runat="server" />
            </SelectionModel>
        </ext:GridPanel>
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
