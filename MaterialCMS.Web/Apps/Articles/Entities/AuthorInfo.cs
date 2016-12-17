using MaterialCMS.Entities.People;

namespace MaterialCMS.Web.Apps.Articles.Entities
{
    public class AuthorInfo : UserProfileData
    {
        public virtual string Bio { get; set; }
    }
}