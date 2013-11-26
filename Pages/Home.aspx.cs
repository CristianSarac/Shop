using System;
using Facebook;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace Pages
{
    public partial class Pages_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //g+ login

            if (string.IsNullOrEmpty(Request.QueryString["accessToken"])) return;

            //let's send an http-request to Google+ API using the token          
            string json = GetGoogleUserEmailJSON(Request.QueryString["accessToken"]);
            string json2 = GetGoogleUserJSON(Request.QueryString["accessToken"]);

            //and Deserialize the JSON response
            JavaScriptSerializer js = new JavaScriptSerializer();
            GoogleUser oUser = js.Deserialize<GoogleUser>(json2);

            if (oUser != null)
            {

                User user = null;

                if (!ConnectionClass.searchUser(oUser.email))
                {
                    Debug.WriteLine("Nu lam gasit");
                    user = new User(oUser.name, "1234", oUser.email, "user");
                    ConnectionClass.RegisterUser(user);


                }
                else
                {
                    Debug.WriteLine("else");
                    user = ConnectionClass.GetUserByEmail(oUser.email);
                }
                ConnectionClass.LoginUser(user.Name, user.Password);
                Session["login"] = user.Name;
                Session["type"] = user.Type;

            }

        }


        /// <summary>
        /// sends http-request to Google+ API and returns the response string
        /// </summary>
        private string GetGoogleUserEmailJSON(string access_token)
        {
            string url = "https://www.googleapis.com/userinfo/email?alt=json";
            //string url2 = "https://www.googleapis.com/plus/v1/people/" + Request.QueryString["accessToken"];

            WebClient wc = new WebClient();
            wc.Headers.Add("Authorization", "OAuth " + Request.QueryString["accessToken"]);
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string retirnedJson = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return retirnedJson;
        }

        private string GetGoogleUserJSON(string access_token)
        {




            string url = "";
            url = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;

            WebClient wc = new WebClient();
            wc.Headers.Add("Authorization", "OAuth " + Request.QueryString["accessToken"]);
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string retirnedJson = reader.ReadToEnd();
            data.Close();
            reader.Close();




            return retirnedJson;



        }
    }



    public class GoogleUser
    {
        public string email { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string verified_email { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string link { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
    }
}