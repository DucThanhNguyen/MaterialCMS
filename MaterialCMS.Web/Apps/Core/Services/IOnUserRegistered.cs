using MaterialCMS.Events;

namespace MaterialCMS.Web.Apps.Core.Services
{
    public interface IOnUserRegistered : IEvent<OnUserRegisteredEventArgs>
    {
    }
}