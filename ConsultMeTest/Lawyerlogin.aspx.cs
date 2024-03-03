using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Security.Cryptography;
using System.Text;

namespace ConsultMeTest
{
    public partial class Lawyerlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void law_Login_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open(); 
                }
                SqlCommand cmd = new SqlCommand("SELECT *FROM Lawyer WHERE LawyerUsername='" + l_Username.Text.Trim() + "'", con);
                SqlDataReader dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string hashedPassword = HashPassword(l_Password.Text.Trim());
                        if(hashedPassword==dr.GetValue(5).ToString())
                        {
                            if (dr.GetValue(6).ToString() == "Verified")
                            {
                                Response.Write("<Script>alert('Login successful !!');</script>");
                                Session["LawyerId"] = dr.GetValue(0).ToString();
                                Session["firstname"] = dr.GetValue(1).ToString();
                                Session["username"] = dr.GetValue(4).ToString();
                                Session["role"] = "lawyer";
                            }
                            else
                            {
                                Response.Write("<script>alert('Your account verification is still pending.');</script>");
                                return;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid Credentials !!');</script>");

                        }

                    }
                    // Since there are rows, redirect outside the loop
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    // No rows, show invalid credentials message
                    Response.Write("<script>alert('Invalid Credentials !!');</script>");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{ex.Message}');");
            }
        }
        string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }

}
