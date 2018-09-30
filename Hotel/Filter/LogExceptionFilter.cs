using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Hotel.Filter
{
    public class LogExceptionFilter:FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //定义日志文件路径
            string filePath = filterContext.HttpContext.Server.MapPath(@"~/log.txt");
            //写入日志信息
            using(StreamWriter sw=File.AppendText(filePath))
            {
                sw.WriteLine("时间:{0}", DateTime.Now.ToString());
                sw.WriteLine("控制器:{0}",filterContext.RouteData.Values["Controller"]);
                sw.WriteLine("动作方法:{0}", filterContext.RouteData.Values["Action"]);
                sw.WriteLine("异常信息:{0}",filterContext.Exception.Message);
            }
        }
    }
}