using System;
using MaterialCMS.Website;

namespace MaterialCMS.DbConfiguration.Types
{
    [Serializable]
    public class NullableDateTimeData : NullableDateTimeDataBase
    {
        protected override TimeZoneInfo TimeZone
        {
            get { return CurrentRequestData.TimeZoneInfo; }
        }
    }
}