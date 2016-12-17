using MaterialCMS.Settings;

namespace MaterialCMS.DbConfiguration
{
    public class CreateSqlServerAzureDatabase :CreateSqlServerDatabase, ICreateDatabase<SqlServerAzureProvider>
    {
        protected override IDatabaseProvider GetProvider(string connectionString)
        {
            return new SqlServerAzureProvider(new DatabaseSettings
            {
                ConnectionString = connectionString
            });
        }
    }
}