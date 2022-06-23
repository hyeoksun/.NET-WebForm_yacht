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
    public partial class yacht_video : System.Web.UI.Page
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
                string videoStr = HttpUtility.HtmlDecode(reader["videoLink"].ToString());
                //將取出的 YouTube 連結字串分離出 "影片 ID 字串"
                //使用者如果是用分享功能複製連結時處理方式
                string[] youtubeUrlArr = videoStr.Split('/');
                //使用者如果是直接從網址複製連結時處理方式
                string[] vedioIDArr = youtubeUrlArr[youtubeUrlArr.Length - 1].Split('=');
                //將 "影片 ID 字串" 組合成嵌入狀態的 YouTube 連結
                string strNewUrl = "https:/" + "/youtube.com/" + "embed/" + vedioIDArr[vedioIDArr.Length - 1];
                //更新 <iframe> src 連結
                video.Attributes.Add("src", strNewUrl);
            }

            connection.Close();

            
        }
    }
}