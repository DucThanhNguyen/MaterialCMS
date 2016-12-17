using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Services.FileMigration
{
    public interface IFileMigrationService
    {
        FileMigrationResult MigrateFiles();
    }
}