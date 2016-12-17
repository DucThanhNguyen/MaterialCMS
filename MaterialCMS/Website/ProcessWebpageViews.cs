using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Layout;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Services;

namespace MaterialCMS.Website
{
    public class ProcessWebpageViews : IProcessWebpageViews
    {
        private readonly IGetCurrentLayout _getCurrentLayout;

        public ProcessWebpageViews(IGetCurrentLayout getCurrentLayout)
        {
            _getCurrentLayout = getCurrentLayout;
        }

        public void Process(ViewResult result, Webpage webpage)
        {
            if (string.IsNullOrWhiteSpace(result.ViewName))
            {
                if (webpage.PageTemplate != null && !string.IsNullOrWhiteSpace(webpage.PageTemplate.PageTemplateName))
                {
                    result.ViewName = webpage.PageTemplate.PageTemplateName;
                }
                else
                {
                    result.ViewName = webpage.GetType().Name;
                }
            }

            if (string.IsNullOrWhiteSpace(result.MasterName))
            {
                Layout layout = _getCurrentLayout.Get(webpage);
                if (layout != null)
                {
                    result.MasterName = layout.GetLayoutName();
                }
            }
        }
    }
}