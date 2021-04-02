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
using WebAPIClient.Models;

namespace WebAPIClient
{
    public partial class Customer_AddReview : System.Web.UI.Page
    {
        HttpClient client = null;
        Uri baseAddress = new Uri("https://localhost:44306/api");
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            List<Restaurant_Manual> modelList = new List<Restaurant_Manual>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/restaurant").Result;
            if (response.IsSuccessStatusCode)
            {
                var restaurants = response.Content.ReadAsStringAsync().Result;
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Restaurant_Manual>>(data);

                foreach(var x in modelList)
                {
                    ListItem item = new ListItem();
                    item.Text = x.Name;
                    item.Value =x.RestaurantId.ToString();
                    DropDownList1.Items.Add(item);
                }
                
            }
        }

        protected void Btn_Add_Review_Click(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            Review review = new Review();
            review.RestaurantId = Convert.ToInt32(DropDownList1.SelectedValue);
            review.UserId = Convert.ToInt32( Session["uid"] );
            review.cleanliness_rating = Convert.ToInt32(txtClean.Text);
            review.staff_rating = Convert.ToInt32(txtStaff.Text);
            review.food_rating = Convert.ToInt32(txtFood.Text);
            review.review_detail = txtReviewDetails.Text;

            string data = JsonConvert.SerializeObject(review);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/review/addreview", content).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStauts.Text = "Review Added Successfully...";
                lblStauts.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}