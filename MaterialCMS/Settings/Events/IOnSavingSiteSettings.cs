using MaterialCMS.Events;

namespace MaterialCMS.Settings.Events
{
    public interface IOnSavingSiteSettings<T> : IEvent<OnSavingSiteSettingsArgs<T>> where T : SiteSettingsBase
    {

    }
}