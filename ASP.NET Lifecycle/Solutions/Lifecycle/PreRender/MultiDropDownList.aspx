<%@ Page language="c#" Codebehind="MultiDropDownList.aspx.cs" AutoEventWireup="false" Inherits="Lifecycle.MultiDropDownList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>MultiDropDownList</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
			<asp:DropDownList Runat="server" ID="ddlTop" OnSelectedIndexChanged="ddlTop_SelectedIndexChanged">
				<asp:ListItem Value="0">0 - top</asp:ListItem>
				<asp:ListItem Value="1">1 - top</asp:ListItem>
				<asp:ListItem Value="2">2 - top</asp:ListItem>
			</asp:DropDownList>
			
			<br>
			
			<asp:DropDownList Runat="server" ID="ddlMid" OnSelectedIndexChanged="ddlMid_SelectedIndexChanged">
				<asp:ListItem Value="0">0 - mid</asp:ListItem>
				<asp:ListItem Value="1">1 - mid</asp:ListItem>
				<asp:ListItem Value="2">2 - mid</asp:ListItem>
			</asp:DropDownList>
			
			<br>
			
			<asp:DropDownList Runat="server" ID="ddlBottom" OnSelectedIndexChanged="ddlBottom_SelectedIndexChanged">
				<asp:ListItem Value="0">0 - bot</asp:ListItem>
				<asp:ListItem Value="1">1 - bot</asp:ListItem>
				<asp:ListItem Value="2">2 - bot</asp:ListItem>
			</asp:DropDownList>
			
			<br>
			
			<asp:Button Runat="server" ID="cmdSubmit" Text="Do Something Complicated" />
			
			<br>
			
			<asp:Label Runat="server" ID="lblComplicatedResults" />
     </form>
  </body>
</html>
