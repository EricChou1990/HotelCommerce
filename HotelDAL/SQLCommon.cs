using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelDAL
{
  

    public class SQLCommon
    {
 
        public static DataSet GetList(int PageSize, string Order, int CurrentCount, string TableName, string where, out int TotalCount)
        {
            SqlParameter[] parmlist =
            {
                      new  SqlParameter("@PageSize",PageSize),       
                      new  SqlParameter("@CurrentCount",CurrentCount),
                      new  SqlParameter("@TableName",TableName),      
                      new  SqlParameter("@where",where),   
                      new  SqlParameter("@TotalCount",SqlDbType.Int,4),    
                      new  SqlParameter("@Order",Order)     
            };
            parmlist[4].Direction = ParameterDirection.Output;
            DataSet ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "prPager", parmlist);
            TotalCount = Convert.ToInt32(parmlist[4].Value);
            return ds;
        }
    }
}
