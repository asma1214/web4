using System;
using System.Data.SqlClient;
using System.Data;


namespace web4
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-63JE2M4\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");
        SqlConnection conn = new SqlConnection("Data Source=HQ-JOWAHER\\WEBDB; Initial Catalog=webDB; User Id=sa; Password=webDB1234; Integrated Security=false");

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
            int colCount = dt.Columns.Count;
            if (Session["role"].ToString() == "a")
            {
                colCount = dt.Columns.Count + 1;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Response.Write("<tr style=\"text-align:right\">");
                for(int j=0; j < colCount; j++)
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
                    else if(j == 7)
                    {
                        string status = dt.Rows[i][6].ToString();
                        string sql = "SELECT comments,image FROM [transaction] WHERE tranNum=@tranNum";
                        if (Session["role"].ToString() == "a")
                        {

                            if (status == "s")
                            {
                                string id = dt.Rows[i][5].ToString();
                                using (SqlCommand command = new SqlCommand(sql,conn))
                                {
                                    if (conn.State == ConnectionState.Closed)
                                        conn.Open();
                                    command.Parameters.AddWithValue("@tranNum", id);
                                    SqlDataReader reader = command.ExecuteReader();
                                    reader.Read();
                                    string comm = reader["comments"].ToString();
                                    string tranImg = reader["image"].ToString();
                                    reader.Close();
                                    if (conn.State == ConnectionState.Open)
                                        conn.Close();
                                    Response.Write("<div style=\"justify-content:center; align-content:center\">");
                                    Response.Output.Write("<a role=\"button\" data-toggle=\"dropdown\" data-bs-toggle=\"modal\" data-bs-target=\"#{0}\" aria-haspopup=\"true\" aria-expanded=\"false\"><span style=\"color: #4e73df;\">عرض التفاصيل</span></a>","a"+id);
                                    Response.Write("</div>");
                                    Response.Output.Write("<div class=\"modal fade\" id=\"{0}\" data-bs-keyboard=\"false\" tabindex=\"-1\" aria-labelledby=\"staticBackdropLabel\" aria-hidden=\"true\">\r\n                        <div class=\"modal-dialog modal-dialog-centered modal-lg\">\r\n                            <div class=\"modal-content\">\r\n                                <div class=\"modal-header\">\r\n                                    <h1 class=\"modal-title fs-5\" id=\"staticBackdropLabel\">تفاصيل المعاملة</h1>\r\n\r\n                                </div>\r\n                                <div class=\"modal-body\">\r\n                                    <div class=\"container-fluid\">\r\n                                        <div class=\"row flex-row-reverse\">\r\n   <div class=\"col-md-6\"> <label for=\"empName\" class=\"labels\">:الملاحظة</label> <label for=\"empName\" class=\"labels\">{1}</label> </div>  <div class=\"col-md-6 mt-2\"><label for=\"empName\" class=\"labels\">:الصورة</label>  <img src ={2} class=\"imgSize\"/> </div>                                   </div>\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"modal-footer mt-4\">\r\n                                    <button type=\"button\" class=\"btn btn-secondary\" data-bs-dismiss=\"modal\">إغلاق</button>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>", "a" + id,comm,tranImg);
                                    //Response.Output.Write("<div class=\"modal fade\" id=\"{0}\" data-bs-keyboard=\"false\" tabindex=\"-1\" aria-labelledby=\"staticBackdropLabel\" aria-hidden=\"true\">\r\n                        <div class=\"modal-dialog modal-dialog-centered modal-lg\">\r\n                            <div class=\"modal-content\">\r\n                                <div class=\"modal-header\">\r\n                                    <h1 class=\"modal-title fs-5\" id=\"staticBackdropLabel\">الملف الشخصي</h1>\r\n\r\n                                </div>\r\n                                <div class=\"modal-body\">\r\n                                    <div class=\"container-fluid\">\r\n                                        <div class=\"row flex-row-reverse\">\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>", "a" + id);
                                //Response.Output.Write("<div class=\"modal fade\" id=\"{0}\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\">\r\n  <div class=\"modal-dialog modal-dialog-centered modal-lg\" role=\"document\">\r\n    <div class=\"modal-content\">\r\n      <div class=\"modal-header\">\r\n        <h5 class=\"modal-title\" id=\"exampleModalLabel\">Modal title</h5>\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n          <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n      </div>\r\n      <div class=\"modal-body\">\r\n        ...\r\n      </div>\r\n      <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n        <button type=\"button\" class=\"btn btn-primary\">Save changes</button>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>", "a"+id);
                                //Response.Write("<div class=\"modal fade bd-example-modal-lg\" id=\"recieveBut\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myLargeModalLabel\" aria-hidden=\"true\">\r\n            <div class=\"modal-dialog modal-lg\">\r\n                <div class=\"modal-content\">\r\n                    ...\r\n                </div>\r\n            </div>\r\n        </div>");
                                //Response.Write(" <div class=\"modal fade\" id=\"recieveBut\" data-bs-keyboard=\"false\" tabindex=\"-1\" aria-labelledby=\"staticBackdropLabel\" aria-hidden=\"true\">\r\n        <div class=\"modal-dialog modal-dialog-centered modal-lg\">\r\n            <div class=\"modal-content\">\r\n                <div class=\"modal-header\">\r\n                    <h1 class=\"modal-title fs-5\" id=\"staticBackdropLabel\">استلام المعاملة</h1>\r\n\r\n                </div>\r\n                <div class=\"modal-body\">\r\n                    <div class=\"container-fluid\">\r\n                        <div class=\"row flex-row-reverse\">\r\n                            <div class=\"col-6 px-4\">\r\n                                <div class=\"row flex-row-reverse \">\r\n                                </div>\r\n                                <div class=\"row\">\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-6 pe-2\">\r\n                                <div class=\"row flex-row-reverse\">\r\n                                </div>\r\n                                <div class=\"row\">\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>");
                                }
                                
                            }
                            else
                            {
                                Response.Write("<p>لم يتم استلامها بعد</p>");
                            }
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