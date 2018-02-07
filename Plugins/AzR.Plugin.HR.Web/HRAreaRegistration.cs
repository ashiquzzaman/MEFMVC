using System.Web.Mvc;

namespace AzR.Plugin.HR.Web
{
    public class HRAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HR_default",
                "hr/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "AzR.Plugin.HR.Web.Controllers" }
            );
        }

    }
}