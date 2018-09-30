using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
 public   class SysAdminService
    {
   
  
     /// <param name="objmodel"></param>
     /// <returns></returns>
     public SysAdmins AdminLogin(SysAdmins objmodel)
     {
         string sql = "SELECT LoginName FROM SysAdmins WHERE LoginId=@LoginId and LoginPwd=@LoginPwd";
         SqlParameter[] param = new SqlParameter[] 
         {
             new SqlParameter("@LoginId",objmodel.LoginId),
             new SqlParameter("@LoginPwd",objmodel.LoginPwd)
         };
         try
         {
             SqlDataReader objReader = SQLHelper.GetReader(sql, param);
             if (objReader.Read())
             {
                 objmodel = new SysAdmins()
                 {
                     LoginName = objReader["LoginName"].ToString()
                 };
             }
             else
             {
                 objmodel = null;
             }
             objReader.Read();
            
         }
         catch (Exception ex)
         {
             throw ex;
         }
         return objmodel;
     }
    }
}
