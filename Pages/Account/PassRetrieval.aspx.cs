using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Pages_Account_PassRetrieval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        String userEmail = tbxEmail.Text;
        if (Session["email"] == userEmail)
        {
            lblEror.Text = "You are already loged in ! ";
            tbxEmail.Text = "";
        }
        else
        {
            User user = ConnectionClass.GetUserByEmail(userEmail);
            if (user != null)
            {

                try
                {
                    StringBuilder sbody = new StringBuilder();
                    //string code;
                    //code = Guid.NewGuid().ToString();

                    sbody.Append("<a href=http://www.oakleaproductions.somee.com/Pages/Account/PassReset.aspx?email=" + tbxEmail.Text);
                    sbody.Append("&code=" + "codulnustiucare" + "&uname=" + user.Name + ">Click here to change your password</a>");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("oaklea21@gmail.com", user.Email, "Reset Your Password", sbody.ToString());
                    //mail.CC.Add("any other email address if u want for cc");
                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("oaklea21", "oaklea211");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.Credentials = mailAuthenticaion;
                    // here am setting the property IsBodyHtml true because i am using html tags inside the mail's code
                    mail.IsBodyHtml = true;
                    mailclient.Send(mail);

                    lblEror.Text = "Link has been sent to your email address";
                }

                catch (Exception ex)
                {
                    // if there will be any error created at the time of the sending mail then it goes inside the catch
                    //and display the error in the label
                    lblEror.Text = ex.Message;
                }


            }
            else
            {
                lblEror.Text = "Email not found in our database";
            }

        }

    }




}

