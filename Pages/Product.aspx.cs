using System;
using System.Collections;
using System.Text;


public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       FillPage();
    }

   private void FillPage()
   {
       ArrayList productList = new ArrayList();

       if(!IsPostBack)
       {
           productList = ConnectionClass.GetProductByType("%");
       }
       else
       {
           productList = ConnectionClass.GetProductByType(DropDownList1.SelectedValue);
       }
       
       StringBuilder sb = new StringBuilder();

       foreach (Product product in productList)
       {
           sb.Append(
               string.Format(
                   @"<table class='productTable'>
            <tr>
                <th rowspan='6' width='150px'><img runat='server' src='{6}' /></th>
                <th width='50px'>Name: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Type: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Price: </th>
                <td>{2} $</td>
            </tr>

            <tr>
                <th>Roast: </th>
                <td>{3}</td>
            </tr>

            <tr>
                <th>Origin: </th>
                <td>{4}</td>
            </tr>

            <tr>
                <td colspan='2'>{5}</td>
            </tr>           
            
           </table>",
                   product.Name, product.Type, product.Price, product.Roast, product.Country, product.Review, product.Image));

           lblOuput.Text = sb.ToString();

       }

       
   }
   protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
   {
       FillPage();
   }
}