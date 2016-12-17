using System.Linq;
using MaterialCMS.Models;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class ACLUpdateModelBinder : MaterialCMSDefaultModelBinder
    {
        public ACLUpdateModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var nameValueCollection = controllerContext.HttpContext.Request.Form;

            var keys = nameValueCollection.AllKeys.Where(s => s.StartsWith("acl-"));

            return keys.Select(s =>
                                   {
                                       var substring = s.Substring(4).Split('-');
                                       return new ACLUpdateRecord
                                                  {
                                                      Role = substring[0],
                                                      Key = substring[1],
                                                      Allowed = nameValueCollection[s].Contains("true")
                                                  };
                                   }).ToList();
        }
    }
}