using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Models;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IFormAdminService
    {
        PostingsModel GetFormPostings(Webpage webpage, int page, string search);
        void AddFormProperty(FormProperty formProperty);
        void SaveFormProperty(FormProperty property);
        void DeleteFormProperty(FormProperty property);
        void SaveFormListOption(FormListOption formListOption);
        void UpdateFormListOption(FormListOption formListOption);
        void DeleteFormListOption(FormListOption formListOption);
        void SetOrders(List<SortItem> items);
        void ClearFormData(Webpage webpage);
        byte[] ExportFormData(Webpage webpage);
        void DeletePosting(FormPosting posting);
    }
}