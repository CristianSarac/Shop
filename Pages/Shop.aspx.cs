using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using Entities;
using System.Collections.Generic;
using System.Diagnostics;
using Facebook;


namespace Pages
{
    public partial class Pages_Shop : System.Web.UI.Page
    {
        List<Product> listOfProducts = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {

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
        int user_id=(int)Session["user_id"];
        Product toBeAdded=null;
	    foreach(Product p in listOfProducts){
            if (p.Id == int.Parse(id.Text))
            {
                toBeAdded = p;
            }
        }
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