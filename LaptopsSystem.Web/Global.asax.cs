using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using LaptopsSystem.Data;
using LaptopsSystem.Data.Migrations;
using LaptopsSystem.Web.App_Start;

namespace LaptopsSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<LaptopsSystemDbContext>(new MigrateDatabaseToLatestVersion<LaptopsSystemDbContext, Configuration>());

            BundleTable.EnableOptimizations = false;

            AutoMapperConfig.RegisterMappings();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
