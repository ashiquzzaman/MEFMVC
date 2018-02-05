using AzR.Web.Root.Controllers;
using AzR.Web.Root.MEF;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace AzR.Mef.Web.Controllers
{
    [ControllerExport(typeof(HomeController))]
    // [ExportMetadata("ControllerName", "Home")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}