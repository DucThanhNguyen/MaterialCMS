using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace MaterialCMS.Web.Apps.Articles.DbConfiguration
{
    public class ArticleOverride : IAutoMappingOverride<Pages.Article>
    {
        public void Override(AutoMapping<Pages.Article> mapping)
        {
            mapping.Map(item => item.Abstract).Length(160);
        }
    }
}