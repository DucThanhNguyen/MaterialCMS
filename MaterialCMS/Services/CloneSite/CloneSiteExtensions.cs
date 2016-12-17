using System;
using System.Reflection;
using MaterialCMS.Entities;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;

namespace MaterialCMS.Services.CloneSite
{
    public static class CloneSiteExtensions
    {
        public static T GetCopyForSite<T>(this T entity, Site site) where T : SiteEntity
        {
            var shallowCopy = entity.ShallowCopy();
            shallowCopy.Site = site;
            return shallowCopy;
        }

        public static int GetCloneSitePartOrder(Type type)
        {
            if (type == null)
                return int.MaxValue;
            var cloneSitePartOrderAttribute = type.GetCustomAttribute<CloneSitePartAttribute>();
            return cloneSitePartOrderAttribute != null ? cloneSitePartOrderAttribute.Order : int.MaxValue;
        }
        public static string GetCloneSitePartDisplayName(Type type)
        {
            if (type == null)
                return string.Empty;
            var cloneSitePartOrderAttribute = type.GetCustomAttribute<CloneSitePartAttribute>();
            return cloneSitePartOrderAttribute != null && !string.IsNullOrWhiteSpace(cloneSitePartOrderAttribute.Name)
                ? cloneSitePartOrderAttribute.Name
                : type.Name.BreakUpString();
        }
    }
}