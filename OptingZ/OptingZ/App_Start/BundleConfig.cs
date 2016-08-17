﻿using System.Web;
using System.Web.Optimization;

namespace OptingZ
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base").Include(
              "~/Content/themes/base/all.css",
              "~/Content/themes/base/core.css",
              "~/Content/themes/base/autocomplete.css",
              "~/Content/themes/base/jquery.ui.button.css",
              "~/Content/themes/base/jquery.ui.datepicker.css",
              "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui-1.8.21.custom.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets/lib").Include(
              "~/Content/assets/libraries/font-awesome/css/font-awesome.min.css",
              "~/Content/assets/libraries/owl.carousel/assets/owl.carousel.css",
              "~/Content/assets/libraries/colorbox/example1/colorbox.css",
              "~/Content/assets/libraries/bootstrap-select/bootstrap-select.min.css",
              "~/Content/assets/libraries/bootstrap-fileinput/fileinput.min.css"));

            bundles.Add(new StyleBundle("~/Content/assets/csstest").Include(
                 "~/Content/assets/css/superlist.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

        }
    }
}
