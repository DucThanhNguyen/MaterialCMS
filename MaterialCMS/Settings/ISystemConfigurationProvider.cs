using System.Collections.Generic;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Settings
{
    public interface ISystemConfigurationProvider:IClearCache
    {
        TSettings GetSystemSettings<TSettings>() where TSettings : SystemSettingsBase, new();
        void SaveSettings(SystemSettingsBase settings);
        void SaveSettings<TSettings>(TSettings settings) where TSettings : SystemSettingsBase, new();
        List<SystemSettingsBase> GetAllSystemSettings();
    }
}