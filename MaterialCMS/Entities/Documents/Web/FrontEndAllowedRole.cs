using MaterialCMS.Entities.People;

namespace MaterialCMS.Entities.Documents.Web
{
    public class FrontEndAllowedRole : SiteEntity, IRole
    {
        public virtual Webpage Webpage { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual bool? IsRecursive { get; set; }
    }
}