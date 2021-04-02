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
    public partial class Admin_AddRestaurant : System.Web.UI.Page
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

            Restaurant res = new Restaurant();
            res.Name = txtName.Text;
            res.phoneno = txtContactNo.Text;
            res.description = txtDescription.Text;
            res.address = txtAddress.Text;

            string data = JsonConvert.SerializeObject(res);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/restaurant/addRestaurant", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    lblStatus.Text = "Restaurant Added Successfully...";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}