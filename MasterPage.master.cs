﻿using System;
using System.Diagnostics;
using System.Web.UI;



public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //Check if a user is logged in
        if (Session["login"] != null)
        {
            
            lblLogin.Text = "Welcome " + Session["login"];
            lblLogin.Visible = true;
            LinkButton1.Text = "Logout";  
           
        }
       
        else
        {
            lblLogin.Visible = true;
            lblLogin.Text = "Your Account";
            LinkButton1.Text = "Login";
          
            
            
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //User logs in 
        if (LinkButton1.Text == "Login")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
        {
            //User logs out
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }

    }   

   
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Session["search"] = tbxSearch.Text;
        Response.Redirect("~/Pages/Shop.aspx");

    }

    protected void btnWishlist_Click(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
            Response.Redirect("~/Pages/Wishlist.aspx?id=" + (int)Session["user_id"]);
        }
        else
        {
            Response.Redirect("~/Pages/Wishlist.aspx");
        }
    }
}

