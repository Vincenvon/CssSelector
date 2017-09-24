using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CssSelector.BL.Factory;
using CssSelector.BL.HtmlPageDocument;
using CssSelector.BL.Service;
using CssSelector.BL.Service.UserService;
using Ninject;

namespace CssSelector.UI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        private string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;

        public NinjectControllerFactory()
        {
            _ninjectKernel=new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext context,Type controllerType)
        {
            return (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IHtmlPageDocument>().To<HtmlPageDocument>();
            _ninjectKernel.Bind<IUserService>().ToMethod(contex => Factory.GetService(connectionString));
            _ninjectKernel.Bind<IDataBaseService>()
                .ToMethod(contex => ElementServiceFactory.GetElementService(connectionString));
        }
    }
}