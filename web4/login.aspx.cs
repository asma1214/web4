using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace web4
{
    
    public partial class login : System.Web.UI.Page
    {
        public string errorMsg;
        // private string errorMsg = "Sorry, your password or username was incorrect.";

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string email;
            string username;
            string password;
            string name;
            string role;
            string emailPattern = @"^[0-9]{10}@iau.edu.sa$";
            bool isEmailValid = Regex.IsMatch(yourEmail.Value, emailPattern);

            // SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE username='" + yourUsername.Value + "'", conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE email='" + yourEmail.Value + "'", conn);

            if (isEmailValid)
            {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            //username = reader["username"].ToString();
            email = reader["email"].ToString();
            password = reader["password"].ToString();
            name = reader["name"].ToString();
            role = reader["role"].ToString();

            bool varify = BCrypt.Net.BCrypt.Verify(yourPassword.Value, password);
            conn.Close();
            // if (username == yourUsername.Value)
  
                if (email == yourEmail.Value)
                {
                    if (varify)
                    {
                    Session["name"] = name;
                    Session["role"] = role;
                  //Session["username"] = username;
                    Session["email"] = email;
                    Response.Redirect("userSit.aspx");
                    }
                    else
                    {
                        this.errorMsg = "Please enter a valid password";
                    }

                }
                else
                {
                    this.errorMsg = "Invalid email or password";
                }
            }
            else
            {
                this.errorMsg = "Please enter a valid email";
            }

        }
        // CS0234.cs  
        //public class C
        //{
        //    public static void Main()
        //    {
        //        //System.DateTime x = new System.DateTim();   // CS0234  
        //                                                    // try the following line instead  
        //        System.DateTime x = new System.DateTime();  
        //    }
        //}


    }




}