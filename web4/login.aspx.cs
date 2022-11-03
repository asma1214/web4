using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Data;
using System.IO;

namespace web4
{
    
    public partial class login : System.Web.UI.Page
    {
        public string errorMsg;
        // private string errorMsg = "Sorry, your password or username was incorrect.";

        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string email;
                //string username;
                string password;
                string name;
                string role;

                string emailPattern = @"^[a-z0-9](\.?[a-z0-9]){5,}@(?:iau.edu.sa)$";
                bool isEmailValid = Regex.IsMatch(yourEmail.Value, emailPattern);


                SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE email= @email", conn);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@email", yourEmail.Value);
                cmd.Parameters.Add(param[0]);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteReader();

                if (conn.State == ConnectionState.Open)
                    conn.Close();


                if (isEmailValid)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    //username = reader["username"].ToString();
                    email = reader["email"].ToString();
                    password = reader["password"].ToString();
                    name = reader["name"].ToString();
                    role = reader["role"].ToString();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    bool varify = BCrypt.Net.BCrypt.Verify(yourPassword.Value, password);
                    // if (username == yourUsername.Value)

                    if (email == yourEmail.Value && varify)
                    {
                        Session["name"] = name;
                        Session["role"] = role;
                        //Session["username"] = username;
                        Session["email"] = email;

                        Response.Redirect("userSit.aspx");
                    }
                    else
                    {
                            this.errorMsg = "البريد الإلكتروني او كلمة المرور غير صحيحة";
                    }

                    
                }
                else
                {
                    this.errorMsg = "لم يتم العثور على حسابك في مراسلات";
                }
            }
            catch(Exception ex)
            {
                this.LogError(ex);
            }

        }

        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }




    }




}