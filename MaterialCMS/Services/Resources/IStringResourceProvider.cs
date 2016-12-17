using System.Collections.Generic;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Entities.Resources;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Services.Resources
{
    public interface IStringResourceProvider : IClearCache
    {
        IEnumerable<StringResource> AllResources { get; }
        string GetValue(string key, string defaultValue = null);
        IEnumerable<string> GetOverriddenLanguages();
        IEnumerable<string> GetOverriddenLanguages(string key, Site site);
        void Insert(StringResource resource);
        void AddOverride(StringResource resource);
        void Update(StringResource resource);
        void Delete(StringResource resource);
    }
}