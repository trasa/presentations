<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Json.aspx.cs" Inherits="Json" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to use the ASP.NET 2.0 AJAX Extensions' JavaScriptSerializer to serialize objects using JSON, and how JSON serialization differs from XML serialization
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <b>Object:</b><br />
     Point(100, 200)
    <br /><br />
    <b>JSON representation:</b><br />
    <asp:Label ID="JsonOutput" runat="server" />
    <br /><br />
    <b>XML representation:</b><br />
    <asp:Label ID="XmlOutput" runat="server" />

    <script type="text/javascript">
/*
    function pageLoad()
    {
        var point = Sys.Serialization.JavaScriptSerializer.deserialize('{"IsEmpty":false,"X":100,"Y":200}');
        window.alert(point.X + ', ' + point.Y);
    }
*/
    </script>
</asp:Content>