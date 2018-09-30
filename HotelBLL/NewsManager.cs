using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
   public class NewsManager
    {
       NewsService objNewsService = new NewsService();
      
       /// <param name="count"></param>
       /// <returns></returns>
        public List<News> GetNews(int count)
        {
            return objNewsService.GetNews(count);
        }
        public string GetCategoryName(int categoryId) 
        {
            return objNewsService.GetCategoryName(categoryId);
        }
       
       /// <param name="objmodel"></param>
       /// <returns></returns>
        public int ModifyNews(News objmodel)
        {
            return objNewsService.ModifyNews(objmodel);
        }
         
        /// <returns></returns>
        public List<NewsCategory> GetAllCategory()
        {
            return objNewsService.GetAllCategory();
        }
      
       /// <param name="newsId"></param>
       /// <returns></returns>
        public int DelNews(string newsId)
        {
            return objNewsService.DelNews(newsId);
        }
       
        /// <param name="stuName"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentCount"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public List<News> GetNews(string CategoryId, int pageSize, int currentCount, out int TotalCount)
        {
            return objNewsService.GetNews(CategoryId, pageSize, currentCount, out TotalCount);
        }
       
       /// <param name="newsId"></param>
       /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            return objNewsService.GetNewsById(newsId);
        }
      
       /// <param name="objNews"></param>
       /// <returns></returns>
        public int PublishNews(News objNews)
        {
            return objNewsService.PublishNews(objNews);
        }
    }
}
