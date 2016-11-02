using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using SimpleBlog;
using SimpleBlog.Core;
using System.Data.Entity;
using SimpleBlog.Core.Mappings;

namespace SimpleBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MockInitializer());

            DependencyContainer container = new DependencyContainer();
        }

        
    }
}
