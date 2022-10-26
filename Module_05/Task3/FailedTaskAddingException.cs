using System;

namespace Task3
{
    public class FailedTaskAddingException : Exception
    {
        public FailedTaskAddingException() { }
        public FailedTaskAddingException(string message) : base(message) { }
        public FailedTaskAddingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
