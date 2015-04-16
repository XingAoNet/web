using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.Templates
{
    public class TemplatesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Templates";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Templates_default",
                "Templates/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
