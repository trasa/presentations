<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcTmpHlprs.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MVC Product Index Sample
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Index using  Html.DisplayFor</h2>
    <table><tr>
     <th>  </th>
            <th> Product ID </th>
            <th>Name</th>
            <th>Color</th>
            <th>Std. Cost</th>
            <th>List Price</th>
            <th>Size</th>
            <th>Weight</th>
            <th>Sell Starts  </th>
            <th>Sell Ends  </th>
            <th>Discontinued Date </th>        </tr>
  <% foreach (var item in Model) { %>    
<tr>
 <td>
<%= Html.ActionLink("Details", "Details", new { id=item.ProductID }) %> |
<%= Html.ActionLink("Edit", "Edit", new { id=item.ProductID })%>
    </td>
    <td> <%= Html.DisplayFor(c => item.ProductID) %> </td>
    <td> <%= Html.DisplayFor(c => item.Name)%> </td>
    <td> <%= Html.DisplayFor(c => item.Color) %></td>
    <td> <%= Html.DisplayFor(c => item.StandardCost)%> </td>
    <td> <%= Html.DisplayFor(c => item.ListPrice)%> </td>
    <td> <%= Html.DisplayFor(c => item.Size) %></td>
    <td> <%= Html.DisplayFor(c => item.Weight) %> </td>
    <td> <%= Html.DisplayFor(c => item.SellStartDate, 
             "Date") %> </td>
    <td> <%= Html.DisplayFor(c => item.SellEndDate) %></td>
    <td> <%= Html.DisplayFor(c => item.DiscontinuedDate)%></td>
</tr>
    
 <% } %>
    </table>
</asp:Content>
