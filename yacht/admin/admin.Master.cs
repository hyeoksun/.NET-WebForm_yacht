using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yacht.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //清除Cache，避免登出後按上一頁還會顯示Cache頁面
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //權限關門判斷 (Cookie)
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("SignIn.aspx"); //導回登入頁
            }
            else
            {
                //取得驗證票夾帶資訊
                string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                string[] ticketUserDataArr = ticketUserData.Split(';');
                bool haveRight = HttpContext.Current.User.Identity.IsAuthenticated;
                //依管理權限導頁
                if (haveRight)
                {
                    if (ticketUserDataArr[0].Equals("True"))
                    {
                        //以驗證票夾帶資料作為限制，最高權限者使用時顯示使用者管理頁並切換圖示
                        ManageContentPlaceHolder.Visible = true;
                        ManageMainContentPlaceHolder.Visible = true;
                    }
                    else
                    {
                        ManageContentPlaceHolder.Visible = false;
                        ManageMainContentPlaceHolder.Visible = false;
                    }
                    //載入使用者個人基本資料(渲染畫面)
                    userName.Text = ticketUserDataArr[2];
                    photoLiteral.Text = $"<img src=\"/admin/upload/members/{ticketUserDataArr[3]}\" class=\"img-radius\" alt=\"User-Profile-Image\">";
                }
            }
        }
    }
}