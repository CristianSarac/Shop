using System;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using Entities;

namespace Pages
{
    public partial class Pages_Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateControls();
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

            foreach (Product product in productList)
            {
                //Create Controls
                Panel productPanel = new Panel();
                Image image = new Image { ImageUrl = product.Image, CssClass = "ProductsImage" };
                Literal literal = new Literal { Text = "<br />" };
                Literal literal2 = new Literal { Text = "<br />" };
                Label lblName = new Label { Text = product.Name, CssClass = "ProductsName" };
                Label lblPrice = new Label
                                     {
                                         Text = String.Format("{0:0.00}", product.Price + "<br />"),
                                         CssClass = "ProductsPrice"
                                     };
                TextBox textBox = new TextBox
                                      {
                                          ID = product.Id.ToString(),
                                          CssClass = "ProductsTextBox",
                                          Width = 60,
                                          Text = "0"
                                      };

                //Add validation so only numbers can be entered into the textfields
                RegularExpressionValidator regex = new RegularExpressionValidator
                                                       {
                                                           ValidationExpression = "^[0-9]*",
                                                           ControlToValidate = textBox.ID,
                                                           ErrorMessage = "Please enter a number."
                                                       };

                //Add controls to Panels
                productPanel.Controls.Add(image);
                productPanel.Controls.Add(literal);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(literal2);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(textBox);
                productPanel.Controls.Add(regex);

                pnlProducts.Controls.Add(productPanel);
            }
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
            if (Session["login"] == null)
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }
        }
    }
}