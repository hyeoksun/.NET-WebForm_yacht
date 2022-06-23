using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //取得國家的值
            string Counrty = coutryDropDownList.SelectedValue;
            //取得船型的值
            string Yacht = yachtDropDownList.SelectedValue;

            //存入資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            string data = $"INSERT INTO contact(Name, Email, Phone, Country, Type, Comments)VALUES(@Name, @Email, @Phone, @Country, @Type, @Comments)";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            cmd.Parameters["@Name"].Value = name.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            cmd.Parameters["@Email"].Value = email.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
            cmd.Parameters["@Phone"].Value = phone.Text;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar);
            cmd.Parameters["@Country"].Value = Counrty;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
            cmd.Parameters["@Type"].Value = Yacht;
            cmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
            cmd.Parameters["@Comments"].Value = comments.Text;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("contact.aspx");
        }
    }
}