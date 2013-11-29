using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Shared_wishlist : System.Web.UI.Page
{
    public string url;
    List<Product> listOfProducts = new List<Product>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
            return;
        else
        {
            int user_id = Int32.Parse(Request.QueryString["id"]);
            listOfProducts = ConnectionClass.GetWishlist(user_id);
            repeater.DataSource = listOfProducts;
            repeater.DataBind();

        }
    }

}