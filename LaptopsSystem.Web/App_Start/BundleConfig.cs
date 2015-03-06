using System.Web;
using System.Web.Optimization;

namespace LaptopsSystem.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.11.3.custom/jquery-ui.js",
                        "~/Scripts/Custom/autocomplete-and-slider.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/voting").Include(
                        "~/Scripts/Custom/voting-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/image").Include(
                        "~/Scripts/Custom/image-modal.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.slate.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Scripts/jquery-ui-1.11.3.custom/jqueryui").Include(
                "~/Scripts/jquery-ui-1.11.3.custom/jquery-ui.css",
                "~/Scripts/jquery-ui-1.11.3.custom/jquery-ui.structure.css",
                "~/Scripts/jquery-ui-1.11.3.custom/jquery-ui.theme.css"));

        }
    }
}
