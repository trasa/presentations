<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Debugging.aspx.cs" Inherits="Debugging" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to do tracing and asserting using the Microsoft AJAX Library
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">

<h3>Trace Console (&lt;textarea id="TraceConsole"&gt;)</h3>
    <textarea id="TraceConsole" style="width: 512px; height: 300px; background-color: lightyellow">
    </textarea>

    <br /><br />
    <input type="button" value="Sys.Debug.trace" onclick="onTrace();" style="width: 192px" />
    <br /><br />
    <input type="button" value="Sys.Debug.traceDump" onclick="onTraceDump();" style="width: 192px" />
    <br /><br />
    <input type="button" value="Sys.Debug.assert" onclick="onAssert();" style="width: 192px" />

    <script type="text/javascript">
    var _console;

    function pageLoad()
    {
        _console = new Sys.UI.Control($get('TraceConsole'));
    }

    function onTrace()
    {
        Sys.Debug.clearTrace();
        Sys.Debug.trace('Hello from ASP.NET AJAX!');
    }

    function onTraceDump()
    {
        Sys.Debug.clearTrace();
        Sys.Debug.traceDump(_console, '');
    }

    function onAssert()
    {
        var happy = false;
        Sys.Debug.assert(happy == true, 'Somebody is NOT happy!', false);
    }
    </script>

</asp:Content>