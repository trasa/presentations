<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MissileCommand.Web._Default" MasterPageFile="~/Missile.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
<h2>Satellites we are tracking</h2>
<table class="list" border="1">
    <thead>
        <tr><td width="7%">Id</td><td>Name</td><td>Altitude (km)</td><td>Velocity (km/s)</td><td>&nbsp;</td></tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Altitude") %></td>
                    <td><%# Eval("OrbitalVelocity", "{0:0.000}") %></td>
                    <td><a href="Shoot.aspx?id=<%# Eval("Id") %>">Shoot it down</a></td></tr>
            </ItemTemplate>
        </asp:Repeater>
        
    </tbody>
</table>
</asp:Content>
