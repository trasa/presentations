<%@ Page trace="true" language="c#" Codebehind="Simple.aspx.cs" AutoEventWireup="false" Inherits="Lifecycle.Simple" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>Simple</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
		<asp:TextBox Runat="server" ID="txt" text="Default Value" OnTextChanged="txt_TextChanged" />
		
		<asp:DropDownList Runat="server" ID="ddl" OnSelectedIndexChanged="ddl_SelectedIndexChanged" >
			<asp:ListItem Value="0">Zero</asp:ListItem>
			<asp:ListItem Value="1">One</asp:ListItem>
			<asp:ListItem Value="2">Two</asp:ListItem>
			<asp:ListItem Value="3">Three</asp:ListItem>
		</asp:DropDownList>
		
		<asp:Button Runat="server" ID="cmdSubmit" Text="Submit" OnClick="cmdSubmit_Click" />
		<br><br>
		<br><br><br>
    </form>
  </body>
</html>
