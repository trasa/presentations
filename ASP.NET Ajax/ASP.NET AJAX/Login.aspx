<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="ASP.NET AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Description" Runat="Server">
This page demonstrates how to access ASP.NET 2.0's membership and profile services from the client side using ASP.NET AJAX's AuthenticationService and ProfileService proxies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <fieldset id="LoginPanel" style="width: 300px; height: 140px;">
        <legend>Please Log In</legend>
        <table style="width: 100%; height: 100%">
            <tr>
                <td>
                    <table cellpadding="4">
                        <tr>
                            <td>User name</td>
                            <td><input type="text" id="UserName" /></td>
                        </tr>
                        <tr>
                            <td>Password</td>
                            <td><input type="password" id="Password" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><input type="button" value="Log In" onclick="onLogin();" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </fieldset>
    <br /><br />
    <fieldset id="ProfilePanel" style="width: 300px; height: 100px;">
        <legend>Profile Data</legend>
        <table style="width: 100%; height: 100%">
            <tr>
                <td>
                    Mobile Number:<br />
                    <input type="text" id="MobileNumber" />
                    <input type="button" id="UpdateButton" value="Update" onclick="onUpdate();" />
                </td>
            </tr>
        </table>
    </fieldset>

    <script type="text/javascript">
    var _userNameTextBox;
    var _passwordTextBox;
    var _mobileNumberTextBox;

    function pageLoad()
    {
        // Instantiate TextBox controls wrapping HTML input boxes
        _userNameTextBox = new Sys.Preview.UI.TextBox($get('UserName'));
        _passwordTextBox = new Sys.Preview.UI.TextBox($get('Password'));
        _mobileNumberTextBox = new Sys.Preview.UI.TextBox($get('MobileNumber'));

        // If the user is already logged in, read his or her profile
        // and display their mobile number
        if (Sys.Services.AuthenticationService.get_isLoggedIn())
            loadMobileNumber();
    }

    function onLogin()
    {
        // Attempt to log in the user
        var username = _userNameTextBox.get_text();
        var password = _passwordTextBox.get_text();

        Sys.Services.AuthenticationService.login (username, password,
            false, null, null, onLoginCompleted, onLoginFailed);
    }

    function onLoginCompleted(result, context, methodName)
    {
        window.alert(result ? 'Login succeeded' : 'Login failed');
        
        if (result)
            loadMobileNumber();
    }

    function onLoginFailed(err, context, methodName)
    {
        window.alert(err.get_message());
    }

    function loadMobileNumber()
    {
        // Read the current user's mobile number from his or her profile
        Sys.Services.ProfileService.load(['Mobile'], onLoadCompleted, onLoadFailed);
    }

    function onLoadCompleted(result, context, methodName)
    {
        // Display the mobile number
        _mobileNumberTextBox.set_text(Sys.Services.ProfileService.properties.Mobile);
    }

    function onLoadFailed(err, context, methodName)
    {
        window.alert(err.get_message());
    }

    function onUpdate()
    {
        // Update the user profile with the a mobile number
        Sys.Services.ProfileService.properties.Mobile = _mobileNumberTextBox.get_text();
        Sys.Services.ProfileService.save(['Mobile'], onSaveCompleted, onSaveFailed);
    }

    function onSaveCompleted(result, context, methodName)
    {
        window.alert('Update succeeded');
    }

    function onSaveFailed(err, context, methodName)
    {
        window.alert(err.get_message());
    }
    </script>
</asp:Content>