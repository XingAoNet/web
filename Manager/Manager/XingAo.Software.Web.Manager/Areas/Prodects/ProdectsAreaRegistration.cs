using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Areas.Prodects
{
    public class ProdectsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Prodects";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Prodects_default",
                "Prodects/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
