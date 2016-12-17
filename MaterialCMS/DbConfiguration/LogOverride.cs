using Elmah;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Logging;

namespace MaterialCMS.DbConfiguration
{
    public class LogOverride : IAutoMappingOverride<Log>
    {
        public void Override(AutoMapping<Log> mapping)
        {
            mapping.Map(entry => entry.Error).CustomType<BinaryData<Error>>().Length(9999);
            mapping.Map(entry => entry.Message).MakeVarCharMax();
            mapping.Map(entry => entry.Detail).MakeVarCharMax();
        }
    }
}