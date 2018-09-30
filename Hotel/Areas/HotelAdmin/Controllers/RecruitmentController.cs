using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBLL;

namespace Hotel.Areas.HotelAdmin.Controllers
{
     [Authorize]
    public class RecruitmentController : Controller
    {
        //
        // GET: /HotelAdmin/Recruitment/

        public ActionResult RecruitmentPublish()
        {
            return View();
        }
        
        /// <returns></returns>
        public ActionResult RecruitmentManagers() 
        {
            List<Recruitment> objlist = new RecruitmentManager().GetAllRecList();
            ViewBag.list = objlist;
            return View();
        }
        public ActionResult ModifyRecruit(string postId) 
        {
            Recruitment objmodel = new RecruitmentManager().GetPostById(postId);
            return View("ModifyRecruit", objmodel);
        }
        public ActionResult DelPost(string postId) 
        {
            
            int res = new RecruitmentManager().DeleteRecruiment(postId);
            if (res > 0)
            {
                return Content("<script>alert('delete recruit post successfully!');location.href='" + Url.Action("RecruitmentManagers") + "'</script>");
            }
            else 
            {
                return Content("<script>alert('fail to delete recruit post!');location.href='" + Url.Action("RecruitmentManagers") + "'</script>");
            }
        }
     
        /// <param name="objRec"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoRecruitment(Recruitment objRec) 
        {
            objRec.PublishTime = DateTime.Now;
            int res = 0;
            if (objRec.PostId != 0)
            {
                res = new RecruitmentManager().ModifyRecruiment(objRec);
                if (res > 0)
                {
                    return Content("<script>alert('update recruit post successfully!');location.href='" + Url.Action("RecruitmentPublish") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('fail to update recruit post!');location.href='" + Url.Action("RecruitmentPublish") + "'</script>");
                }
            }
            else {
                //调用BLL（缺少了验证）
                res = new RecruitmentManager().AddRecruitment(objRec);
                if (res > 0)
                {
                    return Content("<script>alert('update recruit post successfully!');location.href='" + Url.Action("RecruitmentPublish") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('fail to update recruit post!');location.href='" + Url.Action("RecruitmentPublish") + "'</script>");
                }
            }
          
        }

    }
}
