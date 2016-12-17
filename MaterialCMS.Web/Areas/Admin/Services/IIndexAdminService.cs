using System.Collections.Generic;
using MaterialCMS.Indexing.Management;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IIndexAdminService
    {
        List<LuceneFieldBoost> GetBoosts(string type);
        void SaveBoosts(List<LuceneFieldBoost> boosts);

        List<MaterialCMSIndex> GetIndexes();
        void Reindex(string typeName);
        void Optimise(string typeName);

        MaterialCMSIndex GetUniversalSearchIndexInfo();
        void ReindexUniversalSearch();
        void OptimiseUniversalSearch();
    }
}