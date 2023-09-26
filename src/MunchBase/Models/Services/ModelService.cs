using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Consumers.Interfaces;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Models.Services;

public partial class ModelService : BaseService<Model>, IModelService
{
    public ModelService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public IQueryable<Model> Models => Repository.Queryable();

    public Task<T> GetModel<T>(IConsumer consumer, int modelId) where T : ModelDto
    {
        return Models.Where(x => x.Id == modelId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<T> GetModel<T>(IAdmin admin, int modelId) where T : ModelDto
    {
        return Models.Where(x => x.Id == modelId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<T> GetModel<T>(IModel model, int modelId) where T : ModelDto
    {
        return Models.Where(x => x.Id == modelId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<T> GetModel<T>(IEditor editor, int modelId) where T : ModelDto
    {
        return Models.Where(x => x.Id == modelId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<T> GetModel<T>(IProducer producer, int modelId) where T : ModelDto
    {
        return Models.Where(x => x.Id == modelId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<Result> Subscribe(IConsumer consumer, int modelId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Unsubscribe(IConsumer consumer, int modelId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> CreateModelAccount(int userId, ModelInput input)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetProfile<T>(IModel model) where T : ModelDto
    {
        return Models.Where(x => x.Id == model.Id).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<Result> UpdateProfile(IModel model, ModelInput input)
    {
        throw new NotImplementedException();
    }
}