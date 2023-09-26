using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Models.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Models.ViewModels;

namespace MunchBase.Models.Services;

public class ModelSubscriberService : BaseService<ModelSubscription>, IModelSubscriberService
{
    public ModelSubscriberService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<List<T>> GetSubscribersForModel<T>(int modelId, PagingQuery paging) where T : SubscriberDto
    {
        throw new NotImplementedException();
    }
}