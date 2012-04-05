<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaunchSites.aspx.cs" Inherits="MissileCommand.Web.LaunchSites" MasterPageFile="~/Missile.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadCrumbContent" ID="breadCrumb">
    You are here : <a href="default.aspx">Home</a> &middot; Launch Sites
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <h2>Create a new Site</h2>
    <table>
        <tr>
            <td>Site Name:</td>
            <td><asp:TextBox runat="server" ID="txtName" /><asp:RequiredFieldValidator runat="server" ID="rfName" ControlToValidate="txtName" Text="*" ErrorMessage="Name is required." /></td>
        </tr>
        <tr>
            <td>Max Altitude:</td>
            <td><asp:TextBox runat="server" ID="txtAltitude" /><asp:RequiredFieldValidator runat="server" ID="rfAltitude" ControlToValidate="txtAltitude" Text="*" ErrorMessage="Altitude is required." /><asp:CustomValidator runat="server" id="cvAltitude" ControlToValidate="txtAltitude" Text="*" ErrorMessage="Altitude must be a positive number." OnServerValidate="cvAltitude_ServerValidate" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CausesValidation="true" />
                <asp:ValidationSummary runat="server" ID="valsum" />
            </td>
        </tr>
    </table>
</asp:Content>