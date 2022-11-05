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
            string message = null;
            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }

            if (message != null)
            {
                model.AddAttribute(ActionAttribute, message);
                return false;
            }

            return true;
        }
    }
}