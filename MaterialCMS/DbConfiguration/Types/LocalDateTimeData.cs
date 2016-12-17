using System;

namespace MaterialCMS.DbConfiguration.Types
{
    [Serializable]
    public class LocalDateTimeData : DateTimeDataBase
    {
        protected override TimeZoneInfo TimeZone
        {
            get { return TimeZoneInfo.Local; }
        }
    }
}