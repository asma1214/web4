using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;


namespace web4
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(tranNum);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Response.Write(dt.Rows[i]["tranNum"]);
            //    Response.Write("");
            //}
        }
        public int Print_Table()
        {
            string date = "dd/MM/yyyy";
            conn.Open();
            string role = Session["role"].ToString();
            string username = Session["username"].ToString();
            SqlDataAdapter cmd = new SqlDataAdapter();
            if (role == "a")
            {
                SqlCommand command = new SqlCommand("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum from [transaction]", conn);
                cmd.SelectCommand = command;
               // SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction]", conn);
            }
            else
            {
                SqlCommand command = new SqlCommand("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum " +
                    "FROM [transaction] INNER JOIN [login] on [transaction].[username] = [login].[username] WHERE[login].[username] = '" + username + "'", conn);
                //                SELECT[employeeName]
                //,[receivedDate]
                //      ,[recipient]
                //      ,[senderParty]
                //      ,[receivedParty]
                //      ,[tranNum]

                //                FROM[transaction] INNER JOIN[login] on[transaction].[username] = [login].[username] WHERE[login].[username] = 'huda90'

                // "SELECT (employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum) FROM [transaction] INNER JOIN [login] on [transaction].[username] = [login].[username] WHERE[login].[username] = '"+username+"'"
                cmd.SelectCommand = command;
            }

            DataTable dt = new DataTable();
            cmd.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr>");
                for(int j=0; j < dt.Columns.Count; j++)
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
            
            conn.Close();

            return 0;
        }




    }
}