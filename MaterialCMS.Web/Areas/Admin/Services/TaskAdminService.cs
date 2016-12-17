using System.Collections.Generic;
using System.Linq;
using MaterialCMS.DbConfiguration;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;
using MaterialCMS.Paging;
using MaterialCMS.Settings;
using MaterialCMS.Tasks;
using MaterialCMS.Tasks.Entities;
using MaterialCMS.Web.Areas.Admin.Models;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class TaskAdminService : ITaskAdminService
    {
        private readonly ISession _session;
        private readonly ITaskSettingManager _taskSettingManager;

        public TaskAdminService(ISession session,ITaskSettingManager taskSettingManager)
        {
            _session = session;
            _taskSettingManager = taskSettingManager;
        }

        public List<TaskInfo> GetAllScheduledTasks()
        {
            return _taskSettingManager.GetInfo().OrderBy(x => x.Name).ToList();
        }

        public TaskUpdateData GetTaskUpdateData(string type)
        {
            var info = GetAllScheduledTasks().FirstOrDefault(x => x.TypeName == type);

            return info == null
                ? null
                : new TaskUpdateData
                {
                    Enabled = info.Enabled,
                    TypeName = info.TypeName,
                    FrequencyInSeconds = info.FrequencyInSeconds,
                    Name = info.Name
                };
        }

        public IPagedList<QueuedTask> GetQueuedTasks(QueuedTaskSearchQuery searchQuery)
        {
            using (new SiteFilterDisabler(_session))
            {
                return _session.QueryOver<QueuedTask>()
                    .OrderBy(task => task.CreatedOn).Desc
                    .Paged(searchQuery.Page);
            }
        }

        public void Update(TaskUpdateData info)
        {
            _taskSettingManager.Update(info.Type, info.Enabled, info.FrequencyInSeconds);
        }

        public void Reset(TaskUpdateData info)
        {
            _taskSettingManager.Reset(info.Type, true);
        }
    }
}