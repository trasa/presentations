<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcTmpHlprs.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <p><%= Html.Encode(ViewData["EditError"])%>  
  
<%= Html.Encode(ViewData["EditError"])%>
    <h2>Edit 
     <%= Html.LabelFor(c =>Model.ProductID )%>  :  <%= Html.DisplayFor(c => Model.ProductID)%> </h2>
    <%= Html.EditorFor(Product=> Model)%> 
    
    
   <%-- Add links with ProdEditDetailsCtl --%>
<%--      <% Html.RenderPartial("ProdEditDetailsCtl"); %>--%>
</asp:Content>
