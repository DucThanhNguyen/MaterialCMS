using System;
using System.Collections.Generic;
using MaterialCMS.Indexing.Management;
using MaterialCMS.Models;

namespace MaterialCMS.Services
{
    public interface IIndexService
    {
        void InitializeAllIndices();
        List<MaterialCMSIndex> GetIndexes();
        void Reindex(string typeName);
        void Optimise(string typeName);
        IIndexManagerBase GetIndexManagerBase(Type indexType);
        IEnumerable<IIndexManagerBase> GetAllIndexManagers();
    }
}