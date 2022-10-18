using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        public bool flag = false;
        public string msg = "";
        public string icon;
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            flag = true;
            //SqlDataAdapter cmd = new SqlDataAdapter("INSERT INTO [login] (username, name) values('"+username.Value+"','"+empName.Value+"')", conn);
            conn.Open();
            //conn.Close();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "INSERT INTO [login] (username, name) values('" + username.Value + "','" + empName.Value + "')";
            command = new SqlCommand(sql, conn);
            adapter.InsertCommand = new SqlCommand(sql, conn);
            int a = adapter.InsertCommand.ExecuteNonQuery();
            if (a == 0) { 
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
}