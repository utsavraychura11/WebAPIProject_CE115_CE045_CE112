using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPIClient
{
    public partial class Admin_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Restaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_ManageRestaurant.aspx");
        }

        protected void Btn_Review_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_ManageReview.aspx");
        }

        protected void Btn_User_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_ViewCustomers.aspx");
        }

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Session.Clear();
            Response.Redirect("Main_Page.aspx");
        }
    }
}