namespace MaterialCMS.Installation
{
    public interface IFileSystemAccessService
    {
        InstallationResult EnsureAccessToFileSystem();
        void EmptyAppData();
    }
}