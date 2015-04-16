using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.Wechats
{
    public class WechatsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Wechats";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Wechats_default",
                "Wechats/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
