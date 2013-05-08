using System.Web;
using System.Web.Optimization;

namespace mm_contest
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.colorbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/stylesheets/base.css",
                        "~/Content/stylesheets/skeleton.css",
                        "~/Content/stylesheets/layout.css",
                        "~/Content/stylesheets/buttons.css",
                        "~/Content/stylesheets/form.css",
                        "~/Content/stylesheets/colorbox.css"));
        }
    }
}