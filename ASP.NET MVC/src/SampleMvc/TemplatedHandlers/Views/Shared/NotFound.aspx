<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NotFound
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <%= Html.Encode(ViewData["BogusID"])%></h2>
    
<p>Bad ID(<b>  <%= Html.Encode(ViewData["BogusID"])%>  </b>)doesn't exist </br>
Perhaps it was deleted.</p>


</asp:Content>
