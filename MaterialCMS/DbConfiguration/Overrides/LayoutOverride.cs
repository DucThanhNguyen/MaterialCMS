using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Layout;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class LayoutOverride : IAutoMappingOverride<Layout>
    {
        public void Override(AutoMapping<Layout> mapping)
        {
            mapping.HasMany(x => x.LayoutAreas).KeyColumn("LayoutId").Cascade.All().Cache.ReadWrite();
            mapping.HasMany(layout => layout.PageTemplates).KeyColumn("LayoutId").Cascade.None();
        }
    }
}