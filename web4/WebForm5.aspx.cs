﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT name FROM [login] WHERE userID= '" + value + "'";
            int a;
            //SELECT password FROM [login] WHERE email = @email
            //using (SqlCommand cmd = new SqlCommand(sql, conn))
            //{

            //}
                //string v = "أسماء,1";
                //char[] spearator = { ','};
                //string v2 = v.Split(spearator)[1] ;
                //Response.Write(v2);

            }
        public int print()
        {
            SqlDataAdapter command = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT userID, name FROM [login]";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                command.SelectCommand = cmd;
                command.Fill(dt);
                Response.Write(" <select name=\"empname\" id=\"empmame\">");
                Response.Write("<option value=\"none\" selected disabled hidden>اختر اسم الموظف</option>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());


                }


            }
            Response.Write("</select>");
             value = Request.Form["empname"];
    
           // Response.Write(value);
            //    char[] sep = { ',' };
            //string v = Request.Form.Get("empname");
            //    Response.Write(v);
            //    string v2 = v.Split(sep)[1];


            return 0;
        }
        protected void submit_Click(object sender, EventArgs e)
        {

            string sql = "SELECT name FROM login WHERE userID= 3";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

        }
    }
}