﻿using System.Web;
using System.Web.Optimization;

namespace LaptopsSystem.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/Custom/set-timezone-cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                        "~/Scripts/globalize/globalize.js",
                        "~/Scripts/globalize/globalize-validation.js"));
                        //.IncludeDirectory("~/Scripts/globalize/cultures",string.Format("*.{0}.js",System.Globalization.CultureInfo.CurrentCulture.Name)));

            bundles.Add(new ScriptBundle("~/bundles/custom")
                .Include("~/Scripts/jquery-ui-1.11.3.custom/jquery-ui.js")
                .IncludeDirectory("~/Scripts/Custom", "*.js", false));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.slate.css",
                        "~/Content/jquery-ui.css",
                        "~/Content/jquery-ui.structure.css",
                        "~/Content/jquery-ui.theme.css",
                        "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
