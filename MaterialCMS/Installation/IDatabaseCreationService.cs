using System.Collections.Generic;
using MaterialCMS.DbConfiguration;

namespace MaterialCMS.Installation
{
    public interface IDatabaseCreationService
    {
        InstallationResult ValidateConnectionString(InstallModel model);
        IDatabaseProvider CreateDatabase(InstallModel model);
    }
}