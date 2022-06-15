using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRestaurantDemoApp
{
    public class MvcApplication : IHttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(Route);
        }
    }

 
}
