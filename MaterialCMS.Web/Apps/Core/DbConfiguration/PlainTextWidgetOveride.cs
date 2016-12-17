using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Web.Apps.Core.Widgets;

namespace MaterialCMS.Web.Apps.Core.DbConfiguration
{
    public class PlainTextWidgetOveride : IAutoMappingOverride<PlainTextWidget>
    {
        public void Override(AutoMapping<PlainTextWidget> mapping)
        {
            mapping.Map(x => x.Text).CustomType<VarcharMax>().Length(4001);
        }
    }
}