using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web4
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //<input type="text" name="trial" value="yes" onclick="print(id)" runat="server"/>
            //Response.Write("<input type=\"button\" name=\"trial\" value=\"yes\" onclick=\"print(\"one\")\" runat=\"server\"/>");
        }
        public int printInt(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton == null) // just to be on the safe side
                return 1;

            if (clickedButton.ID == "trial")
            {
                Response.Write("hi");
            }

            Response.Write("i: " );
            return 1;
        }
    }
}