<%@ Page  language="c#" Codebehind="ControlTreeExample.aspx.cs" AutoEventWireup="false" Inherits="Lifecycle.ControlTreeExample" %>
<html>
<body>
<h1>Welcome to my Homepage!</h1>
<form id="Form1" method="post" runat="server">
	What is your name? <asp:Textbox Runat="server" ID="txtName" />
	What is your gender? <asp:DropDownList runat="server" ID="ddlGender">
		<asp:ListItem value="M" Selected>M</asp:ListItem>
		<asp:ListItem Value="F">F</asp:ListItem>
		<asp:ListItem Value="U">Unknown</asp:ListItem>
	</asp:DropDownList>
	<br/>
	<asp:Button Runat="server" Text="Submit!" />
</form>
</body>
</html>
