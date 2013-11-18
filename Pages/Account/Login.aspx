<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function(){ 
            $(window).keydown(function(e){
                if (e.keyCode == 13) {
                    alert($('.login-button'));
                    $('.login input[type="submit"]').click();
                }
            });

        });

    </script>
    <table class="login">
        <tr>
            <td class="text">Login:</td>
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
            </td>
        </tr>
    </table>
</asp:Content>

