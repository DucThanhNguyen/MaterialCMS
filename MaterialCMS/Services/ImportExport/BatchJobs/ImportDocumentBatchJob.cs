using MaterialCMS.Batching.Entities;
using MaterialCMS.Services.ImportExport.DTOs;
using Newtonsoft.Json;

namespace MaterialCMS.Services.ImportExport.BatchJobs
{
    public class ImportDocumentBatchJob : BatchJob
    {
        public virtual string UrlSegment { get; set; }
        public virtual DocumentImportDTO DocumentImportDto
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<DocumentImportDTO>(Data);
                }
                catch
                {
                    return null;
                }
            }
        }

        public override string Name
        {
            get { return "Import Document - " + UrlSegment; }
        }
    }
}