namespace MaterialCMS.Settings
{
    public class DatabaseSettings : SystemSettingsBase
    {
        [AppSettingName("materialcms-database-provider")]
        public string DatabaseProviderType { get; set; }

        [ConnectionString("materialcms")]
        public string ConnectionString { get; set; }
    }
}