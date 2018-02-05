using System.Collections.Generic;
using System.Web.Mvc;

namespace AzR.Web.Root.MEF
{
    public class AzRViewEngine : RazorViewEngine
    {
        private List<string> _plugins = new List<string>();

        public AzRViewEngine(List<string> pluginFolders)
        {
            _plugins = pluginFolders;

            ViewLocationFormats = GetViewLocations();
            MasterLocationFormats = GetMasterLocations();
            PartialViewLocationFormats = GetViewLocations();
        }

        public string[] GetViewLocations()
        {
            var views = new List<string> { "~/Views/{1}/{0}.cshtml", "~/bin/Views/{1}/{0}.cshtml" };

            _plugins.ForEach(plugin =>
                views.Add("~/Plugins/" + plugin + "/Views/{1}/{0}.cshtml")
            );
            _plugins.ForEach(plugin =>
                views.Add("~/bin/" + plugin + "/Views/{1}/{0}.cshtml")
            );
            return views.ToArray();
        }

        public string[] GetMasterLocations()
        {
            var masterPages = new List<string> { "~/Views/Shared/{0}.cshtml", "~/bin/Views/Shared/{0}.cshtml" };


            _plugins.ForEach(plugin =>
                masterPages.Add("~/Plugins/" + plugin + "/Views/Shared/{0}.cshtml")
            );
            _plugins.ForEach(plugin =>
                masterPages.Add("~/bin/" + plugin + "/Views/Shared/{0}.cshtml")
            );

            return masterPages.ToArray();
        }
    }
}