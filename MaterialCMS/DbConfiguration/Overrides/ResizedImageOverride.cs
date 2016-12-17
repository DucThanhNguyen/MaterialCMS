using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class ResizedImageOverride : IAutoMappingOverride<ResizedImage>
    {
        public void Override(AutoMapping<ResizedImage> mapping)
        {
            mapping.Map(file => file.Url).Length(1000);
        }
    }
}