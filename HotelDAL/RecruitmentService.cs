using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelDAL
{
  public class RecruitmentService
    {
        
        /// <param name="objRecru"></param>
        /// <returns></returns>
        public int AddRecruitment(Recruitment objRecru)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("INSERT INTO Recruitment (PostName,PostType,PostPlace,PostDesc,");
            strsql.Append("PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)");
            strsql.Append("VALUES(@PostName,@PostType,@PostPlace,@PostDesc,");
            strsql.Append("@PostRequire,@Experience,@EduBackground,@RequireCount,");
            strsql.Append("@Manager,@PhoneNumber,@Email)");
            SqlParameter[] param = new SqlParameter[] 
         { 
             new SqlParameter("@PostName",objRecru.PostName),
             new SqlParameter("@PostType",objRecru.PostType),
             new SqlParameter("@PostPlace",objRecru.PostPlace),
             new SqlParameter("@PostDesc",objRecru.PostDesc),
             new SqlParameter("@PostRequire",objRecru.PostRequire),
             new SqlParameter("@EduBackground",objRecru.EduBackground),
             new SqlParameter("@Experience",objRecru.Experience),
             new SqlParameter("@RequireCount",objRecru.RequireCount),
             new SqlParameter("@Manager",objRecru.Manager),           
             new SqlParameter("@PhoneNumber",objRecru.PhoneNumber),
             new SqlParameter("@Email",objRecru.Email)            
         };
            return SQLHelper.Update(strsql.ToString(), param);
        }
       
        /// <returns></returns>
        public List<Recruitment> GetAllRecList()
        {
            string sql = "SELECT *  FROM Recruitment";
            DataTable dt = SQLHelper.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<Recruitment> objList = new List<Recruitment>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Recruitment model = new Recruitment();
                    model.PostId = Convert.ToInt32(dt.Rows[i]["PostId"].ToString());
                    model.PostName = dt.Rows[i]["PostName"].ToString();
                    model.EduBackground = dt.Rows[i]["EduBackground"].ToString();
                    model.Email = dt.Rows[i]["Email"].ToString();
                    model.Experience = dt.Rows[i]["Experience"].ToString();
                    model.Manager = dt.Rows[i]["Manager"].ToString();
                    model.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                    model.PostDesc = dt.Rows[i]["PostDesc"].ToString();
                    model.PostPlace = dt.Rows[i]["PostPlace"].ToString();
                    model.PostRequire = dt.Rows[i]["PostRequire"].ToString();
                    model.PostType = dt.Rows[i]["PostType"].ToString();
                    model.PublishTime = Convert.ToDateTime(dt.Rows[i]["PublishTime"]);
                    model.RequireCount = Convert.ToInt32(dt.Rows[i]["RequireCount"]);
                    objList.Add(model);
                }
                return objList;
            }
            return null;
        }
       
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(string postId)
        {
            string sql = "SELECT * FROM Recruitment WHERE PostId=@PostId";
            Recruitment objRec = null;
            SqlParameter[] param = new SqlParameter[] 
            {
               new SqlParameter("@PostId",postId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objRec = new Recruitment()
                {
                    PostId = Convert.ToInt32(objReader["PostId"]),
                    PostName = objReader["PostName"].ToString(),
                    PostPlace = objReader["PostPlace"].ToString(),
                    RequireCount = Convert.ToInt32(objReader["RequireCount"]),
                    PostType = objReader["PostType"].ToString(),
                    PostDesc = objReader["PostDesc"].ToString(),
                    PostRequire = objReader["PostRequire"].ToString(),
                    Experience = objReader["Experience"].ToString(),
                    EduBackground = objReader["EduBackground"].ToString(),
                    Manager = objReader["Manager"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                };
            }
            objReader.Close();
            return objRec;
        }
       
        /// <param name="objRecruitment"></param>
        /// <returns></returns>
        public int ModifyRecruiment(Recruitment objRecruitment)
        {
            string sql = "UPDATE Recruitment SET PostName=@PostName,PostType=@PostType,PostPlace=@PostPlace,PostDesc=@PostDesc,";
            sql += "PostRequire=@PostRequire,Experience=@Experience,EduBackground=@EduBackground,RequireCount=@RequireCount,PublishTime=getdate(),";
            sql += "Manager=@Manager,PhoneNumber=@PhoneNumber,Email=@Email  WHERE PostId=@PostId";
            SqlParameter[] param = new SqlParameter[]
            {
                   new SqlParameter("@PostName",objRecruitment.PostName),
                   new SqlParameter("@PostType",objRecruitment.PostType),
                   new SqlParameter("@PostPlace",objRecruitment.PostPlace),             
                   new SqlParameter("@PostDesc",objRecruitment.PostDesc),
                   new SqlParameter("@PostRequire",objRecruitment.PostRequire),
                   new SqlParameter("@Experience",objRecruitment.Experience),
                   new SqlParameter("@EduBackground",objRecruitment.EduBackground),
                   new SqlParameter("@RequireCount",objRecruitment.RequireCount),
                   new SqlParameter("@Manager",objRecruitment.Manager),
                   new SqlParameter("@PhoneNumber",objRecruitment.PhoneNumber),
                   new SqlParameter("@Email",objRecruitment.Email),
                   new SqlParameter("@PostId",objRecruitment.PostId)
            };
            return SQLHelper.Update(sql, param);
        }
       
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruiment(string postId)
        {
            string sql = "delete from Recruitment where PostId=@PostId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@PostId", postId) };
            return SQLHelper.Update(sql, param);
        }
    }
}

