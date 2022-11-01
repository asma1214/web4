using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace web4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        public bool flag = false;
        public string msg = "";
        public string icon;
        public string title;
        public string errorMsg;
        public int a;
        String sql;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string emailPattern = @"^[a-z0-9](\.?[a-z0-9]){5,}@(?:iau.edu.sa)$";
            bool isEmailValid = Regex.IsMatch(email.Value, emailPattern);
            flag = true;

            if ((String.IsNullOrEmpty(email.Value)) || (String.IsNullOrEmpty(empName.Value)))
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
                        //int a = cmd.ExecuteNonQuery();
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

                        //sql = "INSERT INTO [login] (email, name, role) values('" + email.Value + "','" + empName.Value + "')";
                        //command = new SqlCommand(sql, conn);
                        //adapter.InsertCommand = new SqlCommand(sql, conn);
                        //a = adapter.InsertCommand.ExecuteNonQuery();
                        //error happened while executing the query

                        sql = "INSERT INTO [login] (email, name, role) values(@email, @name, @role)";
                        command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@email", email.Value);
                        command.Parameters.AddWithValue("@name", empName.Value);
                        command.Parameters.AddWithValue("@role", "u");
                        a = command.ExecuteNonQuery();
                       

                        //SqlParameter[] param = new SqlParameter[3];
                        //param[0] = new SqlParameter("email", email.Value);
                        //param[1] = new SqlParameter("name", empName.Value);
                        //param[2] = new SqlParameter("role", "u");
                        ////adapter.InsertCommand = new SqlCommand(sql, conn);
                        //command.Parameters.Add(param[0]);
                        //command.Parameters.Add(param[1]);
                        //command.Parameters.Add(param[2]);
                        //a = adapter.InsertCommand.ExecuteNonQuery();
                        if(a == 0)
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
    }
}