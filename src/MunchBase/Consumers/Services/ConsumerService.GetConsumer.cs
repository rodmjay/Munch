using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Consumers.Interfaces;
using MunchBase.Consumers.ViewModels;
using MunchBase.Models.Interfaces;

namespace MunchBase.Consumers.Services;

public partial class ConsumerService
{
    public Task<T> GetConsumer<T>(IModel model, int consumerId) where T : ConsumerDto
    {
        return GetConsumer<T>(consumerId);
    }

    public Task<T> GetConsumer<T>(IAdmin admin, int consumerId) where T : ConsumerDto
    {
        return GetConsumer<T>(consumerId);
    }

    public Task<T> GetConsumer<T>(IConsumer consumer) where T : ConsumerDto
    {
        return GetConsumer<T>(consumer.Id);
    }

    private Task<T> GetConsumer<T>(int consumerId) where T : ConsumerDto
    {
        return Repository.Queryable().Where(x => x.Id == consumerId)
            .ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }
}