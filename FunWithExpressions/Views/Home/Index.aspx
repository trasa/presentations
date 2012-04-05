<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Magic Strings are Evil</h2>
    <p>
        <%= Html.ActionLink<HomeController>(c => c.FavoriteNumber(16), "A Number") %>
        <%= Html.ActionLink<HomeController>(c => c.FavoriteNumber(32), "Another Number") %>
        <%= Html.ActionLink<HomeController>(c => c.FavoriteNumber(42), "Yet Another Number") %>        
    </p>
</asp:Content>

