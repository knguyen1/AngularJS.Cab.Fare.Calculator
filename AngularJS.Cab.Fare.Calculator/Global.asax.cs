using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using AngularJS.Cab.Fare.Calculator.App_Start;
using AngularJS.Cab.Fare.Calculator.Services;
using AngularJS.Cab.Fare.Calculator.Controllers;
using StructureMap;
using AngularJS.Cab.Fare.Calculator.DependencyResolution;

namespace AngularJS.Cab.Fare.Calculator
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //bundling css and javascript
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = false; //enabling bundling and minification

            //register classes and interfaces
            //StructureMap Container
            IContainer container = IoC.Initialize();

            //Register for MVC
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));

            //Register for Web API
            var resolver = new StructureMapDependencyResolver(container);
        }
    }
}