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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string errMsg;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        DataTable dt = new DataTable();
        string date = "dd/MM/yyyy";


        protected void Page_Load(object sender, EventArgs e)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(),"showTable","showTable();" , true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string role = Session["role"].ToString();
            if (role == "a")
            {

                if (empName.Value.Length != 0)
                {
                    if (fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                    {
                        int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                        if (result > 0)
                        {
                            errMsg = "نطاق تاريخ غير صالح";
                        }
                        string sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] " +
                            "WHERE receivedDate BETWEEN @fromDate AND @toDate AND employeeName= @empName";
                        //--- For SQL Injuction ---
                        SqlCommand command = new SqlCommand(sql,conn);
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@fromDate", fromDate.Value);
                        param[1] = new SqlParameter("@toDate", toDate.Value);
                        param[2] = new SqlParameter("@empName", empName.Value);
                        command.Parameters.Add(param[0]);
                        command.Parameters.Add(param[1]);
                        command.Parameters.Add(param[2]);
                        conn.Open();
                        dt.Load(command.ExecuteReader());
                        conn.Close();
                        //command.ExecuteNonQuery();
                        //SqlDataAdapter command1 = new SqlDataAdapter(sql, conn);
                        //command1.GetFillParameters();



                        //SqlDataAdapter cmd = new SqlDataAdapter("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] WHERE receivedDate BETWEEN '" 
                        //    + fromDate.Value + "' AND '" + toDate.Value + "' AND employeeName= '" + empName.Value + "'", conn);
                        //conn.Open();
                        ////cmd.Fill(dt);
                        //conn.Close();
                    }
                    else if (fromDate.Value.Length == 0 && toDate.Value.Length == 0)
                    {
                        string sql = "SELECT employeeName, receivedDate, recipient, senderParty, " +
                            "receivedParty, tranNum from [transaction] WHERE employeeName= @empName";
                        SqlCommand command = new SqlCommand(sql, conn);
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@empName", empName.Value);
                        command.Parameters.Add (param[0]);
                        conn.Open();
                        dt.Load(command.ExecuteReader());
                        conn.Close();


                        //SqlDataAdapter cmd = new SqlDataAdapter("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] WHERE employeeName= '" + empName.Value + "'", conn);
                        //conn.Open();
                        //cmd.Fill(dt);
                        //conn.Close();
                    }

                    else if (fromDate.Value.Length == 0 || toDate.Value.Length == 0)
                        errMsg = "عليك اختيار نطاق من التاريخ";

                }
                else
                {
                    if (fromDate.Value.Length == 0 || toDate.Value.Length == 0)
                        errMsg = "عليك اختيار نطاق من التاريخ";



                    else
                    {
                        int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                        if (result > 0)
                        {
                            errMsg = "نطاق تاريخ غير صالح";
                        }
                        else
                        {

                            string sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, " +
                                "tranNum from [transaction] WHERE receivedDate BETWEEN @fromDate AND @toDate";
                            SqlCommand command = new SqlCommand(sql, conn);
                            SqlParameter[] param = new SqlParameter[2];
                            param[0] = new SqlParameter("@fromDate", fromDate.Value);
                            param[1] = new SqlParameter("@toDate", toDate.Value);
                            command.Parameters.Add(param[0]);
                            command.Parameters.Add(param[1]);
                            conn.Open();
                            dt.Load(command.ExecuteReader());
                            conn.Close();


                            SqlDataAdapter cmd = new SqlDataAdapter("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction] WHERE receivedDate BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "'", conn);
                            conn.Open();
                            cmd.Fill(dt);
                            conn.Close();
                        }
                    }



                }
            }
            else
            {
                string email = Session["email"].ToString();
                int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                if (result > 0)
                {
                    errMsg = "نطاق تاريخ غير صالح";
                }

                string sql = "SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum" +
                        " from [transaction] WHERE receivedDate BETWEEN @fromDate AND @toDate AND email='" + Session["email"] + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@fromDate", fromDate.Value);
                param[1] = new SqlParameter("@toDate", toDate.Value);
                param[2] = new SqlParameter("@email", email);
                command.Parameters.Add(param[0]);
                command.Parameters.Add(param[1]);
                command.Parameters.Add(param[2]);
                conn.Open();
                dt.Load(command.ExecuteReader());
                conn.Close();



                //SqlDataAdapter cmd = new SqlDataAdapter("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum" +
                //        " from [transaction] WHERE receivedDate BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "' AND username= '" +username + "'", conn);
                //    conn.Open();
                //    cmd.Fill(dt);
                //    conn.Close();
                

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




