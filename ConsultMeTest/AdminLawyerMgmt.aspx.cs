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
    public partial class AdminLawyerMgmt : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            LawyerList.DataBind();
        }

        protected void go_Click(object sender, EventArgs e)
        {
            GetLawyerById();
        }

        protected void Verified_Click(object sender, EventArgs e)
        {
            UpdateLawyerStatusById("Verified");
        }

        protected void Pending_Click(object sender, EventArgs e)
        {
            UpdateLawyerStatusById("Pending");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DeleteLawyerById();
        }


        void GetLawyerById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT *FROM Lawyer WHERE LawyerID='" + Ad_lawyerid.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Ad_fullname.Text= dr.GetValue(1).ToString();
                        Ad_email.Text= dr.GetValue(2).ToString();
                        Ad_username.Text= dr.GetValue(4).ToString();
                        Ad_number.Text= dr.GetValue(3).ToString();
                        status.Text= dr.GetValue(6).ToString();
                        
                    }

                }
                else
                {
                    Response.Write("<script>alert(' No Lawyer found !!');</script>");
                }


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{ex.Message}');");
            }
        }
        void UpdateLawyerStatusById(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE Lawyer SET LawyerStatus='" +status+ "' WHERE LawyerID='"+Ad_lawyerid.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                LawyerList.DataBind();
                Response.Write("<script>alert('Lawyer status Updated');</script>");
                ClearForm();


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{ex.Message}');");
            }
        }
        void DeleteLawyerById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Lawyer WHERE LawyerID='" + Ad_lawyerid.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Member Deleted Sucessfully');</script>");
                ClearForm();
                LawyerList.DataBind();
                


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{ex.Message}');");
            }
        }
        void ClearForm()
        {
            Ad_lawyerid.Text = string.Empty;
            Ad_fullname.Text = string.Empty;
            Ad_email.Text = string.Empty;
            Ad_username.Text = string.Empty;
            Ad_number.Text = string.Empty;
            status.Text = string.Empty;
        }

    }
}