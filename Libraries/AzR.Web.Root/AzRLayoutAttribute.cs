using System.Web.Mvc;

namespace AzR.Web.Root
{
    public class AzRLayoutAttribute : ActionFilterAttribute
    {
        private readonly string _masterName;
        public AzRLayoutAttribute(string masterName)
        {
            _masterName = masterName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.MasterName = _masterName;
            }
        }
    }
}
