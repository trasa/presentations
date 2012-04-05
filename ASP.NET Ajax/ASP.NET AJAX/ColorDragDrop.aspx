<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ColorDragDrop.aspx.cs" Inherits="ColorDragDrop" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to use DragDropManager to implement rich drag-drop scenarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Name="PreviewDragDrop.js" Assembly="Microsoft.Web.Preview" />
            <asp:ScriptReference Path="~/Scripts/ColorDragDrop.js" />
        </Scripts>
    </asp:ScriptManagerProxy>

    <fieldset>
        <legend>Pick a Color</legend>
        <table cellpadding="8">
            <tr>
                <!-- Drag sources -->
                <td><div id="RedDragSource" style="width: 32px; height: 32px; background-color: red" /></td>
                <td><div id="YellowDragSource" style="width: 32px; height: 32px; background-color: yellow" /></td>
                <td><div id="GreenDragSource" style="width: 32px; height: 32px; background-color: green" /></td>
                <td><div id="MagentaDragSource" style="width: 32px; height: 32px; background-color: magenta" /></td>
                <td><div id="BlueDragSource" style="width: 32px; height: 32px; background-color: blue" /></td>
            </tr>
        </table>
    </fieldset>

    <div style="width: 100%; height: 128px">&nbsp;</div>

    <fieldset>
        <legend>Drop It Here</legend>
        <!-- Drop target -->
        <div id="DropTarget" style="width: 100%; height: 196px">&nbsp;</div>
    </fieldset>

    <script type="text/javascript">
    function pageLoad()
    {
        //
        // Make the "DragSource" DIVs drag sources.
        //
        var source1 = new Custom.UI.ColorDragSourceBehavior ($get('RedDragSource'), 'red');
        var source2 = new Custom.UI.ColorDragSourceBehavior ($get('YellowDragSource'), 'yellow');
        var source3 = new Custom.UI.ColorDragSourceBehavior ($get('GreenDragSource'), 'green');
        var source4 = new Custom.UI.ColorDragSourceBehavior ($get('MagentaDragSource'), 'magenta');
        var source5 = new Custom.UI.ColorDragSourceBehavior ($get('BlueDragSource'), 'blue');

        source1.initialize();
        source2.initialize();
        source3.initialize();
        source4.initialize();
        source5.initialize();

        //
        // Make the "DropTarget" DIV a drop target.
        //
        var target = new Custom.UI.ColorDropTargetBehavior ($get('DropTarget'));
        target.initialize();
    }
    </script>
</asp:Content>