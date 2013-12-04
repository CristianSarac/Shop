<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Pages.Pages_Shop" EnableViewState="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="pnlProducts" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <h1>
            <asp:Label ID="lblTitle" runat="server" Text="Filter through our products" Visible="True"></asp:Label></h1>
        <asp:Label ID="lblCategory" runat="server" Text="Category: " />
        <asp:DropDownList ID="Typeddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Typeddl_SelectedIndexChanged" />
        <asp:Label ID="lblSize" runat="server" Text="Size: " />
        <asp:DropDownList ID="Sizeddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Sizeddl_SelectedIndexChanged" EnableViewState="false">
        </asp:DropDownList>

        <asp:ListView ID="listView" runat="server" OnItemCommand="listView_ItemCommand">
            <LayoutTemplate>
                <table class="shop-tabel" cellpadding="4" cellspacing="0" border="0">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <table class="shop-tabel" cellpadding="4" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <asp:Image ID="imgProd" CssClass="ProductsImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image") %>' />

                            <div class="details">
                                <div class="alignLeft">
                                    <a href="Product_description.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>" class="ProductsName">
                                        <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                                    </a>
                                    <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="false"></asp:Label>

                                    <br />

                                    <asp:Label ID="lblDescription" CssClass="ProductsDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"description") %>'> </asp:Label><br />
                                    <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                    <br />

                                    <div>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAddWishlist" runat="server" CommandName="ID" Text="Add to Wishlist" CommandArgument='AddWishList' UseSubmitBehavior="false" /><br />
                                                <asp:Label ID="lblWish" ForeColor="Red" runat="server" Text="<html>This item has been<br/> added to your wishlist!<html>" Visible="false"></asp:Label>

                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </div>

                                </div>

                                <div id="Div1" class="paypal" runat="server">
                                    <script type="text/javascript"
                                        src="../JavaScript/paypal-button-minicart.min.js?merchant=axel19ro@yahoo.com"
                                        data-button="cart"
                                        data-name="<%# DataBinder.Eval(Container.DataItem, "name") %>"
                                        data-quantity-editable="1"
                                        data-amount="<%# DataBinder.Eval(Container.DataItem, "price") %>"
                                        data-currency="usd"
                                        data-callback="mysite/shop"
                                        data-env="sandbox"></script>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>

        <script type="text/javascript">
            PAYPAL.minicart.render();

        </script>
    </asp:Panel>
</asp:Content>