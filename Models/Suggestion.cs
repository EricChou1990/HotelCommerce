using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Models
{
  
    [Serializable]
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        [DisplayName("username")]
        [Required(ErrorMessage="{0}can't be empty")]
        public string CustomerName { get; set; }
        [DisplayName("purchasing")]
        [Required(ErrorMessage = "{0}can't be empty")]
        public string ConsumeDesc { get; set; }
        [DisplayName("suggestion list")]
        [Required(ErrorMessage = "{0}can't be empty")]
        public string SuggestionDesc { get; set; }
        public DateTime SuggestTime { get; set; }
        [DisplayName("phone number")]
        [Required(ErrorMessage = "{0}can't be empty")]
        [RegularExpression(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$",ErrorMessage="please enter{0}")]
        public string PhoneNumber { get; set; }
        [DisplayName("email")]
        [Required(ErrorMessage = "{0}can't be empty")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "please enter{0}")]
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
