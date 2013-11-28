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
        <div style="float: left; margin-left: 18px;">
            <h4>Do you like our product? Share it on Facebook and Google+ </h4>

            <!--facebook share -->
            <div class="fb-share-button"
                data-href=<%= url %> 
                data-type="button">
            </div>
            <!-- END OF facebook share -->
           
            

            <!-- Place this tag where you want the share button to render. -->
            <div class="g-plus" 
                data-action="share" 
                data-annotation="none"
                data-href=<%= url %> >

            </div>
            <!-- Place this tag after the last share tag. -->
            <script type="text/javascript">
                (function () {
                    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                    po.src = 'https://apis.google.com/js/platform.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
                })();
            </script>
        </div>
        <div class="clearfix"></div>
    </div>


    <h3 class="alignLeft">Here are reviews made by our users</h3>


    <asp:Button ID="btnComment" CssClass="btn_review" runat="server" Text="Add review" />
    <ajaxToolkit:ModalPopupExtender ID="MP1" runat="server"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground"
        TargetControlID="btnComment"
        CancelControlID="btnClose">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
        &nbsp;&nbsp;Please add your review:<br />

        <ajaxToolkit:Rating ID="Rating2" runat="server"
            CurrentRating='2'
            MaxRating="5"
            StarCssClass="ratingStar"
            WaitingStarCssClass="savedRatingStar"
            FilledStarCssClass="filledRatingStar"
            EmptyStarCssClass="emptyRatingStar"
            OnChanged="Rating_Changed" />

        <asp:TextBox ID="tbxReview" runat="server" TextMode="MultiLine" Rows="11"></asp:TextBox>
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
        <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" />
    </asp:Panel>



    <div class="clearfix"></div>

    <asp:Repeater ID="repeater" runat="server">
        <HeaderTemplate>
            <div class="reviews">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="single_product_review">


                <div class="user_info">
                    <h4>By: 
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "user.name") %>'></asp:Label></h4>

                    <ajaxToolkit:Rating ID="Rating" runat="server"
                        ReadOnly="true"
                        CurrentRating='<%# DataBinder.Eval(Container.DataItem, "rating") %>'
                        MaxRating="5"
                        StarCssClass="ratingStar"
                        WaitingStarCssClass="savedRatingStar"
                        FilledStarCssClass="filledRatingStar"
                        EmptyStarCssClass="emptyRatingStar"
                        OnChanged="Rating_Changed1" />
                    <div style="clear: both; float: none;"></div>
                </div>
                <asp:Label ID="lblReview" CssClass="review" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "reviewtext") %>'></asp:Label>


                <div class="clearfix"></div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

