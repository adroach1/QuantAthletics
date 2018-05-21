using AdminSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AdminSite
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureUnity();
            ConfigureJson();
        }

        private void ConfigureUnity()
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.BuildContainer();
            var userController = container.Resolve(typeof(UserController), "");
            var unityResolver = new UnityResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = unityResolver;

        }

        private void ConfigureJson()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

    }
}