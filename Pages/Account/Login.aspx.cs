﻿using System;

using System.Diagnostics;



public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        User user = ConnectionClass.LoginUser(txtLogin.Text, txtPassword.Text);

        if (user != null)
        {
            //Store login variables in session
            Session["login"] = user.Name;
            Session["type"] = user.Type;
            Session["user_id"] = user.Id;
            Session["email"] = user.Email;

           Response.Redirect("~/Pages/Home.aspx");
        }
        else
        {
            lblError.Text = "Login failed";
        }

    }

    
}

