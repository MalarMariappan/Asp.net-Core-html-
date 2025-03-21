using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASP.NET_HTML_
{
    public partial class Login_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Data Source = localhost; Initial Catalog = aspdotnet; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            sql.Open();
            string loginQuery = "SELECT  COUNT(*) FROM loginform WHERE username =@username AND password=@password";
            SqlCommand cmd = new SqlCommand(loginQuery, sql);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            int count = (int)cmd.ExecuteScalar();
            sql.Close();
            if(count > 0)
            {
                Response.Write("<script>alert('Login Success');</script>");
            }
            else
            {
                Response.Write("<script>alert('Login fail');</script>");
            }

        }
    }
}