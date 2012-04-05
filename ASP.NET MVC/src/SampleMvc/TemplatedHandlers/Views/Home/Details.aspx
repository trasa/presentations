<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcTmpHlprs.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details using Html.DisplayFor(c =>Model)
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <table>
<tr>
 <td><b> 
 <%= Html.LabelFor(c =>Model.Name)%>  :</b></td><td>   <%= Html.DisplayFor(c =>Model.Name)%> 
</td><td><b> <%= Html.LabelFor(c =>Model.Color) %> :</b></td><td> <%= Html.DisplayFor(c =>Model.Color) %>
 </td> </tr> <tr> <td><b>
 
  <%= Html.LabelFor(c =>Model.Weight)%> :</b></td><td> <%= Html.DisplayFor(c =>Model.Weight)%>
</td><td><b>  <%= Html.LabelFor(c =>Model.ProductNumber)%> :</b> </td><td> <%= Html.DisplayFor(c =>Model.ProductNumber)%>
   </td> </tr> <tr> <td><b>
   
  <%= Html.LabelFor(c =>Model.StandardCost)%>:</b></td><td>  <%= Html.DisplayFor(c =>Model.StandardCost)%>
 </td><td><b> <%= Html.LabelFor(c =>Model.ListPrice)%>:</b></td><td>  <%= Html.DisplayFor(c =>Model.ListPrice, "gbCurrency")%>
   </td> </tr> <tr> <td><b>
   
  <%= Html.LabelFor(c =>Model.SellStartDate)%>:</b></td><td>   <%= Html.DisplayFor(c =>Model.SellStartDate,"rbDate")%>
 </td><td><b> <%= Html.LabelFor(c =>Model.SellEndDate)%> :</b></td><td>  <%= Html.DisplayFor(c =>Model.SellEndDate)%>
   </td> </tr> <tr> <td><b>
   
  <%= Html.LabelFor(Product => Model.DiscontinuedDate)%> :</b></td><td>  <%= Html.DisplayFor(Product => Model.DiscontinuedDate)%>
     </td><td><b>     
      </td> </tr> <tr> <td><b>
  <%-- <% Html.RenderPartial("ProdEditDetailsCtl"); %>--%>
  </table>       
</asp:Content>
