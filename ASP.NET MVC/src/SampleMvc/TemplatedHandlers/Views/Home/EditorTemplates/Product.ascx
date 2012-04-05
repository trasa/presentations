<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcTmpHlprs.Models.Product>" %>
<h1> Using Product template</h1>
<% using (Html.BeginForm()) { %>
    <fieldset>
<div><%= Html.LabelFor(c => Model.Name)%> 
    <%= Html.EditorFor(c => Model.Name)%>
    <%= Html.ValidationMessage("Name", "*") %>
</div><div>
    <%= Html.LabelFor(c => Model.Color) %>
    <%= Html.EditorFor(c => Model.Color) %>
    <%= Html.ValidationMessage("Color", "*") %>
</div><div>
   <%= Html.LabelFor(c => Model.StandardCost)%>
 <%= Html.EditorFor(c => Model.StandardCost)%>
 <%= Html.ValidationMessage("StandardCost", "*")%>
 </div><div>
 </div><div>
   <%= Html.LabelFor(c => Model.ListPrice)%>
 <%= Html.EditorFor(c => Model.ListPrice)%>
 <%= Html.ValidationMessage("ListPrice", "*")%>
 </div><div>
 
 <div><%= Html.LabelFor(c => Model.Size)%></div><div>
    <%= Html.EditorFor(c => Model.Size)%>
    <%= Html.ValidationMessage("Size", "*") %>
</div>
<div><%= Html.LabelFor(c => Model.Weight)%></div><div>
    <%= Html.EditorFor(c => Model.Weight)%>
    <%= Html.ValidationMessage("Weight", "*") %>
</div>

 <div><%= Html.LabelFor(c => Model.SellStartDate)%></div>
 <div><%= Html.EditorFor(c => Model.SellStartDate)%></div>
 <%= Html.ValidationMessage("SellStartDate", "*") %>
 
   <div><%= Html.LabelFor(c => Model.SellEndDate)%></div><div>
    <%= Html.EditorFor(c => Model.SellEndDate)%>
    <%= Html.ValidationMessage("SellEndDate", "*")%>
</div>

 <div><%= Html.LabelFor(c => Model.DiscontinuedDate)%></div><div>
    <%= Html.EditorFor(c => Model.DiscontinuedDate)%>
    <%= Html.ValidationMessage("Discontinued Date", "*")%>
</div>




  <p> <input type="submit" value="Save"/> </p>
    </fieldset>
    
<%--    Remove comment from ProductID to test error handling.
    ProductID is a PK and cannot be updated.
    <%= Html.Hidden("ProductID", Model.ProductID)%>
    
    --%>
    
<% } %>