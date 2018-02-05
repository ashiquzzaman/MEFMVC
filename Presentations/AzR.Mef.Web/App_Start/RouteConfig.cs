using AzR.Mef.Web.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace AzR.Mef.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { typeof(HomeController).Namespace }
                //namespaces: new string[] { "AzR.Mef.Web.Controllers", "AzR.Plugin.Test.Web.Controllers" }
            );
        }
    }
}
