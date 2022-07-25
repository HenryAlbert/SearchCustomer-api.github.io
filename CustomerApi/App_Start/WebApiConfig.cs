using DBService;
using Customer.Service.Viewmodel;
using Service.Data;
using Service.Models;
using System.Web.Http;
using Unity;
using Newtonsoft.Json;

namespace refactor_this
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
             
            //Register the IOC Container - Unity 
            var container = new Unity.UnityContainer();
            container.RegisterType<DBService.IDBRepository, DBService.DBRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICustomerModule, CustomerModule>();

            config.DependencyResolver = new IocUnityConfig(container);
    
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;


          
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

     
            config.Routes.MapHttpRoute(
                name: "defaultapi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
