using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
   
    public class DishBookManager
    {
        DishBookService objDishBookS = new DishBookService();
       
        /// <param name="objDishBook"></param>
        /// <returns></returns>
        public int Book(DishBook objDishBook)
        {
            return objDishBookS.Book(objDishBook);
        }
       
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(string bookId, string orderStatus)
        {
            return objDishBookS.ModifyBook(bookId, orderStatus);
        }
       
        /// <returns></returns>
        public List<DishBook> GetAllDishBook()
        {
            return objDishBookS.GetAllDishBook();
        }
    }
}
