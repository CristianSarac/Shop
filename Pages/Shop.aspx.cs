using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using Entities;
using System.Collections.Generic;
using System.Diagnostics;



namespace Pages
{
    public partial class Pages_Shop : System.Web.UI.Page
    {
        List<Product> listOfProducts = new List<Product>();
        int user_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                
                 user_id = (int)Session["user_id"];
            }

            if (!IsPostBack)
            {
                Typeddl.DataSource = ConnectionClass.GetProductTypes();
                Typeddl.DataBind();
                Sizeddl.DataSource = ConnectionClass.GetProductSizes();
                Sizeddl.DataBind();
            }
            if (Session["search"] != null)
            {
               
                string keyword = Session["search"] as string;
                listOfProducts = ConnectionClass.GetProductsByKeyword(keyword);
                Session["search"] = null;
                repeater.DataSource = listOfProducts;
                repeater.DataBind();
                lblTitle.Text = listOfProducts.Count + " results for "+keyword;
                lblCategory.Visible = false;
                Typeddl.Visible = false;
                lblSize.Visible = false;
                Sizeddl.Visible = false;
            }
            else
            {
                listOfProducts = ConnectionClass.GetAllProducts();
                repeater.DataSource = listOfProducts;
                repeater.DataBind();
                Typeddl.DataSource = ConnectionClass.GetProductTypes();
                Typeddl.DataBind();
                Sizeddl.DataSource = ConnectionClass.GetProductSizes();
                Sizeddl.DataBind();

                if (Session["login"] == null)
                {
                    foreach (RepeaterItem item in repeater.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            Button btnAdd = (Button)item.FindControl("btnAddToWishlist") as Button;
                            btnAdd.Visible = false;    
                        }
                    }
                }
            }

            foreach (RepeaterItem item in repeater.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label labelId = (Label)item.FindControl("lblId");
                    Label lbllWishListAdd = (Label)item.FindControl("lblWishList");
                    Debug.WriteLine(labelId.Text);
                    if (ConnectionClass.CheckWishList(Int32.Parse(labelId.Text), user_id) && Session["login"] != null)
                    {
                        lbllWishListAdd.Visible = true;
                    }          
                }
            }

        }


        protected void Typeddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<Product> productsByType = new List<Product>();
            
            foreach (Product p in listOfProducts)
            {
               
                if (p.Type==Typeddl.SelectedValue)
                {
                    productsByType.Add(p);
                    

                }
            }
            repeater.DataSource = productsByType;
            repeater.DataBind();

        }

        protected void Sizeddl_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Product> productsBySize = new List<Product>();

            foreach (Product p in listOfProducts)
            {

                if (p.Size == Sizeddl.SelectedValue && p.Type == Typeddl.SelectedValue && Typeddl.SelectedValue=="Painting")
                {
                    productsBySize.Add(p);

                }
            }
            repeater.DataSource = productsBySize;
            repeater.DataBind();


        }

        protected void Button_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
        Authenticate();
	    Label id = (Label)e.Item.FindControl("lblId");
        Label idWish = (Label)e.Item.FindControl("lblWishList");
       // user_id=(int)Session["user_id"];
        Product toBeAdded=null;
        if (ConnectionClass.CheckWishList(int.Parse(id.Text), user_id))
        {
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
        
        idWish.Visible = true; 
        ConnectionClass.AddToWishlist(toBeAdded,user_id);
                      
	}

        //Check if user is logged in
        private void Authenticate()
        {

            if (Session["login"] == null)
            {
                Response.Redirect("~/pages/account/login.aspx");
            }
        } 
}

}