<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleDataBinding.aspx.cs" Inherits="SimpleDataBinding" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses simple data binding to bind a property of one control to a property of another
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <input type="checkbox" id="ShowDetails" checked="true" />Show details
    <br /><br />
    <div id="DetailsPanel" style="background-color: BlanchedAlmond; border-style: dotted">
        <table cellpadding="4">
            <tr>
                <td>
                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec pede. Curabitur volutpat. Cras cursus metus vel sapien. Aliquam justo. Proin aliquet, massa sit amet blandit rutrum, nibh est facilisis libero, vel interdum mauris purus pulvinar pede. Nulla vel purus. Aliquam a nunc. Phasellus fringilla tempus lacus. Aliquam erat volutpat. Sed faucibus interdum lorem. Cras suscipit erat nec metus. Aliquam erat volutpat. Duis et leo non elit accumsan convallis. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse potenti. Donec magna diam, aliquet faucibus, tempus eu, fermentum eu, nunc. Maecenas sit amet dui.
                </td>
            </tr>
        </table>
    </div>

    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <components>
                <checkBox id="ShowDetails" />
                <control id="DetailsPanel">
                    <bindings>
                        <binding dataContext="ShowDetails" dataPath="checked" property="visible" />
                    </bindings>
                </control>
            </components>
        </page>
    </script>
</asp:Content>