<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Controls1.aspx.cs" Inherits="Controls1" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses control classes and JavaScript to abstract HTML controls
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <input type="text" id="Input" />&nbsp;
    <input type="button" id="MyButton" value="Click Me" />&nbsp;
    <span id="Output" />

    <script type="text/javascript">
    var g_textBox;
    var g_label;

    function pageLoad() 
    {
        g_textBox = new Sys.Preview.UI.TextBox($get('Input'));
        var button = new Sys.Preview.UI.Button($get('MyButton'));
        g_label = new Sys.Preview.UI.Label($get('Output'));
        button.initialize();
        button.add_click(onClick);
    }

    function onClick()
    {
        g_label.set_text(g_textBox.get_text());
    }
    </script>
</asp:Content>