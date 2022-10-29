using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;


namespace web4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string securepass = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA256");
            string securepass = BCrypt.Net.BCrypt.HashPassword(TextBox2.Text);
            Label1.Text = "Your HashPassword is-" + securepass;
            //bool verify = BCrypt.Net.BCrypt.Verify(TextBox2.Text, TextBox1.Text);
            Label2.ForeColor = System.Drawing.Color.ForestGreen;
            Label1.ForeColor = System.Drawing.Color.ForestGreen;

        }
    }
}