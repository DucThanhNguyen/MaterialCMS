using MaterialCMS.Events;
using MaterialCMS.Services.Events.Args;

namespace MaterialCMS.Services.Events
{
    public interface IOnUserAdded : IEvent<OnUserAddedEventArgs>
    {
    }
}