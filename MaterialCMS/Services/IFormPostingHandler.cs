using System.Collections.Generic;
using System.Web;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public interface IFormPostingHandler
    {
        List<string> SaveFormData(Webpage webpage, HttpRequestBase request);
    }
}