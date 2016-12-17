using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class FormValueOverride : IAutoMappingOverride<FormValue>
    {
        public void Override(AutoMapping<FormValue> mapping)
        {
            mapping.Map(posting => posting.Value).MakeVarCharMax();
            mapping.Map(posting => posting.Key).MakeVarCharMax();
        }
    }
}