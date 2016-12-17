using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.People;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class UserRoleOverride : IAutoMappingOverride<UserRole>
    {
        public void Override(AutoMapping<UserRole> mapping)
        {
            mapping.HasManyToMany(role => role.FrontEndWebpages).Inverse().Table("FrontEndWebpageRoles").Cache.ReadWrite();
            mapping.HasManyToMany(role => role.Users).Inverse().Cascade.SaveUpdate().Cache.ReadWrite();
        }
    }
}