<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Satellites.aspx.cs" Inherits="MissileCommand.Web.Satellites" MasterPageFile="~/Missile.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadCrumbContent" ID="breadCrumb">
    You are here : <a href="default.aspx">Home</a> &middot; Satellites
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <h2>Launch a new Satellite</h2>
    <table>
        <tr>
            <td>Satellite Name:</td>
            <td><asp:TextBox runat="server" ID="txtSatName" /><asp:RequiredFieldValidator runat="server" ID="rfSatName" ControlToValidate="txtSatName" Text="*" ErrorMessage="Name is required." /></td>
        </tr>
        <tr>
            <td>Orbital Altitude:</td>
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