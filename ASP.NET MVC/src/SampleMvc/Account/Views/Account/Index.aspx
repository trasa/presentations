<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
<p><%= Html.ActionLink("Edit Billing", "EditBilling") %></p>
<p><%= Html.ActionLink("Edit Shipping", "EditShipping") %></p>


</asp:Content>
