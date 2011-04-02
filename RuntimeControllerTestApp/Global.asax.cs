﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fusonic.Web.Mvc.RuntimeController;
using System.Reflection;

namespace RuntimeControllerTestApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
			       RegisterRoutes(RouteTable.Routes);
						
			RuntimeControllerFactory factory = new RuntimeControllerFactory(new DefaultPathProvider());
			factory.ReferenceAssembly(Assembly.GetExecutingAssembly());
			
			ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}