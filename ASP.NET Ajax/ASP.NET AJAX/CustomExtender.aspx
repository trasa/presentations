<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomExtender.aspx.cs" Inherits="CustomExtender" Title="ASP.NET AJAX" %>
<%@ Register Assembly="DropDownListWatermark" Namespace="DropDownListWatermark" TagPrefix="win" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses a custom extender, DropDownListWatermarkExtender, to add a watermark to a drop-down list
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:DropDownList ID="Days" runat="server">
        <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
        <asp:ListItem Value="Monday">Monday</asp:ListItem>
        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
        <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
        <asp:ListItem Value="Friday">Friday</asp:ListItem>
        <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
    </asp:DropDownList>

    <win:DropDownListWatermarkExtender ID="DropDownListWatermarkExtender1"
        TargetControlID="Days" WatermarkText="Select one" Runat="server" />

    <asp:Button ID="SubmitButton" Text="Submit" runat="server" />
</asp:Content>