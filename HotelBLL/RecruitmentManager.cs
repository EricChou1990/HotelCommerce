using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
    public class RecruitmentManager
    {
        RecruitmentService objRe = new RecruitmentService();
     
        /// <param name="objRecru"></param>
        /// <returns></returns>
        public int AddRecruitment(Recruitment objRecru)
        {
            return objRe.AddRecruitment(objRecru);
        }
      
        /// <returns></returns>
        public List<Recruitment> GetAllRecList()
        {
            return objRe.GetAllRecList();
        }
      
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(string postId)
        {
            return objRe.GetPostById(postId);
        }
      
        
        /// <param name="objRecruitment"></param>
        /// <returns></returns>
        public int ModifyRecruiment(Recruitment objRecruitment)
        {
            return objRe.ModifyRecruiment(objRecruitment);
        }
      
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruiment(string postId)
        {
            return objRe.DeleteRecruiment(postId);
        }
    }
}
