using System;
using System.Collections.Generic;
using MaterialCMS.Helpers;

namespace MaterialCMS.Entities.People
{
    public abstract class UserProfileData : SystemEntity
    {
        public virtual User User { get; set; }

        public static IEnumerable<Type> Types
        {
            get { return TypeHelper.GetAllConcreteMappedClassesAssignableFrom<UserProfileData>(); }
        }
    }
}