using AzR.Plugin.Test.Web.Models;
using AzR.Web.Root.Controllers;
using AzR.Web.Root.MEF;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace AzR.Plugin.Test.Web.Controllers
{
    [ControllerExport(typeof(TestController))]
    // [ExportMetadata("ControllerName", "Home")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestController : BaseController
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            ViewBag.TestModel = new TestModel() { Foo = "Hello Swami" };
            return View();
        }

    }
}
