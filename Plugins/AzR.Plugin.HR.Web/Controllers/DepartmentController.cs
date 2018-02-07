using AzR.Core.Services;
using AzR.Web.Root.Controllers;
using AzR.Web.Root.MEF;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace AzR.Plugin.HR.Web.Controllers
{
    [ControllerExport(typeof(DepartmentController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartmentController : BaseController
    {
        private IDepartmentService _dept;
        private readonly string _layout;
        [ImportingConstructor]
        public DepartmentController(IDepartmentService dept)
        {
            _dept = dept;
            _layout = LayoutPages["Public"];
        }

        public ActionResult Index()
        {
            var depts = _dept.GetAll();
            return View("Index", _layout, depts);
        }

    }
}
