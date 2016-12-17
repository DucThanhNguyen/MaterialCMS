using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities;
using MaterialCMS.Search.Models;

namespace MaterialCMS.Search
{
    public interface IUniversalSearchItemGenerator
    {
        bool CanGenerate(SystemEntity entity);
        UniversalSearchItem GenerateItem(SystemEntity entity);
        Document GenerateDocument(SystemEntity entity);
        Dictionary<SystemEntity, Document> GenerateDocuments(IEnumerable<SystemEntity> entities);
        IEnumerable<Document> GetAllItems();
    }
}