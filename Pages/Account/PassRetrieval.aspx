<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PassRetrieval.aspx.cs" Inherits="Pages_Account_PassRetrieval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" Text="<html>To reset your password, enter the email address you used to sign in on our Web Shop.<br/> This is the email address associated with your account.<html>"></asp:Label><br />
    <asp:TextBox ID="tbxEmail" runat="server" placeholder="example@example.com"></asp:TextBox>
    <asp:Button  ID="btnOk" Text="Submit" runat="server" OnClick="btnOk_Click"/><br />
    <asp:Label runat="server" Text="" ID="lblError"></asp:Label>
    </asp:Content>
