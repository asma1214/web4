using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace web4
{
    
    public partial class login : System.Web.UI.Page
    {
        public string errorMsg;
        // private string errorMsg = "Sorry, your password or username was incorrect.";

        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            string username;
            string password;
            string name;
            string role;
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE username='" + yourUsername.Value + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            username = reader["username"].ToString();
            password = reader["password"].ToString();
            name = reader["name"].ToString();
            role = reader["role"].ToString();
            conn.Close();
            if(username == yourUsername.Value && password == yourPassword.Value)
            {
                if(role == "a") { 
                Session["name"] = name;
                Response.Redirect("userSit.aspx");
                }
                else
                {

                }
                Session["role"] = role;

            }
            else
            {
                this.errorMsg = "Invalid username or password";
            }

        }

   
    }




}