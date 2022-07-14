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
    public partial class area_dealers : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(getsql);
                SqlCommand cmd = new SqlCommand(@"SELECT  country.*, dealers.* FROM  country INNER JOIN dealers ON country.id = dealers.CountryId", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                dataAdapter.Fill(set);
                GridView1.DataSource = set;
                GridView1.DataBind();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDealer.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection sqlConnection = new SqlConnection(getsql);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"delete from dealers WHERE  (id = {id})", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect(Request.Url.ToString());
        }
    }
}