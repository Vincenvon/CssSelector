using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CssSelector.UI.CustomViewEngine
{
    public class CustomViewEngine:IViewEngine
    {
        private string proxyViewName = ConfigurationManager.AppSettings["ProxyViewName"];
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName,
            bool useCache)
        {
            return new ViewEngineResult(new CustomView(controllerContext.Controller.ViewData.Model), this);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName,
            bool useCache)
        {
            if (viewName.Equals(proxyViewName))
            {
                return new ViewEngineResult(new CustomView(controllerContext.Controller.ViewData.Model), this);
            }
            else
            {
                var razorEngine = (RazorViewEngine)ViewEngines.Engines.Where(item => item.GetType() == typeof(RazorViewEngine))
                    .FirstOrDefault();
                return razorEngine.FindView(controllerContext,viewName,masterName,useCache);
            }
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
        }
    }

}