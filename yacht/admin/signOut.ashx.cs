using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace yacht.admin
{
    /// <summary>
    /// signOut 的摘要描述
    /// </summary>
    public class signOut : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //清除所有的 Session
            if (context.Session != null)
            {
                context.Session.Abandon();
                context.Session.RemoveAll();
            }

            //建立一個同名的 Cookie 來覆蓋原本的 Cookie
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authenticationCookie.Expires = DateTime.Now.AddYears(-1);
            context.Response.Cookies.Add(authenticationCookie);

            // 執行登出
            FormsAuthentication.SignOut();

            // 轉向到你登出後要到的頁面
            context.Response.Redirect("SignIn.aspx", true);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}