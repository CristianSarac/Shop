using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_Account_PassReset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {       
       lblError.Text= ConnectionClass.UpdatePassword(Request.QueryString["email"].ToString(), tbxNewPass.Text);
       lblError.Visible = true;
    }
}