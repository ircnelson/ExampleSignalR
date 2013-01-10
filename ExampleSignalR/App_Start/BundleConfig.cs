using System.Web;
using System.Web.Optimization;

namespace ExampleSignalR
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();

            #region Javascripts

            bundles.Add(new ScriptBundle("~/bundles/jasmine").Include(
                    "~/Scripts/jasmine-1.3.1/jasmine.js",
                    "~/Scripts/jasmine-1.3.1/jasmine-html.js",
                    "~/Scripts/jasmine-jquery.js",
                    "~/Scripts/mock-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                    "~/Scripts/highcharts/highcharts.js",
                    "~/Scripts/highcharts/modules/exporting.js"));

            bundles.Add(new ScriptBundle("~/bundles/autosuggest").Include(
                    "~/Scripts/jquery.autosuggest.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                    "~/Scripts/knockout-2.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/json").Include(
                    "~/Scripts/json2.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                    "~/Scripts/jquery.signalR-1.0.0-rc1.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.tmpl.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-1.9.2.custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            #endregion

            #region Stylesheets

            bundles.Add(new StyleBundle("~/css/jasmine").Include(
                    "~/Scripts/jasmine-1.3.1/jasmine.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                        "~/Content/bootstrap.css", 
                        "~/Content/bootstrap-responsive.css",
                        "~/Content/bootstrap-custom.css"));

            bundles.Add(new StyleBundle("~/css/autosuggest").Include(
                        "~/Content/autoSuggest.css"));

            bundles.Add(new StyleBundle("~/css/themes/bootstrap/css").Include(
                        "~/Content/themes/bootstrap/jquery-ui-1.9.2.custom.css"));

            bundles.Add(new StyleBundle("~/css/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            #endregion
        }
    }
}