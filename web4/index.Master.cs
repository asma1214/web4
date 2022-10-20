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
    public partial class index1 : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        public string username, password, name, email, phone;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT username, name, password, email, phone from [login] WHERE username = '" + Session["username"] + "' ", conn);
                conn.Open();
                cmd.Fill(dt);
                conn.Close();

                username = dt.Rows[0][0].ToString();
                name = dt.Rows[0][1].ToString();
                password = dt.Rows[0][2].ToString();
                email = dt.Rows[0][3].ToString();
                phone = dt.Rows[0][4].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }


        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");

        }

        //protected void change(object sender, EventArgs e)
        //{
        //    string empname = Request.Form["empName"];
        //    string emusr = Request.Form["username"];
        //    if(empname != name || emusr != username)
        //    {
        //        SqlDataAdapter cmd = new SqlDataAdapter("UPDATE username, name, password, email, phone from [login] WHERE username = '" + Session["username"] + "' ", conn);


        //    }

        //}
    }
}