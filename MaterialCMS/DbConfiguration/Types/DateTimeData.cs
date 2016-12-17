using System;
using MaterialCMS.Website;

namespace MaterialCMS.DbConfiguration.Types
{
    [Serializable]
    public class DateTimeData : DateTimeDataBase
    {
        protected override TimeZoneInfo TimeZone
        {
            get { return CurrentRequestData.TimeZoneInfo; }
        }
    }
}