<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.AntiForgeryToken() %>
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("robot.Name") %>
            </p>
            <p>
                <label for="IsPsychotic">Is Psycho?</label>
                <%= Html.CheckBox("robot.IsPsychotic") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>
