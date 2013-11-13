<%@ Page Title="Product Reviews" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../JavaScript/minicart.min.js"></script>
 <script type="text/javascript">
     paypal.minicart.render();


        </script>
    <p>
    Select a type:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="sds_type" DataTextField="type" DataValueField="type" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="sds_type" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ProductDBConnectionString %>" 
        SelectCommand="SELECT DISTINCT [type] FROM [products] ORDER BY [type]">
    </asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblOuput" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>

