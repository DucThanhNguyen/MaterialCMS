using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MaterialCMS.Services
{
    public interface IAzureFileSystem
    {
        CloudBlobContainer Container { get; }
        CloudStorageAccount StorageAccount { get; }
    }
}