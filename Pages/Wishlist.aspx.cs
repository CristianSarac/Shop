﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Wishlist : System.Web.UI.Page
{
    List<Product> listOfProducts = new List<Product>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        int user_id = (int)Session["user_id"];
        listOfProducts = ConnectionClass.GetWishlist(user_id);
        repeater.DataSource = listOfProducts;
        repeater.DataBind();

    }


    protected void Button_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label id = (Label)e.Item.FindControl("lblId");
        int user_id = (int)Session["user_id"];
        Product toBeRemoved = null;
        foreach (Product p in listOfProducts)
        {
            if (p.Id == int.Parse(id.Text))
            {
                toBeRemoved = p;
            }
        }
        listOfProducts.Remove(toBeRemoved);
        ConnectionClass.RemoveFromWishlist(toBeRemoved, user_id);
        repeater.DataSource = listOfProducts;
        repeater.DataBind();
        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Add button clicked');", true);
    }

    //Check if user is logged in
    private void Authenticate()
    {

        if (Session["login"] == null)
        {
            Response.Redirect("~/pages/account/login.aspx");
        }
    }
};