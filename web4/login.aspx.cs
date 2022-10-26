using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            bool varify = BCrypt.Net.BCrypt.Verify(yourPassword.Value, password);
            if (username == yourUsername.Value)
            {
                if (varify)
                {
                Session["name"] = name;
                Session["role"] = role;
                Session["username"] = username;
                Response.Redirect("userSit.aspx");

                }


            }
            else
            {
                this.errorMsg = "Invalid username or password";
            }

        }

   
    }




}