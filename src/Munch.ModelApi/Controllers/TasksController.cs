using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Tasks.Interfaces;
using MunchBase.Tasks.ViewModels;

namespace Munch.ModelApi.Controllers
{
    public class TasksController : BaseModelController
    {
        private readonly ITaskService _service;

        public TasksController(IServiceProvider serviceProvider, ITaskService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<List<TaskDto>> GetTasks()
        {
            return _service.GetTasks<TaskDto>(Model);
        }

        [HttpPatch("{taskId}")]
        public Task<Result> CompleteTask(int taskId)
        {
            return _service.CompleteTask(Model, taskId);
        }
     }
}
