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
    public partial class yacht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM [yachtType]", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                dataAdapter.Fill(set);
                GridView1.DataSource = set;
                GridView1.DataBind();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addYacht.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"delete from yachtType WHERE  (id = {id})", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect(Request.Url.ToString());
        }
    }
}