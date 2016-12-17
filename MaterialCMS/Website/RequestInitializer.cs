using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Elmah;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Services;
using MaterialCMS.Settings;
using Ninject;
using StackExchange.Profiling;

namespace MaterialCMS.Website
{
    public static class RequestInitializer
    {
        public static void Initialize(HttpRequest request)
        {
            CurrentRequestData.ErrorSignal = ErrorSignal.FromCurrentContext();

            var kernel = MaterialCMSKernel.Kernel;
            CurrentRequestData.CurrentContext.SetKernel(kernel);
            if (!IsFileRequest(request.Url))
            {
                CurrentRequestData.CurrentSite = kernel.Get<Site>();
                CurrentRequestData.SiteSettings = kernel.Get<SiteSettings>();
                CurrentRequestData.HomePage = kernel.Get<IGetHomePage>().Get();
                Thread.CurrentThread.CurrentCulture = CurrentRequestData.SiteSettings.CultureInfo;
                Thread.CurrentThread.CurrentUICulture = CurrentRequestData.SiteSettings.CultureInfo;

                if (MiniProfilerAuth.ShouldStartFor(request))
                    MiniProfiler.Start();
            }
        }

        public static bool IsFileRequest(Uri uri)
        {
            string absolutePath = uri.AbsolutePath;
            if (string.IsNullOrWhiteSpace(absolutePath))
                return false;
            string extension = Path.GetExtension(absolutePath);

            return !string.IsNullOrWhiteSpace(extension) && !WebExtensions.Contains(extension);
        }

        private static IEnumerable<string> WebExtensions => MaterialCMSKernel.Kernel.Get<WebExtensionsToRoute>().Get;
    }
}