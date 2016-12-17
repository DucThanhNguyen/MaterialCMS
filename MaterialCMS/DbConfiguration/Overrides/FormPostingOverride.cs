using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class FormPostingOverride : IAutoMappingOverride<FormPosting>
    {
        public void Override(AutoMapping<FormPosting> mapping)
        {
            mapping.HasMany(posting => posting.FormValues).Cascade.All();
        }
    }
}