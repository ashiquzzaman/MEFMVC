using AzR.Web.Root.MEF;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

//Install-Package Microsoft.Composition -Version 1.0.31
namespace AzR.Mef.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AzRAppRegister.Register();
            ViewEngines.Engines.Add(new AzRViewEngine());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //  AppDomain.CurrentDomain.AssemblyResolve += AzRBootstrap.CurrentDomain_AssemblyResolve;

        }


    }
}
