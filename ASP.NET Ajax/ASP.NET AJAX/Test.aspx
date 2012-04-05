<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server">
            <Scripts>
                <asp:ScriptReference Name="PreviewDragDrop.js" Assembly="Microsoft.Web.Preview" />
                <asp:ScriptReference Name="PreviewGlitz.js" Assembly="Microsoft.Web.Preview" />
            </Scripts>
        </asp:ScriptManager>
    </div>
    </form>
</body>
</html>
