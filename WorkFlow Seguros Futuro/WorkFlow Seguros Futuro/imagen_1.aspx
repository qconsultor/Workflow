<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imagen_1.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.imagen_1" %>

<!DOCTYPE html>


  
<script runat="server"> 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
        }
    }
    
   
</script> 
<script type="text/javascript">
    var newWindow = function (config, url, id) {
        var renderToObject;
        var window;

        renderToObject = this;
        body = renderToObject.Ext.getBody();
        window = renderToObject.Ext.getCmp(id);
        if (window != null)
            window.close();
        new renderToObject.Ext.Window(renderToObject.Ext.apply({
            renderTo: renderToObject.Ext.getBody(),
            resizable: true,
            height: 500,
            width: 500,
            frame: true,
            padding: 5,
            id: id,
            autoLoad: { maskMsg: "Laddar...", showMask: true, mode: "iframe", url: url }
        }, config)).show();
    }
</script>
  
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head id="Head1" runat="server"> 
    <title>Ext.Net Example</title> 
</head> 
<body> 
     
      <form id="Form2" runat="server"> 
    <ext:ResourceManager ID="ResourceManager1" runat="server" /> 
        <ext:Button runat="server" Text="Open window" ID="btnOpen"><Listeners><Click Handler="newWindow({title: 'Window', height: 380, width: 760, minHeight: 380, minWidth: 760, modal: true}, '', 'window2');" /></Listeners></ext:Button>
        <ext:Panel ID="Panel1" runat="server" Height="400" Width="300"> <Loader ID="Loader1"  runat="server"  Url="../files/318i TwinPower Turbo Luxury (1).pdf" Mode="Frame"> </Loader> </ext:Panel>
        
        
        
    </form>   
        

</body> 
</html>
