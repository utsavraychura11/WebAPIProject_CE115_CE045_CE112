using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPIClient
{
    public partial class Customer_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["name"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer_AddReview.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer_ManageReview.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer_UpdateProfile.aspx");
        }

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;
            Session["name"] = null;

            Session.Clear();
            Response.Redirect("Main_Page.aspx");
        }
    }
}