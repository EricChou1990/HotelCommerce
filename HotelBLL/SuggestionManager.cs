using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
    public class SuggestionManager
    {
        SuggestionService objsug = new SuggestionService();
      
        /// <param name="objSuggestion"></param>
        /// <returns></returns>
        public int SubmitSuggestion(Suggestion objSuggestion)
        {
            return objsug.SubmitSuggestion(objSuggestion);
        }
      
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            return objsug.GetSuggestion();
        }
        
        /// <param name="suggestionId"></param>
        /// <returns></returns>
        public int HandlSuggestion(string suggestionId)
        {
            return objsug.HandlSuggestion(suggestionId);
        }
    }
}
