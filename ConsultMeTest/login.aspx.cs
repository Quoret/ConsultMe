using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsultMeTest
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string query_user;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State ==ConnectionState.Closed)
                {
                    con.Open();
                }
                query_user = "SELECT *FROM Client where ClientUsername='" + Username.Text.Trim() + "'";
                SqlCommand cmd_U = new SqlCommand(query_user, con); 
                SqlDataReader dr_U = cmd_U.ExecuteReader();
                if (dr_U.HasRows)
                {
                    while (dr_U.Read())
                    {
                        string hashedPassword=HashPassword(Password.Text.Trim());
                        if (hashedPassword==dr_U.GetValue(4).ToString())
                        {
                            Response.Write("<script>alert('Login Sucessful');</script>");
                            Session["ClientId"] = dr_U.GetValue(0).ToString();
                            Session["username"] = dr_U.GetValue(3).ToString();
                            Session["fullname"] = dr_U.GetValue(1).ToString();
                            Session["role"] = "client";
                        }
                       
                    }
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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