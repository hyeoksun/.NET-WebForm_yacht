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
    public partial class news_content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadNewsContent();
            }
        }

        private void loadNewsContent()
        {
            string guidStr = Request.QueryString["id"];
            //如果沒有網址傳值就導回新聞列表頁
            if (String.IsNullOrEmpty(guidStr))
            {
                Response.Redirect("~/Tayanahtml/new_list.aspx");
            }
            //依取得 guid 連線資料庫取得新聞資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM news WHERE guid = @guid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guid", guidStr.Trim());
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染新聞標題
                newsTitleLiteral.Text = reader["title"].ToString();
                //渲染新聞主文
                newsContentLiteral.Text = HttpUtility.HtmlDecode(reader["newsContent"].ToString());
            }
            connection.Close();
        }
    }
}