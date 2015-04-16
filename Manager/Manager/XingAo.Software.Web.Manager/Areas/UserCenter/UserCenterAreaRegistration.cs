using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.UserCenter
{
    public class UserCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UserCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UserCenter_default",
                "UserCenter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
