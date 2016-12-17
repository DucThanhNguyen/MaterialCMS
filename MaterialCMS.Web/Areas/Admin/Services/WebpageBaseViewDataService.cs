using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.ACL;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class WebpageBaseViewDataService : IWebpageBaseViewDataService
    {
        private readonly IGetValidPageTemplatesToAdd _getValidPageTemplatesToAdd;
        private readonly IGetWebpageEditTabsService _getWebpageEditTabsService;
        private readonly IValidWebpageChildrenService _validWebpageChildrenService;

        public WebpageBaseViewDataService(IValidWebpageChildrenService validWebpageChildrenService, IGetValidPageTemplatesToAdd getValidPageTemplatesToAdd,
            IGetWebpageEditTabsService getWebpageEditTabsService)
        {
            _validWebpageChildrenService = validWebpageChildrenService;
            _getValidPageTemplatesToAdd = getValidPageTemplatesToAdd;
            _getWebpageEditTabsService = getWebpageEditTabsService;
        }

        public void SetAddPageViewData(ViewDataDictionary viewData, Webpage parent)
        {
            IOrderedEnumerable<DocumentMetadata> validWebpageDocumentTypes = _validWebpageChildrenService
                .GetValidWebpageDocumentTypes(parent,
                    metadata =>
                        CurrentRequestData.CurrentUser.CanAccess<TypeACLRule>(TypeACLRule.Add, metadata.Type.FullName))
                .OrderBy(metadata => metadata.DisplayOrder);

            var templates = _getValidPageTemplatesToAdd.Get(validWebpageDocumentTypes);

            var documentTypeToAdds = new List<DocumentTypeToAdd>();

            foreach (DocumentMetadata type in validWebpageDocumentTypes)
            {
                if (templates.Any(template => template.PageType == type.Type.FullName))
                {
                    documentTypeToAdds.Add(new DocumentTypeToAdd
                    {
                        Type = type,
                        DisplayName = string.Format("Default {0}", type.Name)
                    });
                    DocumentMetadata typeCopy = type;
                    documentTypeToAdds.AddRange(
                        templates.Where(template => template.PageType == typeCopy.Type.FullName)
                            .Select(pageTemplate => new DocumentTypeToAdd
                            {
                                Type = type,
                                DisplayName = pageTemplate.Name,
                                TemplateId = pageTemplate.Id
                            }));
                }
                else
                {
                    documentTypeToAdds.Add(new DocumentTypeToAdd { Type = type, DisplayName = type.Name });
                }
            }

            viewData["DocumentTypes"] = documentTypeToAdds;
        }

        public void SetEditPageViewData(ViewDataDictionary viewData, Webpage page)
        {
            DocumentMetadata documentMetadata = page.GetMetadata();
            if (documentMetadata != null)
            {
                viewData["EditView"] = documentMetadata.EditPartialView;
            }

            viewData["edit-tabs"] = _getWebpageEditTabsService.GetEditTabs(page);
        }
    }
}