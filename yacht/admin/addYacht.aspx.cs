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
    public partial class addYacht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString().Trim();
            int isNewDesign;
            if (newDesignCheck.Checked)
            {
                isNewDesign = 1;
            }
            else
            {
                isNewDesign = 0;
            }
            int isNewBuilding;
            if (newBuildingCheck.Checked)
            {
                isNewBuilding = 1;
            }
            else
            {
                isNewBuilding = 0;
            }
            //將船型資訊存進資料庫，並回傳id
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string data = "INSERT INTO yachtType (guid, typeName, newDesign, newBuilding, videoLink)VALUES(@guid, @typeName, @newDesign, @newBuilding, @videoLink) select scope_identity()";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.Add("@guid", SqlDbType.NVarChar);
            cmd.Parameters["@guid"].Value = guid;
            cmd.Parameters.Add("@typeName", SqlDbType.NVarChar);
            cmd.Parameters["@typeName"].Value = typeName.Text;
            cmd.Parameters.Add("@newDesign", SqlDbType.Int);
            cmd.Parameters["@newDesign"].Value = isNewDesign;
            cmd.Parameters.Add("@newBuilding", SqlDbType.Int);
            cmd.Parameters["@newBuilding"].Value = isNewBuilding;
            cmd.Parameters.Add("@videoLink", SqlDbType.NVarChar);
            cmd.Parameters["@videoLink"].Value = videoTB.Text;
            connection.Open();
            //cmd.ExecuteNonQuery(); 

            //取得剛新增的資料ID值，ExecuteScalar也是新增一個物件(一筆資料)，所以上面不用ExecuteNonQuery
            int yachtID= Convert.ToInt32(cmd.ExecuteScalar());
            
            //將banner存進目標資料夾
            string bannerSavePath = Server.MapPath("~/admin/upload/yacht/banner/");
            if (bannerUpload.HasFile)
            {
                DirectoryInfo banner = new DirectoryInfo(bannerSavePath);
                string bannerName = bannerUpload.FileName;
                string[] bannerNameArray = bannerName.Split('.');
                int count = 0;
                foreach (var file in banner.GetFiles())
                {
                    if (file.Name.Contains(bannerNameArray[0]))
                    {
                        count++;
                    }
                }
                bannerName = bannerNameArray[0] + $"({count + 1})." + bannerNameArray[1];
                bannerUpload.SaveAs(bannerSavePath + bannerName);
                string bannerSQL = "UPDATE yachtType SET banner =@banner WHERE id=@id";
                SqlCommand sql = new SqlCommand(bannerSQL, connection);
                sql.Parameters.AddWithValue("@banner", bannerName);
                sql.Parameters.AddWithValue("@id", yachtID);
                sql.ExecuteNonQuery();
            }
            
            //將附件檔案存進目標資料夾
            string attachSavePath = Server.MapPath("~/admin/upload/yacht/attachment/");
            if (attachedUpload.HasFiles)
            {
                foreach (HttpPostedFile uploadFile in attachedUpload.PostedFiles)
                {
                    DirectoryInfo attached = new DirectoryInfo(attachSavePath);
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
                    attachedUpload.SaveAs(attachSavePath + attachedFileName);
                    string attachedSQL = "INSERT INTO yachtFile(fileName, yacht_id)VALUES(@fileName, @yacht_id)";
                    SqlCommand sql2 = new SqlCommand(attachedSQL, connection);
                    sql2.Parameters.Add("@fileName", SqlDbType.NVarChar);
                    sql2.Parameters["@fileName"].Value = attachedFileName;
                    sql2.Parameters.Add("@yacht_id", SqlDbType.Int);
                    sql2.Parameters["@yacht_id"].Value = yachtID;
                    sql2.ExecuteNonQuery();
                }
            }

            //將遊艇圖片存進目標資料夾
            string photoSavePath = Server.MapPath("~/admin/upload/yacht/photo/");
            if (yachtPhotosUpload.HasFiles)
            {
                foreach (HttpPostedFile photo in yachtPhotosUpload.PostedFiles)
                {
                    DirectoryInfo yachtPhoto = new DirectoryInfo(photoSavePath);
                    string photoFileName = yachtPhotosUpload.FileName;
                    string[] photoFileNameArray = photoFileName.Split('.');
                    int count = 0;
                    foreach (var file in yachtPhoto.GetFiles())
                    {
                        if (file.Name.Contains(photoFileNameArray[0]))
                        {
                            count++;
                        }
                    }
                    photoFileName = photoFileNameArray[0] + $"({count + 1})." + photoFileNameArray[1];
                    yachtPhotosUpload.SaveAs(photoSavePath + photoFileName);
                    string photoSQL = "INSERT INTO yachtPhoto(photoName, yacht_id)VALUES(@photoName, @yacht_id)";
                    SqlCommand sql3 = new SqlCommand(photoSQL, connection);
                    sql3.Parameters.Add("@photoName", SqlDbType.NVarChar);
                    sql3.Parameters["@photoName"].Value = photoFileName;
                    sql3.Parameters.Add("@yacht_id", SqlDbType.Int);
                    sql3.Parameters["@yacht_id"].Value = yachtID;
                    sql3.ExecuteNonQuery();
                }
            }
            connection.Close();
            Response.Redirect("addYachtContent.aspx?id="+yachtID);
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("yacht.aspx");
        }
    }
}