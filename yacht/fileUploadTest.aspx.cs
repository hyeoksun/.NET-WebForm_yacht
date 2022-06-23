using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class fileUploadTest : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] ImageNames = Builditemarr();
                SetImageItems(CheckBoxList1, ImageNames);
            }
        }
        private string[] Builditemarr()
        {
            //string id = Request.QueryString["ID"].ToString();
            SqlConnection connection = new SqlConnection(getsql);
            string sql = $"SELECT * FROM uploadTest";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            //command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            List<string> filename_list = new List<string>();
            //string file = "";
            while (dataReader.Read())
            {
                //file = file + dataReader["FileName"].ToString() + ",";

                filename_list.Add(dataReader["photoName"].ToString());
            }
            //file = file.TrimEnd(',');
            connection.Close();
            string[] Filename = filename_list.ToArray();
            //string[] Filename = file.Split(',');
            return Filename;
        }
        private void SetImageItems(ListControl lc, string[] ImageNames)
        {
            foreach (string ImageName in ImageNames)
            {
                ListItem li = new ListItem();
                li.Text = $@"<img src='/admin/upload/news/attached/{ImageName}' width='250px' height='200px' />";
                li.Value = ImageName;
                lc.Items.Add(li);
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //將附件檔案存進目標資料夾
            string SavePath2 = Server.MapPath("~/admin/upload/news/attached/");
            if (FileUpload1.HasFile)
            {
                DirectoryInfo attached = new DirectoryInfo(SavePath2);
                foreach (var postedFile in FileUpload1.PostedFiles)
                {
                    string attachedFileName = Path.GetFileName(postedFile.FileName);
                    string[] attachedFileNameArray = attachedFileName.Split('.');
                    int count = 0;
                    foreach (var file in attached.GetFiles())
                    {
                        if (file.Name.Contains(attachedFileNameArray[0]))
                        {
                            count++;
                        }    
                    }
                    SqlConnection connection = new SqlConnection(getsql);
                    connection.Open();
                    attachedFileName = attachedFileNameArray[0] + $"({count + 1})." + attachedFileNameArray[1];
                    postedFile.SaveAs(SavePath2 + attachedFileName);
                    string attachedName2 = "INSERT INTO uploadTest(photoName) VALUES(@photoName)";
                    SqlCommand cmd = new SqlCommand(attachedName2, connection);
                    cmd.Parameters.Add("@photoName", SqlDbType.NVarChar);
                    cmd.Parameters["@photoName"].Value = attachedFileName;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string check = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    check += CheckBoxList1.Items[i].Value.ToString() + ",";
                }
            }
            check.TrimEnd(',');
            string[] checkstrary = check.Split(',');
            foreach (string checkstr in checkstrary)
            {
                string SavePath = Server.MapPath("~/admin/upload/news/attached/");
                //連接 Sql連線
                SqlConnection connect = new SqlConnection(getsql);
                
                
                SqlCommand command2 = new SqlCommand($"SELECT photoName FROM uploadTest WHERE (photoName = @photoName)", connect);
                command2.Parameters.AddWithValue("@photoName",checkstr);
                connect.Open();
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    string DelFile = reader["photoName"].ToString();
                    File.Delete(SavePath + DelFile);
                }
                reader.Close();
                //這邊刪除會有PK和FK的問題  所以要先刪除 FK 的內容再刪除 PK 的內容
                SqlCommand command = new SqlCommand($"DELETE FROM uploadTest WHERE (photoName = @photoName)", connect);
                command.Parameters.AddWithValue("@photoName", checkstr);
                command.ExecuteNonQuery();
                
                connect.Close();
            }
            string url = Request.Url.ToString();
            Response.Write($"<script>alert('Have Already Delete');;location.href='{url}';</script>");
        }
    }
}