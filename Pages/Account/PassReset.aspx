<%@ Page Title="Password reset" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PassReset.aspx.cs" Inherits="Pages_Account_PassReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox runat="server" ID="tbxNewPass"  placeholder="New password"  type="password"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="tbxConfirmPass" placeholder="Confirm password" type="password"></asp:TextBox><br />
     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxConfirmPass"  ControlToValidate="tbxNewPass"  ErrorMessage="Passwords do not match!" /><br />
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"/><br />
    <asp:Label runat="server" ID="lblError" Text="" Visible="false"></asp:Label>
</asp:Content>