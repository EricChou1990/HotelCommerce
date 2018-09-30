using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace Hotel.Models
{
    public class Common
    {
        public PagedList<Dishes> Dishes { get; set; }
        public PagedList<News> objNewsModel { get; set; }
    }
}