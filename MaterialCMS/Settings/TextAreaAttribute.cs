using System;

namespace MaterialCMS.Settings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextAreaAttribute : Attribute
    {
        public bool CKEnabled { get; set; }
    }
}