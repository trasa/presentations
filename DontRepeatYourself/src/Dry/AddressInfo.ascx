<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressInfo.ascx.cs" Inherits="Dry.AddressInfo" %>
<table cellpadding="0" cellspacing="10" class="formTable">
	<tr>
		<th>
			Type:
		</th>
		<td><asp:DropDownList ID="addressType" runat="server" DataValueField="Key" DataTextField="Value" /></td>
	</tr>	
	<tr>
		<th>
			Address 1:
		</th>
		<td><asp:TextBox ID="address1" runat="server" Columns="30" MaxLength="50" /></td>
	</tr>	
	<tr>
		<th>Address 2:</th>
		<td><asp:TextBox ID="address2" runat="server" Columns="30" MaxLength="50" /></td>
	</tr>
	<tr>
		<th>
			City:
		</th>
		<td><asp:TextBox ID="city" runat="server" Columns="30" MaxLength="50" /></td>
	</tr>	
	<tr>
		<th>
			State:
		</th>
		<td><asp:TextBox ID="state" runat="server" Columns="2" MaxLength="50" /></td>
	</tr>
	<tr>
		<th>
			Postal Code:
		</th>
		<td><asp:TextBox ID="postalCode" runat="server" Columns="10" MaxLength="50" /></td>
	</tr>
</table>