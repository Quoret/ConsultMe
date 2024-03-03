using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ConsultMeTest
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT *FROM Admin WHERE AdminUsername='" + AdminUsername.Text.Trim() + "'AND AdminPassword='" + AdminPassword.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<Script>alert('Login successful !!');</script>");
                        Session["AdminId"] = dr.GetValue(0).ToString();
                        Session["username"] = dr.GetValue(1).ToString();
                        
                        Session["role"] = "Admin";
                    }
                    Response.Write("< script > alert('" + Session["AdminId"] + "');</ script > ");
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials !!');</script>");
                }


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{ex.Message}');");
            }
        }
    }
}