using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
  public  class DishService
    {
      public List<DishCategory> GetALL() 
      {
          string sql = "select CategoryId,CategoryName from DishCategory ";
          SqlDataReader objreader = SQLHelper.GetReader(sql);
          List<DishCategory> objlist = new List<DishCategory>();
          while (objreader.Read())
          {
              objlist.Add(new DishCategory()
              {
                  CategoryId =Convert.ToInt32( objreader["CategoryId"]),
                  CategoryName = objreader["CategoryName"].ToString()
              });
          }
          objreader.Close();
          return objlist;
      }
     
      /// <param name="objDish"></param>
      /// <returns></returns>
      public int AddDish(Dishes objDish) 
      {
          StringBuilder strsql = new StringBuilder("INSERT INTO Dishes");
          strsql.Append(" (DishName,UnitPrice,CategoryId,DishImg) VALUES ");
          strsql.Append(" (@DishName,@UnitPrice,@CategoryId,@DishImg); SELECT @@IDENTITY");
          SqlParameter[] param = new SqlParameter[] 
          {
            new SqlParameter("@DishName",objDish.DishName),
            new SqlParameter("@UnitPrice",objDish.UnitPrice),
            new SqlParameter("@CategoryId",objDish.CategoryId),
            new SqlParameter("@DishImg",objDish.DishImg)
            };
          return Convert.ToInt32( SQLHelper.GetSingleResult(strsql.ToString(), param));
      }
      
      /// <param name="objDish"></param>
      /// <returns></returns>

      public int ModifyDish(Dishes objDish)
      {         
          SqlParameter[] param = new SqlParameter[] 
          {
            new SqlParameter("@DishName",objDish.DishName),
            new SqlParameter("@UnitPrice",objDish.UnitPrice),
            new SqlParameter("@CategoryId",objDish.CategoryId),
            new SqlParameter("@DishId",objDish.DishId),
            new SqlParameter("@DishImg",objDish.DishImg)
            };
          return SQLHelper.UpdateByProcedure("usp_UpDish", param);
      }

     
      /// <param name="stuName"></param>
      /// <param name="pageSize"></param>
      /// <param name="currentCount"></param>
      /// <param name="TotalCount"></param>
      /// <returns></returns>
      public  List<Dishes> GetDishes(string CategoryId, int pageSize, int currentCount, out int TotalCount)
      {
          string order = string.Format("DishId DESC");
          string TableName = string.Format("Dishes");
          string Where = "1=1";
          if (!string.IsNullOrEmpty(CategoryId)) 
          {
              Where += string.Format("  And CategoryId='{0}'", CategoryId);
          }
          DataSet ds = SQLCommon.GetList(pageSize, order, currentCount, TableName, Where, out TotalCount);
          List<Dishes> result = new List<Dishes>();
          if (ds != null && ds.Tables.Count > 0)
          {
              foreach (DataRow dr in ds.Tables[0].Rows)
              {
                  result.Add(new Dishes()
                  {
                      CategoryId = Convert.ToInt32(dr["CategoryId"]),                      
                      DishImg = dr["DishImg"].ToString(),
                      DishId = Convert.ToInt32(dr["DishId"]),
                      DishName = dr["DishName"].ToString(),
                      UnitPrice = Convert.ToInt32(dr["UnitPrice"])                    
                  });
              }
          }
          return result;
      }
  
      /// <param name="id"></param>
      /// <returns></returns>
      public string CategoryName(int id) 
      {
          string sql =string.Format( "select CategoryName from DishCategory where CategoryId={0}",id);
          SqlDataReader objreader = SQLHelper.GetReader(sql);
          string categoryName=null;
          if (objreader.Read()) {
              categoryName = objreader["CategoryName"].ToString();
          }
          return categoryName;

      }
   
      /// <param name="id"></param>
      /// <returns></returns>
      public Dishes GetDishById(string id)
      {
          string sql = "select DishName,UnitPrice,CategoryId,DishImg from Dishes where DishId=@DishId";
          SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@DishId",id)
          };
          Dishes objDish = null;
          try
          {
              SqlDataReader objReader = SQLHelper.GetReader(sql, param);
              if (objReader.Read())
              {
                  objDish = new Dishes()
                  {
                      CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                      DishImg = objReader["DishImg"].ToString(),                  
                      DishName = objReader["DishName"].ToString(),
                      UnitPrice = Convert.ToInt32(objReader["UnitPrice"])    
                  };             
              }
              objReader.Close();
              return objDish;
          }
          catch (Exception)
          {

              throw;
          }
          
      }

    
      /// <param name="id"></param>
      /// <returns></returns>
      public int DelDish(string id)
      {
          string sql = "Delete from Dishes where DishId=@DishId";
          SqlParameter[] param = new SqlParameter[] {
            new SqlParameter("@DishId",id)
          };
          return Convert.ToInt32( SQLHelper.GetSingleResult(sql, param));
       }
    }
}
