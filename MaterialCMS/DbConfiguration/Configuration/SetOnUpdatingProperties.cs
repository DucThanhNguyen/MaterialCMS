using System;
using MaterialCMS.Entities;
using MaterialCMS.Events;
using MaterialCMS.Website;

namespace MaterialCMS.DbConfiguration.Configuration
{
    public class SetOnUpdatingProperties : IOnUpdating<SystemEntity>
    {
        public void Execute(OnUpdatingArgs<SystemEntity> args)
        {
            DateTime now = CurrentRequestData.Now;
            SystemEntity systemEntity = args.Item;
            systemEntity.UpdatedOn = now;
        }
    }
}