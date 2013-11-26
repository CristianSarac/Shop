using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Pages_Product_description : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
            return;
        else
        {

            Product product = ConnectionClass.GetProductById(Int32.Parse(Request.QueryString["id"]));
            product.Id = Int32.Parse(Request.QueryString["id"]);

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
        }
    }

    protected void Rating_Changed(object sender, EventArgs e) {
    }
 
    protected void btnOk_Click(object sender, EventArgs e)
    {
        MP1.Hide();
        String review = tbxReview.Text;
        tbxReview.Text = "";

    }
}