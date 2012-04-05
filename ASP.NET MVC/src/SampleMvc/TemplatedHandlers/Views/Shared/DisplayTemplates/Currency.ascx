<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
  <%= Html.Encode(String.Format("{0:C}", Model)) %>

