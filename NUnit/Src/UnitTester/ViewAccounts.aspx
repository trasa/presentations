<%@ Page language="c#" Codebehind="ViewAccounts.aspx.cs" AutoEventWireup="false" Inherits="UnitTester.Web.ViewAccounts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>ViewAccounts</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
		<asp:DataGrid Runat="server" ID="grdAccounts" AutoGenerateColumns="False">
			<AlternatingItemStyle BackColor="#99cc99" />
			<Columns>
				<asp:TemplateColumn>
					<HeaderTemplate>Account ID</HeaderTemplate>
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem, "ID") %>
					</ItemTemplate>
				</asp:TemplateColumn>
				
				<asp:TemplateColumn>
					<HeaderTemplate>Name</HeaderTemplate>
					<ItemTemplate>
						<%# DataBinder.Eval(Container.DataItem, "Name") %>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn>
					<HeaderTemplate>Current Balance</HeaderTemplate>
					<ItemStyle HorizontalAlign="Right"/>
					<ItemTemplate>
						<%# ((Decimal)DataBinder.Eval(Container.DataItem, "Balance")).ToString("c") %>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
		</asp:DataGrid>
		<br><br>
		<table border="1">
			<tr><td colspan="2" align="center">New Account</td></tr>
			<tr>
				<td>Name:</td>
				<td>
					<asp:TextBox Runat="server" ID="txtName" />
					
				</td>
			</tr>
			<tr>
				<td>Starting Balance:</td>
				<td>
					<asp:TextBox Runat="server" ID="txtBalance" />
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center"><asp:Button Runat="server" ID="btnCreate" OnClick="btnCreate_Click" Text="Save" /></td>
			</tr>
		</table>
		<asp:RequiredFieldValidator Runat="server" ID="reqvalName" ControlToValidate="txtName" Display="Dynamic">
You must enter a name.
</asp:RequiredFieldValidator>
<asp:CompareValidator Runat="server" ID="cmpvalBalance" ControlToValidate="txtBalance" Type="Currency" Operator="DataTypeCheck" Display="Dynamic">
	Balance must be a valid number.
</asp:CompareValidator>
<asp:RequiredFieldValidator Runat="server" ID="reqvalBalance" ControlToValidate="txtBalance" Display="Dynamic">
	You must enter a balance.
</asp:RequiredFieldValidator>
    </form>	
  </body>
</html>
