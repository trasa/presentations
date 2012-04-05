<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Timer2.aspx.cs" Inherits="Timer2" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses XML script to program a Timer object to display a message box every 5 seconds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <script type="text/javascript">
    function onTick()
    {
        window.alert('Isn\'t this annoying?');
    }
    </script>

    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <components>
                <timer enabled="true" interval="5000" tick="onTick" />
            </components>
        </page>
    </script>
</asp:Content>