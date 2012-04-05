<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentContacts.aspx.cs" Inherits="Dry.AgentContacts" MasterPageFile="~/Master/Blueish.Master" %>
<%@ Register TagPrefix="dry" TagName="AddressInfo" Src="~/AddressInfo.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="CenterContent">
    Add New Agent Contact
    <!-- contact name -->
    <table cellpadding="0" cellspacing="10" class="formTable">
		<tr>
			<th>
				First Name:
			</th>
			<td><asp:TextBox ID="firstName" runat="server" Columns="30" MaxLength="50" /></td>
			
			<th>Middle Name:</th>
			<td><asp:TextBox ID="middleName" runat="server" Columns="30" MaxLength="50" /></td>
		</tr>
		<tr>
			<th>
				Last Name: 
			</th>
			<td><asp:TextBox ID="lastName" runat="server" Columns="30" MaxLength="50" /></td>
			
			<th>Title:</th>
			<td><asp:TextBox ID="title" runat="server" Columns="30" MaxLength="50" /></td>
		</tr>
		<tr>
			<th>Notes: </th>
			<td colspan="3">
				<asp:TextBox ID="notes" runat="server" TextMode="MultiLine" Rows="3" MaxLength="500" Width="100%" />
			</td>
		</tr>
	</table>
	
    <h3 style="padding:20px 0 0;">Addresses</h3>
    <table cellpadding="0" cellspacing="0" width="100%">
	    <tr>
		    <td><dry:AddressInfo id="address1" runat="server" /></td>
		    <td><dry:AddressInfo id="address2" runat="server" /></td>
		    <td><dry:AddressInfo id="address3" runat="server" /></td>
	    </tr>
    </table>

    <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" />
</asp:Content>