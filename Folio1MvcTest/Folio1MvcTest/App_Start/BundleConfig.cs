using System.Web;
using System.Web.Optimization;

namespace Folio1MvcTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            // angularJS scripts
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-*")
                .Include("~/Scripts/angular/app.js")
                .IncludeDirectory("~/Scripts/angular", "*.js", true)
                .IncludeDirectory("~/Scripts/plugins", "*.js", true)
                .IncludeDirectory("~/Scripts/angular-ui", "*.js", true)
            );

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia")
                .Include("~/Scripts/app/inspinia.js")
            );

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/*.css", new CssRewriteUrlTransform())
                .Include("~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/fonts/font-awesome/css/*.css", new CssRewriteUrlTransform())

                );
        }
    }
}
