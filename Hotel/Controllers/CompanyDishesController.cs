using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using Models;
using HotelBLL;
using Webdiyer.WebControls.Mvc;

namespace Hotel.Controllers
{
    public class CompanyDishesController : Controller
    {
        //
        // GET: /CompanyDishes/

        public ActionResult DishesBooks()
        {
            return View();
        }
        public ActionResult Environment() 
        {
            return View();
        }
       
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DishesShow(int? id=1) 
        {
            int totalCount=0;
            int pageIndex=id??1;
            int pageSize=6;
          PagedList<Dishes> objlist=new DishMananger().GetDishes("",pageSize,(pageIndex-1)*6,out totalCount).AsQueryable().ToPagedList(pageIndex,pageSize);
          objlist.TotalItemCount = totalCount;
          objlist.CurrentPageIndex = (int)(id ?? 1);
          Hotel.Models.Common info = new Hotel.Models.Common();
          info.Dishes = objlist;
            return View("DishesShow",info);
        }
        /// <summary>
        /// 在线预订
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoAdd(DishBook objDish)
        {
            
            objDish.BookTime = DateTime.Now;
           int res = new DishBookManager().Book(objDish);
           if (res > 0)
           {
               return Content("success");
           }
           else
           {
               return Content("error");
           }          
        }
       
        /// <returns></returns>
        public ActionResult ExsitsValidate()
        {
            string txtValidateCode = Request["value"];          
            if (String.Compare(Session["ValidateCode"].ToString(), txtValidateCode, true) != 0)
            {                
                return Content("0");  
            }
            else
            {
                return Content("1");
            }
        }
       
        /// <returns></returns>
        public ActionResult ValidateCode() 
        {
            CreateValidateCode objCreate = new CreateValidateCode();
            string code = objCreate.CreateRandomCode(6);
            Session["ValidateCode"] = code;         
            return File(objCreate.CreateValidateGraphic(code), "images/jpeg");
        }
    }
}
