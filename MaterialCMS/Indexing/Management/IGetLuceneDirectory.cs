using Lucene.Net.Store;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Indexing.Management
{
    public interface IGetLuceneDirectory : IClearCache
    {
        Directory Get(Site site, string folderName, bool useRAMCache = false);
    }
}