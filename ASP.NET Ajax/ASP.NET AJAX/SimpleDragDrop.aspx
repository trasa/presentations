<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleDragDrop.aspx.cs" Inherits="SimpleDragDrop" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses a FloatingBehavior to allow an image to be dragged and dropped
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Name="PreviewDragDrop.js" Assembly="Microsoft.Web.Preview" />
        </Scripts>
    </asp:ScriptManagerProxy>

    <img id="Picture" src="Images/Mona.jpg" />
    
    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <components>
                <image id="Picture">
                    <behaviors>
                        <floatingBehavior handle="Picture" />
                        <clickBehavior>
                            <click>
                                <setPropertyAction target="Picture" property="imageURL" value="Images/Lisa.jpg" />
                            </click>
                        </clickBehavior>
                    </behaviors>
                </image>
            </components>
        </page>
    </script>
</asp:Content>