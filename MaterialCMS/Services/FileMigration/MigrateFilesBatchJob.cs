using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Services.FileMigration
{
    public class MigrateFilesBatchJob : BatchJob
    {
        public override string Name
        {
            get { return "Migrate Files"; }
        }
    }
}