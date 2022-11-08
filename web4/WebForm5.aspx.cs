using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.HtmlControls;
using System.Windows.Documents;
using System.Security.Cryptography.X509Certificates;

namespace web4
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");
        string value;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    //HtmlTable tbl = new HtmlTable();
                    //string HtmlContent = "<table>";    
                    Button button = new Button();
                    //for (int i = 0; i < 4; i++)
                    //{

                    //    HtmlContent += "<tr><td>" + i + "</td></tr>";
                    //    HtmlContent += "<tr><td>";
                    button.ID = "submit";
                    button.Text = "submit";
                    button.Click += submit_Click;
                    //    HtmlContent += "</td></tr>";
                    //}

                    //HtmlContent += "</table>";
                    HtmlTable iTblCart = new HtmlTable();
                    for (int i = 0; i < 4; i++)
                    {
                        HtmlTableRow iRowHeader = new HtmlTableRow();
                        iRowHeader.InnerText = "HI";
                        iTblCart.Rows.Add(iRowHeader);
                        HtmlTableCell iCellHead1 = new HtmlTableCell();
                        iCellHead1.InnerText = "Item";
                        iRowHeader.Cells.Add(iCellHead1);

                    }
                    //iCellHead1.InnerText = "I";

                    PlaceHolder.Controls.Add(iTblCart); ;

                    // PlaceHolder.Controls.Add(new LiteralControl(HtmlContent));    
                    //PlaceHolder.Controls.Add((button));
                    //PlaceHolder.Controls.Add((button));    
                }

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
//string yourHTMLstring = "<asp:Button ID=\"save\"  Text=\"حفظ\" CommandArgument=\"55\" value=\"one\" OnClick=\"printNum\" runat=\"server\" />";
string yourHTMLstring = "<p>hi</p>";
            //<asp:Button ID="save" class="btn btn-primary" Text="حفظ" value="one" OnClick="submit_Click" runat="server" />
            //var button = new Button
            //{
            //    ID = "Button",
            //    //CommandArgument = "5",
            //    Text = "Submit",
            //    OnClientClick = "printint",
                
                

            //};
            //Button button = new Button();
            //button.ID = "submit";
            //button.Text = "submit";
            //button.Click += submit_Click;
            //button.CommandArgument = "6";
            //button.Command += Load_Items;
            // button.Command += Load_Items;
            //PlaceHolder.Controls.Add(new LiteralControl(yourHTMLstring));
           // PlaceHolder1.Controls.Add(button);

            //Response.Write("<%int count = 1;%>");
            //for(int i = 0; i < 2; i++)
            //{
            // Response.Output.Write("<input type=\"text\" id=\"trial\" name=\"trial\" value=\"yes\" runat=\"server\"/>");
            //Response.Output.Write("<input type=\"text\" id=\"two\" name=\"trial1\" value=\"yes\" runat=\"server\"/>");
            //}

        public string printTable()
        {
            string html ="";
            for (int i=0; i<4; i++)
            {
                html += "<tr> <td>"+i+"</td><tr>";
                
            }
            return html;
        }
        private void Load_Items(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            // Do something with id
        }
        protected void printint()
        {
            Response.Write("hi");
            //for (int i = 0; i < 2; i++)
            //{

            //    Response.Write("<input type=\"button\" id=\"trial\" name=\"trial\" value=\"one\" onclick=\"printNum\" runat=\"server\"/>");
            //}
            //    //Response.Output.Write("<input type=\"hidden\" name=1 value=\"yes\" runat=\"server\"/>");
               // return 1;
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string ProductID = btn.CommandArgument.ToString();
            Response.Write("num: " + ProductID);

            //string id = Request.Form["trial"];
            //Response.Write("hi");
            Response.Write("hi" );

        }

        protected void printNum(object sender, EventArgs e)
        {
            try
            {
                //string ProductID = ((LinkButton)sender).CommandArgument.ToString();
                //Button btn = (Button)sender;
                //string ProductID = btn.CommandArgument.ToString();
                //Response.Write("num: " + ProductID);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
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
    }
}