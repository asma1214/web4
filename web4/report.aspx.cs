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
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(),"showTable","showTable();" , true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "JavaScript", "showTable();", true);



            //string Date1 = fromDate.Value;
            //conn.Open();
            //SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN'" + fromDate.Value + "AND '" + toDate.Value + '"', conn);
            //SqlDataAdapter cmd = new SqlDataAdapter("SELECT * from [transaction] WHERE receivedDate BETWEEN '"+fromDate+"' AND '"+toDate+"' OR employeeName= '"+empName.Value+"'", conn);



            //DataTable dt = new DataTable();
            //cmd.Fill(dt);

        }
    }

}