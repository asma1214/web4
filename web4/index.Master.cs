using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web4
{
    public partial class index1 : System.Web.UI.MasterPage
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false; MultipleActiveResultSets=true");
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        public string password, name, email, phone;
        public bool flag = true;
        public string msg = "";
        public string icon;
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Header.DataBind();
            DataTable dt = new DataTable();
            try
            {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
                using (SqlDataAdapter cmd = new SqlDataAdapter("SELECT name, password, email, phone from [login] WHERE email = '" + Session["email"] + "' ", conn))
                {

                    cmd.Fill(dt);
                }


               // username = dt.Rows[0][0].ToString();
                name = dt.Rows[0][0].ToString();
                password = dt.Rows[0][1].ToString();
                email = dt.Rows[0][2].ToString();
                phone = dt.Rows[0][3].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();

        }


        protected void submit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");

        }

        protected void change(object sender, EventArgs e)
        {
            string empname = Request.Form["empName"];
            //string emusr = Request.Form["username"];
            string email = Request.Form["email"];
            string currentPass = Request.Form["currentPass"];
            string newPass = Request.Form["newPass"];
            string validPass = Request.Form["validPass"];
            string pass;
            string sql;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            bool isPassValid = Regex.IsMatch(newPass, pattern);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if ((String.IsNullOrEmpty(newPass)) == false)
            {
                if ((String.IsNullOrEmpty(currentPass)) == false && (String.IsNullOrEmpty(validPass) == false))
                {
                    sql = "SELECT password FROM [login] WHERE email = @email";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@email", Session["email"]);
                        cmd.Parameters.Add(param[0]);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        pass = reader["password"].ToString();
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }
                    bool varify = BCrypt.Net.BCrypt.Verify(currentPass, pass);
                    if (varify)
                    {
                        if (newPass == validPass)
                        {
                            if (isPassValid)
                            {
                                string myNewHash = BCrypt.Net.BCrypt.ValidateAndReplacePassword(currentPass, pass, newPass);

                                sql = " UPDATE [login] SET name = @empname , password = @newPass " +
                                    "WHERE email = @Session";
                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    if (conn.State == ConnectionState.Closed)
                                        conn.Open();
                                    cmd.Parameters.AddWithValue("@empname", empname);
                                    cmd.Parameters.AddWithValue("@newPass", myNewHash);
                                    cmd.Parameters.AddWithValue("@Session", Session["email"]);
                                   
                                    cmd.ExecuteNonQuery();
                                    if (conn.State == ConnectionState.Open)
                                        conn.Close();
                                }

                            }
                            else
                            {
                                msg = ".يرجى اختيار كلمة مرور أقوى. جرّب مزيجًا من الأحرف والأرقام";

                            }
                        }
                    }
                }
            }
            else
            {
                sql = "UPDATE [login] SET name = @empname WHERE email = @email";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@empname", empname);
                    cmd.Parameters.AddWithValue("@email", Session["email"]);
                    cmd.ExecuteNonQuery();
                    Session["name"] = empname;
                }


            }

            if (conn.State == ConnectionState.Open)
                conn.Close();




        }
    }
}
