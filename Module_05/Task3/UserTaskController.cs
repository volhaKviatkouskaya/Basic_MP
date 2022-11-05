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
            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
            }
            catch (Exception exception)
            {
                model.AddAttribute(ActionAttribute, exception.Message);
                return false;
            }

            return true;
        }
    }
}