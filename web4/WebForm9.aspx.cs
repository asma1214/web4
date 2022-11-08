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
    public partial class WebForm9 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Request.Form["trial"];
            //Response.Write("id: "+ id);
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string id = Request.Form["trial"];
            Response.Write("hi");
            Response.Write("id: " + id);
            //   string v=
            //        Request.Form["employee_name"];
            //    string sql = "SELECT name FROM [login] WHERE userID= '" + v + "'";
            //    int a;
            //    //SELECT password FROM [login] WHERE email = @email
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        //cmd.Parameters.AddWithValue("@id", value1);
            //        //SqlDataReader reader = cmd.ExecuteReader();
            //        //reader.Read();
            //        cmd.ExecuteNonQuery();
            //    }
            //    }

            //public int print_names()
            //{
            //    SqlDataAdapter command = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    string sql = "SELECT userID, name FROM [login]";
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        command.SelectCommand = cmd;
            //        command.Fill(dt);
            //        Response.Write(" <select name=\"employee_name\" class=\"form-control form-control-user\">");
            //        Response.Write("<option value=\"none\" selected disabled hidden>اختر اسم الموظف</option>");
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {

            //            Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());


            //        }


            //    }
            //    Response.Write("</select>");
            //    //value = Request.Form["empname"];
            //    //Response.Write(value);
            //    //    char[] sep = { ',' };
            //    //string v = Request.Form.Get("empname");
            //    //    Response.Write(v);
            //    //    string v2 = v.Split(sep)[1];


            //    return 0;
        }
    }

}