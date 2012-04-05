<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Controls2.aspx.cs" Inherits="Controls2" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses control classes and XML script to abstract HTML controls
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <input type="text" id="Input" />&nbsp;
    <input type="button" id="MyButton" value="Click Me" />&nbsp;
    <span id="Output" />
        
    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <components>
                <textBox id="Input" />
                <button id="MyButton">
                    <click>
                        <invokeMethodAction target="TextBinding" method="evaluateIn" />
                    </click>
                </button>
                <label id="Output">
                    <bindings>
                        <binding id="TextBinding" dataContext="Input"
                            dataPath="text" property="text" automatic="false" />
                    </bindings>
                </label>
            </components>
        </page>
    </script>
</asp:Content>