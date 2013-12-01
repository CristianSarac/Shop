<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="Shared_wishlist.aspx.cs" Inherits="Pages_Shared_wishlist" EnableViewState="false" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlProducts" runat="server"> 
        <asp:Repeater ID="repeater" runat="server">

            <HeaderTemplate>
                <table class="shop-tabel" cellpadding="4" cellspacing="0" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Image ID="imgProduct" CssClass="ProductsImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image") %>' />

                        <div class="details">
                            <div class="alignLeft">
                                <asp:Label ID="lblName" CssClass="ProductsName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescription" CssClass="ProductsDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label><br />
                                <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                <br />
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
</asp:Content>