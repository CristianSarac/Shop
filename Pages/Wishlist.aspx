﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="Wishlist.aspx.cs" Inherits="Pages_Wishlist" EnableViewState="false" %>



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

     
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
   <h1><asp:Label ID="lblTitle" runat="server" Text="Welcome to your wishlist !"></asp:Label></h1>
    <h3><asp:Label ID="lblEmpty" runat="server" Visible="false" ForeColor="Red" /></h3>
    <div class="wishListEmpty" >
    <asp:Label ID="lblInfo" runat="server" Visible="false"/> 
    <asp:LinkButton id="btnRedirect" runat="server" OnClick="btnRedirect_Click" Text="shop" Visible="false" ></asp:LinkButton>
         </div>
    <asp:Panel ID="pnlShare" runat="server">
    <h4> Share your wishlist on Facebook and Google+ </h4>
     <div class="fb-share-button" 
         data-href=<%= url %> 
         data-type="icon_link"></div>
    <div class="g-plus" 
        data-action="share" 
        data-annotation="none" 
        data-href=<%= url %> ></div>
        </asp:Panel>
    <asp:Panel ID="pnlProducts" runat="server"> 
       
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
                                <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblName" CssClass="ProductsName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescription" CssClass="ProductsDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label><br />
                                <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                <br />
                                    <asp:Button ID="btnRemoveFromWishlist" runat="server" CommandName="ID" Text="Remove from Wishlist" />
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