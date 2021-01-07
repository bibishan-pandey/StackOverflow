using System.Web.Optimization;

namespace StackOverflow
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
                .Include(
                    "~/Scripts/jquery-3.5.1.js",
                    "~/Scripts/umd/popper.js",
                    "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include(
                    "~/Content/bootstrap.css",
                    "~/Content/styles.css"
                    ));
            BundleTable.EnableOptimizations = true;
        }
    }
}