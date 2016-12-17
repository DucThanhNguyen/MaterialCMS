using MaterialCMS.Services.Resources;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class MaterialCMSResources
    {
        public static string Get(string key, string defaultValue = null)
        {
            return MaterialCMSApplication.Get<IStringResourceProvider>().GetValue(key, defaultValue);
        }
    }
}