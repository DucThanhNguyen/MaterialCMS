using MaterialCMS.Installation;

namespace MaterialCMS.DbConfiguration
{
    public interface ICreateDatabase
    {
        void CreateDatabase(InstallModel model);
        string GetConnectionString(InstallModel model);
    }

    public interface ICreateDatabase<T> : ICreateDatabase
    {
    }
}