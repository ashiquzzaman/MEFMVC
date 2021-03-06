﻿using AzR.Web.Root.MEF;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AzR.Web.Root.Controllers
{
    public abstract class BaseController : Controller, IAzRController
    {
        protected readonly Dictionary<string, string> LayoutPages = new Dictionary<string, string>
        {
            {"Public" , "~/Views/Shared/_Layout.cshtml" }
        };
    }
}
