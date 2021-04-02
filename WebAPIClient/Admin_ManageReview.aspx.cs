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
    public partial class Admin_ManageReview : System.Web.UI.Page
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
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<Review_Manual> modelList = new List<Review_Manual>();
            

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/review/getallreviews").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
               // Response.Write(data);
                modelList = JsonConvert.DeserializeObject<List<Review_Manual>>(data);
                GridView1.DataSource = modelList;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)e.Keys["ReviewId"];
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/review/deletereview/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStatus.Text = "Review Deleted Successfully..";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            BindData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "Customer Name";
                e.Row.Cells[3].Text = "Restaurant Name";
                e.Row.Cells[4].Text = "Food Rating";
                e.Row.Cells[5].Text = "Staff Rating";
                e.Row.Cells[6].Text = "Cleanliness Rating";
                e.Row.Cells[7].Text = "Review Details";
                
            }
            e.Row.Cells[1].Visible = false;
            
        }
    }
}
