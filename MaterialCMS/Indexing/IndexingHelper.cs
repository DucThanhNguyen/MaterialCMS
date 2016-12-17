using System;
using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Helpers;
using MaterialCMS.Indexing.Management;
using MaterialCMS.Tasks;
using MaterialCMS.Website;

namespace MaterialCMS.Indexing
{
    public static class IndexingHelper
    {
        public static bool AnyIndexes(object obj, LuceneOperation operation)
        {
            if (obj == null)
                return false;
            return
                IndexDefinitionTypes.Any(
                    definition => definition.GetUpdateTypes(operation).Any(type => type.IsAssignableFrom(obj.GetType())));
        }

        public static List<IndexDefinition> IndexDefinitionTypes
        {
            get
            {
                return
                    TypeHelper.GetAllConcreteTypesAssignableFrom(typeof(IndexDefinition<>))
                        .Select(type => MaterialCMSApplication.Get(type) as IndexDefinition)
                        .ToList();
            }
        }

        public static IndexDefinition Get<T>() where T :IndexDefinition
        {
            return IndexDefinitionTypes.OfType<T>().FirstOrDefault();
        }
    }
}