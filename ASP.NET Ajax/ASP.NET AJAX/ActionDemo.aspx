<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ActionDemo.aspx.cs" Inherits="ActionDemo" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses ClickBehavior and SetPropertyAction to hide an image when it's clicked
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <img id="ClickMe" src="Images/Mona.jpg">

    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <components>
                <image id="ClickMe">
                    <behaviors>
                        <clickBehavior>
                            <click>
                                <setPropertyAction target="ClickMe" property="visible" value="false" />
                            </click>
                        </clickBehavior>
                    </behaviors>
                </image>
            </components>
        </page>
    </script>
</asp:Content>