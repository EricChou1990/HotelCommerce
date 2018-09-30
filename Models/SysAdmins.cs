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
 public  class SysAdmins
    {
       [DisplayName("username")]
        [Required(ErrorMessage="{0}can't be empty")]
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        [DisplayName("password")]
        [Required(ErrorMessage = "{0}can't be empty")]
        public string LoginPwd { get; set; }            
    }
}
