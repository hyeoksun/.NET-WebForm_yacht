using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadProfile();
            }
        }

        private void loadProfile()
        {
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM members id = @id1", connection);
            cmd.Parameters.Add("@id1", SqlDbType.NVarChar);
            cmd.Parameters["@id1"].Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string SavePath = reader["photo"].ToString();
                LiteralImg.Text = $"<img alt='Contact Image' src='/admin/upload/members/{SavePath}' style='display:block; margin:auto;'' Width='210px'/>";
                EmailTB.Text = reader["email"].ToString();
            }
            connection.Close();
        }
        
        protected void PhotoUpload_Click(object sender, EventArgs e)
        {
            string SavePath = Server.MapPath("~/admin/upload/members/");
            if (FileUpload1.HasFile)
            {
                string id = Request.QueryString["id"];
                //刪除舊檔案
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
                string PhotoDel = "SELECT photo FROM members WHERE id=@id";
                SqlCommand cmdDel = new SqlCommand(PhotoDel, connection);
                cmdDel.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmdDel.ExecuteReader();
                if (reader.Read())
                {
                    string DelFile = reader["photo"].ToString();
                    string defaultPhoto = "default.png";
                    //不刪到預設圖片
                    if (DelFile != defaultPhoto)
                    {
                        //有舊圖就刪除
                        //if (!string.IsNullOrEmpty(DelFile))
                        //{
                        File.Delete(SavePath + DelFile);
                        //}
                    }
                }
                connection.Close();

                //儲存圖片檔案及名稱
                DirectoryInfo info = new DirectoryInfo(SavePath);
                string FileName = FileUpload1.FileName;
                string[] FileNameArray = FileName.Split('.');
                int count = 0;
                foreach (var file in info.GetFiles())
                {
                    if (file.Name.Contains(FileNameArray[0]))
                    {
                        count++;
                    }
                }
                FileName = FileNameArray[0] + $"({count + 1})." + FileNameArray[1];
                FileUpload1.SaveAs(SavePath + FileName);
                //更新資料庫
                SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
                string updateFileName = "UPDATE members SET photo = @FileName WHERE id=@id";
                connect.Open();
                SqlCommand sql = new SqlCommand(updateFileName, connect);
                sql.Parameters.AddWithValue("@FileName", FileName);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                connect.Close();
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                FileLabel.Visible = true;
                FileLabel.ForeColor = Color.Red;
                FileLabel.Text = "Please choose file！";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);

            if (!string.IsNullOrEmpty(OriginPassTB.Text))
            {
                string data = $"UPDATE dealers SET password=@password, salt=@salt, email=@email WHERE id=@id";
                SqlCommand cmd = new SqlCommand(data, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", EmailTB.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("UpdateProfile.aspx");
            }
            else
            {
                string data = $"UPDATE dealers SET email=@email WHERE id=@id";
                SqlCommand cmd = new SqlCommand(data, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", EmailTB.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("UpdateProfile.aspx");
            }
            
        }
    }
}