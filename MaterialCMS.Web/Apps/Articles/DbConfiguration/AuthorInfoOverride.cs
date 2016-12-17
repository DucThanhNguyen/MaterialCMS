using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Web.Apps.Articles.Entities;

namespace MaterialCMS.Web.Apps.Articles.DbConfiguration
{
    public class AuthorInfoOverride : IAutoMappingOverride<AuthorInfo>
    {
        public void Override(AutoMapping<AuthorInfo> mapping)
        {
            mapping.Map(info => info.Bio).CustomType<VarcharMax>().Length(4001);
        }
    }
}