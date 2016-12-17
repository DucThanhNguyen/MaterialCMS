using System;
using Lucene.Net.Index;
using Lucene.Net.Search;
using MaterialCMS.Entities;
using MaterialCMS.Models;

namespace MaterialCMS.Search
{
    public interface IUniversalSearchIndexManager
    {
        void Insert(SystemEntity entity);
        void Update(SystemEntity entity);
        void Delete(SystemEntity entity);
        void ReindexAll();
        void Optimise();
        IndexSearcher GetSearcher();
        void Write(Action<IndexWriter> writeFunc, bool recreateIndex = false);
        
        void EnsureIndexExists();
        MaterialCMSIndex GetUniversalIndexInfo();
    }
}