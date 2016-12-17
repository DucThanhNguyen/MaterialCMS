using System;
using MaterialCMS.Helpers;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class TaskUpdateData
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        public Type Type
        {
            get { return TypeHelper.GetTypeByName(TypeName); }
        }

        public bool Enabled { get; set; }
        public int FrequencyInSeconds { get; set; }
    }
}