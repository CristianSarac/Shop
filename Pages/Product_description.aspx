<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product_description.aspx.cs" Inherits="Pages_Product_description" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <div id="single_product">

        <asp:Image ID="Image_description" CssClass="alignLeft" runat="server" />
        <table class="alignLeft details">

            <tr>
                <td class="td1">
                    <h3>Name:</h3>
                </td>
                <td>
                    <h3>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td class="td1">Artist:</td>

                <td>
                    <asp:Label ID="lblArtist" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">Price:</td>
                <td>
                    <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">Type:</td>
                <td>
                    <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">Size:</td>
                <td>
                    <asp:Label ID="lblSize" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td1">Description:</td>
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <div class="clearfix"></div>
    </div>



    <h3 class="alignLeft">Here are reviews made by our users</h3>


    <asp:Button ID="btnComment" CssClass="btn_review" runat="server" Text="Add review" />
    <ajaxToolkit:ModalPopupExtender ID="MP1" runat="server"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground"
        TargetControlID="btnComment"
        CancelControlID="btnClose"
        >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
        &nbsp;&nbsp;Please add your review:<br />
        <asp:TextBox ID="tbxReview" runat="server" TextMode="MultiLine" Rows="11"></asp:TextBox>
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
        <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" />
    </asp:Panel>

    <div class="clearfix"></div>

    <asp:Repeater ID="repeater" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="single_product_review">
                <div class="user_info">
                    <h4>By: 
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "user.name") %>'></asp:Label></h4>
                </div>
                <div class="review">
                    <ajaxToolkit:Rating ID="Rating" runat="server"
                        ReadOnly="true"
                        CurrentRating='<%# DataBinder.Eval(Container.DataItem, "rating") %>'
                        MaxRating="5"
                        StarCssClass="ratingStar"
                        WaitingStarCssClass="savedRatingStar"
                        FilledStarCssClass="filledRatingStar"
                        EmptyStarCssClass="emptyRatingStar"
                        OnChanged="Rating_Changed" />
                    <asp:Label ID="lblReview" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "reviewtext") %>'></asp:Label>
                </div>

                <div class="clearfix"></div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

