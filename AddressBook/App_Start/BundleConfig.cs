using System.Web;
using System.Web.Optimization;

namespace AddressBook
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-multiselect.js",
                       "~/Scripts/moment.min.js",
                       "~/Scripts/bootstrap-datetimepicker.min.js",

                       "~/Scripts/respond.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/jsGrid").Include(
                      "~/Scripts/jsGrid/jsgrid.js",
                      "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/AlertJs.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/bootstrap-multiselect.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/jsgrid-theme.css",
                      "~/Content/jsgrid.css",
                      "~/Content/JsGridCustomization.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/site.css"));
        }
    }
}
