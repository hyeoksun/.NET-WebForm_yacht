using CKFinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class updateNews : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ckeditor();
                string id = Request.QueryString["id"];
                SqlConnection connection = new SqlConnection(getsql);
                SqlCommand cmd = new SqlCommand($"SELECT  id, date, title, isTop, guid, summary, newsContent, thumbnail, attached FROM news WHERE id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                cmd.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    postDateTB.Value = Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd");
                    titleTB.Text = reader["title"].ToString();
                    CheckBox1.Checked = (bool)reader["isTop"];
                    CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["newsContent"].ToString());
                    summaryTB.Text = reader["summary"].ToString();
                    string SavePath = reader["thumbnail"].ToString();
                    LiteralImg.Text = $"<img alt='Contact Image' src='/admin/upload/news/thumbnail/{SavePath}' style='display:block;'' Width='210px'/>";
                }
                connection.Close();

            }
        }
        private void ckeditor()
        {
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.BasePath = "/ckfinder";
            fileBrowser.SetupCKEditor(CKEditorControl1);
        }
        protected void PhotoUpload_Click(object sender, EventArgs e)
        {
            string SavePath = Server.MapPath("~/admin/upload/news/thumbnail/");
            if (thumbnailUpload.HasFile)
            {
                string id = Request.QueryString["id"];
                //刪除舊檔案
                SqlConnection connection = new SqlConnection(getsql);
                string PhotoDel = "SELECT thumbnail FROM news WHERE id=@id";
                SqlCommand cmdDel = new SqlCommand(PhotoDel, connection);
                cmdDel.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmdDel.ExecuteReader();
                if (reader.Read())
                {
                    string DelFile = reader["thumbnail"].ToString();
                    string defaultPhoto = "default.jpg";
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
                string FileName = thumbnailUpload.FileName;
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
                thumbnailUpload.SaveAs(SavePath + FileName);
                //更新資料庫
                SqlConnection connect = new SqlConnection(getsql);
                string updateFileName = "UPDATE news SET thumbnail = @thumbnail WHERE id=@id";
                connect.Open();
                SqlCommand sql = new SqlCommand(updateFileName, connect);
                sql.Parameters.AddWithValue("@thumbnail", FileName);
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

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            int isTop;
            if (CheckBox1.Checked)
            {
                isTop = 1;
            }
            else
            {
                isTop = 0;
            }
            SqlConnection connection = new SqlConnection(getsql);
            string data = $"UPDATE news SET date = @date, title = @title, isTop = @isTop, summary = @summary, newsContent = @newsContent, lastMotifiedDate = @lastMotifiedDate WHERE id=@id";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", postDateTB.Value);
            cmd.Parameters.AddWithValue("@title", titleTB.Text);
            cmd.Parameters.AddWithValue("@isTop", isTop);
            cmd.Parameters.AddWithValue("@summary", summaryTB.Text);
            cmd.Parameters.AddWithValue("@newsContent", CKEditorControl1.Text);
            cmd.Parameters.AddWithValue("@LastMotifiedDate", dateNow);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("news.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx");
        }
        //private void calendar()
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        yearDDL.Items.Add((DateTime.Now.Year - i).ToString());
        //    }
        //    for (int i = 0; i < 12; i++)
        //    {
        //        monthDDL.Items.Add((12 - i).ToString());
        //    }
        //    yearDDL.SelectedValue = Convert.ToString(DateTime.Now.Year);
        //    monthDDL.SelectedValue = Convert.ToString(DateTime.Now.Month);
        //    Calendar1.SelectedDate = Calendar1.TodaysDate;
        //}
        //protected void yearDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Calendar1.TodaysDate = new DateTime(Convert.ToInt32(yearDDL.SelectedValue), Convert.ToInt32(monthDDL.SelectedValue), 1); // 1. Calendar.TodaysDate

        //    //Calendar1.VisibleDate = new DateTime(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue), 1); // 2. Calendar.VisibleDate
        //}
        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    postDateTB.Text = Calendar1.SelectedDate.ToShortDateString();
        //    Calendar1.Visible = false;
        //    yearDDL.Visible = false;
        //    monthDDL.Visible = false;
        //}
        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    yearDDL.Visible = true;
        //    monthDDL.Visible = true;
        //    Calendar1.Visible = true;
        //}
    }
}