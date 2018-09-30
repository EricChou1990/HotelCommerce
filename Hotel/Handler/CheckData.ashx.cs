using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Hotel.Handler
{
    /// <summary>
    /// CheckData 的摘要说明
    /// </summary>
    public class CheckData : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //如果用户直接请求该Handler则拒绝
            if (context.Request.UrlReferrer == null)
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }
            //获取请求来路的完整URL
            string url = context.Request.UrlReferrer.AbsoluteUri;
            if (!url.Contains("/CompanyDishes/DishesBooks"))
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }
            string validateType = context.Request["type"];//获取验证类型
            string validateValue = context.Request["value"];//获取验证的值
            //根据类型验证
            if (validateType == "uname")
            {
                //验证用户名是否已经存在...

            }
            else if (validateType == "email")
            {
                //验证邮箱是否已经注册...

            }
            else if (validateType == "checkcode")
            {
                if (validateValue != context.Session["ValidateCode"].ToString())
                    context.Response.Write("0");//表示验证码不正确
                else
                    context.Response.Write("1");
            }
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