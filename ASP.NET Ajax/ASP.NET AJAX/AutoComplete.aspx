<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoComplete.aspx.cs" Inherits="AutoComplete" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page uses an AutoCompleteExtender to decorate a TextBox with a drop-down completion list
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    Zip Code:&nbsp;<asp:TextBox ID="ZipCode" runat="server" />

    <ajaxToolkit:AutoCompleteExtender ID="ZipCodeAutoCompleteExtender" TargetControlID="ZipCode"
        ServicePath="ZipCodeService.asmx" ServiceMethod="GetMatchingZipCodes" MinimumPrefixLength="2"
        CompletionSetCount="20"
        runat="server" />
</asp:Content>