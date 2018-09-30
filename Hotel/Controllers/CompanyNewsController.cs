using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CompanyNewsController : Controller
    {
        //
        // GET: /CompanyNews/

        public ActionResult Index()
        {
            return View();
        }
       
        /// <param name="newsId"></param>
        /// <returns></returns>
        public ActionResult NewsDetail(string newsId) 
        {
            News objModel=new NewsManager().GetNewsById(newsId);
            return View("NewsDetail",objModel);
        }
        public ActionResult NewsList() 
        {
            return View();
        }

    }
}
