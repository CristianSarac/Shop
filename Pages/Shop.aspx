<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Pages.Pages_Shop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/minicart.min.js"></script>
    <script type="text/javascript"
        src="../JavaScript/paypal-button-minicart.min.js"></script>
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px"
        OnClick="btnOk_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False"
        Width="100px" OnClick="btnCancel_Click" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:Panel ID="pnlProducts" runat="server">
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" />
        <asp:Repeater ID="repeater" runat="server">
            <HeaderTemplate>
                <table class="shop-tabel" cellpadding="4" cellspacing="0" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Image ID="imgProduct" CssClass="ProductsImage"  runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image") %>' />

                        <div class="details">
                            <div class="alignLeft">
                                <asp:Label ID="lblName" CssClass="ProductsName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescription" CssClass="ProductsReview" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "review") %>'></asp:Label><br />
                                <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                <br />
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
                        <div class="clearfix"></div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <br />
</asp:Content>

