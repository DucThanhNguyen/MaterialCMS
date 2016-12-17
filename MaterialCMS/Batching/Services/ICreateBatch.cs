using System.Collections.Generic;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Services.FileMigration;
using Newtonsoft.Json;

namespace MaterialCMS.Batching.Services
{
    public interface ICreateBatch
    {
        BatchCreationResult Create(IEnumerable<BatchJob> jobs);
    }
}