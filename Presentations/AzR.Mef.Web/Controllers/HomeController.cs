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
        private readonly string _layout;
        [ImportingConstructor]
        public HomeController()
        {
            _layout = LayoutPages["Public"];
        }

        public ActionResult Index()
        {
            return View("Index", masterName: _layout);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About", masterName: _layout);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact", masterName: _layout);
        }
    }
}