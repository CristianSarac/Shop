using System;
using System.Diagnostics;

public partial class Pages_Account_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Create a new user
        User user = new User(txtName.Text, txtPassword.Text, txtEmail.Text, "user");

        //Register the user and return a result message
        lblResult.Text = ConnectionClass.RegisterUser(user);
        if (!lblResult.Text.Equals("A user with this email already exists"))
        {
            User user1 = ConnectionClass.GetUserByEmail(user.Email);


            ConnectionClass.LoginUser(user1.Email, user1.Password);
            if (user != null)
            {
                //Store login variables in session
                Session["login"] = user.Name;
                Session["type"] = user.Type;
                Session["user_id"] = user.Id;
                Session["email"] = user.Email;

                Response.Redirect("~/Pages/Home.aspx");
            }
        }
        

        
       
    }
}