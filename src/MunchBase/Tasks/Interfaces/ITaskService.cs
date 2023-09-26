using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Models.Interfaces;
using MunchBase.Tasks.ViewModels;

namespace MunchBase.Tasks.Interfaces
{
    public interface ITaskService
    {
        Task<List<T>> GetTasks<T>(IModel model) where T : TaskDto;
        Task<Result> CompleteTask(IModel model, int taskId);
    }
}
