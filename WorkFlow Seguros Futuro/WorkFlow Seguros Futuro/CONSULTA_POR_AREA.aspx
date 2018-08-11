<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CONSULTA_POR_AREA.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.CONSULTA_POR_AREA" %>


<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Panel UI Styles - Ext.NET Examples</title>
</head>
<body style="padding:30px;">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" SeparateUIStyles="false" />

        <ext:ComboBox ID="ThemeSelector" runat="server" FieldLabel="Theme" AutoPostBack="true">
            <Items>
                <ext:ListItem Text="Classic" Value="0" />
                <ext:ListItem Text="Gray" Value="1" />
                <ext:ListItem Text="Neptune" Value="2" />
            </Items>
        </ext:ComboBox>

        <h3>Panel UI</h3>

        <ext:Panel ID="Panel1" runat="server" Width="800" Height="250" Title="Simple">
            <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Stretch" StretchMaxPartner="5"/>
            </LayoutConfig>
            <Items>
                <ext:Panel ID="Panel2" runat="server" UI="Primary" Flex="1" Title='UI="Primary"' />
                <ext:Panel ID="Panel3" runat="server" UI="Success" Flex="1" Title='UI="Success"' />
                <ext:Panel ID="Panel4" runat="server" UI="Info" Flex="1" Title='UI="Info"' />
                <ext:Panel ID="Panel5" runat="server" UI="Danger" Flex="1" Title='UI="Danger"' />
                <ext:Panel ID="Panel6" runat="server" UI="Warning" Flex="1" Title='UI="Warning"' />
            </Items>
        </ext:Panel>

        <br />

        <ext:Panel ID="Panel7" runat="server" Width="800" Height="250" Title="Framed">
            <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Stretch" StretchMaxPartner="5"/>
            </LayoutConfig>
            <Items>
                <ext:Panel ID="Panel8" runat="server" UI="Primary" Flex="1" Title='UI="Primary"' Frame="true" />
                <ext:Panel ID="Panel9" runat="server" UI="Success" Flex="1" Title='UI="Success"' Frame="true" />
                <ext:Panel ID="Panel10" runat="server" UI="Info" Flex="1" Title='UI="Info"' Frame="true" />
                <ext:Panel ID="Panel11" runat="server" UI="Danger" Flex="1" Title='UI="Danger"' Frame="true" />
                <ext:Panel ID="Panel12" runat="server" UI="Warning" Flex="1" Title='UI="Warning"' Frame="true" />
            </Items>
        </ext:Panel>

        <br />

        <ext:Panel ID="Panel13" 
            runat="server" 
            Width="800" 
            Height="250" 
            Title="Tools" 
            UI="Primary" 
            Frame="true" 
            Layout="AccordionLayout">
            <Tools>
                <ext:Tool Type="Toggle" />
                <ext:Tool Type="Close" />
                <ext:Tool Type="Minimize" />
                <ext:Tool Type="Maximize" />
                <ext:Tool Type="Restore" />
                <ext:Tool Type="Gear" />
                <ext:Tool Type="Pin" />
                <ext:Tool Type="Unpin" />
                <ext:Tool Type="Right" />
                <ext:Tool Type="Left" />
                <ext:Tool Type="Up" />
                <ext:Tool Type="Down" />
                <ext:Tool Type="Refresh" />
                <ext:Tool Type="Plus" />
                <ext:Tool Type="Help" />
                <ext:Tool Type="Search" />
                <ext:Tool Type="Save" />
                <ext:Tool Type="Print" />
            </Tools>
            <Items>
                <ext:Panel ID="Panel14" runat="server" UI="Primary" Title='UI="Primary"' />
                <ext:Panel ID="Panel15" runat="server" UI="Success" Title='UI="Success"' />
                <ext:Panel ID="Panel16" runat="server" UI="Info" Title='UI="Info"' />
                <ext:Panel ID="Panel17" runat="server" UI="Danger" Title='UI="Danger"' />
                <ext:Panel ID="Panel18" runat="server" UI="Warning" Title='UI="Warning"' />
            </Items>
        </ext:Panel>

        <br />

        <ext:Panel ID="Panel19" 
            runat="server" 
            Width="800" 
            Height="500" 
            Title="Border Layout" 
            UI="Primary" 
            Frame="true" 
            Layout="BorderLayout">                       
            <Items>
                <ext:Panel ID="Panel20" 
                    runat="server" 
                    UI="Primary" 
                    Width="200" 
                    Title='UI="Primary"' 
                    Region="West" 
                    Collapsible="true" 
                    Margins="3" 
                    />
                <ext:Panel ID="Panel21" 
                    runat="server" 
                    UI="Success" 
                    Width="200" 
                    Title='UI="Success"' 
                    Region="East" 
                    Collapsible="true" 
                    Margins="3" 
                    />
                <ext:Panel ID="Panel22" 
                    runat="server" 
                    UI="Info" 
                    Title='UI="Info"' 
                    Region="Center" 
                    Margins="3" 
                    />
                <ext:Panel ID="Panel23" 
                    runat="server" 
                    UI="Danger" 
                    Height="100" 
                    Title='UI="Danger"' 
                    Region="North" 
                    Collapsible="true" 
                    Margins="3" 
                    />
                <ext:Panel ID="Panel24" 
                    runat="server" 
                    UI="Warning" 
                    Height="100" 
                    Title='UI="Warning"' 
                    Region="South" 
                    Collapsible="true" 
                    Margins="3" 
                    />
            </Items>
        </ext:Panel>

    </form>
</body>
</html>
