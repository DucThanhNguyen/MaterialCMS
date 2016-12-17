using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class MediaFileOverride : IAutoMappingOverride<MediaFile>
    {
        public void Override(AutoMapping<MediaFile> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("MediaFileType");
            mapping.Map(file => file.Description).CustomType<VarcharMax>().Length(4001);
            mapping.Map(file => file.Title).Length(4000);
            mapping.Map(file => file.FileUrl).Length(1000);
            mapping.Map(file => file.FileUrl).Index("IX_MediaFile_FileUrl");
        }
    }
}