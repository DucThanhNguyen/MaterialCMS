using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Helpers;
using MaterialCMS.Search.Models;

namespace MaterialCMS.Search.ItemCreation
{
    public class GetMediaFileSearchItem : GetUniversalSearchItemBase<MediaFile>
    {
        public override UniversalSearchItem GetSearchItem(MediaFile entity)
        {
            return new UniversalSearchItem
            {
                DisplayName = entity.FileName,
                Id = entity.Id,
                PrimarySearchTerms = new[] {entity.FileName, entity.Title, entity.Description},
                SecondarySearchTerms = new[] {entity.FileExtension, entity.FileUrl},
                SystemType = typeof (MediaFile).FullName,
                ActionUrl = "/admin/file/edit/" + entity.Id,
                CreatedOn = entity.CreatedOn,
                SearchGuid = entity.Guid
            };
        }

        public override HashSet<UniversalSearchItem> GetSearchItems(HashSet<MediaFile> entities)
        {
            return entities.Select(GetSearchItem).ToHashSet();
        }
    }
}