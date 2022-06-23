using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class updateYachtPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPhotos();
            }
        }

        private void loadPhotos()
        {
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM yachtPhoto WHERE yacht_id=@id", connection);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd.Parameters["@id"].Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string photoId = reader["id"].ToString();
                string photoName = reader["photoName"].ToString();
                ListItem photoList =
                    new ListItem(
                        $"<img src='/admin/upload/yacht/photo/{photoName}' alt='yacht thumbnail' width='70%'/>",
                        photoName);
                RadioButtonList1.Items.Add(photoList);
            }
            connection.Close();
        }
        
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("yacht.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            //先讀取資料庫原有資料
            loadPhotos();
            //取得選取項目的值
            string selectImageStr = RadioButtonList1.SelectedValue;

            //刪除圖片檔案
            string savePath = Server.MapPath("~/admin/upload/yacht/photo/");
            File.Delete(savePath + selectImageStr);


            //更新刪除後的圖片名稱 JSON 存入資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string sql = "DELETE FROM yachtPhoto WHERE(photoName = @photoName)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@photoName", selectImageStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面
            RadioButtonList1.Items.Clear();
            loadPhotos();
        }
    }
}