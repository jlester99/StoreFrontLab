using StoreFrontLab.UI.MVC.Models;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StoreFrontLab.UI.MVC
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            Exception ex = this.Server.GetLastError();

            if (ex is HttpException)
            {
                HttpException httpEx = (HttpException)ex;

                if (httpEx.GetHttpCode() == 404)
                {
                    Response.Redirect("~/Errors/NotFound");
                }
                else
                {
                    Response.Redirect("~/Errors/Unresolved");
                }
            }
        }
    }// end class
}//end namespace
