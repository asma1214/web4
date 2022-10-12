using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace web4
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=ASMA_BADR\\DBWEB; Initial Catalog=webDB; User Id=asmaBadr; Password=webDB1234; Integrated Security=false");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Print_Table()
        {
            return 0;
        }
    }
}