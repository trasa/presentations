<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<RobotArmy.Core.Model.Robot>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                IsPsychotic
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
            
                <%= Html.ActionLink<RobotController>("Edit", c => c.Edit(0), new { id = item.Id }) %> |
                <%= Html.ActionLink<RobotController>("Details", c => c.Details(0), new { id = item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.IsPsychotic) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink<RobotController>("Create New", c => c.Create()) %>
    </p>

</asp:Content>

