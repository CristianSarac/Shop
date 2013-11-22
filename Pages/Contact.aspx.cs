using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { }



    protected void SendMail()
    {
        // Gmail Address from where you send the mail
        var fromAddress = "oaklea21@gmail.com";
        var toAddress = "oaklea21@gmail.com";
        //Password of your gmail address
        const string fromPassword = "oaklea211";
        // Passing the values and make a email formate to display
        string subject = YourSubject.Text.ToString();
        string body = "From: " + YourName.Text + "\n";
        body += "From Email: " + YourEmail.Text + "\n";
        body += "Subject: " + YourSubject.Text + "\n";
        body += "Question: \n" + Comments.Text + "\n";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //here on button click what will done 
            SendMail();
            DisplayMessage.Text = "Thank you for your intrest in our company.";
            DisplayMessage.Visible = true;
            YourSubject.Text = "";
            YourEmail.Text = "";
            YourName.Text = "";
            Comments.Text = "";

        }
        catch (Exception) { }
    }





}
