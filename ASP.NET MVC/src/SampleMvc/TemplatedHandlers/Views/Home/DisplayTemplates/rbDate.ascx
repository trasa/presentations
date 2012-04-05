<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<span style="font-weight:bold;color:red;">
<%= Html.Encode(String.Format("{0:d}", Model)) %>
</span>


