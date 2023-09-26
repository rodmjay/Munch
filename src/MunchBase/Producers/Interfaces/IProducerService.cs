using System.Collections.Generic;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Interfaces;

public interface IProducerService
{
    Task<T> GetProducer<T>(IProducer producer) where T : ProducerDto;
    Task<List<T>> GetProducer<T>(int producerId) where T : ProducerDto;
    Task<PagedList<T>> GetProducers<T>(IAdmin admin, ProducerQuery query, PagingQuery paging);
    Task<T> GetProducer<T>(IAdmin admin, int producerId) where T: ProducerDto;
    Task<Result> DeleteProducer(IAdmin admin, int producerId);
}