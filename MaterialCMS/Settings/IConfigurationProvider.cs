using System.Collections.Generic;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Settings
{
    public interface IConfigurationProvider : IClearCache
    {
        TSettings GetSiteSettings<TSettings>() where TSettings : SiteSettingsBase, new();
        void SaveSettings(SiteSettingsBase settings);
        void SaveSettings<T>(T settings) where T : SiteSettingsBase, new();
        void DeleteSettings<T>(T settings)where T : SiteSettingsBase, new();
        List<SiteSettingsBase> GetAllSiteSettings();
    }
}