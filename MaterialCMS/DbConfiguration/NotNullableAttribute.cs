using System;

namespace MaterialCMS.DbConfiguration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullableAttribute : Attribute
    {
    }
}