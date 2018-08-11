<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lista_adjuntos.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.lista_adjuntos" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>GridPanel - Ext.NET Examples</title>    
    <link href="/resources/css/examples.css" rel="stylesheet" />
    
    <script>
        var selectionChanged = function (selModel, selected) {
            var count = selected.length, s = count != 1 ? "s" : "";
            App.Panel1.setTitle("Simple GridPanel (" + count + " item" + s + " selected)");
        };
    </script>   
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>ListView Example</h1>
        
        <p>Ext.Net 2 replaces Ext.ListView with the default GridPanel.</p>
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Width="650" 
            Height="300"
            Title="Simple List <i>View (0 items selected)</i>"
            Layout="Fit">
            <Items>
                <ext:GridPanel ID="GridPanel1" runat="server">
                    <Store>
                        <ext:Store ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="name">
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
                    <ColumnModel>
                        <Columns>
                            <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                Text="File" 
                                Flex="15" 
                                DataIndex="url" 
                                TemplateString='<img style="width:60px;height:45px;" src="{url}" />' 
                                />
                            <ext:Column ID="Column1" 
                                runat="server"
                                Text="File" 
                                Flex="35" 
                                DataIndex="name" 
                                />
                            <ext:TemplateColumn ID="TemplateColumn2" 
                                runat="server"
                                Text="Last Modified" 
                                Flex="30" 
                                DataIndex="lastmod" 
                                TemplateString='{lastmod:date("m-d h:i a")}' 
                                />
                            <ext:TemplateColumn ID="TemplateColumn3"
                                runat="server" 
                                Text="Size" 
                                Flex="20" 
                                DataIndex="size" 
                                Align="Right" 
                                TemplateString="{size:fileSize}" 
                                />
                        </Columns>    
                    </ColumnModel>
                    <View>
                        <ext:GridView ID="GridView1" 
                            runat="server" 
                            EmptyText="No Images to Display" />
                    </View>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Multi" />
                    </SelectionModel>
                    <Listeners>
                        <SelectionChange Fn="selectionChanged" /> 
                    </Listeners> 
                </ext:GridPanel>
            </Items>        
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Submit Selected" OnDirectClick="Button1_Click" />
                <ext:Button ID="Button2" runat="server" Text="Submit Selected with Values">
                    <DirectEvents>
                        <Click OnEvent="SubmitSelection">
                            <ExtraParams>
                                <ext:Parameter 
                                    Name="Values" 
                                    Value="#{GridPanel1}.getRowsValues({ selectedOnly : true })" 
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button3" runat="server" Text="Clear Selections" OnDirectClick="Clear_Click" />
                <ext:Button ID="Button4" runat="server" Text="Add 'Zack' to Selection " OnDirectClick="Add_Click" />
            </Buttons>
        </ext:Panel>
        
        <div style="width:650px; border:1px solid gray; padding:5px;">
            <ext:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>