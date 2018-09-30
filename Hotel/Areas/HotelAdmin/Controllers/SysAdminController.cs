using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Areas.HotelAdmin.Controllers
{
    public class SysAdminController : Controller
    {
        //
        // GET: /HotelAdmin/SysAdmin/

        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        [Authorize]
        public ActionResult AdminMain()
        {
            string name = User.Identity.Name;
            return View();
        }
        
        public ActionResult SuggestionList()
        {
            List<Suggestion> objlist = new SuggestionManager().GetSuggestion();         
            return View("SuggestionList",objlist);
        }
        [HttpGet]
        public ActionResult DoSugg(string suggId) 
        {
            
            int res = new SuggestionManager().HandlSuggestion(suggId);
            if (res > 0)
            {
                return Content("<script>alert('suggestion has been taken!');location.href='" + Url.Action("SuggestionList") + "'</script>");
            }
            else
            {
                return Content("<script>alert('fail to update suggestion!');location.href='" + Url.Action("SuggestionList") + "'</script>");
            }
          
        }
        
        /// <returns></returns>
        public ActionResult ExtSys() 
        {
            Session["currentAdmin"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("AdminLogin");
        }
       
        /// <param name="objSys"></param>
        /// <returns></returns>
        public ActionResult LoginUser(SysAdmins objSys) 
        {
            
            if (ModelState.IsValid)
            {
                
                objSys = new SysAdminManager().AdminLogin(objSys);
                
                if (objSys != null)
                {
                    Session["currentAdmin"] = objSys.LoginName;
                    
                    FormsAuthentication.SetAuthCookie(objSys.LoginName, true);
                    return View("AdminMain");
                }
                else
                {
                    return Content("<script>alert('wrong username or password!');location.href='" + Url.Action("Index") + "'</script>");
                }
            }
            else
           {

                return View("AdminLogin");
            }
           
        }
    }
}
