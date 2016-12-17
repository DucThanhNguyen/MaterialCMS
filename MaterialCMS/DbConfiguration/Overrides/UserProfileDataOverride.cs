using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.People;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class UserProfileDataOverride : IAutoMappingOverride<UserProfileData>
    {
        public void Override(AutoMapping<UserProfileData> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("ProfileInfoType");
        }
    }
}