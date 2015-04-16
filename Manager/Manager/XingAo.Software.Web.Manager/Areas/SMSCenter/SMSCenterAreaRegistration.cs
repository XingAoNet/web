using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.SMSCenter
{
    public class SMSCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SMSCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SMSCenter_default",
                "SMSCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
