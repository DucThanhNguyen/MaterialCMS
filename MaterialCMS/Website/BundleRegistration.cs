using System.Web.Optimization;
using MaterialCMS.Settings;
using MaterialCMS.Website.Optimization;
using Ninject;

namespace MaterialCMS.Website
{
    public static class BundleRegistration
    {
        public static void Register(IKernel kernel)
        {
            if (!CurrentRequestData.DatabaseIsInstalled)
                return;

            foreach (IStylesheetBundle bundle in kernel.GetAll<IStylesheetBundle>())
            {
                var styleBundle = new StyleBundle(bundle.Url);
                foreach (string file in bundle.Files)
                {
                    styleBundle.Include(file);
                }
                BundleTable.Bundles.Add(styleBundle);
            }
            foreach (IScriptBundle bundle in kernel.GetAll<IScriptBundle>())
            {
                var styleBundle = new ScriptBundle(bundle.Url);
                foreach (string file in bundle.Files)
                {
                    styleBundle.Include(file);
                }
                BundleTable.Bundles.Add(styleBundle);
            }
            BundleTable.EnableOptimizations = kernel.Get<BundlingSettings>().EnableOptimisations;
        }
    }
}