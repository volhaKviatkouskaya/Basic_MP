using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class UserTaskServiceException : Exception
    {
        public UserTaskServiceException() { }
        public UserTaskServiceException(string message) : base(message) { }
        public UserTaskServiceException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidUserIdException : UserTaskServiceException
    {
        private const string DefaultMessage = "Invalid userId";
        public InvalidUserIdException() : base(DefaultMessage) { }
        public InvalidUserIdException(string message) : base(message) { }
        public InvalidUserIdException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class UserNotFoundException : UserTaskServiceException
    {
        private const string DefaultMessage = "User not found";
        public UserNotFoundException() : base(DefaultMessage) { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class FailedTaskAddingException : UserTaskServiceException
    {
        private const string DefaultMessage = "The task already exists";
        public FailedTaskAddingException() : base(DefaultMessage) { }
        public FailedTaskAddingException(string message) : base(message) { }
        public FailedTaskAddingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
