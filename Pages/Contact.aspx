<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Pages_Contact" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript" src="../JavaScript/minicart.min.js"></script>
 <script type="text/javascript">
     paypal.minicart.render();


        </script>



    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">

        <p>
            <asp:Label ID="DisplayMessage" runat="server" ForeColor="green" Visible="false" />
        </p>
        <p>
            Please fill the following to send a mail to our management staff.
        </p>
        <div class="box1">
            <p>
                Your name:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
            ControlToValidate="YourName" ValidationGroup="save" /><br />
                <asp:TextBox ID="YourName" runat="server" Width="360px" /><br />
                Your email address:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
            ControlToValidate="YourEmail" ValidationGroup="save" /><br />
                <asp:TextBox ID="YourEmail" runat="server" Width="360px" />
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator23"
                    SetFocusOnError="true" Text="Example: username@gmail.com" ControlToValidate="YourEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                    ValidationGroup="save" /><br />
                Subject:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
            ControlToValidate="YourSubject" ValidationGroup="save" /><br />
                <asp:TextBox ID="YourSubject" runat="server" Width="360px" /><br />
            </p>
        </div>
        <div class="box2">
            <p>
                Your Question:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
            ControlToValidate="Comments" ValidationGroup="save" /><br />
                <asp:TextBox ID="Comments" runat="server"
                    TextMode="MultiLine"   />
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Send"
                    OnClick="Button1_Click" ValidationGroup="save" />
            </p>
        </div>
    </asp:Panel>






</asp:Content>
