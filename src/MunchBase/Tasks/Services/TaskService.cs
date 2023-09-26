using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Interfaces;
using MunchBase.Tasks.Interfaces;
using MunchBase.Tasks.ViewModels;

namespace MunchBase.Tasks.Services
{
    public class TaskService : BaseService<Entities.Task>, ITaskService
    {
        public TaskService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IQueryable<Entities.Task> Tasks => Repository.Queryable();

        public Task<List<T>> GetTasks<T>(IModel model) where T : TaskDto
        {
            return Tasks.Where(x => x.ModelId == model.Id).ProjectTo<T>(ProjectionMapping)
                .ToListAsync();
        }

        public async Task<Result> CompleteTask(IModel model, int taskId)
        {
            var task = await Tasks.Where(x => x.Id == taskId && x.ModelId == model.Id)
                .FirstOrDefaultAsync();

            return Result.Success(task.Id);
        }
    }
}
