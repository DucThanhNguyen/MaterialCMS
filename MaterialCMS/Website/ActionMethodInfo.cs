using System.Web.Mvc;

namespace MaterialCMS.Website
{
    public class ActionMethodInfo<T>
    {
        public ActionDescriptor Descriptor { get; set; }
        public T Attribute { get; set; }
    }
}