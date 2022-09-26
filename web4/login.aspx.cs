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
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM users WHERE username='" + yourUsername.Value + "'", conn);
            //SELECT * FROM users WHERE username
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE username='" + yourUsername.Value + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            username = reader["username"].ToString();
            password = reader["password"].ToString();
            name = reader["name"].ToString();
            conn.Close();
            if(username == yourUsername.Value && password == yourPassword.Value)
            {
                Session["name"] = name;
                Response.Redirect("userSit.aspx");

            }
            else
            {
                this.errorMsg = "Invalid username or password";
            }


            //SqlCommand cmd = new SqlCommand("select userName, password FROM login WHERE userName=username AND password=password", conn);

            //SqlCommand cmd = new SqlCommand("insert into login values('" + yourUsername.Value + "','" + yourPassword.Value + "')", conn);
            //cmd.ExecuteNonQuery();
            //result.Text = "Record Sumbited successfully!";
          
            //{

                //    Response.Redirect("userSit.aspx");

                //    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                //    //this.Hide();
                //    // new home().Show();
                //}
                //else
                //{
                //    this.clients = "Invalid username or password";
                //    //this.clients = "Invalid username or password";
                //    //MessageBox.Show("Invalid username or password");
                //    conn.Close();



                //}


        }

    }




}