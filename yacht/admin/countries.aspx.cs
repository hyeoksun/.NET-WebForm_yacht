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
    public partial class countries : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridviewData();
            }
            //TextBox1.Text = "Country Name";
            //TextBox1.Attributes.Add("style", "font-size:10px;color=#666666");//改變文字大小顏色
            //TextBox1.Attributes.Add("onFocus", "this.value=''");//點擊後清除文字
        }
        private void gridviewData()
        {
            SqlConnection sqlConnection = new SqlConnection(getsql);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT  id, Country, InitDate, LastMotifiedDate FROM country", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
            sqlConnection.Close();
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(getsql);
            SqlCommand cmd = new SqlCommand($"INSERT INTO country(Country)VALUES(@Country)",connection);
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar);
            cmd.Parameters["@Country"].Value = TextBox1.Text;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridviewData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridviewData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Country =((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            DateTime getdate = DateTime.Now;
            string dateNow = getdate.ToString("yyyy-MM-dd HH:mm:ss");
            string Update = "UPDATE country SET Country='" + Country + "', LastMotifiedDate='" + dateNow + "'WHERE id=" + id;
            //string up = $"UPDATE country SET Country={Country}, LastMotifiedDate={getdate} WHERE id={id}";
            SqlConnection sql = new SqlConnection(getsql);
            sql.Open();
            SqlCommand cmd = new SqlCommand(Update, sql);
            cmd.ExecuteNonQuery();
            sql.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection sqlConnection = new SqlConnection(getsql);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"delete from country WHERE  (id = {id})", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect(Request.Url.ToString());
        }
    }
}