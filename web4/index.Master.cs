using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;


namespace web4
{
    public partial class index1 : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false; MultipleActiveResultSets=true");
        public string username, password, name, email, phone;
        public bool flag = true;
        public string msg = "";
        public string icon;
        public string title;
        Button checkButton = new Button();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();


            }
            Page.Header.DataBind();
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter("SELECT username, name, password, email, phone from [login] WHERE username = '" + Session["username"] + "' ", conn))
                {

                    cmd.Fill(dt);
                }


                username = dt.Rows[0][0].ToString();
                name = dt.Rows[0][1].ToString();
                password = dt.Rows[0][2].ToString();
                email = dt.Rows[0][3].ToString();
                phone = dt.Rows[0][4].ToString();
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
            string emusr = Request.Form["username"];
            string currentPass = Request.Form["currentPass"];
            string newPass = Request.Form["newPass"];
            string validPass = Request.Form["validPass"];
            string pass;
            string sql;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if ((String.IsNullOrEmpty(newPass)) == false)
            {
                if ((String.IsNullOrEmpty(currentPass)) == false && (String.IsNullOrEmpty(validPass) == false))
                {
                    sql = "SELECT password FROM [login] WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@emusr", Session["username"]);
                        cmd.Parameters.Add(param[0]);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        pass = reader["password"].ToString();
                    }
                    bool varify = BCrypt.Net.BCrypt.Verify(currentPass, pass);
                    if (varify)
                    {
                        if (newPass == validPass)
                        {
                            string myNewHash = BCrypt.Net.BCrypt.ValidateAndReplacePassword(currentPass, pass, newPass);

                            sql = " UPDATE [login] SET username = @emusr ,name = @empname , password = @newPass " +
                                "WHERE username = @Session";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                SqlParameter[] param = new SqlParameter[4];
                                param[0] = new SqlParameter("@emusr", emusr);
                                param[1] = new SqlParameter("@empname", empname);
                                param[2] = new SqlParameter("@newPass", myNewHash);
                                param[3] = new SqlParameter("@Session", Session["username"]);
                                cmd.Parameters.Add(param[0]);
                                cmd.Parameters.Add(param[1]);
                                cmd.Parameters.Add(param[2]);
                                cmd.Parameters.Add(param[3]);
                                cmd.ExecuteReader();
                                if (conn.State == ConnectionState.Open)
                                    conn.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                sql = "UPDATE [login] SET username = @emusr , name = @empname WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteReader();
                }


            }

            if (conn.State == ConnectionState.Open)
                conn.Close();




        }
    }
}
