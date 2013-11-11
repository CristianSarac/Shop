<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="Product_Overview.aspx.cs" Inherits="Pages_Product_Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Available Products:</h3>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Pages/Product_Add.aspx">Add new Product</asp:LinkButton>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            CellSpacing="4" DataKeyNames="id" DataSourceID="sds_product" ForeColor="Black" 
            GridLines="Vertical" Width="858px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="artist" HeaderText="artist" SortExpression="artist" />
                <asp:BoundField DataField="size" HeaderText="size" 
                    SortExpression="size" />
                <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
                <asp:BoundField DataField="review" HeaderText="review" 
                    SortExpression="review" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="sds_product" runat="server" 
            ConnectionString="<%$ ConnectionStrings:productConnection %>" 
            DeleteCommand="DELETE FROM [products] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [products] ([name], [type], [price], [artist], [size], [image], [review]) VALUES (@name, @type, @price, @artist, @size, @image, @review)" 
            SelectCommand="SELECT * FROM [products]" 
            UpdateCommand="UPDATE [products] SET [name] = @name, [type] = @type, [price] = @price, [artist] = @artist, [size] = @size, [image] = @image, [review] = @review WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="artist" Type="String" />
                <asp:Parameter Name="size" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="review" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="artist" Type="String" />
                <asp:Parameter Name="size" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="review" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>

