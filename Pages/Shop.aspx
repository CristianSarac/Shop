<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Pages.Pages_Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/minicart.min.js"></script>
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px"
        OnClick="btnOk_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False"
        Width="100px" OnClick="btnCancel_Click" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:Panel ID="pnlProducts" runat="server">
        <asp:SqlDataSource ID="dsProducts" runat="server"
            ConnectionString="<%$ ConnectionStrings:productConnection %>"
            SelectCommand="SELECT [image], [review], [name], [price] FROM [products]"></asp:SqlDataSource>
        <asp:Repeater ID="repeater" runat="server" DataSourceID="dsProducts">
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
                                <asp:Label ID="lblDescription" CssClass="ProductsReview" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "review") %>'></asp:Label><br />
                                <asp:Label ID="lblPrice" runat="server" CssClass="ProductsPrice" Text='<%# String.Format("{0:c}", DataBinder.Eval(Container.DataItem, "price")) %>' Font-Bold="true"></asp:Label>
                                <br />
                            </div>
                            <div id="Div1" class="paypal" runat="server">
                                <form target="paypal" action="https://www.paypal.com/cgi-bin/webscr" method="post">
                                    <input type="hidden" name="cmd" value="_cart">
                                    <input type="hidden" name="add" value="1">
                                    <input type="hidden" name="item_name" value='<%# DataBinder.Eval(Container.DataItem, "name") %>'>
                                    <input type="hidden" name="amount" value='<%# DataBinder.Eval(Container.DataItem, "price") %>'>
                                    <input type="hidden" name="currency_code" value="USD">
                                    <input type="hidden" name="return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings[" successurl="] %>" />
                                    <input type="hidden" name="cancel_return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings[" failedurl="] %>" />
                                    <input type="image" src="http://www.paypalobjects.com/en_US/i/btn/x-click-but22.gif" border="0" name="submit" width="87" height="23" alt="Make payments with PayPal - it's fast, free and secure!">
                                </form>

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
            paypal.minicart.render();

        </script>
    </asp:Panel>

    <br />
</asp:Content>

