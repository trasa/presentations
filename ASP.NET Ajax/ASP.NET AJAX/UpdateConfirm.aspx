<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpdateConfirm.aspx.cs" Inherits="UpdateConfirm" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to use PageRequestManager's initializeRequest events to cancel UpdatePanel updates
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ScriptManagerProxy ID="UpdateHighlightScriptManagerProxy" runat="server">
        <Scripts>
            <asp:ScriptReference Name="PreviewGlitz.js" Assembly="Microsoft.Web.Preview" />
        </Scripts>
    </asp:ScriptManagerProxy>

    <asp:UpdatePanel ID="TestUpdatePanel" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Image ID="TestImage" ImageUrl="~/Images/Photos/tech_bindings_02.gif" Runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />
    <asp:Button ID="UpdateButton" Text="Update" OnClick="OnUpdateButtonClicked" runat="server" />

    <script type="text/javascript">

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_initializeRequest(initializeRequest);

    function initializeRequest(sender, args)
    {
        args.set_cancel(!confirm('Are you sure?'));
    }
    </script>
</asp:Content>