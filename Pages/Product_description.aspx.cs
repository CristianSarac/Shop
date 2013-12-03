using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;

public partial class Pages_Product_description : System.Web.UI.Page
{
    Product product = null;
    public string url;
    public int id = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
            return;
        else
        {

            product = ConnectionClass.GetProductById(Int32.Parse(Request.QueryString["id"]));
            product.Id = Int32.Parse(Request.QueryString["id"]);
            id = product.Id;
            url="http://oakleaproductions.somee.com/Pages/Product_description.aspx?id="+id;
            Image_description.ImageUrl = product.Image;
            lblName.Text = product.Name;
            lblPrice.Text = product.Price + "";
            lblSize.Text = product.Size;
            lblType.Text = product.Type;
            lblDescription.Text = product.Description;
            lblArtist.Text = product.Artist;


            List<Review> reviewList = new List<Review>();

            reviewList = ConnectionClass.GetProductReviews(product);

            repeater.DataSource = reviewList;
            repeater.DataBind();
            // Default rating for an item 
            Session["review_rating"] = 2;
            if (Session["user_id"] == null)
            {
                //Response.Redirect("~/Pages/Account/Login.aspx");
                btnComment.Visible = false;

            }
            else {
                btnComment.Visible = true;
            }


        }
    }

    protected void Rating_Changed(object sender, RatingEventArgs e)
    {

        
        int rating = 0;
        rating = Int32.Parse(e.Value);
        Session["review_rating"] = rating;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        MP1.Hide();
        String reviewText = tbxReview.Text;
        tbxReview.Text = "";

        User u = ConnectionClass.GetUserById((int)Session["user_id"]);
        
            int rating = (int)Session["review_rating"];
            Session["review_rating"] = 0;
            Review review = new Review(u, product, reviewText, rating);

            ConnectionClass.AddReview(review);
            Response.Redirect(Request.RawUrl);
        
    }
    protected void Rating_Changed1(object sender, RatingEventArgs e)
    {

    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        
    }
}