<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DragOverlay.aspx.cs" Inherits="DragOverlay" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses a DragOverlayExtender to allow users to reposition a content panel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Panel ID="SearchPanel" BackColor="White" BorderStyle="Solid" BorderWidth="1px" Width="290px" runat="server">
        <asp:DragOverlayExtender ID="DragOverLayExtender1" TargetControlID="SearchPanel" Enabled="true" Runat="server" />
        <table cellpadding="4">
            <tr>
                <td><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Goggle_Logo.gif" /></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="190px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Search" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse pulvinar tortor ut lorem. Vestibulum vel ante at dui sodales condimentum. Aenean in nisi. Fusce aliquam, tortor sed bibendum tempor, nulla felis nonummy elit, sed ultrices diam purus et sapien. Maecenas ut eros nec arcu tristique nonummy. Nullam nonummy erat quis velit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Integer arcu dolor, commodo quis, lacinia vitae, consequat id, felis. Aliquam ullamcorper orci id nisi. Etiam fringilla urna. Phasellus molestie blandit nibh. Etiam placerat, odio eu euismod consectetuer, dui lorem rutrum mauris, semper imperdiet dolor quam vitae quam. Phasellus justo nulla, pharetra et, sodales vel, varius ac, tellus. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam euismod, lacus quis adipiscing viverra, neque lacus congue dui, nec venenatis nibh dui ut dolor. Fusce et sem. Aliquam erat volutpat. Maecenas nec turpis.</p>
    <p>Proin vel massa. Aenean eu dolor eu urna lacinia faucibus. Nunc diam felis, sagittis vel, commodo et, elementum ut, pede. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam felis ante, eleifend eget, gravida at, aliquet eu, arcu. Curabitur in neque vel magna viverra adipiscing. Mauris congue ipsum eget metus. Morbi ornare. Integer ligula. Fusce pharetra sem ut est. Phasellus quam tellus, gravida at, luctus vitae, ornare nec, elit. In sed ligula. Praesent rutrum tempus nibh. Nulla at ante eu risus vulputate consequat. Sed adipiscing tincidunt dui. Ut vulputate viverra neque. Aenean eu felis.</p>
    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec arcu massa, porttitor nec, fringilla et, posuere in, dui. Donec tristique. Maecenas neque dui, dignissim eu, dictum ut, tincidunt et, arcu. Nullam felis. Aliquam turpis magna, lobortis at, gravida in, dignissim ut, nisi. In eleifend. Morbi consequat, leo in mollis fermentum, risus mi adipiscing erat, at volutpat tortor quam vel lacus. Duis gravida ullamcorper odio. Suspendisse porta feugiat erat.</p>
    <p>Maecenas facilisis convallis diam. Nam nibh urna, porttitor quis, viverra suscipit, hendrerit at, odio. Mauris volutpat. Fusce metus. Fusce nonummy blandit tellus. Sed blandit arcu in libero. Nulla dapibus leo eget est. Fusce pretium. Proin sollicitudin. Nulla facilisi. Ut aliquam neque sit amet magna. In hac habitasse platea dictumst. Curabitur non enim. Donec elementum. Ut ornare turpis sed felis. Nulla volutpat. Praesent cursus lacinia magna. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Etiam aliquet.</p>
    <p>Cras a nisl. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam sed mi vel mi nonummy ullamcorper. Quisque vitae odio. Curabitur quis tellus sed erat pellentesque aliquam. Quisque sit amet diam eu odio pharetra porta. Etiam sodales hendrerit arcu. Suspendisse sollicitudin laoreet nisi. Nulla vitae nisl. Suspendisse ultrices hendrerit nibh. Donec ac ipsum. Sed consectetuer malesuada nisl. Integer consectetuer rutrum lorem.</p>
</asp:Content>