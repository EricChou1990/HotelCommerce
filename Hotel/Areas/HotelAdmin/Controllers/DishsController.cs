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
    public class DishsController : Controller
    {
        //
        // GET: /HotelAdmin/Dishs/

        public ActionResult DishesPublish()
        {
            return View();
        }
       
        /// <param name="objModel"></param>
        /// <param name="DishImg"></param>
        /// <returns></returns>
        public ActionResult DoAdd(Dishes objModel, HttpPostedFileBase DishImg) 
        {
                
            try
            {
                   
                if (DishImg != null && DishImg.FileName != "")
                {
                   
                    double fileLength = DishImg.ContentLength / (1024.0 * 1024.0);
                    if (fileLength > 2.0)
                    {
                        return Content("<script>alert('max content of img is 2MB');loaction.href='" + Url.Action("DishesPublish") + "'</script>");
                    }
                  
                    string fileName = DishImg.FileName;
                    fileName = DateTime.Now.ToString("yyyyMMddmmhhss") + ".png";
                    objModel.DishImg = fileName;
                    int res = 0;

                    
                    if (objModel.DishId != 0&& objModel.DishId != null) 
                    {
                        
                        res = new DishMananger().ModifyDish(objModel);
                        if (res > 0)
                        {
                            
                            string filePath = Server.MapPath("~/UploadFile/" + fileName);
                            DishImg.SaveAs(filePath);
                            return Content("<script>alert('change successfully!');location.href='" + Url.Action("DishesManager") + "'</script>");
                        }
                        else
                        {
                            return Content("<script>alert('change successfully!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                    }
                    else {  
                        
                        res = new DishMananger().AddDish(objModel);
                        if (res > 0)
                        {
                            
                            string filePath = Server.MapPath("~/UploadFile/" + fileName);
                            DishImg.SaveAs(filePath);
                            return Content("<script>alert('change successfully!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                        else
                        {
                            return Content("<script>alert('change successfully!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                    
                    }                   
                }
                else
                {
                    return Content("<script>alert('please choose img!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                }
            }
            catch (Exception ex)
            {
                return Content("<script>alert('error'"+ex.Message+");location.href='" + Url.Action("DishesPublish") + "'</script>");
            }  
        }
        
        /// <param name="CategoryId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DishesManager(string CategoryId, int? id = 1)
        {
            int totalCount = 0;
            int pageIndex = id ?? 1;
            int pageSize = 6;
            PagedList<Dishes> objlist =new DishMananger().GetDishes(CategoryId, pageSize, (pageIndex - 1) * 5, out totalCount).AsQueryable().ToPagedList(pageIndex, pageSize);
            objlist.TotalItemCount = totalCount;
            objlist.CurrentPageIndex = (int)(id ?? 1);
            Hotel.Models.Common info=new    Hotel.Models.Common();     
            info.Dishes = objlist;
            return View("DishesManager", info);          
        }
       
        /// <param name="disId"></param>
        /// <returns></returns>
        public ActionResult DelDish(string disId) 
        {
           
            Dishes objModel=new DishMananger().GetDishById(disId);
            string filePath=Server.MapPath("~/UploadFile/"+objModel.DishImg);
            int res = new DishMananger().DelDish(disId);
            if (res > 0)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Content("delete successfully!");
            }
            else
            {
                return Content("fail to delete!");
            }
        }
    
    }
}
