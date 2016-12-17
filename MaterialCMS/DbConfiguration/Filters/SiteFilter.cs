using FluentNHibernate.Mapping;
using NHibernate;

namespace MaterialCMS.DbConfiguration.Filters
{
    public class SiteFilter : FilterDefinition
    {
        public SiteFilter()
        {
            WithName("SiteFilter").WithCondition("(SiteId = :site or SiteId is null)").AddParameter("site", NHibernateUtil.Int32);
        }
    }
}