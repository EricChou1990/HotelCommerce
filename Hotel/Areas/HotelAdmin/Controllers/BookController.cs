using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Areas.HotelAdmin.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        //
        // GET: /HotelAdmin/Book/

        public ActionResult BookManagers()
        {
            List<DishBook> objlist = new DishBookManager().GetAllDishBook();
            ViewBag.list = objlist;
            return View();
        }
       
        [HttpGet]
        public ActionResult DoUpdate(string statId, string BookId) 
        {
            try
            {
               
                int res = new DishBookManager().ModifyBook(BookId, statId);
                if (res > 0)
                {
                    return Content("<script>alert('modification completed!');location.href='" + Url.Action("BookManagers") + "'</script>");
                }
                else {
                    return Content("<script>alert('modification completed!');location.href='" + Url.Action("BookManagers") + "'</script>");
                }
            }
            catch (Exception ex)
            {
                return Content("<script>alert('"+ex.Message+"');location.href='" + Url.Action("BookManagers") + "'</script>");
              
            }
        }

    }
}
