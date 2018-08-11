<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="colores.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.colores" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>ProgressBar UI Styles - Ext.NET Examples</title>

    <script type="text/javascript">
        var runProgressbar = function (bar) {
            bar.wait({
                interval: 500,
                duration: 50000,
                increment: 15,
                text: 'Updating...',
                scope: bar,
                fn: function () {
                    this.updateText('Done!');
                }
            });
        };
    </script>
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


        <h3>ProgressBar UI</h3>

        <ext:ProgressBar ID="ProgressBar1" runat="server" Width="300" UI="Primary">
            <Listeners>
                <AfterRender Fn="runProgressbar" />
            </Listeners>
        </ext:ProgressBar>
        <br />

        <ext:ProgressBar ID="ProgressBar2" runat="server" Width="300" UI="Success">
            <Listeners>
                <AfterRender Fn="runProgressbar" />
            </Listeners>
        </ext:ProgressBar>
        <br />

        <ext:ProgressBar ID="ProgressBar3" runat="server" Width="300" UI="Info">
            <Listeners>
                <AfterRender Fn="runProgressbar" />
            </Listeners>
        </ext:ProgressBar>
        <br />

        <ext:ProgressBar ID="ProgressBar4" runat="server" Width="300" UI="Danger">
            <Listeners>
                <AfterRender Fn="runProgressbar" />
            </Listeners>
        </ext:ProgressBar>
        <br />

        <ext:ProgressBar ID="ProgressBar5" runat="server" Width="300" UI="Warning">
            <Listeners>
                <AfterRender Fn="runProgressbar" />
            </Listeners>
        </ext:ProgressBar>
        <br />
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
