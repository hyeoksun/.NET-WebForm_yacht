using CKEditor.NET;
using CKFinder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class AboutUsContent : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl2);
                SqlConnection connection = new SqlConnection(getsql);
                string sql = "SELECT AboutUsContent FROM AboutUs WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //渲染畫面
                    CKEditorControl2.Text = HttpUtility.HtmlDecode(reader["AboutUsContent"].ToString());
                }
                connection.Close();
            }
            
        }

        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            string aboutUs = HttpUtility.HtmlEncode(CKEditorControl2.Text);
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection connection = new SqlConnection(getsql);
            string sql = "UPDATE AboutUs SET AboutUsContent = @AboutUsContent, LastMotifiedDate = @LastMotifiedDate WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AboutUsContent", aboutUs);
            command.Parameters.AddWithValue("@LastMotifiedDate", dateNow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("AboutUs.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }
    }
}