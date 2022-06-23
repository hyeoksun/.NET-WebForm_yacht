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
    public partial class updateDealer : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                SqlConnection connection = new SqlConnection(getsql);
                SqlCommand cmd = new SqlCommand($"SELECT country.id, country.Country, dealers.id, dealers.Photo, dealers.Area, dealers.CompanyName, dealers.Contact, dealers.Address, dealers.TEL, dealers.FAX, dealers.Email, dealers.Website, dealers.CountryId FROM country INNER JOIN dealers ON country.id = dealers.CountryId WHERE dealers.id = @id1", connection);
                cmd.Parameters.Add("@id1", SqlDbType.NVarChar);
                cmd.Parameters["@id1"].Value = id;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string SavePath = reader["Photo"].ToString();
                    LiteralImg.Text= $"<img alt='Contact Image' src='/admin/upload/dealerPhoto/{SavePath}' style='display:block; margin:auto;'' Width='210px'/>";
                    CountryList.SelectedValue = reader["CountryId"].ToString();
                    AreaTB.Text = reader["Area"].ToString();
                    CompanyTB.Text = reader["CompanyName"].ToString();
                    ContactTB.Text = reader["Contact"].ToString();
                    AddressTB.Text = reader["Address"].ToString();
                    TelTB.Text = reader["TEL"].ToString();
                    FaxTB.Text = reader["FAX"].ToString();
                    EmailTB.Text = reader["Email"].ToString();
                    WebsiteTB.Text = reader["Website"].ToString();
                }
                connection.Close();
            }
        }

        protected void PhotoUpload_Click(object sender, EventArgs e)
        {
            string SavePath = Server.MapPath("~/admin/upload/dealerPhoto/");
            if (FileUpload1.HasFile)
            {
                string id = Request.QueryString["id"];
                //刪除舊檔案
                SqlConnection connection = new SqlConnection(getsql);
                string PhotoDel = "SELECT Photo FROM dealers  WHERE id=@id";
                SqlCommand cmdDel = new SqlCommand(PhotoDel, connection);
                cmdDel.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmdDel.ExecuteReader();
                if (reader.Read())
                {
                    string DelFile = reader["Photo"].ToString();
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
                SqlConnection connect = new SqlConnection(getsql);
                string updateFileName = "UPDATE dealers SET Photo = @FileName WHERE id=@id";
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
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection connection = new SqlConnection(getsql);
            string data = $"UPDATE dealers SET Area=@Area, CompanyName=@CompanyName, Address=@Address, Contact=@Contact, TEL=@TEL, FAX=@FAX, Email=@Email, Website=@Website, CountryId=@CountryId, LastMotifiedDate=@LastMotifiedDate WHERE id=@id";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Area", AreaTB.Text);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyTB.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTB.Text);
            cmd.Parameters.AddWithValue("@Contact", ContactTB.Text);
            cmd.Parameters.AddWithValue("@TEL", TelTB.Text);
            cmd.Parameters.AddWithValue("@FAX", FaxTB.Text);
            cmd.Parameters.AddWithValue("@Email", EmailTB.Text);
            cmd.Parameters.AddWithValue("@Website", WebsiteTB.Text);
            cmd.Parameters.AddWithValue("@CountryID", CountryList.SelectedValue);
            cmd.Parameters.AddWithValue("@LastMotifiedDate", dateNow);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("area_dealers.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("area_dealers.aspx");
        }
    }
}