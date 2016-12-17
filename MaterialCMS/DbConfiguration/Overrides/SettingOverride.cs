using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities.Settings;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class SettingOverride : IAutoMappingOverride<Setting>
    {
        public void Override(AutoMapping<Setting> mapping)
        {
            mapping.Map(setting => setting.Value).CustomType<VarcharMax>().Length(4001);

            mapping.Map(setting => setting.SettingType).Length(120);
            mapping.Map(setting => setting.PropertyName).Length(50);
        }
    }
}