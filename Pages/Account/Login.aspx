<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        function onSignInCallback(authResult) {
            if (authResult['access_token']) {
                // The user is signed in
                var loc = '/Shop/Pages/Home.aspx?accessToken=' + authResult['access_token'];
                window.location.href = loc;
            } else if (authResult['error']) {
                // There was an error, which means the user is not signed in.
                // As an example, you can troubleshoot by writing to the console:

            }
            //console.log('authResult', authResult);
        }
    </script>

    <script type="text/javascript">
        (function () {
            var po = document.createElement('script');
            po.type = 'text/javascript'; po.async = true;
            po.src = 'https://plus.google.com/js/client:plusone.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(po, s);
        })();
    </script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script>

        window.fbAsyncInit = function () {
            FB.init({
                appId: '668264679884232', // App ID
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            FB.Event.subscribe('auth.authResponseChange', function (response) {
                if (response.status === 'connected') {
                    // the user is logged in and has authenticated your
                    // app, and response.authResponse supplies
                    // the user's ID, a valid access token, a signed
                    // request, and the time the access token 
                    // and signed request each expire
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;

                    // Do a post to the server to finish the logon
                    // This is a form post since we don't want to use AJAX
                    var form = document.createElement("form");
                    form.setAttribute("method", 'post');
                    form.setAttribute("action", 'FacebookLogin.ashx');

                    var field = document.createElement("input");
                    field.setAttribute("type", "hidden");
                    field.setAttribute("name", 'accessToken');
                    field.setAttribute("value", accessToken);
                    form.appendChild(field);

                    document.body.appendChild(form);

                    //$("#bt").css("display", "block");
                    // $("#bt").click(function (e) {
                    form.submit();

                    //});
                } else if (response.status === 'not_authorized') {
                    // the user is logged in to Facebook, 
                    // but has not authenticated your app
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;

                    // Do a post to the server to finish the logon
                    // This is a form post since we don't want to use AJAX
                    var form = document.createElement("form");
                    form.setAttribute("method", 'post');
                    form.setAttribute("action", 'FacebookLogin.ashx');

                    var field = document.createElement("input");
                    field.setAttribute("type", "hidden");
                    field.setAttribute("name", 'accessToken');
                    field.setAttribute("value", accessToken);
                    form.appendChild(field);

                    document.body.appendChild(form);
                    form.submit();

                } else {
                    // the user isn't logged in to Facebook.
                    // the user is logged in and has authenticated your
                    // app, and response.authResponse supplies
                    // the user's ID, a valid access token, a signed
                    // request, and the time the access token 
                    // and signed request each expire
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;

                    // Do a post to the server to finish the logon
                    // This is a form post since we don't want to use AJAX
                    var form = document.createElement("form");
                    form.setAttribute("method", 'post');
                    form.setAttribute("action", 'FacebookLogin.ashx');

                    var field = document.createElement("input");
                    field.setAttribute("type", "hidden");
                    field.setAttribute("name", 'accessToken');
                    field.setAttribute("value", accessToken);
                    form.appendChild(field);

                    document.body.appendChild(form);
                    form.submit();

                }
            });



        };

        // Load the SDK Asynchronously
        (function (d) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all.js";
            ref.parentNode.insertBefore(js, ref);
        }(document));
    </script>


    <table class="login">
        <tr>
            <td class="text">Login with email:</td>
            
            <td>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="text">Password:</td>
            <td>

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>

            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" runat="server" CssClass="login-button" Text="Login"
                    OnClick="btnLogin_Click" />
                <asp:Label ID="lblError" CssClass="error-message" runat="server" Text=""></asp:Label>

                <asp:LinkButton ID="LinkButton2" runat="server"
                    PostBackUrl="~/Pages/Account/Registration.aspx" CssClass="register-button" CausesValidation="False">Register</asp:LinkButton>
                <!--div used by facebook to display its data-->

            </td>
        </tr>

    </table>
    <div style="margin-top: 10px;">
        <div class="fb-login-button" data-show-faces="true" data-width="400" data-max-rows="1" data-scope="email"></div>
        <a href="#" style="display: none;" id="bt">Login with Facebook</a>
        <div id="gConnect">
            <button class="g-signin"
                data-scope="https://www.googleapis.com/auth/plus.login  https://www.googleapis.com/auth/userinfo.email  https://www.googleapis.com/auth/userinfo.profile"
                data-requestvisibleactions="http://schemas.google.com/AddActivity"
                data-clientid="238144009696.apps.googleusercontent.com"
                data-accesstype="offline"
                data-callback="onSignInCallback"
                data-theme="dark"
                data-cookiepolicy="single_host_origin">
            </button>
        </div>

    </div>
    <div>   
        <a id="pass" href="~/Pages/Account/PassRetrieval.aspx" runat="server">Pass retrieval</a>
    </div>
</asp:Content>

