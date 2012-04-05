<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dry._Default" MasterPageFile="~/Master/Blueish.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="CenterContent">
    <h3>Stuff To Do:</h3>
    <div style="padding-bottom:1em">
        <asp:CheckBox runat="server" ID="chkReadOnly" Text="Read Only?" />
    </div>
    <div style="padding-bottom:1em">
        Id to retrieve: <asp:TextBox runat="server" ID="txtId" Text="1" />
    </div>
    <ul>
        <li><asp:LinkButton runat="server" ID="btnAgent" OnClick="btnAgent_Click" Text="Agent Contacts" /></li>
        <li><asp:LinkButton runat="server" ID="btnClient" OnClick="btnClient_Click" Text="Client Contacts" /></li>
    </ul>
</asp:Content>