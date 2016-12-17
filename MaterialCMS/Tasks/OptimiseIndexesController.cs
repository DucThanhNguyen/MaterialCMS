using System.Web.Mvc;
using MaterialCMS.Services;
using MaterialCMS.Website.Controllers;
using MaterialCMS.Website.Filters;

namespace MaterialCMS.Tasks
{
    public class OptimiseIndexesController : MaterialCMSUIController
    {
        public const string OptimiseIndexUrl = "optimise-index";
        private readonly IIndexService _indexService;

        public OptimiseIndexesController(IIndexService indexService)
        {
            _indexService = indexService;
        }

        [TaskExecutionKeyPasswordAuth]
        public ContentResult Execute(string type)
        {
            _indexService.Optimise(type);
            return new ContentResult {Content = "Executed", ContentType = "text/plain"};
        }
    }
}