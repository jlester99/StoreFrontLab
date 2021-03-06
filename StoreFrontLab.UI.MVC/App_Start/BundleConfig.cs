using System.Web.Optimization;

namespace StoreFrontLab.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                      "~/Content/assets/js/jquery-1.11.0.min.js",
                      "~/Content/assets/js/jquery-migrate-1.2.1.min.js",
                      "~/Content/assets/js/bootstrap.bundle.min.js",
                      "~/Content/assets/js/templatemo.js",
                      "~/Content/assets/js/custom.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/assets/css").Include(
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/fontawesome.min.css",
                      "~/Content/assets/css/templatemo.css",
                      "~/Content/assets/css/custom.css"));
        }
    }
}

 