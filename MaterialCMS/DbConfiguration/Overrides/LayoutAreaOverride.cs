using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Layout;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class LayoutAreaOverride : IAutoMappingOverride<LayoutArea>
    {
        public void Override(AutoMapping<LayoutArea> mapping)
        {
            mapping.HasMany(area => area.Widgets).OrderBy("DisplayOrder").Cascade.All().Cache.ReadWrite();
        }
    }
}