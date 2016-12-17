using System.Configuration;

namespace MaterialCMS.Settings
{
    public sealed class MaterialCMSSettingsSection : ConfigurationSection
    {
        public MaterialCMSSettingsSection()
        {
        }

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public KeyValueConfigurationCollection Settings
        {
            get { return base[""] as KeyValueConfigurationCollection; }
        }
    }
}