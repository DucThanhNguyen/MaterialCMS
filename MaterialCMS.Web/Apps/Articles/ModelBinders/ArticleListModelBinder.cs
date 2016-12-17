using System;
using System.Web.Mvc;
using MaterialCMS.Web.Apps.Articles.Models;
using MaterialCMS.Website.Binders;
using NHibernate;
using Ninject;

namespace MaterialCMS.Web.Apps.Articles.ModelBinders
{
    public class ArticleListModelBinder : MaterialCMSDefaultModelBinder
    {
        public ArticleListModelBinder(IKernel kernel) : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int page;
            int.TryParse(GetValueFromContext(controllerContext, "page"), out page);
            int monthVal;
            int? month = int.TryParse(Convert.ToString(GetValueFromContext(controllerContext, "month")), out monthVal)
                ? monthVal
                : (int?) null;
            int yearVal;
            int? year = int.TryParse(Convert.ToString(GetValueFromContext(controllerContext, "year")), out yearVal)
                ? yearVal
                : (int?) null;
            return new ArticleSearchModel
                       {
                           Page = page,
                           Category = GetValueFromContext(controllerContext, "category"),
                           Month = month,
                           Year = year
                       };
        }
    }
}