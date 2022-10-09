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
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        DataTable dt = new DataTable();
        string date = "dd/MM/yyyy";


        protected void Page_Load(object sender, EventArgs e)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(),"showTable","showTable();" , true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            if(empName.Value.Length != 0)
            {
                if(fromDate.Value.Length != 0 && toDate.Value.Length != 0)
                {
                    int result = DateTime.Compare(DateTime.Parse(fromDate.Value), DateTime.Parse(toDate.Value));
                    if (result > 0)
                    {
                        errMsg = "نطاق تاريخ غير صالح";
                    }
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "' AND employeeName= '" + empName.Value + "'", conn);
                    conn.Open();
                    cmd.Fill(dt);
                    conn.Close();
                }
                else if(fromDate.Value.Length == 0 && toDate.Value.Length == 0)
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE employeeName= '" + empName.Value + "'", conn);
                    conn.Open();
                    cmd.Fill(dt);
                    conn.Close();
                }

                else if(fromDate.Value.Length == 0 || toDate.Value.Length == 0)
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

                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "'", conn);
                    conn.Open();
                    cmd.Fill(dt);
                    conn.Close();
                    }
                }



            }

            //if (empName.Value.Length == 0)
            //    if(fromDate.Value.Length == 0 || toDate.Value.Length == 0)
            //    {
            //         errMsg = "عليك اختيار نطاق من التاريخ";
            //    }
            //    else
            //    {

            //    SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '" +fromDate.Value+ "' AND '" +toDate.Value+ "'", conn);
            //    conn.Open();
            //    cmd.Fill(dt);
            //    conn.Close();
            //    }
            //else if(empName.Value.Length != 0)
            //{
            //    if(fromDate.Value.Length == 0 && toDate.Value.Length == 0)
            //    {
            //        SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE employeeName= '"+empName.Value+"'", conn);

            //    }
            //    else if (fromDate.Value.Length == 0 || toDate.Value.Length == 0)
            //         errMsg = "عليك اختيار نطاق من التاريخ";
            //    {

            //    }

            //}
            //else
            //{
            //    if (fromDate.Value.Length == 0 || toDate.Value.Length == 0)
            //    {
            //        errMsg = "عليك اختيار نطاق من التاريخ";
            //    }
            //    else
            //    {
            //        SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '"+fromDate+"' AND '"+toDate+"' AND employeeName= '"+empName.Value+"'", conn);

            //    }

            //}
            //SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN'" + fromDate.Value + "AND '" + toDate.Value + '"', conn);
            //SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '"+fromDate+"' AND '"+toDate+"' OR employeeName= '"+empName.Value+"'", conn);




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




