using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls.Primitives;

namespace web4
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        string value = "";
        public string msg = "";
        public string icon;
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            value = Request.Form["employee_name"];
            int empID = Convert.ToInt32(Request.Form["employee_name"]);
            //Response.Write(empID);

            string sql = "";
            string employeeName;
            string empEmail;
            sql = "SELECT name, email FROM [login] WHERE userID= @id";
            int a;
            //SELECT password FROM [login] WHERE email = @email
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.Parameters.AddWithValue("@id", empID);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                employeeName = reader["name"].ToString();
                empEmail = reader["email"].ToString();
            }

            sql = "INSERT INTO [transaction] (employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum, email, status, userID)" +
             "VALUES (@employName, @recDate, @recipientName, @sendName, @recName, @tranNumber, @employEmail, @stat, @id)";
            //Response.Write(reciveDate.Value);
            //Response.Write(empEmail);

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State == ConnectionState.Closed)
                conn.Open();
                cmd.Parameters.AddWithValue("@employName", employeeName);
                cmd.Parameters.AddWithValue("@recDate", reciveDate.Value);
                cmd.Parameters.AddWithValue("@recipientName", reciever.Value); ;
                cmd.Parameters.AddWithValue("@sendName", senderAdress.Value);
                cmd.Parameters.AddWithValue("@recName", recieverAdress.Value);
                cmd.Parameters.AddWithValue("@tranNumber", Convert.ToInt32(tranID.Value));
                cmd.Parameters.AddWithValue("@employEmail", empEmail);
                cmd.Parameters.AddWithValue("@stat", "p");
                cmd.Parameters.AddWithValue("@id", empID);
                a = cmd.ExecuteNonQuery();
            }




                //if (a == 0)
                //{
                //    msg = "لم يتم إضافة المستخدم بنجاح";
                //    icon = "error";
                //    title = "!حدث خطأ";
                //}
                //else
                //{
                //    msg = "تم إضافة المستخدم بنجاح";
                //    icon = "success";
                //    title = "!تم بنجاح";
                //}

            if (conn.State == ConnectionState.Open)
                conn.Close();

        }
        public int print_names()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter command = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT userID, name FROM [login]";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                command.SelectCommand = cmd;
                command.Fill(dt);
                Response.Write("<select name=\"employee_name\" class=\"form-control form-control-user\">");
                Response.Write("<option value=\"none\" selected disabled hidden>اختر اسم الموظف</option>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());


                }


            }
            Response.Write("</select>");

            value = Request.Form["employee_name"];
            int value1 = Convert.ToInt32(Request.Form["employee_name"]);
            //Response.Write(value);
            //    char[] sep = { ',' };
            //string v = Request.Form.Get("empname");
            //    Response.Write(v);
            //    string v2 = v.Split(sep)[1];

            if (conn.State == ConnectionState.Open)
                conn.Close();
            return 0;
        }

    }
}