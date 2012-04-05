<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RobotArmy.Core.Model.Robot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            IsPsychotic:
            <%= Html.Encode(Model.IsPsychotic) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink<RobotController>("Edit", c => c.Edit(0), new { id = Model.Id }) %> |
        <%=Html.ActionLink<RobotController>("Back to List", c => c.List()) %>
    </p>

</asp:Content>

