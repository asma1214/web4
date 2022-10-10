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
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Print_Table()
        {
            string date = "dd/MM/yyyy";
            conn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT name,username,phone from [login]", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write("<td>");

                    Response.Write(dt.Rows[i][j].ToString());

                    Response.Write("</td>");



                }
                Response.Write("<td>");
                Response.Write(" <a class=\"add\" title=\"Add\" data-toggle=\"tooltip\"><i class=\"material-icons\">&#xE03B;</i></a>");
                Response.Write("<a class=\"edit\" title=\"Edit\" data-toggle=\"tooltip\"><i class=\"material-icons\">&#xE254;</i></a>\r\n");
                Response.Write("<a class=\"delete\" title=\"Delete\" data-toggle=\"tooltip\"><i class=\"material-icons\">&#xE872;</i></a>");
                Response.Write("</td>");
                Response.Write("</tr>");
            }

            conn.Close();

            return 0;
        }
    }
}