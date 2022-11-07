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
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int Print_Table()
        {
            try
            {


                string sql;
                conn.Open();
                int userID;
                sql = "SELECT userID from [login] WHERE email = @userEmail";
                //--- For SQL Injuction ---
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

                //SqlDataAdapter cmd = new SqlDataAdapter();
                sql = "SELECT tranNum, status " +
                    "FROM [transaction] INNER JOIN [login] on [transaction].[userID] = [login].[userID] WHERE [login].[userID] = @userID AND status = @stat";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.Parameters.AddWithValue("userID", userID);
                    cmd.Parameters.AddWithValue("stat", "p");
                    dt.Load(cmd.ExecuteReader());
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Response.Write("<tr style=\"text-align:right\">");
                    for (int j = 0; j < dt.Columns.Count + 1; j++)
                    {
                        Response.Write("<td>");
                        if (j == 0)
                        {
                            Response.Write(dt.Rows[i][j].ToString());
                        }
                        else if (j == 1)
                        {
                            Response.Write("معلق");
                            Response.Write(" <i class=\"fas fa-circle pen-color\"></i>");
                        }
                        else
                        {
                            Response.Write("<div style=\"justify-content:center; align-content:center\">");
                            //Response.Write("<button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#recieveBut\">استلام</button>");
                            //Response.Write("<a class=\"nav-link dropdown-toggle\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\" data-bs-toggle=\"modal\" data-bs-target=\"#recieveBut\">");
                            //Response.Write("<span class=\"mr-2 d-none d-lg-inline text-gray-600 small\">استلام</span>");

                            //Response.Write("<button class=\"btn btn-primary w-100\" OnClick=\"submit_Click\"runat=\"server\" data-bs-toggle=\"modal\" data-bs-target=\"#recieveBut\">استلام</button>");
                            Response.Write("</div>");
                        }


                        Response.Write("</td>");
                    }

                    Response.Write("</tr>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
            return 0;
        }

        protected void submit_Click(object sender, EventArgs e)
        {


        }
    }
}