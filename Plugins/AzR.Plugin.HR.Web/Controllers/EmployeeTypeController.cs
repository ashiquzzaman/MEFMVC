using AzR.Core.Services;
using AzR.Web.Root.Controllers;
using AzR.Web.Root.MEF;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace AzR.Plugin.HR.Web.Controllers
{
    [ControllerExport(typeof(EmployeeTypeController))]
    // [ExportMetadata("ControllerName", "Employee")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeeTypeController : BaseController
    {
        private IEmployeeTypeService _employee;
        private readonly string _layout;
        [ImportingConstructor]
        public EmployeeTypeController(IEmployeeTypeService employee)
        {
            _employee = employee;
            _layout = LayoutPages["Public"];
        }

        public ActionResult Index()
        {
            var employees = _employee.GetAll();

            return View("Index", _layout, employees);
        }

    }
}
