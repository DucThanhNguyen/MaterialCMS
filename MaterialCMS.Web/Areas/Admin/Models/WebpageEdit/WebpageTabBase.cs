using System;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Models.WebpageEdit
{
    public abstract class WebpageTabBase
    {
        public abstract int Order { get; }
        public abstract string Name(Webpage webpage);

        public abstract bool ShouldShow(Webpage webpage);

        public abstract Type ParentType { get; }
    }
}