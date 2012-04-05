<%@ Page language="c#" Codebehind="MultiDropDownListNoEvent.aspx.cs" AutoEventWireup="false" Inherits="Lifecycle.MultiDropDownListNoEvent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>MultiDropDownList - No Events</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
			<asp:DropDownList Runat="server" ID="ddlTop" />
			<br>
			<asp:DropDownList Runat="server" ID="ddlMid" />
			<br>
			<asp:DropDownList Runat="server" ID="ddlBottom" />
			<br>
			<asp:Button Runat="server" ID="cmdSubmit" Text="Do Something Complicated" />
			<br>
			<asp:Label Runat="server" ID="lblComplicatedResults" />
     </form>
  </body>
</html>