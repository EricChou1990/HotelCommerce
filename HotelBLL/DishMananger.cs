using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
  public  class DishMananger
    {
      DishService objdish = new DishService();
     
      /// <param name="objDish"></param>
      /// <returns></returns>
      public int AddDish(Dishes objDish)
      {
          return objdish.AddDish(objDish);
      }
      public List<DishCategory> GetALL()
      {
          return objdish.GetALL();
      }
      public string CategoryName(int id)
      {
          return objdish.CategoryName(id);
      }
     
      /// <param name="stuName"></param>
      /// <param name="pageSize"></param>
      /// <param name="currentCount"></param>
      /// <param name="TotalCount"></param>
      /// <returns></returns>
      public  List<Dishes> GetDishes(string CategoryId, int pageSize, int currentCount, out int TotalCount)
      {
          return objdish.GetDishes(CategoryId, pageSize, currentCount, out TotalCount);
      }
     
      /// <param name="id"></param>
      /// <returns></returns>
      public Dishes GetDishById(string id)
      {
          return objdish.GetDishById(id);
      }
      public int ModifyDish(Dishes objDish)
      {
          return objdish.ModifyDish(objDish);
      }
     
      /// <param name="id"></param>
      /// <returns></returns>
      public int DelDish(string id)
      {
          return objdish.DelDish(id);
      }
    }
}
