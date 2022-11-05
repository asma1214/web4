using System;
using System.Data.SqlClient;
using System.Data;


namespace web4
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {
 
        }
        public int Print_Table()
        {
            string date = "dd/MM/yyyy";
            conn.Open();
            string role = Session["role"].ToString();
            string email = Session["email"].ToString();
            SqlDataAdapter cmd = new SqlDataAdapter();
            if (role == "a")
            {
                SqlCommand command = new SqlCommand("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum,status from [transaction]", conn);
                cmd.SelectCommand = command;
            
            }
            else
            {
                
                SqlCommand command = new SqlCommand("SELECT employeeName, receivedDate, recipient, senderParty, receivedParty, tranNum, status " +
                    "FROM [transaction] INNER JOIN [login] on [transaction].[email] = [login].[email] WHERE [login].[email] = '" + email + "'", conn);


              
                cmd.SelectCommand = command;
            }

            DataTable dt = new DataTable();
            cmd.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr style=\"text-align:right\">");
                for(int j=0; j < dt.Columns.Count; j++)
                {
                    Response.Write("<td>");
                    if (j == 1)
                    {
                        Response.Write(dt.Rows[i].Field<DateTime>("receivedDate").ToString(date));

                    }
                    else if(j == 6)
                    {
                        string status = dt.Rows[i][6].ToString();
                        if (status == "p") {
                            Response.Write("معلق");
                            Response.Write(" <i class=\"fas fa-circle pen-color\"></i>");
                        }
                        else
                        {

                            Response.Write("تم بنجاح");
                            Response.Write(" <i class=\"fas fa-circle sucess-color\"></i>");
                        }
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