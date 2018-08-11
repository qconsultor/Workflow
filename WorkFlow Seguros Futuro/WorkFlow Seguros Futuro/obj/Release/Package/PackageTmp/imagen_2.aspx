<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imagen_2.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.imagen_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <form id="form1" runat="server">
    
    <ext:Viewport ID="Viewport2" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabStrip ID="TabStrip1" runat="server" Region="North" ActiveTabIndex="1" >
                <Items>
                    <ext:Tab ActionItemID="test1" Text="Test 1**" />
                    <ext:Tab ActionItemID="test2" Text="Test 2**" />
                </Items>
            </ext:TabStrip>

            <ext:Panel ID="test1" Title="test1" Html="teste 1">
                <Listeners>
                    <BeforeActivate Handler="alert('test 1 activated');" />
                    <BeforeShow Handler="alert('test 1 show!');" />
                </Listeners>
            </ext:Panel>
            <ext:Panel ID="test2" Title="test2" Html="teste 2" >
                <Listeners>
                    <BeforeActivate Handler="alert('test 2 activated');" />
                    <BeforeShow Handler="alert('test 2 show!');" />
                </Listeners>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
