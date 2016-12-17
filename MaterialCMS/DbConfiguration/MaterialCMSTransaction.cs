using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MaterialCMS.DbConfiguration.Helpers;
using MaterialCMS.Entities;
using MaterialCMS.Events;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using NHibernate;
using NHibernate.Transaction;

namespace MaterialCMS.DbConfiguration
{
    public class MaterialCMSTransaction : ITransaction
    {
        private readonly MaterialCMSSession _session;
        private readonly ITransaction _transaction;

        public MaterialCMSTransaction(ITransaction transaction, MaterialCMSSession session)
        {
            _transaction = transaction;
            _session = session;
        }

        public HttpContextBase HttpContext
        {
            get { return _session.HttpContext; }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Begin()
        {
            _transaction.Begin();
        }

        public void Begin(IsolationLevel isolationLevel)
        {
            _transaction.Begin(isolationLevel);
        }

        public void Commit()
        {
            HandlePreTransaction(_session);
            _transaction.Commit();
            if (!MaterialCMSTransactionWrapper.IsInPostTransaction(HttpContext))
            {
                using (new MaterialCMSTransactionWrapper(HttpContext))
                {
                    HandlePostTransaction(_session);
                }
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Enlist(IDbCommand command)
        {
            _transaction.Enlist(command);
        }

        public void RegisterSynchronization(ISynchronization synchronization)
        {
            _transaction.RegisterSynchronization(synchronization);
        }

        public bool IsActive
        {
            get { return _transaction.IsActive; }
        }

        public bool WasRolledBack
        {
            get { return _transaction.WasRolledBack; }
        }

        public bool WasCommitted
        {
            get { return _transaction.WasCommitted; }
        }

        private static void HandlePostTransaction(MaterialCMSSession session)
        {
            while (GetNextAddedEventInfoForPostTransaction(session) != null)
            {
                EventInfo obj = GetNextAddedEventInfoForPostTransaction(session);
                obj.PostTransactionHandled = true;
                Publish(obj, session, typeof (IOnAdded<>), (info, ses, t) => info.GetTypedInfo(t).ToAddedArgs(ses, t));
            }

            while (GetNextUpdatedEventInfoForPostTransaction(session) != null)
            {
                UpdatedEventInfo obj = GetNextUpdatedEventInfoForPostTransaction(session);
                obj.PostTransactionHandled = true;
                Publish(obj, session, typeof (IOnUpdated<>),
                    (info, ses, t) => info.GetTypedInfo(t).ToUpdatedArgs(ses, t));
            }

            while (GetNextDeletedEventInfoForPostTransaction(session) != null)
            {
                EventInfo obj = GetNextDeletedEventInfoForPostTransaction(session);
                obj.PostTransactionHandled = true;
                Publish(obj, session, typeof (IOnDeleted<>),
                    (info, ses, t) => info.GetTypedInfo(t).ToDeletedArgs(ses, t));
            }
        }

        private static EventInfo GetNextAddedEventInfoForPostTransaction(MaterialCMSSession session)
        {
            return session.Added.FirstOrDefault(x => !x.PostTransactionHandled);
        }

        private static UpdatedEventInfo GetNextUpdatedEventInfoForPostTransaction(MaterialCMSSession session)
        {
            return session.Updated.FirstOrDefault(x => !x.PostTransactionHandled);
        }

        private static EventInfo GetNextDeletedEventInfoForPostTransaction(MaterialCMSSession session)
        {
            return session.Deleted.FirstOrDefault(x => !x.PostTransactionHandled);
        }

        private static void Publish<T>(T onUpdatedArgs, ISession session, Type eventType,
            Func<T, ISession, Type, object> getArgs)
        {
            Type type = onUpdatedArgs.GetType().GenericTypeArguments[0];

            List<Type> types = GetEntityTypes(type).Reverse().ToList();

            types.ForEach(
                t => EventContext.Instance.Publish(eventType.MakeGenericType(t), getArgs(onUpdatedArgs, session, t)));
        }

        private static IEnumerable<Type> GetEntityTypes(Type type)
        {
            Type thisType = type;
            while (thisType != null && thisType != typeof (SystemEntity))
            {
                yield return thisType;
                thisType = thisType.BaseType;
            }
            yield return typeof (SystemEntity);
        }

        private static void HandlePreTransaction(MaterialCMSSession session)
        {
            HashSet<EventInfo> eventInfos = session.Added.ToHashSet();
            eventInfos.ForEach(obj =>
            {
                if (obj.PreTransactionHandled)
                    return;
                obj.PreTransactionHandled = true;
                Publish(obj, session, typeof (IOnAdding<>), (info, ses, t) => info.GetTypedInfo(t).ToAddingArgs(ses, t));
            });
            HashSet<UpdatedEventInfo> updatedEventInfos = session.Updated.ToHashSet();
            updatedEventInfos.ForEach(obj =>
            {
                if (obj.PreTransactionHandled)
                    return;
                obj.PreTransactionHandled = true;
                Publish(obj, session, typeof (IOnUpdating<>),
                    (info, ses, t) => info.GetTypedInfo(t).ToUpdatingArgs(ses, t));
            });
            HashSet<EventInfo> hashSet = session.Deleted.ToHashSet();
            hashSet.ForEach(obj =>
            {
                if (obj.PreTransactionHandled)
                    return;
                obj.PreTransactionHandled = true;
                Publish(obj, session, typeof (IOnDeleting<>),
                    (info, ses, t) => info.GetTypedInfo(t).ToDeletingArgs(ses, t));
            });
        }

        private class MaterialCMSTransactionWrapper : IDisposable
        {
            private const string InPostTransactionKey = "in-post-transaction";
            private readonly bool _completeOnDispose;
            private readonly HttpContextBase _httpContext;

            public MaterialCMSTransactionWrapper(HttpContextBase httpContext)
            {
                _httpContext = httpContext;
                if (!IsInPostTransaction(_httpContext))
                {
                    _completeOnDispose = true;
                    BeginPostTransaction(_httpContext);
                }
            }

            public void Dispose()
            {
                if (_completeOnDispose)
                    CompletedPostTransaction(_httpContext);
            }

            private static void BeginPostTransaction(HttpContextBase context)
            {
                if (context != null) context.Items[InPostTransactionKey] = true;
            }

            private static void CompletedPostTransaction(HttpContextBase context)
            {
                if (context != null) context.Items.Remove(InPostTransactionKey);
            }

            public static bool IsInPostTransaction(HttpContextBase context)
            {
                return context != null && context.Items.Contains(InPostTransactionKey);
            }
        }
    }
}