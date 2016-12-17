using System.Collections.Generic;
using MaterialCMS.Entities;
using MaterialCMS.Entities.People;
using MaterialCMS.Paging;
using NHibernate.Criterion;

namespace MaterialCMS.Services
{
    public interface IBelongToUserLookupService
    {
        T Get<T>(User user) where T : SystemEntity, IBelongToUser;
        IList<T> GetAll<T>(User user) where T : SystemEntity, IBelongToUser;
        IPagedList<T> GetPaged<T>(User user, QueryOver<T> query = null, int page = 1) where T : SystemEntity, IBelongToUser;
    }
}