using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CardSaleSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            Console.WriteLine("Session:start---"+ Session["_PreUserCode"]);
            Console.WriteLine("Session:start---"+ Session["_Point"]);
            Console.WriteLine("Session:start---"+ Session["_IsAdmin"]);
            Console.WriteLine("Session:start---"+ Session["_UserInfo"]);
        }

        protected void Session_End()
        {
            Console.WriteLine("Session:end---" + Session["_PreUserCode"]);
            Console.WriteLine("Session:end---" + Session["_Point"]);
            Console.WriteLine("Session:end---" + Session["_IsAdmin"]);
            Console.WriteLine("Session:end---" + Session["_UserInfo"]);
        }
    }
}
