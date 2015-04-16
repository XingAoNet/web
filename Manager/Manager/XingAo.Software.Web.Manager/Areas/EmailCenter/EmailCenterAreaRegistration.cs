using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.EmailCenter
{
    public class EmailCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmailCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmailCenter_default",
                "EmailCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
