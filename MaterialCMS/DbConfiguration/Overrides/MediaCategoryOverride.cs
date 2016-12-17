using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class MediaCategoryOverride : IAutoMappingOverride<MediaCategory>
    {
        public void Override(AutoMapping<MediaCategory> mapping)
        {
            mapping.HasMany(x => x.Files).KeyColumn("MediaCategoryId").Cascade.Delete();
        }
    }
}