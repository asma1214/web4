using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
 
namespace web4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=HQ-JOWAHER\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");

        public bool flag = false;
        public string msg = "";
        public string icon;
        public string title;
        public string errorMsg;
        public int k;
        String sql;
        string role1;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is HttpUnhandledException)
            {

                Response.Write("An error occurred on this page. Please verify your " +
                 "information to resolve the issue.");
            }
            // Clear the error from the server.
            Server.ClearError();
        }
        

            protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
               /*string password = Request.Form["password"]; 
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20); // 20 is the length of the hash
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string passwordHash = Convert.ToBase64String(hashBytes);*/


               string emailPattern = @"^[a-z0-9](\.?[a-z0-9]){5,}@(?:iau.edu.sa)$";
               bool isEmailValid = Regex.IsMatch(email.Value, emailPattern);
               flag = true;
               string passpattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
               bool ispassValid = Regex.IsMatch(password.Value, passpattern);
               flag = true;
               
                    // bool isAdmin = Convert.ToBoolean(Request.Form["admin1"]);
                role1 = admin1.Checked ? "a" : "u";

              string passwordHash = BCrypt.Net.BCrypt.HashPassword(password.Value);

                if ((String.IsNullOrEmpty(email.Value)) || (String.IsNullOrEmpty(empName.Value) ||
                    (String.IsNullOrEmpty(password.Value))))
                {
                    msg = "يجب عليك تعبئة جميع الحقول";
                    icon = "error";
                    title = "!حدث خطأ";
                }
                else
                {

                    if (isEmailValid)
                    {
                        conn.Open();
                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        sql = "SELECT count(*) FROM [login] WHERE email = @email";
                        bool exist = false;
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            SqlParameter[] param = new SqlParameter[1];
                            param[0] = new SqlParameter("@email", email.Value);
                            cmd.Parameters.Add(param[0]);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                                exist = (int)cmd.ExecuteScalar() > 0;
                        }

                        if (exist)
                        {
                            msg = "البريد الإلكتروني مسجل مسبقًا";
                            icon = "warning";
                            title = "!حدث خطأ";
                        }

                        else
                        {
                            // bool isAdmin = Convert.ToBoolean(Request.Form["admin1"]);
                            //  role1 = admin1.Checked ? "a" : "u";
                            //  string passwordHash= System.Web.Helpers.Crypto.HashPassword(password)
                           // string passwordHash = BCrypt.Net.BCrypt.HashPassword(password.Value);

                            sql = "INSERT INTO [login] (email, password, name, role) values(@email,@password, @name, @role)";
                            command = new SqlCommand(sql, conn);
                            command.Parameters.AddWithValue("@email", email.Value);
                            command.Parameters.AddWithValue("@name", empName.Value);
                            command.Parameters.AddWithValue("@password", passwordHash);
                            command.Parameters.AddWithValue("@role", role1);
                            k = command.ExecuteNonQuery();

                        }




                        if (k == 0)
                        {
                            msg = "لم يتم إضافة المستخدم بنجاح";
                            icon = "error";
                            title = "!حدث خطأ";
                        }
                        else
                        {
                            msg = "تم إضافة المستخدم بنجاح";
                            icon = "success";
                            title = "!تم بنجاح";
                        }
                    }

                    else
                    {
                        //invalid email format
                        msg = "صيغة البريد الإلكتروني غير صحيحة";
                        icon = "warning";
                        title = "!حدث خطأ";
                    }   
            }




        }
            //*
            catch(HttpRequestValidationException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
    }
    }
}