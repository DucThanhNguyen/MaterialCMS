using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Apps.Galleries.Pages;
using MaterialCMS.Web.Areas.Admin.Services;
using NHibernate;

namespace MaterialCMS.Web.Apps.Galleries.Areas.Admin.Services
{
    public class GetGalleryAdminViewData : BaseAssignWebpageAdminViewData<Gallery>
    {
        private readonly ISession _session;

        public GetGalleryAdminViewData(ISession session)
        {
            _session = session;
        }

        public override void AssignViewData(Gallery webpage, ViewDataDictionary viewData)
        {
            viewData["galleries"] = _session.QueryOver<MediaCategory>()
                .OrderBy(category => category.Name)
                .Desc.Cacheable()
                .List()
                .BuildSelectItemList(category => category.Name,
                    category => category.Id.ToString(),
                    emptyItemText: "Select a gallery...");
        }
    }
}