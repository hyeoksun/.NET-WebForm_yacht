using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class yachtType : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //將型號相對應的 guid存入session與子頁共用
                //換頁時會先讀Content頁面才讀取Master頁面 => 要放在Init
                getGuid();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGallery();
                loadLeftMenu();
                loadTopMenu();
            }
        }

        private void getGuid()
        {
            //取得網址傳值的型號對應 GUID
            string guidStr = Request.QueryString["id"];
            string idStr = Request.QueryString["no"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT TOP 1 guid,id FROM yachtType";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //如果無網址傳值就用第一筆遊艇型號的 GUID
                if (String.IsNullOrEmpty(guidStr))
                {
                    guidStr = reader["guid"].ToString().Trim();
                    idStr = reader["id"].ToString().Trim();
                }
            }
            connection.Close();
            //將 GUID 存入 Session 供上方列表共用
            Session["guid"] = guidStr;
            Session["id"] = idStr;
        }

        private void loadGallery()
        {
            //建立資料表存資料
            DataTable dataTable = new DataTable();
            //新增表格欄位，預設從 1 開始, 設定欄位名稱
            dataTable.Columns.AddRange(new DataColumn[1] { new DataColumn("ImageUrl") });

            //取得 Session 共用 GUID，Session 物件需轉回字串
            string idStr = Session["id"].ToString();
            //string guidStr = Session["guid"].ToString();
            //依 GUID 取得遊艇輪播圖片資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT photoName FROM yachtPhoto WHERE yacht_id = @yacht_id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@yacht_id", idStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string photoName = reader["photoName"].ToString();
                dataTable.Rows.Add($"admin/upload/yacht/photo/{photoName}");
            }
            connection.Close();

            //輪播圖片必須用 Repeater 送不然 JavaScript 抓不到 HTML 標籤會失敗
            //設定用 Eval 綁定的輪播圖片路徑資料
            RepeaterPhoto.DataSource = dataTable; //設定資料來源
            RepeaterPhoto.DataBind(); //刷新圖片資料
        }


        private void loadLeftMenu()
        {
            //取得遊艇型號資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM yachtType";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder leftMenuHtml = new StringBuilder();
            while (reader.Read())
            {
                string yachtModelStr = reader["typeName"].ToString();
                string isNewDesignStr = reader["newDesign"].ToString();
                string isNewBuildingStr = reader["newBuilding"].ToString();
                string guidStr = reader["guid"].ToString();
                string idStr = reader["id"].ToString();
                string isNewStr = "";
                //依是否為新建或新設計加入標註
                if (isNewDesignStr.Equals("True"))
                {
                    isNewStr = "(New Design)";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    isNewStr = "(New Building)";
                }
                leftMenuHtml.Append($"<li><a href='yacht_overview.aspx?id={guidStr}&no={idStr}'>{yachtModelStr} {isNewStr}</a></li>");
            }
            connection.Close();

            //渲染左側遊艇型號選單
            LeftMenu.Text = leftMenuHtml.ToString();
        }

        private void loadTopMenu()
        {
            //取得 Session 共用 GUID，Session 物件需轉回字串
            string guidStr = Session["guid"].ToString();
            string idStr = Session["id"].ToString();
            //依 GUID 取得遊艇資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM yachtType WHERE guid = @guidStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@guidStr", guidStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder topMenuHtmlStr = new StringBuilder();
            if (reader.Read())
            {
                string yachtModelStr = reader["typeName"].ToString();
                string contentHtmlStr = HttpUtility.HtmlDecode(reader["overviewContent"].ToString());

                //加入渲染型號內容上方分類連結列表
                topMenuHtmlStr.Append($"<li><a class='menu_yli01' href='yacht_overview.aspx?id={guidStr}&no={idStr}' >OverView</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli02' href='yacht_layout.aspx?id={guidStr}&no={idStr}' >Layout & deck plan</a></li>");
                topMenuHtmlStr.Append($"<li><a class='menu_yli03' href='yacht_specification.aspx?id={guidStr}&no={idStr}' >Specification</a></li>");
                //加入渲染型號內容上方分類連結列表 Video 分頁標籤，有存影片連結網址才渲染
                string video = reader["videoLink"].ToString();
                if (!String.IsNullOrEmpty(video))
                {
                    topMenuHtmlStr.Append($"<li><a class='menu_yli04' href='yacht_video.aspx?id={guidStr}&no={idStr}' >Video</a></li>");
                }

                //渲染畫面
                //渲染上方小連結
                labLink.InnerText = yachtModelStr;
                //渲染標題
                labTitle.InnerText = yachtModelStr;
                //渲染型號內容上方分類連結列表
                TopMenuLink.Text = topMenuHtmlStr.ToString();
            }
            connection.Close();
        }
    }
}