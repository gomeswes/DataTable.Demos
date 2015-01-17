using System.Web;
using System.Web.Optimization;

namespace DataTable.Demos.Site
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.2.min.js", 
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.dataTables.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/Scripts")
                .Include("~/Scripts/jquery-1.11.2.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.dataTables.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css",
                        "~/Content/Site.css",
                        "~/Content/jquery.dataTables.min.css",
                        "~/Content/bootstrap-theme.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css"));

            BundleTable.EnableOptimizations= false;
        }
    }
}