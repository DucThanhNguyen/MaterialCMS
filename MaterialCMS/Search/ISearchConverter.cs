using Lucene.Net.Documents;
using MaterialCMS.Search.Models;

namespace MaterialCMS.Search
{
    public interface ISearchConverter
    {
        Document Convert(UniversalSearchItem item);
        UniversalSearchItem Convert(Document document);
    }
}