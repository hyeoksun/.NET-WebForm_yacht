using CKFinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class updateYachtContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadContent();
            }
        }

        private void loadContent()
        {
            string id=Request.QueryString["id"];
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.BasePath = "/ckfinder";
            fileBrowser.SetupCKEditor(CKEditorControl1);
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM yachtType WHERE id=@id", connection);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar);
            cmd.Parameters["@id"].Value = id;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["overviewContent"].ToString());
                CKEditorControl2.Text = HttpUtility.HtmlDecode(reader["layout"].ToString());
                CKEditorControl3.Text = HttpUtility.HtmlDecode(reader["specification"].ToString());
            }
            connection.Close();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string overview = HttpUtility.HtmlEncode(CKEditorControl1.Text);
            string layout = HttpUtility.HtmlEncode(CKEditorControl2.Text);
            string specification= HttpUtility.HtmlEncode(CKEditorControl3.Text);
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string data = "UPDATE yachtType SET overviewContent = @overviewContent, layout = @layout, specification = @specification, LastModifiedDate = @LastModifiedDate WHERE id=@id";
            SqlCommand command = new SqlCommand(data, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@overviewContent", overview);
            command.Parameters.AddWithValue("@layout", layout);
            command.Parameters.AddWithValue("@specification", specification);
            command.Parameters.AddWithValue("@LastModifiedDate", dateNow);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Response.Redirect($"updateYachtPhoto.aspx?id={id}");
        }
    }
}