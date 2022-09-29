using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        protected void Page_Load(object sender, EventArgs e)
        {
            // string connStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //SqlConnection conn = new SqlConnection(connStr);
            
            //Response.Write(tranNum);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Response.Write(dt.Rows[i]["tranNum"]);
            //    Response.Write("");
            //}
            //string sql = "SELECT * from [transaction]";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //reader.Read();
            //convert.toInt32(reader.getValue(0))
            //int tranNum = Convert.ToInt32(reader["tranNum"]);
            //Response.Write(tranNum);

        }
        public int Print_Table()
        {
            conn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction]", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            //for(int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Response.Write("<tr>");
            //    for(int j=0; j < dt.Columns.Count; j++)
            //    {
            //    }
            //    Response.Write("</tr>");
            //}
            string tranNum = dt.Rows[0][1].ToString();

            Response.Write(dt.Rows[0]["receivedDate"]);
            //Response.Write(dt.Rows[0][0]);

            return 0;
        }
    }
}
