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
    public partial class contact : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridviewData();
            }
        }
        private void gridviewData()
        {
            SqlConnection sqlConnection = new SqlConnection(getsql);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT  id, Name, Email, Phone, Country, Type, Comments,InitDate FROM contact ORDER BY InitDate DESC", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
            sqlConnection.Close();
        }
    }
}