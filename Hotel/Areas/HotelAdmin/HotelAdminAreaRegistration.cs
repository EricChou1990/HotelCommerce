using System.Web.Mvc;

namespace Hotel.Areas.HotelAdmin
{
    public class HotelAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HotelAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HotelAdmin_default",
                "HotelAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
