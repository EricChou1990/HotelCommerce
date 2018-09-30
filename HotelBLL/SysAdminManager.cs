using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
 public   class SysAdminManager
    {
     public SysAdmins AdminLogin(SysAdmins objmodel)
     {
         return new SysAdminService().AdminLogin(objmodel);
     }
    }
}
