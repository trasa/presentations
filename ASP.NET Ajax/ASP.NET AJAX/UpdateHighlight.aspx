<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpdateHighlight.aspx.cs" Inherits="UpdateHighlight" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to highlight content updated by UpdatePanel controls using PageRequestManager's pageLoaded events
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
    prm.add_pageLoaded(pageLoaded);

    var _panels, _count;

    function pageLoaded(sender, args)
    {
        if (_panels != undefined && _panels.length > 0)
        {
            for (i=0; i < _panels.length; i++)
                _panels[i].dispose();
        }

        var panels = args.get_panelsUpdated();

        if (panels.length > 0)
        {
            _panels = new Array(panels.length);

            for (i=0; i < panels.length; i++) 
                _panels[i] = new Sys.UI.Control(panels[i]);

            flashPanels(3);
        }
    }

    function flashPanels(count)
    {
        _count = (count << 1) + 1;
        
        for (i=0; i < _panels.length; i++) 
            _panels[i].set_visible(false);

        window.setTimeout(toggleVisibility, 50);
    }

    function toggleVisibility()
    {
        for (i=0; i < _panels.length; i++) 
            _panels[i].set_visible(!_panels[i].get_visible());
        
        if (--_count > 0)
            window.setTimeout(toggleVisibility, 50);
    }
    </script>
</asp:Content>