<%@ Page trace="true" language="c#" Codebehind="InitChain.aspx.cs" AutoEventWireup="false" Inherits="Lifecycle.Init.InitChain" %>
<%@ Register TagPrefix="LC" TagName="InitControl" src="InitControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>InitChain</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
	
    <form id="Form1" method="post" runat="server">
		<LC:InitControl runat="server" id="ic" />
     </form>
	
  </body>
</html>
