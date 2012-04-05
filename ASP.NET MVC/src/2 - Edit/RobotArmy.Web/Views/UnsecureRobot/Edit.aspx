<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RobotArmy.Core.Model.Robot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
    
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.Encode(Model.Id) %>
                <%= Html.Hidden("robot.Id", Model.Id) %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("robot.Name", Model.Name) %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink<RobotController>("Back to List", c => c.List()) %>
    </div>

</asp:Content>

