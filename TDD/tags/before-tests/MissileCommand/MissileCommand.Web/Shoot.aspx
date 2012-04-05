<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shoot.aspx.cs" Inherits="MissileCommand.Web.Shoot" MasterPageFile="~/Missile.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadCrumbContent" ID="breadCrumb">
    You are here : <a href="default.aspx">Home</a> &middot; Shoot
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    <h2>Shoot Something</h2>
    The Satellite you wanna blast:<br />
    Named "<asp:Label runat="server" ID="lblSatName" />", altitude <asp:Label runat="server" ID="lblSatAlt" /> km, velocity <asp:Label runat="server" ID="lblSatVel" /> km/s<br />
    Possible Sites that could work:
    <table class="list" border="1">
        <thead>
            <tr><td>Id</td><td>Name</td><td>Max Altitude (km)</td><td>&nbsp;</td></tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptLaunchers" OnItemCommand="rptLaunchers_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("MaxAltitude") %></td>
                        <td><asp:Button runat="server" ID="btnFire" Text="Fire" CommandArgument='<%# Eval("Id") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:Label runat="server" ID="lblLaunchNotification" Text="Missile Launched!" Visible="false" ForeColor="red" />
</asp:Content>