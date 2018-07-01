using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using ContactManager.DependancyResolver;
using ContactManager.Models;
using Ninject;
//using WebApiContrib.IoC.Ninject
namespace ContactManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var kernel = new StandardKernel();
            kernel.Bind<IContactStore>().To<ContactStore>();
            // Web API routes
            config.MapHttpAttributeRoutes();


            Register(config, kernel);
        }

        public static void Register(HttpConfiguration config, IKernel kernel)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/html");
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");

            config.DependencyResolver = new NinjectResolver(kernel);
            config.Routes.MapHttpRoute(
                            name: "ControllerWithExt",
                            routeTemplate: "api/{controller}.{ext}");
            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
