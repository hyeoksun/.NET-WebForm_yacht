using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class Certificate : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(getsql);
            string sql = "SELECT certificateContent, LastMotifiedDate FROM certificate WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text= HttpUtility.HtmlDecode(reader["certificateContent"].ToString());
                Literal3.Text = (reader["LastMotifiedDate"].ToString());
            }
            connection.Close();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CertificateContent.aspx");
        }
    }
}