using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
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
            string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] ticketUserDataArr = ticketUserData.Split(';');
            string account = ticketUserDataArr[1].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM members WHERE account = @account", connection);
            cmd.Parameters.Add("@account", SqlDbType.NVarChar);
            cmd.Parameters["@account"].Value = account;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string SavePath = reader["photo"].ToString();
                LiteralImg.Text = $"<img alt='Contact Image' src='/admin/upload/members/{SavePath}' style='display:block; margin:auto;'' Width='210px'/>";
                AccountTB.Text = reader["account"].ToString();
                EmailTB.Text = reader["email"].ToString();
            }
            connection.Close();
        }
        
        protected void PhotoUpload_Click(object sender, EventArgs e)
        {
            string SavePath = Server.MapPath("~/admin/upload/members/");
            if (FileUpload1.HasFile)
            {
                string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                string[] ticketUserDataArr = ticketUserData.Split(';');
                string account = ticketUserDataArr[1].ToString();
                //刪除舊檔案
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
                string PhotoDel = "SELECT photo FROM members WHERE account=@account";
                SqlCommand cmdDel = new SqlCommand(PhotoDel, connection);
                cmdDel.Parameters.AddWithValue("@account", account);
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
                string updateFileName = "UPDATE members SET photo = @FileName WHERE account=@account";
                connect.Open();
                SqlCommand sql = new SqlCommand(updateFileName, connect);
                sql.Parameters.AddWithValue("@FileName", FileName);
                sql.Parameters.AddWithValue("@account", account);
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

        
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] ticketUserDataArr = ticketUserData.Split(';');
            string account = ticketUserDataArr[1].ToString();
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string select = $"SELECT * FROM members WHERE account=@account";
            connection.Open();
            SqlCommand command = new SqlCommand(select, connection);
            // 4.放入參數化資料
            command.Parameters.AddWithValue("@account", account);
            // 5.資料庫用 Adapter 執行指令
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            // 6.建立一個空的 Table
            DataTable dataTable = new DataTable();
            // 7.將資料放入 Table
            dataAdapter.Fill(dataTable);
            connection.Close();
            // 登入流程管理 (Cookie)
            if (dataTable.Rows.Count > 0)
            {
                // SQL 有找到資料時執行
                //將字串轉回 byte
                byte[] hash = Convert.FromBase64String(dataTable.Rows[0]["password"].ToString());
                byte[] salt = Convert.FromBase64String(dataTable.Rows[0]["salt"].ToString());
                string password = OriginPassTB.Text;
                //驗證密碼
                bool success = VerifyHash(password, salt, hash);

                if (success)
                {
                    if (NewPassTB.Text == NewPassTB2.Text)
                    {
                        string data = $"UPDATE members SET password=@password, email=@email, salt=@salt, lastModifiedDate=@lastModifiedDate WHERE account=@account";
                        SqlCommand cmd = new SqlCommand(data, connection);

                        string newPassword = NewPassTB.Text;
                        var newSalt = CreateSalt();
                        string saltStr = Convert.ToBase64String(newSalt); //將 byte 改回字串存回資料表
                        var newHash = HashPassword(newPassword, newSalt);
                        string hashPassword = Convert.ToBase64String(newHash);
                        cmd.Parameters.AddWithValue("@account", account);
                        cmd.Parameters.AddWithValue("@password", hashPassword);
                        cmd.Parameters.AddWithValue("@salt", saltStr);
                        cmd.Parameters.AddWithValue("@email", EmailTB.Text);
                        cmd.Parameters.AddWithValue("@lastModifiedDate", dateNow);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    else
                    {
                        Label5.Text = "password is different";
                        Label5.ForeColor = Color.Red;
                        Label5.Visible = true;
                        return;
                    }
                }
                else
                {
                    //資料庫裡找不到相同資料時，表示密碼有誤!
                    Label1.Text = "password error";
                    Label1.ForeColor = Color.Red;
                    Label1.Visible = true;
                    return;
                }
            }
            Response.Redirect("profile.aspx");
        }
        // Argon2 加密
        //產生 Salt 功能
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        // Argon2 驗證加密密碼
        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; //迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }
        //驗證
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash); // LINEQ
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
    }
}