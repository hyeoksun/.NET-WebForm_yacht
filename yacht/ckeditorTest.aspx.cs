using CKFinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.BasePath = "/ckfinder";
            fileBrowser.SetupCKEditor(CKEditorControl1);
                
                SqlConnection connection = new SqlConnection(getsql);
                string sql = "SELECT context FROM test WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //渲染畫面
                    CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["context"].ToString());
                }
                connection.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string test = HttpUtility.HtmlEncode(CKEditorControl1.Text);
            SqlConnection connection = new SqlConnection(getsql);
            //string sql = "INSERT INTO test (context) VALUES(@context)";
            //SqlCommand cmd = new SqlCommand(sql, connection);
            //cmd.Parameters.Add("@context", SqlDbType.NVarChar);
            //cmd.Parameters["@context"].Value = test;
            string sql = "UPDATE test SET context=@context WHERE id=1";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@context", test);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String saveDir = @"/admin/upload/";
            String fileName, savePath;
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                fileName = postedFile.FileName;

                // –完成檔案上傳的動作。
                savePath = saveDir + fileName;
                postedFile.SaveAs(savePath);

                //myLabel.Append("<hr>檔名---- " + fileName);
            }

            SqlConnection connection = new SqlConnection(getsql);
            string sql = "UPDATE test SET context=@context WHERE id=1";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@context", saveDir);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}