using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Routing
{
    public class MaterialCMSStandardRouteHandler : IMaterialCMSRouteHandler
    {
        private readonly IGetWebpageForRequest _getWebpageForRequest;
        private readonly IHandleStandardMaterialCMSPageExecution _standardMaterialCMSPageExecution;

        public MaterialCMSStandardRouteHandler(IGetWebpageForRequest getWebpageForRequest,
            IHandleStandardMaterialCMSPageExecution standardMaterialCMSPageExecution)
        {
            _getWebpageForRequest = getWebpageForRequest;
            _standardMaterialCMSPageExecution = standardMaterialCMSPageExecution;
        }

        public int Priority
        {
            get { return 1000; }
        }

        public bool Handle(RequestContext context)
        {
            Webpage webpage = _getWebpageForRequest.Get(context);
            if (webpage == null)
            {
                return false;
            }
            context.RouteData.MarkAsStandardExecution();
            _standardMaterialCMSPageExecution.Handle(context, webpage);
            return true;
        }
    }
}