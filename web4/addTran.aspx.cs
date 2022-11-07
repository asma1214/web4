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
        public bool clicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                clicked = true;
                bool exist = false;

                value = Request.Form["employee_name"];
                int empID = Convert.ToInt32(Request.Form["employee_name"]);
                string sql = "";
                string employeeName;
                string empEmail;
                int a;
                if (value == null || reciveDate.Value.Length == 0 || reciever.Value.Length == 0 || senderAdress.Value.Length == 0 || recieverAdress.Value.Length == 0 || tranID.Value.Length == 0)
                {
                    msg = "يجب تعبئة جميع الحقول";
                    icon = "warning";
                    title = "!حدث خطأ";
                }
                else
                {



                    sql = "SELECT name, email FROM [login] WHERE userID= @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        cmd.Parameters.AddWithValue("@id", empID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        employeeName = reader["name"].ToString();
                        empEmail = reader["email"].ToString();
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }


                    if (tranID.Value.Length < 5)
                    {
                        msg = "يجب ان يتكون رقم المعاملة من 5 ارقام";
                        icon = "warning";
                        title = "!حدث خطأ";
                    }
                    else
                    {
                        sql = "SELECT count(*) FROM [transaction] WHERE tranNum = @tranNumber";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            cmd.Parameters.Add("@tranNumber", SqlDbType.Int).Value = Convert.ToInt32(tranID.Value);
                            a = Convert.ToInt32(cmd.ExecuteScalar());
                            if (a > 0)
                            {
                                exist = (int)cmd.ExecuteScalar() > 0;

                            }
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                        if (exist)
                        {
                            msg = "رقم المعاملة مسجل مسبقًا";
                            icon = "warning";
                            title = "!حدث خطأ";
                        }

                        else
                        {
                            sql = "INSERT INTO [transaction] (employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum, email, status, userID) VALUES (@employName, @recDate, @recipientName, @sendName, @recName, @tranNumber, @employEmail, @stat, @id)";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                cmd.Parameters.Add("@employName", SqlDbType.NVarChar).Value = employeeName;
                                cmd.Parameters.Add("@recDate", SqlDbType.Date).Value = reciveDate.Value;
                                cmd.Parameters.Add("@recipientName", SqlDbType.NVarChar).Value = reciever.Value;
                                cmd.Parameters.Add("@sendName", SqlDbType.NVarChar).Value = senderAdress.Value;
                                cmd.Parameters.Add("@recName", SqlDbType.NVarChar).Value = recieverAdress.Value;
                                cmd.Parameters.Add("@tranNumber", SqlDbType.Int).Value = Convert.ToInt32(tranID.Value);
                                cmd.Parameters.Add("@employEmail", SqlDbType.NVarChar).Value = empEmail;
                                cmd.Parameters.Add("@stat", SqlDbType.NVarChar).Value = "p";
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = empID;
                                a = cmd.ExecuteNonQuery();
                                if (a == 0)
                                {
                                    msg = "لم يتم إضافة المعاملة بنجاح";
                                    icon = "error";
                                    title = "!حدث خطأ";
                                }
                                else
                                {
                                    msg = "تم إضافة المعاملة بنجاح";
                                    icon = "success";
                                    title = "!تم بنجاح";
                                }


                            }
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Response.Write("error2: "+ ex.Message);
            }

        }
        public int print_names()
        {
            try
            {
                SqlDataAdapter command = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string sql = "SELECT userID, name FROM [login] where role = 'u'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                    command.SelectCommand = cmd;
                    command.Fill(dt);
                    Response.Write("<select name=\"employee_name\" class=\"form-control form-control-user\" required>");
                    Response.Write("<option value=\"none\" selected disabled hidden>اختر اسم الموظف</option>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());


                    }


                if (conn.State == ConnectionState.Open)
                    conn.Close();
                }
                Response.Write("</select>");

                value = Request.Form["employee_name"];
                int value1 = Convert.ToInt32(Request.Form["employee_name"]);

            }
            catch(Exception ex)
            {
                //Response.Write("value: "+Request.Form["employee_name"]);
                if(Request.Form["employee_name"] == null)
                {
                    Response.Write("yes");
                }
                //Response.Write("error1: "+ex.Message);
            }
                return 0;
        }

    }
}