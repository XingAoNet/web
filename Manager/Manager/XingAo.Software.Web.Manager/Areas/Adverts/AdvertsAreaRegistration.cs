using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.Adverts
{
    public class AdvertsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Adverts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Adverts_default",
                "Adverts/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
