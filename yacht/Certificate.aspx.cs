using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCertificate();
            }
        }

        private void loadCertificate()
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sqlAboutUs = "SELECT TOP 1 certificateContent FROM certificate";
            SqlCommand cmd = new SqlCommand(sqlAboutUs, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Literal1.Text = HttpUtility.HtmlDecode(reader["certificateContent"].ToString());
                connection.Close();
            }
        }
    }
}