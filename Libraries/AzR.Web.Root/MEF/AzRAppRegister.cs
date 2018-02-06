using AzR.Utilities;
using System.Web.Mvc;

namespace AzR.Web.Root.MEF
{
    public class AzRAppRegister
    {
        public static void Register()
        {
            //var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //var container = new CompositionContainer(asmCatalog);

            AzRBootstrap.Intialize();
            ControllerBuilder.Current.SetControllerFactory(new AzRControllerFactory(AzRBootstrap.Container));


            //var dbContext = AzRBootstrap.Container.GetExportedValue<DbContext>();
            //AzRBootstrap.Container.ComposeExportedValue<DbContext>(dbContext);



            var resolver = new AzRDependencyResolver(AzRBootstrap.Container);
            // Install MEF dependency resolver for MVC
            DependencyResolver.SetResolver(resolver);
            // Install MEF dependency resolver for Web API
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
