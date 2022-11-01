using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailPattern = @"^[a-z0-9](\.?[a-z0-9]){5,}@(?:iau.edu.sa)$";
            string email = "2190009074@iau.edu.sa";
            bool isEmailValid = Regex.IsMatch(email, emailPattern);
            if (isEmailValid)
                Response.Write("yes");
            else
                Response.Write("No");
        }
    }
}