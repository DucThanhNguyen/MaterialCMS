using System;

namespace MaterialCMS.Models
{
    public class RequiredFieldException : Exception
    {
        public RequiredFieldException(string message)
            : base(message)
        {

        }
    }
}