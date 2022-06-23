using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class yacht_specification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadContent();
            }
        }

        private void loadContent()
        {
            //取得 Session 共用 GUID，Session 物件需轉回字串
            string guidStr = Session["guid"].ToString();
            //依 GUID 取得遊艇資料
            SqlConnection connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM yachtType WHERE guid=@guidStr";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string yachtModelStr = reader["typeName"].ToString();
                string contentHtmlStr = HttpUtility.HtmlDecode(reader["specification"].ToString());
                contentLiteral.Text = contentHtmlStr;
            }

            connection.Close();
        }
    }
}