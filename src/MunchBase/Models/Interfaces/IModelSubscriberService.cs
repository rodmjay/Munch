using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Common.Models;
using MunchBase.Models.ViewModels;

namespace MunchBase.Models.Interfaces;

public interface IModelSubscriberService
{
    Task<List<T>> GetSubscribersForModel<T>(int modelId, PagingQuery paging) where T: SubscriberDto;
}