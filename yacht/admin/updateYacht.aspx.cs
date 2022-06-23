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
    public partial class updateYacht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadInfo();
                loadAttachment();
            }
        }

        private void loadInfo()
        {
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM yachtType WHERE id = @id", connection);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd.Parameters["@id"].Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string SavePath = reader["banner"].ToString();
                LiteralImg.Text = $"<img alt='Contact Image' src='/admin/upload/yacht/banner/{SavePath}' style='display:block; margin:auto;'' Width='80%'/>";
                nameTB.Text = reader["typeName"].ToString();
                newDesignCB.Checked = reader["newDesign"].Equals(true);
                newBuildingCB.Checked = reader["newBuilding"].Equals(true);
                videoTB.Text = reader["videoLink"].ToString();
            }
            connection.Close();
        }

        private void loadAttachment()
        {
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [yachtFile] WHERE yacht_id=@id", connection);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd.Parameters["@id"].Value = id;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet set = new DataSet();
            dataAdapter.Fill(set);
            GridView1.DataSource = set;
            GridView1.DataBind();
        }
        
        protected void PhotoUpload_Click(object sender, EventArgs e)
        {
            string SavePath = Server.MapPath("~/admin/upload/yacht/banner/");
            if (FileUpload1.HasFile)
            {
                string id = Request.QueryString["id"];
                //刪除舊檔案
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
                string PhotoDel = "SELECT banner FROM yachtType WHERE id=@id";
                SqlCommand cmdDel = new SqlCommand(PhotoDel, connection);
                cmdDel.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmdDel.ExecuteReader();
                if (reader.Read())
                {
                    string DelFile = reader["banner"].ToString();
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
                string updateFileName = "UPDATE yachtType SET banner = @FileName WHERE id=@id";
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

        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"delete from yachtFile WHERE  (id = {id})", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void FileUpload_Click(object sender, EventArgs e)
        {
            //將附件檔案存進目標資料夾
            string attachSavePath = Server.MapPath("~/admin/upload/yacht/attachment/");
            string id = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            if (FileUpload3.HasFile)
            {
                DirectoryInfo attached = new DirectoryInfo(attachSavePath);
                foreach (var uploadFile in FileUpload3.PostedFiles)
                {
                    string attachedFileName = Path.GetFileName(uploadFile.FileName);
                    string[] attachedFileNameArray = attachedFileName.Split('.');
                    int count = 0;
                    foreach (var file in attached.GetFiles())
                    {
                        if (file.Name.Contains(attachedFileNameArray[0]))
                        {
                            count++;
                        }
                    }
                    connection.Open();
                    attachedFileName = attachedFileNameArray[0] + $"({count + 1})." + attachedFileNameArray[1];
                    uploadFile.SaveAs(attachSavePath + attachedFileName);
                    string attachedSQL = "INSERT INTO yachtFile(fileName, yacht_id)VALUES(@fileName, @yacht_id)";
                    SqlCommand sql2 = new SqlCommand(attachedSQL, connection);
                    sql2.Parameters.Add("@fileName", SqlDbType.NVarChar);
                    sql2.Parameters["@fileName"].Value = attachedFileName;
                    sql2.Parameters.Add("@yacht_id", SqlDbType.Int);
                    sql2.Parameters["@yacht_id"].Value = id;
                    sql2.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {
                Label5.Visible = true;
                Label5.ForeColor = Color.Red;
                Label5.Text = "Please choose file！";
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("yacht.aspx");
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            DateTime getdate = DateTime.Now;

            int isNewDesign;
            if (newDesignCB.Checked)
            {
                isNewDesign = 1;
            }
            else
            {
                isNewDesign = 0;
            }

            int newBuilding;
            if (newBuildingCB.Checked)
            {
                newBuilding = 1;
            }
            else
            {
                newBuilding = 0;
            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string data = $"UPDATE yachtType SET typeName=@typeName, newDesign=@newDesign, newBuilding=@newBuilding, videoLink=@videoLink, LastModifiedDate=@LastModifiedDate WHERE id=@id";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@typeName", nameTB.Text);
            cmd.Parameters.AddWithValue("@newDesign", isNewDesign);
            cmd.Parameters.AddWithValue("@newBuilding", newBuilding);
            cmd.Parameters.AddWithValue("@videoLink", videoTB.Text);
            cmd.Parameters.AddWithValue("@LastModifiedDate", getdate);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect($"updateYachtContent.aspx?id={id}");
        }
    }
}