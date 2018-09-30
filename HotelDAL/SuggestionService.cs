using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelDAL
{
    public class SuggestionService
    {
      
        /// <param name="objSuggestion"></param>
        /// <returns></returns>
        public int SubmitSuggestion(Suggestion objSuggestion)
        {
            string sql = "INSERT INTO Suggestion (CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)";
            sql += " VALUES(@CustomerName,@ConsumeDesc,@SuggestionDesc,@PhoneNumber,@Email)";
            SqlParameter[] param = new SqlParameter[]
           {
               new SqlParameter("@CustomerName",objSuggestion.CustomerName),
               new SqlParameter("@ConsumeDesc",objSuggestion.ConsumeDesc),
               new SqlParameter("@SuggestionDesc",objSuggestion.SuggestionDesc),  
               new SqlParameter("@PhoneNumber",objSuggestion.PhoneNumber),
               new SqlParameter("@Email",objSuggestion.Email)
           };
            return Convert.ToInt32(SQLHelper.Update(sql, param));
        }
      
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            string sql = "SELECT  * FROM Suggestion";
            sql += " WHERE StatusId=0 ORDER BY SuggestTime DESC";
            List<Suggestion> list = new List<Suggestion>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {

                list.Add(new Suggestion()
                {
                    SuggestionId = Convert.ToInt32(objReader["SuggestionId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    ConsumeDesc = objReader["ConsumeDesc"].ToString(),
                    SuggestionDesc = objReader["SuggestionDesc"].ToString(),
                    SuggestTime = Convert.ToDateTime(objReader["SuggestTime"]),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),
                    StatusId = Convert.ToInt32(objReader["StatusId"])
                });
            }
            objReader.Close();
            return list;
        }
      
        /// <param name="suggestionId"></param>
        /// <returns></returns>
        public int HandlSuggestion(string suggestionId)
        {
            string sql = "UPDATE Suggestion SET statusId=1 WHERE SuggestionId=@SuggestionId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@SuggestionId", suggestionId) };
            return SQLHelper.Update(sql, param);
        }
    }
}
