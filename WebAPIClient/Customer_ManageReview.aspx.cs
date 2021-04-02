using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using Restaurant_rating.Models;
using WebAPIClient.Models;
using System.Text;

namespace WebAPIClient
{
    public partial class Customer_ManageReview : System.Web.UI.Page
    {
        HttpClient client = null;
        Uri baseAddress = new Uri("https://localhost:44306/api");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            int ID = Convert.ToInt32(Session["uid"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<UserReview_Manual> modelList = new List<UserReview_Manual>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/review/getreviewsbyuserid/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                // Response.Write(data);
                modelList = JsonConvert.DeserializeObject<List<UserReview_Manual>>(data);
                GridView1.DataSource = modelList;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
            }
            e.Row.Cells[0].Visible = false;
            

        }
    }
}