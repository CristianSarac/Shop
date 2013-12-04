using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;



namespace Pages
{
    public partial class Pages_Shop : System.Web.UI.Page
    {
        List<Product> listOfProducts = new List<Product>();
        List<Product> productsBySize = new List<Product>();
        int user_id = 0;
        string size = "";
        string category = "";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            size = GetSelectedValueFromDropDown(Sizeddl);
            category = GetSelectedValueFromDropDown(Typeddl);
            Typeddl.DataSource = ConnectionClass.GetProductTypes();
            Typeddl.DataBind();
            Sizeddl.DataSource = ConnectionClass.GetProductSizes();
            Sizeddl.DataBind();
            Sizeddl.Items.Insert(0, new ListItem("Size"));
            Sizeddl.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                user_id = (int)Session["user_id"];
            }

            if (Session["search"] != null)
            {
                string keyword = Session["search"] as string;
                listOfProducts = ConnectionClass.GetProductsByKeyword(keyword);
                Session["search"] = null;
                listView.DataSource = ConnectionClass.GetProductsByKeyword(keyword);
                listView.DataBind();
                lblTitle.Text = listOfProducts.Count + " results for " + keyword;
                lblCategory.Visible = false;
                Typeddl.Visible = false;
                lblSize.Visible = false;
                Sizeddl.Visible = false;
            }
            else
            {
                listOfProducts = ConnectionClass.GetAllProducts();
                listView.DataSource = listOfProducts;
                listView.DataBind();
                if (Session["login"] == null)
                {
                    setButtonWishVisible(listView);
                }
                RefreshView(listView);
            }


            if (size != null)
            {
                Sizeddl.SelectedValue = Sizeddl.Items.FindByText(size).Value;
            }
        }
        protected void Typeddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Product> productsByType = new List<Product>();

            foreach (Product p in listOfProducts)
            {
                if (p.Type == Typeddl.SelectedValue)
                {
                    productsByType.Add(p);
                }
            }
            listView.DataSource = productsByType;
            listView.DataBind();


        }

        protected void Sizeddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product p in listOfProducts)
            {
                if (p.Size == size)
                {
                    productsBySize.Add(p);
                }
            }
            listView.DataSource = productsBySize;
            listView.DataBind();
            RefreshView(listView);
        }

        protected void listView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Label id = (Label)e.Item.FindControl("lblId");
            Label wishlist = (Label)e.Item.FindControl("lblWish");
            Product toBeAdded = null;
            if (ConnectionClass.CheckWishList(int.Parse(id.Text), user_id))
            {
                wishlist.Visible = true;
                lblWish.Visible = true;
                return;
            }
            else
            {
                foreach (Product p in listOfProducts)
                {
                    if (p.Id == int.Parse(id.Text))
                    {
                        toBeAdded = p;
                    }
                }
            }
            wishlist.Visible = true;
            ConnectionClass.AddToWishlist(toBeAdded, user_id);
        }

        //Check if user is logged in
        private void Authenticate()
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/pages/account/login.aspx");
            }
        }

        private void RefreshView(ListView listView)
        {
            foreach (ListViewItem items in listView.Items)
            {
                if (items.ItemType == ListViewItemType.DataItem)
                {
                    Label labelId = (Label)items.FindControl("lblId");
                    Label lbllWishListAdd = (Label)items.FindControl("lblWish");
                    if (ConnectionClass.CheckWishList(Int32.Parse(labelId.Text), user_id) && Session["login"] != null)
                    {
                        lbllWishListAdd.Visible = true;
                    }
                }
            }
        }

        private void setButtonWishVisible(ListView listView)
        {
            foreach (ListViewDataItem items in listView.Items)
            {
                if (items.ItemType == ListViewItemType.DataItem)
                {
                    Button btnAdd = (Button)items.FindControl("btnAddWishlist") as Button;
                    btnAdd.Visible = false;
                }
            }
        }

        public static string GetSelectedValueFromDropDown(System.Web.UI.WebControls.DropDownList listBox)
        {
            return HttpContext.Current.Request[listBox.UniqueID];
        }
    }
}