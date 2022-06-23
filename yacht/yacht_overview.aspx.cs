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
    public partial class yachts_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadContent();
                loadDownload();
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
                string contentHtmlStr = HttpUtility.HtmlDecode(reader["overviewContent"].ToString());
                contentLiteral.Text = contentHtmlStr;
            }

            connection.Close();
        }

        private void loadDownload()
        {
            string idStr = Session["id"].ToString();
            //依 GUID 取得遊艇資料
            SqlConnection connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            connection.Open();
            string sql2 = "SELECT id, fileName, yacht_id FROM yachtFile WHERE(yacht_id = @idStr)";
            SqlCommand cmd2 = new SqlCommand(sql2, connection);
            cmd2.Parameters.AddWithValue("@idStr", idStr);
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                string downloadStr = reader["fileName"].ToString();

                //渲染下方 Downloads 區塊
                if (!String.IsNullOrEmpty(downloadStr))
                {
                    //渲染下載連結
                    downloadLiteral.Text =
                        $"<a id='HyperLink1' href='admin/upload/yacht/attachment/{downloadStr}' target='blank' >{downloadStr}</a>";
                }
                else
                {
                    //無下載連結則隱藏整個區塊
                    divDownload.Visible = false;
                }
            }
        }
    }
}