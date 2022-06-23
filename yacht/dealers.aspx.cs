using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class dealers : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCountryID();
                loadAreaList();
                loadDealerList();
            }
        }

        private void getCountryID()
        {
            //取得網址傳址內容
            string countryID = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            //沒有傳值的話，取第一筆資料ID
            if (string.IsNullOrEmpty(countryID))
            {
                string sqlFirstCountry = "SELECT TOP 1 id FROM country";
                SqlCommand cmdFirstCountry = new SqlCommand(sqlFirstCountry, connection);
                connection.Open();
                SqlDataReader rdFirstID = cmdFirstCountry.ExecuteReader();
                if (rdFirstID.Read())
                {
                    countryID = rdFirstID["id"].ToString();
                }
                connection.Close();
            }
            else
            {
                //如果有傳值，找到相對應的ID
                string sqlCountry = "SELECT id FROM country WHERE id=@countryID";
                SqlCommand cmdCountryId = new SqlCommand(sqlCountry, connection);
                cmdCountryId.Parameters.AddWithValue("@countryID", countryID);
                connection.Open();
                SqlDataReader rdID = cmdCountryId.ExecuteReader();
                if (rdID.Read())
                {
                    countryID = rdID["id"].ToString();
                }
                connection.Close();
            }
            
            //將ID存進session，以供後續使用
            Session["id"] = countryID;
        }

        private void loadAreaList()
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            //反覆變更字串的值，用StringBuilder效能較好
            StringBuilder leftListHtml = new StringBuilder();
            string sqlCountry = "SELECT  id, Country FROM country";
            SqlCommand cmdCountry = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader rdCountry = cmdCountry.ExecuteReader();
            while (rdCountry.Read())
            {
                string idStr = rdCountry["id"].ToString();
                string countryStr = rdCountry["Country"].ToString();
                //用append將字串內容加入StringBuilder
                leftListHtml.Append($"<li><a href='dealers.aspx?id={idStr}'>{countryStr}</a></li>");
            }
            connection.Close();

            areaList.Text = leftListHtml.ToString();
        }

        private void loadDealerList()
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            //取得session存取的country id，再將session物件轉回字串
            string countryIdStr = Session["id"].ToString();
            
            //取得右選單 右上連結的文字內容
            string sqlCountry = "SELECT  id, Country FROM country WHERE id=@countryIdStr";
            SqlCommand cmdCountry = new SqlCommand(sqlCountry, connection);
            cmdCountry.Parameters.AddWithValue("@countryIdStr", countryIdStr);
            connection.Open();
            SqlDataReader reader = cmdCountry.ExecuteReader();
            if (reader.Read())
            {
                string countryStr = reader["Country"].ToString();
                areaLink.InnerText = countryStr;
                areaTitle.InnerText = countryStr;
            }
            connection.Close();
            
            //取得選擇的area中的所有dealers
            StringBuilder dealerListHtml = new StringBuilder();
            string sqlDealer = "SELECT * FROM dealers WHERE CountryId=@countryIdStr";
            SqlCommand cmdDealers = new SqlCommand(sqlDealer, connection);
            cmdDealers.Parameters.AddWithValue("@countryIdStr", countryIdStr);
            connection.Open();
            SqlDataReader rdDealer = cmdDealers.ExecuteReader();
            while (rdDealer.Read())
            {
                string idStr = rdDealer["id"].ToString();
                string areaStr = rdDealer["Area"].ToString();
                string imgPathStr = rdDealer["Photo"].ToString();
                string companyStr = rdDealer["CompanyName"].ToString();
                string contactStr = rdDealer["Contact"].ToString();
                string addressStr = rdDealer["Address"].ToString();
                string telStr = rdDealer["TEL"].ToString();
                string faxStr = rdDealer["FAX"].ToString();
                string emailStr = rdDealer["Email"].ToString();
                string websiteStr = rdDealer["Website"].ToString();
                //把各供應商詳情放入
                dealerListHtml.Append("<li><div class='list02'><ul><li class='list02li'><div>" +
                                      $"<p><img id = 'Image{idStr}' src='/admin/upload/dealerPhoto/{imgPathStr}' style='border-width:0px;' Width='209px'/></p></div></li> " +
                                      $"<li class='list02li02'> <span>{areaStr}</span><br/>");
                if (!string.IsNullOrEmpty(companyStr))
                {
                    dealerListHtml.Append($"{companyStr}<br/>");
                }
                if (!string.IsNullOrEmpty(contactStr))
                {
                    dealerListHtml.Append($"{contactStr}<br/>");
                }
                if (!string.IsNullOrEmpty(addressStr))
                {
                    dealerListHtml.Append($"{addressStr}<br/>");
                }
                if (!string.IsNullOrEmpty(telStr))
                {
                    dealerListHtml.Append($"{telStr}<br/>");
                }
                if (!string.IsNullOrEmpty(faxStr))
                {
                    dealerListHtml.Append($"{faxStr}<br/>");
                }
                if (!string.IsNullOrEmpty(emailStr))
                {
                    dealerListHtml.Append($"{emailStr}<br/>");
                }
                if (!string.IsNullOrEmpty(websiteStr))
                {
                    dealerListHtml.Append($"<a href='{websiteStr}' target='_blank'>{websiteStr}</a>");
                }

                dealerListHtml.Append("</li></ul></div></li>");
            }
            connection.Close();
            
            //將內容渲染到前台
            dealerList.Text = dealerListHtml.ToString();
        }
    }
}