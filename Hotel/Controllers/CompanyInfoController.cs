using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CompanyInfoController : Controller
    {
        //
        // GET: /CompanyInfo/

        public ActionResult Index()
        {
            List<News> objlist = new NewsManager().GetNews(5);
            ViewBag.list = objlist;
            return View();
        }
        
        /// <returns></returns>
        public ActionResult ComDesc() 
        {
            return View();
        }
        public ActionResult JoinUs()
        {
            return View();
        }
        public ActionResult DoSugg(Suggestion objSug,string ValidateCode ) 
        {
            if (String.Compare(Session["ValidateCode"].ToString(), ValidateCode, true) != 0)
            {
                ModelState.AddModelError("yzm", "wrong code");
                return View("Suggestions");
            }
            else
            {
              
                int res = new SuggestionManager().SubmitSuggestion(objSug);
                if (res > 0)
                {
                    return Content("add successfully!");
                }
                else
                {
                    return Content("fail to add!");
                }
            }
          
        }
        
        /// <returns></returns>
        public ActionResult Suggestions() 
        {
            return View();
        }
        public ActionResult AboutUs() 
        {
            return View();
        }
        public ActionResult ZhaoPinList() 
        {
            return View();
        }
        public ActionResult ZhaoPinDetail(string PostId) 
        {
            Recruitment objRec = new RecruitmentManager().GetPostById(PostId);
            return View("ZhaoPinDetail", objRec);
         }
    }
}
