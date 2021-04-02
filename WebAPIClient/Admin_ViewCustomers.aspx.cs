using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using Restaurant_rating.Models;

namespace WebAPIClient
{
    public partial class Admin_ViewCustomers : System.Web.UI.Page
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
            List<User> modelList = new List<User>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<User>>(data);
                GridView1.DataSource = modelList;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)e.Keys["UserId"];

            client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/user/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStatus.Text = "User Deleted Successfully...";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[1].Visible = false; 
                e.Row.Cells[2].Text = "Customer Name";
                e.Row.Cells[3].Text = "Contact No";
                e.Row.Cells[4].Text = "Address";
                e.Row.Cells[5].Text = "Email ID";
            }
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
        }
    }
}