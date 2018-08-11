<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check_onmulticombo.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.check_onmulticombo" %>--%>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        
        <p>Radio mode</p>
        <ext:MultiCombo ID="MultiCombo1" runat="server">
            <Items>
                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
            </Items>
            
            <Listeners>
                <BeforeSelect Handler="this.clearSelections();" />
            </Listeners>
        </ext:MultiCombo>
        
        <br />
        <p>Single selection mode but it is required to uncheck manually</p>
        <ext:MultiCombo ID="MultiCombo2" runat="server">
            <Items>
                <ext:ListItem Text="Item 1" Value="1" />
                <ext:ListItem Text="Item 2" Value="2" />
                <ext:ListItem Text="Item 3" Value="3" />
                <ext:ListItem Text="Item 4" Value="4" />
                <ext:ListItem Text="Item 5" Value="5" />
            </Items>
            
            <Listeners>
                <BeforeSelect Handler="return (this.checkedRecords.indexOf(record) >= 0) || (this.checkedRecords.length == 0);" />
            </Listeners>
        </ext:MultiCombo>
    </form>
</body>
</html>

