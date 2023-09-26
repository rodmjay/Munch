using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Consumers.ViewModels;
using MunchBase.Models.Interfaces;

namespace MunchBase.Consumers.Interfaces;

public interface IConsumerService
{
    Task<PagedList<T>> GetConsumers<T>(IModel model, ConsumerQuery query, PagingQuery paging) where T: ConsumerDto;
    Task<PagedList<T>> GetConsumers<T>(IAdmin admin, ConsumerQuery query, PagingQuery paging) where T: ConsumerDto;

    Task<T> GetConsumer<T>(IModel model, int consumerId) where T : ConsumerDto;
    Task<T> GetConsumer<T>(IAdmin admin, int consumerId) where T : ConsumerDto;
    Task<T> GetConsumer<T>(IConsumer consumer) where T : ConsumerDto;
}