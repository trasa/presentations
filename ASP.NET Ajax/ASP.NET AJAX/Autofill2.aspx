<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Autofill2.aspx.cs" Inherits="Autofill2" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to build and consume page methods
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    City:<br />
    <asp:TextBox ID="City" runat="server" />
    <br /><br />
    State:<br />
    <asp:DropDownList ID="Region" runat="server">
        <asp:ListItem Value="AL">Alabama</asp:ListItem>
        <asp:ListItem Value="AK">Alaska</asp:ListItem>
        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
        <asp:ListItem Value="CA">California</asp:ListItem>
        <asp:ListItem Value="CO">Colorado</asp:ListItem>
        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
        <asp:ListItem Value="DE">Delaware</asp:ListItem>
        <asp:ListItem Value="DC">District Of Columbia</asp:ListItem>
        <asp:ListItem Value="FL">Florida</asp:ListItem>
        <asp:ListItem Value="GA">Georgia</asp:ListItem>
        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
        <asp:ListItem Value="ID">Idaho</asp:ListItem>
        <asp:ListItem Value="IL">Illinois</asp:ListItem>
        <asp:ListItem Value="IN">Indiana</asp:ListItem>
        <asp:ListItem Value="IA">Iowa</asp:ListItem>
        <asp:ListItem Value="KS">Kansas</asp:ListItem>
        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
        <asp:ListItem Value="ME">Maine</asp:ListItem>
        <asp:ListItem Value="MD">Maryland</asp:ListItem>
        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
        <asp:ListItem Value="MI">Michigan</asp:ListItem>
        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
        <asp:ListItem Value="MO">Missouri</asp:ListItem>
        <asp:ListItem Value="MT">Montana</asp:ListItem>
        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
        <asp:ListItem Value="NV">Nevada</asp:ListItem>
        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
        <asp:ListItem Value="NY">New York</asp:ListItem>
        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
        <asp:ListItem Value="OH">Ohio</asp:ListItem>
        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
        <asp:ListItem Value="OR">Oregon</asp:ListItem>
        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
        <asp:ListItem Value="TX">Texas</asp:ListItem>
        <asp:ListItem Value="UT">Utah</asp:ListItem>
        <asp:ListItem Value="VT">Vermont</asp:ListItem>
        <asp:ListItem Value="VA">Virginia</asp:ListItem>
        <asp:ListItem Value="WA">Washington</asp:ListItem>
        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
    Zip Code:<br />
    <asp:TextBox ID="ZipCode" runat="server" />&nbsp;
    <asp:Button ID="AutofillButton" Text="Autofill" OnClientClick="autoFill(); return false;" runat="server" />

    <script type="text/javascript">
    function autoFill()
    {
        var tb = new Sys.Preview.UI.TextBox ($get('ctl00_Main_ZipCode'));
        var zip = tb.get_text();

        if (zip.length == 5)
            PageMethods.GetCityAndStateFromZipCode (zip, onGetCityAndStateCompleted);
    }

    function onGetCityAndStateCompleted(result)
    {
        if (result != null)
        {
            var tb = new Sys.Preview.UI.TextBox ($get('ctl00_Main_City'));
            tb.set_text(result[0]);

            var select = new Sys.Preview.UI.Selector ($get('ctl00_Main_Region'));
            select.set_selectedValue(result[1]);
        }
    }
    </script>
</asp:Content>