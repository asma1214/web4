using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace web4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string errMsg;
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        DataTable dt = new DataTable();
        string date = "dd/MM/yyyy";


        protected void Page_Load(object sender, EventArgs e)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(),"showTable","showTable();" , true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {


                string sql;
                string role = Session["role"].ToString();
                if (role == "a")
                {

                    if (empName.Value.Length != 0)
                    {
                        if (tranNum.Value.Length != 0)
                        {

                            if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                            {
                                int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                                if (result > 0)
                                {
                                    errMsg = "نطاق تاريخ غير صالح";
                                }
                                sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] " +
                                    "WHERE receivedDate BETWEEN @fromDate AND @toDate AND employeeName= @empName AND tranNum = @tranNumber";
                                //--- For SQL Injuction ---
                                SqlCommand command = new SqlCommand(sql, conn);
                                SqlParameter[] param = new SqlParameter[4];
                                param[0] = new SqlParameter("@fromDate", fromDate.Value);
                                param[1] = new SqlParameter("@toDate", toDate.Value);
                                param[2] = new SqlParameter("@empName", empName.Value);
                                param[3] = new SqlParameter("@tranNumber", Convert.ToInt32(tranNum.Value));
                                command.Parameters.Add(param[0]);
                                command.Parameters.Add(param[1]);
                                command.Parameters.Add(param[2]);
                                command.Parameters.Add(param[3]);
                                conn.Open();
                                dt.Load(command.ExecuteReader());
                                if (dt != null)
                                    if (dt.Rows.Count == 0)
                                    {
                                        errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                    }
                                conn.Close();

                            }
                            else
                            {
                                errMsg = "عليك تعبئة جميع الحقول";
                            }

                        }
                        else if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                        {
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] " +
                                    "WHERE receivedDate BETWEEN @fromDate AND @toDate AND employeeName= @empName";
                            //--- For SQL Injuction ---
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlParameter[] param = new SqlParameter[3];
                            param[0] = new SqlParameter("@fromDate", fromDate.Value);
                            param[1] = new SqlParameter("@toDate", toDate.Value);
                            param[2] = new SqlParameter("@empName", empName.Value);
                            command.Parameters.Add(param[0]);
                            command.Parameters.Add(param[1]);
                            command.Parameters.Add(param[2]);
                            conn.Open();
                            dt.Load(command.ExecuteReader());
                            if (dt != null)
                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }
                            conn.Close();

                        }
                        else
                        {
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, " +
                                "receivedParty, tranNum from [transaction] WHERE employeeName= @empName";
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlParameter[] param = new SqlParameter[1];
                            param[0] = new SqlParameter("@empName", empName.Value);
                            command.Parameters.Add(param[0]);
                            conn.Open();
                            dt.Load(command.ExecuteReader());
                            if (dt != null)
                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }
                            conn.Close();
                        }
                    }
                    else if (tranNum.Value.Length != 0)
                    {
                        if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                        {
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] " +
                                    "WHERE receivedDate BETWEEN @fromDate AND @toDate AND tranNum= @tranNumber";
                            //--- For SQL Injuction ---
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlParameter[] param = new SqlParameter[3];
                            param[0] = new SqlParameter("@fromDate", fromDate.Value);
                            param[1] = new SqlParameter("@toDate", toDate.Value);
                            param[2] = new SqlParameter("@tranNumber", Convert.ToInt32(tranNum.Value));
                            command.Parameters.Add(param[0]);
                            command.Parameters.Add(param[1]);
                            command.Parameters.Add(param[2]);
                            conn.Open();
                            dt.Load(command.ExecuteReader());
                            if (dt != null)
                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }
                            conn.Close();

                        }
                        else
                        {
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, " +
                                "receivedParty, tranNum from [transaction] WHERE tranNum= @tranNumber";
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlParameter[] param = new SqlParameter[1];
                            param[0] = new SqlParameter("@tranNumber", Convert.ToInt32(tranNum.Value));
                            command.Parameters.Add(param[0]);
                            conn.Open();
                            dt.Load(command.ExecuteReader());
                            if (dt != null)
                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }
                            conn.Close();

                        }
                    }
                    else
                    {
                        if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                        {
                            int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                                if (result > 0)
                                {
                                    errMsg = "نطاق تاريخ غير صالح";
                                }
                                else
                                {

                                    sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, " +
                                        "tranNum from [transaction] WHERE receivedDate BETWEEN @fromDate AND @toDate";
                                    SqlCommand command = new SqlCommand(sql, conn);
                                    SqlParameter[] param = new SqlParameter[2];
                                    param[0] = new SqlParameter("@fromDate", fromDate.Value);
                                    param[1] = new SqlParameter("@toDate", toDate.Value);
                                    command.Parameters.Add(param[0]);
                                    command.Parameters.Add(param[1]);
                                    conn.Open();
                                    dt.Load(command.ExecuteReader());
                                    if (dt != null)
                                        if (dt.Rows.Count == 0)
                                        {
                                            errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                        }
                                    conn.Close();
                                }
                        }
                        else
                        {
                            errMsg = "يجب تعبئة جميع الحقول";
                        }
                    }

                }
                else
                {
                    int userID;
                            sql = "SELECT userID from [login] WHERE email = @userEmail";
                            //--- For SQL Injuction ---
                            using(SqlCommand cmd = new SqlCommand(sql, conn))
                            {

                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                cmd.Parameters.AddWithValue("@userEmail", Session["email"]);
                                SqlDataReader reader = cmd.ExecuteReader();
                                reader.Read();
                                userID = Convert.ToInt32(reader["userID"].ToString());
                                if (conn.State == ConnectionState.Open)
                                    conn.Close();


                            }
                    if(tranNum.Value.Length != 0)
                    {
                        if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                        {
                            int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                            if (result > 0)
                            {
                                errMsg = "نطاق تاريخ غير صالح";
                            }
                            else
                            {
                                //search transaction number and date
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] " +
                                   "WHERE receivedDate BETWEEN @fromDate AND @toDate AND userID= @id";
                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    if (conn.State == ConnectionState.Closed) { 
                                        conn.Open();
                                }
                                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Value);
                                    cmd.Parameters.AddWithValue("@toDate", toDate.Value);
                                    cmd.Parameters.AddWithValue("@id", userID);
                                    dt.Load(cmd.ExecuteReader());
                                    if (conn.State == ConnectionState.Open)
                                        conn.Close();
                            }

                            if (dt != null)
                            {

                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }
                            }
                            }
                        }
                        else 
                        {
                            
                            if (fromDate.Value.Length == 0 && toDate.Value.Length == 0)
                            {


                            //search with transaction number ONLY
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, " +
                                "receivedParty, tranNum from [transaction] WHERE tranNum= @tranNumber AND userID = @id";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                cmd.Parameters.AddWithValue("@tranNumber", Convert.ToInt32(tranNum.Value));
                                cmd.Parameters.AddWithValue("@id", userID);
                                dt.Load(cmd.ExecuteReader());
                                if (conn.State == ConnectionState.Open)
                                    conn.Close();

                            }
                            if (dt != null)
                                if (dt.Rows.Count == 0)
                                {
                                    errMsg = "لا يوجد بيانات وفقًا لمدخلات البحث";
                                }

                            }
                            else
                            {
                                errMsg = "نطاق تاريخ غير صالح";
                            }

                        }

                    }
                    else if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                    {
                        int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                        if (result > 0)
                        {
                            errMsg = "نطاق تاريخ غير صالح";
                        }
                        else
                        {
                            //search with date ONLY
                            sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum" +
                                " from [transaction] WHERE receivedDate BETWEEN @fromDate AND @toDate AND userID = @id";
                            using(SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                cmd.Parameters.AddWithValue("@fromDate", fromDate.Value);
                                cmd.Parameters.AddWithValue("@toDate", toDate.Value);
                                cmd.Parameters.AddWithValue("@id", userID);
                                dt.Load(cmd.ExecuteReader());
                                if (conn.State == ConnectionState.Open)
                                    conn.Close();
                            }
                        }

                    }
                    else
                    {
                        errMsg = "يجب تعبئة جميع الحقول";
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.StackTrace);
                Response.Write(ex.Message);
            }

        }






        public int Print_Table()
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write("<td>");
                    if (j == 1)
                    {
                        Response.Write(dt.Rows[i].Field<DateTime>("receivedDate").ToString(date));

                    }
                    else
                    {
                        Response.Write(dt.Rows[i][j].ToString());

                    }
                    Response.Write("</td>");

                }
                Response.Write("</tr>");
            }

            if(dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "JavaScript", "showTable();", true);

            }
            return 0;
        }
    }

}




