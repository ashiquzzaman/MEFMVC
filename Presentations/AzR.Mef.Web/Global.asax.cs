using AzR.Utilities;
using AzR.Web.Root.MEF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AzR.Mef.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var pluginFolders = new List<string>();

            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")).ToList();

            plugins.ForEach(s =>
            {
                var di = new DirectoryInfo(s);
                pluginFolders.Add(di.Name);
            });

            AreaRegistration.RegisterAllAreas();

            //TODO Move into startup class 
            #region MOVETOSTATUP

            AzRBootstrap.Intialize();
            ControllerBuilder.Current.SetControllerFactory(new AzRControllerFactory(AzRBootstrap.Container));
            // ModelBinders.Binders.DefaultBinder = new InterfaceModelBinder();


            #endregion

            ViewEngines.Engines.Add(new AzRViewEngine(pluginFolders));


            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //MefBootstrap.Intialize(pluginFolders);
            //ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory());



        }
    }
}
