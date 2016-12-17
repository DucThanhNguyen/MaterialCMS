using System;
using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities;
using MaterialCMS.Tasks;

namespace MaterialCMS.Indexing.Management
{
    public interface IFieldDefinitionInfo
    {
        string Name { get; }
        string DisplayName { get; }
        string TypeName { get; }
        Field.Store Store { get; }
        Field.Index Index { get; }
        float Boost { get; }
        Dictionary<Type, Func<SystemEntity, IEnumerable<LuceneAction>>> GetRelatedEntities();
    }
}