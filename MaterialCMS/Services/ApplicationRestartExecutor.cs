using System.Collections.Generic;
using MaterialCMS.Installation;
using MaterialCMS.Website;

namespace MaterialCMS.Services
{
    public class ApplicationRestartExecutor : ExecuteEndRequestBase<ApplicationRestart, int>
    {
        private readonly IRestartApplication _restartApplication;

        public ApplicationRestartExecutor(IRestartApplication restartApplication)
        {
            _restartApplication = restartApplication;
        }

        public override void Execute(IEnumerable<int> data)
        {
            _restartApplication.Restart();
        }
    }
}