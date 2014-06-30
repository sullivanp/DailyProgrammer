using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GraphMapper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GraphMapper.Models.GraphMapperContext, GraphMapper.Migrations.Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GraphMapper.Models.ApplicationDbContext, GraphMapper.MigrationsAppDb.Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Use the fixed HandleErrorAttributeWithHealthMonitoring
            //filters.Add(new HandleErrorAttributeWithHealthMonitoring());
        }  
    }
}
