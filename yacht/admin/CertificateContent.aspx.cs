using CKFinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class CertificateContent : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                SqlConnection connection = new SqlConnection(getsql);
                SqlCommand cmd = new SqlCommand($"SELECT certificate.* FROM certificate WHERE id=1", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["certificateContent"].ToString());
                    //ContentTB.Text = reader["certificateContent"].ToString();
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string Content = HttpUtility.HtmlEncode(CKEditorControl1.Text);
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection connection = new SqlConnection(getsql);
            string data = "UPDATE certificate SET certificateContent = @certificateContent, LastMotifiedDate = @LastMotifiedDate WHERE id=1";
            SqlCommand command = new SqlCommand(data, connection);
            command.Parameters.AddWithValue("@certificateContent", Content);
            command.Parameters.AddWithValue("@LastMotifiedDate", dateNow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("Certificate.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Certificate.aspx");
        }
    }
}