<%@ WebHandler Language="C#" Class="FacebookLogin" %>

using System;
using System.Web;
using Facebook;
using System.Diagnostics;


public class FacebookLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        var accessToken = context.Request["accessToken"];
        context.Session["AccessToken"] = accessToken;
        registerWithFacebook(context);
        context.Response.Redirect("~/Pages/Home.aspx");
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    public void registerWithFacebook(HttpContext context)
    {
        var accessToken =context.Session["AccessToken"].ToString();
        var client = new FacebookClient(accessToken);
        dynamic result = client.Get("me", new { fields = "name,id,first_name,last_name,link,username,gender,locale,email,picture,birthday" });
        string name = result.name;
        string id = result.id;
        string email = result.email;
        Debug.WriteLine("Email???" + email+name+id);
        User user = null;
        if (!ConnectionClass.searchUser(email))
        {
            Debug.WriteLine("Nu lam gasit");
            user = new User(name, "1234", email, "user");
            ConnectionClass.RegisterUser(user);


        }
        else
        {
            Debug.WriteLine("else");
            user = ConnectionClass.GetUserByEmail(email);
        }
        Debug.WriteLine(user.Name + "----" + user.Password);
        ConnectionClass.LoginUser(user.Name, user.Password);
        context.Session["login"] = user.Name;
        context.Session["type"] = user.Type;


    }

}