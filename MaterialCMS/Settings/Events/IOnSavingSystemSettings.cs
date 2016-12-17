using System.Web.Optimization;
using MaterialCMS.Events;

namespace MaterialCMS.Settings.Events
{
    public interface IOnSavingSystemSettings<T> : IEvent<OnSavingSystemSettingsArgs<T>> where T : SystemSettingsBase
    {

    }

    public class SetEnableOptimisations : IOnSavingSystemSettings<BundlingSettings>
    {
        public void Execute(OnSavingSystemSettingsArgs<BundlingSettings> args)
        {
            BundleTable.EnableOptimizations = args.Settings.EnableOptimisations;
        }
    }
}