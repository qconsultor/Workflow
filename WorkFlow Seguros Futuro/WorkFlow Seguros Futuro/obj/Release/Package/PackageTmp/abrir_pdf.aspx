<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abrir_pdf.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.abrir_pdf" %>

<!DOCTYPE html>

  <form id="form1" runat="server">
    <div>
    <div>
      <asp:RadioButton id="disco" runat="server" GroupName="guardar"
	    Checked="true" Text="Guardar imagen en disco"/>
      <asp:RadioButton id="bd" runat="server" GroupName="guardar"
	    Text="Guardar imagen en base de datos"/>
    </div>
    <p>
      <asp:Label AssociatedControlId="fileUploader1" runat="server"
	    Text="Seleccionar una imagen:" />
      <asp:FileUpload id="fileUploader1" runat="server" />
    </p>
    <asp:Button id="cargarImagen" runat="server"
	  Text="Cargar imágenes" OnClick="cargarImagen_Click"/>
    </div>
  </form>
