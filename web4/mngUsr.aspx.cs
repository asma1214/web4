using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        public bool flag = false;
        public string msg = "";
        public string icon;
        public string title;
        public string errorMsg;
        public int a;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string emailPattern = @"^[0-9]{10}@iau.edu.sa$";
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
                    String sql = "INSERT INTO [login] (email, name) values('" + email.Value + "','" + empName.Value + "')";
                    command = new SqlCommand(sql, conn);
                    adapter.InsertCommand = new SqlCommand(sql, conn);
                    a = adapter.InsertCommand.ExecuteNonQuery();
                    //error happened while executing the query
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