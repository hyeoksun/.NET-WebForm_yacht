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
    public partial class addYachtContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ckeditor();
            }
        }

        private void ckeditor()
        {
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.BasePath = "/ckfinder";
            fileBrowser.SetupCKEditor(overviewCK);
            fileBrowser.SetupCKEditor(layoutCK);
            fileBrowser.SetupCKEditor(specificationCK);
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string id= Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            connection.Open();
            string data = "UPDATE yachtType SET overviewContent = @overviewContent, layout = @layout, specification = @specification WHERE id=@id";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@overviewContent", overviewCK.Text);
            cmd.Parameters.AddWithValue("@layout", layoutCK.Text);
            cmd.Parameters.AddWithValue("@specification", specificationCK.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("yacht.aspx");
        }
    }
}