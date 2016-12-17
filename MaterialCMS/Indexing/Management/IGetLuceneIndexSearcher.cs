using Lucene.Net.Search;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Indexing.Management
{
    public interface IGetLuceneIndexSearcher : IClearCache
    {
        IndexSearcher Get(IndexDefinition definition);
        IndexSearcher Get(string folderName);
        void Reset(IndexDefinition definition);
        void Reset(string folderName);
    }
}
