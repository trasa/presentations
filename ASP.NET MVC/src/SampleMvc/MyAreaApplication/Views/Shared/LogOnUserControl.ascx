<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
        // NOTE: Linking Between Areas accomplished by {area = "main"} routeValues object.
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>! 
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account", new { area = "main" }, null)%> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "LogOn", "Account", new { area = "main" }, null)%> ]
<%
    }
%>

