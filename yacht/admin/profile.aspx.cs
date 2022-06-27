using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadInfo();
            }
        }

        private void loadInfo()
        {
            string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] ticketUserDataArr = ticketUserData.Split(';');
            string account = ticketUserDataArr[1].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM members WHERE account = @account", connection);
            cmd.Parameters.Add("@account", SqlDbType.NVarChar);
            cmd.Parameters["@account"].Value = account;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string SavePath = reader["photo"].ToString();
                LiteralImg.Text = $"<img alt='Contact Image' src='/admin/upload/members/{SavePath}' style='display:block; margin:auto;'' Width='210px'/>";
                accountLab.Text = reader["account"].ToString();
                nameLab.Text = reader["name"].ToString();
                mailLab.Text = reader["email"].ToString();
            }
            connection.Close();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
    }
}