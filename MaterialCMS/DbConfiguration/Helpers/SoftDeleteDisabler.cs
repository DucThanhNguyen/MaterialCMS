using System;
using MaterialCMS.Website;

namespace MaterialCMS.DbConfiguration.Helpers
{
    public class SoftDeleteDisabler : IDisposable
    {
        private readonly bool _enableOnDispose;

        public SoftDeleteDisabler()
        {
            if (!CurrentRequestData.CurrentContext.IsSoftDeleteDisabled())
            {
                _enableOnDispose = true;
                CurrentRequestData.CurrentContext.DisableSoftDelete();
            }
        }
        public void Dispose()
        {
            if (_enableOnDispose)
                CurrentRequestData.CurrentContext.EnableSoftDelete();
        }
    }
}