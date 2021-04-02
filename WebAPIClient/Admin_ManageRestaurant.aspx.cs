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
    public partial class Admin_ManageRestaurant : System.Web.UI.Page
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
            List<Restaurant> modelList = new List<Restaurant>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/restaurant").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Restaurant>>(data);
                GridView1.DataSource = modelList;
                GridView1.DataBind();
            }
        }
     
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {  
            GridView1.EditIndex = e.NewEditIndex;
           BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            int ID = (int)e.Keys["RestaurantId"];
            Restaurant res = new Restaurant();

            string name = (string)e.NewValues["Name"];
            string phoneno = (string)e.NewValues["phoneno"];
            string address = (string)e.NewValues["address"];
            string description = (string)e.NewValues["description"];

            res.RestaurantId = ID;
            res.Name = name;
            res.phoneno = phoneno;
            res.address = address;
            res.description = description;

            string data = JsonConvert.SerializeObject(res);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/restaurant/updateRestaurant/" + ID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStatus.Text = "Restaurant Updated Successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = (int)e.Keys["RestaurantId"];
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/restaurant/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                lblStatus.Text = "Restaurant deleted Successfully";
            }
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[1].Visible = false; 
                e.Row.Cells[2].Text = "Restaurant Name";
                e.Row.Cells[3].Text = "Contact No";
                e.Row.Cells[4].Text = "Address";
                e.Row.Cells[5].Text = "Description";
            }
            e.Row.Cells[1].Visible = false;
           
        }

        

        protected void add_Restaurant_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admin_AddRestaurant.aspx");
        }
    }
}