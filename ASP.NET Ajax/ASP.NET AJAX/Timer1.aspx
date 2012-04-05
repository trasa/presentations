<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Timer1.aspx.cs" Inherits="Timer1" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses JavaScript to program a Timer object to display a message box every 5 seconds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <script type="text/javascript">
    function pageLoad()
    {
        var timer = new Sys.Preview.Timer();
        timer.initialize();
        timer.set_enabled(true);
        timer.set_interval(5000); // 5 seconds
        timer.add_tick(onTick);
    }

    function onTick()
    {
        window.alert('Isn\'t this annoying?');
    }
    </script>
</asp:Content>