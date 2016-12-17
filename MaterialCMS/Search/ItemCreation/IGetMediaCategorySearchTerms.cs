using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.Search.ItemCreation
{
    public interface IGetMediaCategorySearchTerms
    {
        IEnumerable<string> GetPrimary(MediaCategory mediaCategory);
        Dictionary<MediaCategory, HashSet<string>> GetPrimary(HashSet<MediaCategory> mediaCategories);
        IEnumerable<string> GetSecondary(MediaCategory mediaCategory);
        Dictionary<MediaCategory, HashSet<string>> GetSecondary(HashSet<MediaCategory> mediaCategories);
    }
}