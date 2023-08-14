using System.Web;
using System.Web.Optimization;

namespace Online_Shopping
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTables").Include(
                     "~/Scripts/js/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesBootstrap").Include(
                      "~/Scripts/js/dataTables.bootstrap4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                    "~/Scripts/js/scripts.js",
                    "~/Scripts/js/togglescripts.js",
                    "~/Scripts/js/Password.js"

                    ));
            bundles.Add(new ScriptBundle("~/bundles/Feather").Include(
                    "~/Scripts/js/feather.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                   "~/Scripts/js/script.js"));
            bundles.Add(new ScriptBundle("~/bundles/FontAwesome").Include(
                     "~/Scripts/js/Fontawesome.js"));
            bundles.Add(new ScriptBundle("~/bundles/fa").Include(
                    "~/Scripts/js/fontawesome.com.js"


                                                  ));
            bundles.Add(new ScriptBundle("~/bundles/toggle").Include(
                   "~/Scripts/js/togglescripts.js"

                   ));

            bundles.Add(new ScriptBundle("~/bundles/simple").Include(

                     "~/Scripts/js/datatables-simple-demo.js"

                                                   ));

            bundles.Add(new ScriptBundle("~/bundles/fade").Include(
                     "~/Scripts/js/FadeOut.js"
                                                 ));
            bundles.Add(new ScriptBundle("~/bundles/heart").Include(
                     "~/Scripts/js/heart.js"
                                                 ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                       ));
            bundles.Add(new StyleBundle("~/Content/table").Include(
                      "~/Content/css/table.css"
                       ));

            bundles.Add(new StyleBundle("~/Content/nav").Include(
                      "~/Content/css/styles.css"
                       ));
        }
    }
}
