using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities.Documents;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class DocumentVersionOverride : IAutoMappingOverride<DocumentVersion>
    {
        public void Override(AutoMapping<DocumentVersion> mapping)
        {
            mapping.Map(version => version.Data).CustomType<VarcharMax>().Length(4001);
        }
    }
}