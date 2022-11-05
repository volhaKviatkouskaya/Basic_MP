using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;
        private const string ActionAttribute = "action_result";

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute(ActionAttribute, message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
            }
            catch (InvalidUserIdException exception)
            {
                return exception.Message;
            }
            catch (UserNotFoundException exception)
            {
                return exception.Message;
            }
            catch (FailedTaskAddingException exception)
            {
                return exception.Message;
            }

            return null;
        }
    }
}