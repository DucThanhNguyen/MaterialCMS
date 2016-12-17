using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Widget;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class WidgetOverride : IAutoMappingOverride<Widget>
    {
        public void Override(AutoMapping<Widget> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("WidgetType");
            mapping.HasManyToMany(widget => widget.ShownOn).Inverse().Table("ShownWidgets");
            mapping.HasManyToMany(widget => widget.HiddenOn).Inverse().Table("HiddenWidgets");

            mapping.HasMany(x => x.PageWidgetSorts).KeyColumn("WidgetId").Cascade.Delete();
        }
    }
}