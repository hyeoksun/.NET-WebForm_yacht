using CKFinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class addNews : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                //for (int i = 0; i < 50; i++)
                //{
                //    yearDDL.Items.Add((DateTime.Now.Year - i).ToString());
                //}
                //for (int i = 0; i < 12; i++)
                //{
                //    monthDDL.Items.Add((12 - i).ToString());
                //}
                //yearDDL.SelectedValue = Convert.ToString(DateTime.Now.Year);
                //monthDDL.SelectedValue = Convert.ToString(DateTime.Now.Month);
                //Calendar1.SelectedDate = Calendar1.TodaysDate;
            }
        }

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    yearDDL.Visible = true;
        //    monthDDL.Visible = true;
        //    Calendar1.Visible = true;
        //}

        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    postDateTB.Text = Calendar1.SelectedDate.ToShortDateString();
        //    Calendar1.Visible = false;
        //    yearDDL.Visible = false;
        //    monthDDL.Visible = false;
        //}

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString().Trim();
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
            connection.Open();
            string data = "INSERT INTO news(date, title, isTop, guid, summary, newsContent)VALUES(@date, @title, @isTop, @guid, @summary, @newsContent)";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.Add("@date", SqlDbType.NVarChar);
            cmd.Parameters["@date"].Value = postDateTB1.Value;
            cmd.Parameters.Add("@title", SqlDbType.NVarChar);
            cmd.Parameters["@title"].Value = titleTB.Text;
            cmd.Parameters.Add("@isTop", SqlDbType.Int);
            cmd.Parameters["@isTop"].Value = isTop;
            cmd.Parameters.Add("@guid", SqlDbType.NVarChar);
            cmd.Parameters["@guid"].Value = guid;
            cmd.Parameters.Add("@summary", SqlDbType.NVarChar);
            cmd.Parameters["@summary"].Value = summaryTB.Text;
            cmd.Parameters.Add("@newsContent", SqlDbType.NVarChar);
            cmd.Parameters["@newsContent"].Value = CKEditorControl1.Text;
            cmd.ExecuteNonQuery();
            //將預覽圖存進目標資料夾
            string SavePath1 = Server.MapPath("~/admin/upload/news/thumbnail/");
            if (thumbnailUpload.HasFile)
            {
                DirectoryInfo thumbnail = new DirectoryInfo(SavePath1);
                string FileName = thumbnailUpload.FileName;
                string[] FileNameArray = FileName.Split('.');
                int count = 0;
                foreach (var file in thumbnail.GetFiles())
                {
                    if (file.Name.Contains(FileNameArray[0]))
                    {
                        count++;
                    }
                }
                FileName = FileNameArray[0] + $"({count + 1})." + FileNameArray[1];
                thumbnailUpload.SaveAs(SavePath1 + FileName);
                string thumbnailName = "UPDATE news SET thumbnail =@thumbnail WHERE guid=@guid";
                SqlCommand sql = new SqlCommand(thumbnailName, connection);
                sql.Parameters.AddWithValue("@thumbnail", FileName);
                sql.Parameters.AddWithValue("@guid", guid);
                sql.ExecuteNonQuery();
            }
            //將附件檔案存進目標資料夾
            string SavePath2 = Server.MapPath("~/admin/upload/news/attached/");
            if (attachedUpload.HasFile)
            {
                DirectoryInfo attached = new DirectoryInfo(SavePath2);
                string attachedFileName = attachedUpload.FileName;
                string[] attachedFileNameArray = attachedFileName.Split('.');
                int count = 0;
                foreach (var file in attached.GetFiles())
                {
                    if (file.Name.Contains(attachedFileNameArray[0]))
                    {
                        count++;
                    }
                }
                attachedFileName = attachedFileNameArray[0] + $"({count + 1})." + attachedFileNameArray[1];
                attachedUpload.SaveAs(SavePath2 + attachedFileName);
                string attachedName = "UPDATE news SET attached =@attached WHERE guid=@guid";
                SqlCommand sql2 = new SqlCommand(attachedName, connection);
                sql2.Parameters.AddWithValue("@attached", attachedName);
                sql2.Parameters.AddWithValue("@guid", guid);
                sql2.ExecuteNonQuery();
            }
            connection.Close();
            Response.Redirect("news.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx");
        }

        //protected void yearDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Calendar1.TodaysDate = new DateTime(Convert.ToInt32(yearDDL.SelectedValue), Convert.ToInt32(monthDDL.SelectedValue), 1); // 1. Calendar.TodaysDate

        //    //Calendar1.VisibleDate = new DateTime(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue), 1); // 2. Calendar.VisibleDate
        //}
    }
}