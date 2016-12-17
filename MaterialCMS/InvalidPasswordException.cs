using System;

namespace MaterialCMS
{
    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message)
            : base(message)
        {

        }
    }
}