using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Profile;
using System.Web.Routing;
using System.Web.Security;

namespace GraphMapper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
        {
            var profile = HttpContext.Current.Profile;
            //profile.SetPropertyValue("a", true);
            //ProfileCommon anonymousProfile = profile.GetProfile(args.AnonymousID);
            var anonymousID = args.AnonymousID;
            AnonymousIdentificationModule.ClearAnonymousIdentifier();
            Membership.DeleteUser(args.AnonymousID, true);
        }
    }
}
