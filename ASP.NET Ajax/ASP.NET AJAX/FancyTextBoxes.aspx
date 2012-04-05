<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FancyTextBoxes.aspx.cs" Inherits="FancyTextBoxes" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This pages uses FilteredTextBoxExtenders, TextBoxWatermarkExtenders, and ValidatorCalloutExtenders to dress up TextBoxes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <table cellpadding="8" cellspacing="0">
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="Name" runat="server" /></td>
        </tr>
        <tr>
            <td>E-Mail</td>
            <td>
                <asp:TextBox ID="EMail" runat="server" />
                <ajaxToolkit:TextBoxWatermarkExtender ID="EMailWatermarkExtender" TargetControlID="EMail" WatermarkText="e.g. foo@bar.com" WatermarkCssClass="watermark" runat="server" />
                <asp:RegularExpressionValidator ID="EMailValidator" ControlToValidate="EMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None" runat="server"
                    ErrorMessage="<b>Invalid E-Mail Address</b><br /><br />Please enter an e-mail address in the proper format (e.g., foo@bar.com)" />
                <ajaxToolkit:ValidatorCalloutExtender ID="EMailValidatorExtender" TargetControlID="EMailValidator" HighlightCssClass="highlight" Width="240px" runat="Server" />
            </td>
        </tr>
        <tr>
            <td>Zip</td>
            <td>
                <asp:TextBox ID="ZipCode" runat="server" />
                <ajaxToolkit:TextBoxWatermarkExtender ID="ZipCodeWatermarkExtender" TargetControlID="ZipCode" WatermarkText="e.g. 12345" WatermarkCssClass="watermark" runat="server" />
                <ajaxToolkit:FilteredTextBoxExtender ID="ZipCodeFilter" TargetControlID="ZipCode" FilterType="Numbers" runat="server" />
                <asp:RegularExpressionValidator ID="ZipCodeValidator" ControlToValidate="ZipCode" ValidationExpression="^\d{5}$" Display="None" runat="server"
                    ErrorMessage="<b>Invalid Zip Code</b><br /><br />Please enter a zip code in the format xxxxx (e.g., 12345)" />
                <ajaxToolkit:ValidatorCalloutExtender ID="ZipCodeValidatorExtender" TargetControlID="ZipCodeValidator" HighlightCssClass="highlight" runat="Server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="SubmitButton" Text="Submit" runat="server" /></td>
        </tr>
    </table>
</asp:Content>