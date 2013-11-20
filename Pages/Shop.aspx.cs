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
        List<Product> lista = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Authenticate();

            //var accessToken = Session["AccessToken"].ToString();
            //var client = new FacebookClient(accessToken);
            //dynamic result = client.Get("me", new { fields = "name,id" });
            //string name = result.name;
            //string id = result.id;


            if (!IsPostBack)
            {
                DropDownList1.DataSource = ConnectionClass.GetProductTypes();
                DropDownList1.DataBind();      
            }
            if (Session["search"] != null)
            {
                string keyword = Session["search"] as string;
                lista = ConnectionClass.GetProductsByKeyword(keyword);
                Session["search"] = null;
                repeater.DataSource = lista;
                repeater.DataBind();
            }
            else
            {
                lista = ConnectionClass.GetAllProducts();
                repeater.DataSource = lista;
                repeater.DataBind();
            }
                
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<Product> lista2 = new List<Product>();
            
            foreach (Product p in lista)
            {
               
                if (p.Type==DropDownList1.SelectedValue)
                {
                    lista2.Add(p);
                    
                }
            }
            repeater.DataSource = lista2;
            repeater.DataBind();
            
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Authenticate();
            SendOrder();

            lblResult.Text = "Your order has been placed, thank you for shopping at our store";
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["orders"] = null;
            btnOk.Visible = false;
            btnCancel.Visible = false;
            lblResult.Visible = false;


        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Authenticate();
            GenerateReview();


        }

        //Fill page with dynamic controls showing products in database
        private void GenerateControls()
        {
            //Get all productObjects from database
            ArrayList productList = ConnectionClass.GetProductByType("%");


            //           foreach (Product product in productList)
            //           {
            //               //Create Controls
            //               StringBuilder sb = new StringBuilder();
            //               Panel productPanel = new Panel();
            //               Image image = new Image { ImageUrl = product.Image, CssClass = "ProductsImage" };
            //               Literal literal = new Literal { Text = "<br />" };
            //               Literal literal2 = new Literal { Text = "<br />" };
            //               Label lblName = new Label { Text = product.Name, CssClass = "ProductsName" };
            //               Label lblPrice = new Label
            //                                    {
            //                                        Text = String.Format("{0:0.00}", product.Price + "<br />"),
            //                                        CssClass = "ProductsPrice"
            //                                    };
            //               TextBox textBox = new TextBox
            //                                     {
            //                                         ID = product.Id.ToString(),
            //                                         CssClass = "ProductsTextBox",
            //                                         Width = 60,
            //                                         Text = "0"
            //                                     };

            //               //Add validation so only numbers can be entered into the textfields
            //               RegularExpressionValidator regex = new RegularExpressionValidator
            //                                                      {
            //                                                          ValidationExpression = "^[0-9]*",
            //                                                          ControlToValidate = textBox.ID,
            //                                                          ErrorMessage = "Please enter a number."
            //                                                      };

            //               //PayPal Button


            //               sb.Append(string.Format(
            //                 @"<form method='post' action='https://www.paypal.com/cgi-bin/webscr'>
            //                    <input type='hidden' name='cmd' value='_cart'>
            //                    <input type='hidden' name='add' value='1'>
            //                    <input type='hidden' name='amount' value='5'>
            //                    <input type='hidden' name='item_name' value='Ceva'>
            //                    <input type='hidden' name='currency_code' value='USD'>
            //                    <input type='hidden' name='return' value=''>
            //                    <input type='image' src='http://www.paypalobjects.com/en_US/i/btn/x-click-but22.gif' 
            //                           border='0' name='submit' width='87' height='23' 
            //                           alt='Make payments with PayPal - it's fast, free and secure!'>
            //                        </form>
            //                  <script type='text/javascript' src= '../JavaScript/minicart.min.js'>paypal.minicart.render();</script>
            //                  ",
            //                        textBox.Text, product.Price, product.Name, "../JavaScript/minicart.min.js"));
            //               Label lblOutput = new Label { Text = sb.ToString() };

            //               //Add controls to Panels
            //               productPanel.Controls.Add(image);
            //               productPanel.Controls.Add(literal);
            //               productPanel.Controls.Add(lblName);
            //               productPanel.Controls.Add(literal2);
            //               productPanel.Controls.Add(lblPrice);
            //               productPanel.Controls.Add(textBox);
            //               productPanel.Controls.Add(regex);
            //               productPanel.Controls.Add(lblOutput);

            //               pnlProducts.Controls.Add(productPanel);
            //           }
        }


        //Returns a list of all orders placed in textboxes
        private ArrayList GetOrders()
        {
            //Get list of Textbox objects in ContentPlaceHolder
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            ControlFinder<TextBox> cf = new ControlFinder<TextBox>();
            cf.FindChildControlsRecursive(cph);
            var textBoxList = cf.FoundControls;

            //Create orders using data from textfields
            ArrayList orderList = new ArrayList();

            foreach (TextBox textBox in textBoxList)
            {
                //Make sure textbox.Text is not null
                if (textBox.Text != "")
                {
                    int amountOfOrders = Convert.ToInt32(textBox.Text);

                    //Generate Order for each textbox which has an order greater than 0
                    if (amountOfOrders > 0)
                    {
                        Product product = ConnectionClass.GetProductById(Convert.ToInt32(textBox.ID));
                        Order order = new Order(
                            Session["login"].ToString(), product.Name, amountOfOrders, product.Price, DateTime.Now, false);

                        //Add order to ArrayList
                        orderList.Add(order);
                    }
                }
            }
            return orderList;
        }

        //Generate HTML table to review Current Order
        private void GenerateReview()
        {
            double totalAmount = 0;
            ArrayList orderList = GetOrders();
            Session["orders"] = orderList;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<h3>Please review your order</h3>");

            //Generate a row for each Order
            foreach (Order order in orderList)
            {
                double totalRow = order.Price * order.Amount;
                sb.Append(String.Format(@"<tr>
                                            <td width = '50px'>{0} X </td>
                                            <td width = '200px'>{1} ({2})</td>
                                            <td>{3}</td><td>$</td>
                                        </tr>", order.Amount, order.Product, order.Price, String.Format("{0:0.00}", totalRow)));
                totalAmount = totalAmount + totalRow;
            }

            //Generate row for Total Amount
            sb.Append(String.Format(@"<tr>
                                        <td><b>Total: </b></td>
                                        <td><b>{0} $ </b></td>
                                      </tr>", totalAmount));
            sb.Append("</table>");

            //Export data and make Controls visible
            lblResult.Text = sb.ToString();
            lblResult.Visible = true;
            btnOk.Visible = true;
            btnCancel.Visible = true;
        }

        //Send order to database
        private void SendOrder()
        {
            ArrayList orderList = (ArrayList)Session["orders"];
            ConnectionClass.AddOrders(orderList);
            Session["orders"] = null;
        }

        //Check if user is logged in
        private void Authenticate()
        {
            //if (Session["login"] == null)
            //{
            //    Response.Redirect("~/pages/account/login.aspx");
            //}
        }

}
}