using System;

namespace MaterialCMS.Website
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class MaterialCMSAssemblyAttribute : Attribute
    {
        public MaterialCMSAssemblyAttribute(string version)
        {
            Version = version;
        }

        public string Version { get; set; }
    }
}