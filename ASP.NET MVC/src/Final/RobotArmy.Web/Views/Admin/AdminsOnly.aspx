<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<String>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdminsOnly
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admins Only!</h2>
    Welcome, <%= Html.Encode(Model) %>
</asp:Content>
