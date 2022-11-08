using System;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using Button = System.Web.UI.WebControls.Button;

namespace web4
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        DataTable dt = new DataTable();
        int transNum;
        int userID;
        string fileExt;
        public string msg;
        string path;
        public string icon;
        public string title;
        public bool flag1 = false;
        string path2;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int Print_Table()
        {
            try
            {


                string sql;
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
                string tranID;
                int count = 1;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Response.Write("<tr style=\"text-align:right\">");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write("<td>");
                        if (j == 0)
                        {
                            tranID = dt.Rows[i][j].ToString();
                            Response.Write(dt.Rows[i][j].ToString());
                        }
                        else if (j == 1)
                        {
                            Response.Write("معلق");
                            Response.Write(" <i class=\"fas fa-circle pen-color\"></i>");
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
        public int print_names()
        {
            try
            {
                SqlDataAdapter command = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string sql = "SELECT tranNum " +
                     "FROM [transaction] INNER JOIN [login] on [transaction].[userID] = [login].[userID] WHERE [login].[userID] = @userID AND status = 'p'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    command.SelectCommand = cmd;
                    command.Fill(dt);
                    //Response.Write("row: " + dt.Rows[0][0]);
                    Response.Write("<select name=\"tranNumber\" class=\"form-control form-control-user\" required>");
                    Response.Write("<option value=\"none\" selected disabled hidden>اختر رقم المعاملة</option>");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][0].ToString());


                    }


                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

                Response.Write("</select>");
                //transNum = Convert.ToInt32(Request.Form["tranNumber"]);
                //int value1 = Convert.ToInt32(Request.Form["employee_name"]);



            }
            catch (Exception ex)
            {
                //Response.Write("value: "+Request.Form["employee_name"]);
                Response.Write(ex.Message);
                //Response.Write("error1: "+ex.Message);
            }
            return 0;
        }


        public int printTrans()
        {
            SqlDataAdapter command = new SqlDataAdapter();
            string sql = "SELECT tranNum " +
                    "FROM [transaction] INNER JOIN [login] on [transaction].[userID] = [login].[userID] WHERE [login].[userID] = @userID AND status = @stat";
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.Parameters.AddWithValue("userID", userID);
                cmd.Parameters.AddWithValue("stat", "p");
                command.SelectCommand = cmd;
                command.Fill(dt);
                Response.Write("<select name=\"transNumber\" class=\"form-control form-control-user\">");
                Response.Write("<option value=\"none\" selected disabled hidden>اختر رقم المعاملة </option>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Response.Output.Write("<option value=\"{0}\">{1}</option>", dt.Rows[i].ToString(), dt.Rows[i].ToString());

                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            Response.Write("</select>");
            return 0;   
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                flag1 = true;
                transNum = Convert.ToInt32(Request.Form["tranNumber"]);
                if(transNum > 0)
                {
                    
                
                Response.Write(path2);
                msg = uploadFile();
                
                string comments = "";
                if (comment.SelectedIndex != 0)
                {
                    comments = comment.Items[comment.SelectedIndex].Text;
                }
                
                string sql = "UPDATE [transaction] SET status = 's', comments= @comments , image= @img WHERE tranNum=@tranNum";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.Parameters.AddWithValue("@comments", comments);
                    cmd.Parameters.AddWithValue("@img", path);
                    cmd.Parameters.AddWithValue("@tranNum", transNum);
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        msg = "لم يتم تأكيد المعاملة بنجاح";
                        icon = "error";
                        title = "!حدث خطأ";
                    }
                    else
                    {
                        msg = "تم تأكيد المعاملة بنجاح";
                        icon = "success";
                        title = "!تم بنجاح";
                    }
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                }
                }
                else
                {
                    msg = "عليك اختيار رقم  معاملة";
                    icon = "warning";
                    title = "!حدث خطأ"; 
                }


            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
          
        }

       
        protected string uploadFile()
        {
            
            try
            {
                string ext = @"^.*\.(jpg|JPG|jpeg|JPEG|png|PNG)$";
                if (img.HasFile)
                {
                    msg = "there is an img";
                    //get the file extension
                    fileExt = System.IO.Path.GetExtension(img.FileName);
                    bool isExtensionValid = Regex.IsMatch(fileExt.ToLower(), ext);
                    if (!isExtensionValid)
                    {
                        msg = "الصورة غير صالحة ، يجب اختيار امتداد png او jpg";
                    }
                    else
                    {
                        //create a folder
                        string folderPath = Server.MapPath("trangImage/");
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        //save the file to folder
                        img.SaveAs(folderPath + Path.GetFileName(img.FileName));
                        path2 = "trangImage/"+transNum+fileExt;
                        path = "trangImage/" + Path.GetFileName(img.FileName);
                        msg = "!تم ارفاق الصورة بنجاح";
                    }

                }
                else
                {
                    msg = "!يجب عليك إرفاق صورة";
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
            return msg;

        }


    }
}