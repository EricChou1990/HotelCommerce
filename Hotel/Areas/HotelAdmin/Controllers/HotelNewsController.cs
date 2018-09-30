using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Hotel.Areas.HotelAdmin.Controllers
{
     [Authorize]
    public class HotelNewsController : Controller
    {
        //
        // GET: /HotelAdmin/HotelNews/

        public ActionResult NewsPublish()
        {
            return View();
        }
        public ActionResult NewsUpDate(string newsId)
        {
            News objmodel = new NewsManager().GetNewsById(newsId);
            objmodel.NewsId = Convert.ToInt32(newsId);
            return View("NewsUpDate", objmodel);
        }
        [HttpGet]
       
        /// <returns></returns>
        public ActionResult NewManagers(int? id = 1)
        {
            int totalCount = 0;
            int pageIndex = id ?? 1;
            int pageSize = 6;
            PagedList<News> objlist = new NewsManager().GetNews("", pageSize, (pageIndex - 1) * 5, out totalCount).AsQueryable().ToPagedList(pageIndex, pageSize);
            objlist.TotalItemCount = totalCount;
            objlist.CurrentPageIndex = (int)(id ?? 1);
            Hotel.Models.Common info = new Hotel.Models.Common();
            info.objNewsModel = objlist;
            return View("NewManagers", info);
        }
        [HttpGet]
        public ActionResult DoDelNew(string newsId)
        {
          
            int res = new NewsManager().DelNews(newsId);
            if (res > 0)
            {
                return Content("<script>alert('delete news successfully!');location.href='" + Url.Action("NewManagers") + "'</script>");
            }
            else {
                return Content("<script>alert('fail to delete news!');location.href='" + Url.Action("NewManagers") + "'</script>");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DoNews(News objModel)
        {
            
            objModel.PublishTime = DateTime.Now;
            int res = 0;
            if (objModel.NewsId != 0&& objModel.NewsId != null)   
            {
                res = new NewsManager().ModifyNews(objModel);
                if (res > 0)
                {
                    return Content("<script>alert('modify new successfully!');location.href='" + Url.Action("NewManagers") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('fail to modify!');location.href='" + Url.Action("NewsUpDate") + "'</script>");
                }

            }
            else
            {
                res = new NewsManager().PublishNews(objModel);
                if (res > 0)
                {
                    return Content("<script>alert('publish news successfully!');location.href='" + Url.Action("NewsPublish") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('fail to publish news!');location.href='" + Url.Action("NewsPublish") + "'</script>");
                }
            }

        }

    }
}
