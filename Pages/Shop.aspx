<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Pages.Pages_Shop" EnableViewState="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="fb-root"></div>
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
    <script type="text/javascript" src="../JavaScript/minicart.min.js"></script>
    <script type="text/javascript"
        src="../JavaScript/paypal-button-minicart.min.js"></script>
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
  
    <asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px"
        OnClick="btnOk_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False"
        Width="100px" OnClick="btnCancel_Click" />
    
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:Panel ID="pnlProducts" runat="server">
        <h1>Filter through our products</h1>
        <asp:Label ID="lblCategory" runat="server" Text="Category: " />
        <asp:DropDownList ID="Typeddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Typeddl_SelectedIndexChanged" />
        <asp:Label ID="lblSize" runat="server" Text="Size: " />
        <asp:DropDownList ID="Sizeddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Sizeddl_SelectedIndexChanged" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:Repeater ID="repeater" runat="server" OnItemCommand="Button_ItemCommand">

            <HeaderTemplate>
                <table class="shop-tabel" cellpadding="4" cellspacing="0" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Image ID="imgProduct" CssClass="ProductsImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image") %>' />

                        <div class="details">
                            <div class="alignLeft">

                                <a href="Product_description.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>" class="ProductsName">
                                    <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                                </a>

                                <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="false"></asp:Label>

                                <br />
                                <asp:Label ID="lblDescription" CssClass="ProductsDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label><br />
                                <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnAddToWishlist" runat="server" CommandName="ID" Text="Add to Wishlist" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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

                        <!--facebook share 
                        <div class="fb-share-button" data-href="http://www.google.com" data-type="icon_link"></div>
                        <!-- END OF facebook share -->



                        <!-- Place this tag where you want the share button to render. 
                        <div class="g-plus" data-action="share" data-annotation="none"></div>
                        <div class="clearfix"></div>-->
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <script type="text/javascript">
            PAYPAL.minicart.render();

        </script>
    </asp:Panel>

    <!-- Place this tag after the last share tag. -->
    <script type="text/javascript">
        (function () {
            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
            po.src = 'https://apis.google.com/js/platform.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
        })();
    </script>
    <br />
</asp:Content>

