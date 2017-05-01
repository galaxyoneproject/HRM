using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace HRMWebApplication
{
    public class Global : HttpApplication
    {
        HRMModel db = new HRMModel();

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                List<string> roles = db.GetRoles(HttpContext.Current.User.Identity.Name);
                System.Security.Principal.GenericPrincipal ppl = new System.Security.Principal.GenericPrincipal(HttpContext.Current.User.Identity, roles.ToArray());
                HttpContext.Current.User = ppl;
            }
        }
    }
}