using System.Web;
using System.Web.Optimization;

namespace CompanyPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/i18n/grid.locale-en.js",
                        "~/Scripts/jquery.jqGrid.min.js",
                         "~/Scripts/jquery.unobtrusive-ajax.js",
                         "~/Scripts/jquery.contextMenu.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/lib/js/responsive.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        
                       "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/lib/site.css",
                      "~/lib/responsive.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/jquery.jqGrid/ui.jqgrid.css"
                      ));


            //js  
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-{version}.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include("~/lib/js/site.js"));
            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                   "~/Content/jquery-ui.css",
                   "~/Content/font-awesome.css"));


            

        }
    }
}
