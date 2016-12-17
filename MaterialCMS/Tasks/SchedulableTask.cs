using System;
using MaterialCMS.Website;

namespace MaterialCMS.Tasks
{
    public abstract class SchedulableTask 
    {
        public abstract int Priority { get; }

        public Exception Execute()
        {
            try
            {
                OnExecute();
                return null;
            }
            catch (Exception ex)
            {
                CurrentRequestData.ErrorSignal.Raise(ex);
                return ex;
            }
        }
        protected abstract void OnExecute();
    }
}