using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class addDealer : System.Web.UI.Page
    {
        string getsql = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["yachtConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    CountryList.DataBind();
            //    DealerList();
            //}
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ////取得國家的值
            //string CounrtyID = CountryList.SelectedValue;
            //取得地區內容
            string area = AreaTB.Text;
            //存入資料庫
            SqlConnection connection = new SqlConnection(getsql);
            string data = $"INSERT INTO dealers(Area, CompanyName, Address, Contact, TEL, FAX, Email, Website, CountryId)VALUES(@Area, @CompanyName, @Address, @Contact, @TEL, @FAX, @Email, @Website, @CountryID)";
            SqlCommand cmd = new SqlCommand(data, connection);
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar);
            cmd.Parameters["@Area"].Value = AreaTB.Text;
            cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
            cmd.Parameters["@CompanyName"].Value = CompanyTB.Text;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
            cmd.Parameters["@Address"].Value = AddressTB.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
            cmd.Parameters["@Contact"].Value = ContactTB.Text;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar);
            cmd.Parameters["@TEL"].Value = TelTB.Text;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar);
            cmd.Parameters["@FAX"].Value = FaxTB.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            cmd.Parameters["@Email"].Value = EmailTB.Text;
            cmd.Parameters.Add("@Website", SqlDbType.NVarChar);
            cmd.Parameters["@Website"].Value = WebsiteTB.Text;
            cmd.Parameters.Add("@CountryID", SqlDbType.NVarChar);
            cmd.Parameters["@CountryID"].Value = CountryList.SelectedValue;
            connection.Open();
            cmd.ExecuteNonQuery();
            //將Photo存進目標資料夾
            string SavePath = Server.MapPath("~/admin/upload/dealerPhoto/");
            if (FileUpload1.HasFile)
            {
                DirectoryInfo info = new DirectoryInfo(SavePath);
                string FileName = FileUpload1.FileName;
                string[] FileNameArray = FileName.Split('.');
                int count = 0;
                foreach(var file in info.GetFiles())
                {
                    if (file.Name.Contains(FileNameArray[0]))
                    {
                        count++;
                    }
                }
                FileName = FileNameArray[0] + $"({count + 1})." + FileNameArray[1];
                FileUpload1.SaveAs(SavePath + FileName);
                string updateFileName = "UPDATE dealers SET Photo = @FileName WHERE Area=@area";
                SqlCommand sql = new SqlCommand(updateFileName, connection);
                sql.Parameters.AddWithValue("@FileName", FileName);
                sql.Parameters.AddWithValue("@area", area);
                sql.ExecuteNonQuery();
            }
            connection.Close();
            Response.Redirect("area_dealers.aspx");
            
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("area_dealers.aspx");
        }
    }
}