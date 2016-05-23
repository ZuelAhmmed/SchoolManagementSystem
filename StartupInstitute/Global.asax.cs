using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using StartupInstitute.Security;

namespace StartupInstitute
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer js = new JavaScriptSerializer();
                UserSecurityRole user = js.Deserialize<UserSecurityRole>(ticket.UserData);
                SecurityIdentity identity = new SecurityIdentity(user);
                SecurityPrinciple principle = new SecurityPrinciple(identity);
                HttpContext.Current.User = principle;
            }
        }

    }
}
