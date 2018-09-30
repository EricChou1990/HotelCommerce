using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
   
    [Serializable]
    public class Recruitment
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostType { get; set; }
        public string PostPlace { get; set; }
        public string PostDesc { get; set; }
        public string PostRequire { get; set; }
        public string Experience { get; set; }
        public string EduBackground { get; set; }
        public int RequireCount { get; set; }
        public DateTime PublishTime { get; set; }
        public string Manager { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
