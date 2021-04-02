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


namespace WebAPIClient
{
    public partial class Customer_UpdateProfile : System.Web.UI.Page
    {
        HttpClient client = null;
        Uri baseAddress = new Uri("https://localhost:44306/api");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Add_Restaurant_Click(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            int ID = Convert.ToInt32(Session["uid"]);
            User user = new User();
            user.Name = txtUsername.Text;
            user.email = txtEmail.Text;
            user.phoneno = txtContactNo.Text;
            user.UserId = ID;
            Session["name"] = txtUsername.Text;
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/user/" + ID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStatus.Text = "Profile Updated Successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
           

        }
    }
}