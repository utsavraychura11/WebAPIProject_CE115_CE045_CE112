using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using Restaurant_rating.Models;
using System.Text;
using System.Net;

namespace WebAPIClient
{
    public partial class Customer_Login : System.Web.UI.Page
    {
        HttpClient client = null;
        Uri baseAddress = new Uri("https://localhost:44306/api");
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            User user = new User();
            User tmp = new User();
            user.email = txtEmail.Text;
            user.password = txtPassword.Text;

            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/review/login", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                List<User> userList = new List<User>();
                HttpResponseMessage r = client.GetAsync(client.BaseAddress + "/user").Result;
                if(r.IsSuccessStatusCode)
                {
                    string d = r.Content.ReadAsStringAsync().Result;
                    userList = JsonConvert.DeserializeObject<List<User>>(d);
                    foreach (var x in userList)
                    {
                        if(x.email == txtEmail.Text)
                        {
                            Session["name"] = x.Name;
                            Session["uid"] = x.UserId;
                            Response.Redirect("Customer_Home.aspx");
                        }
                    }
                }
            }
            else
            {
                Response.Write("123");
            }
        }
    }
}