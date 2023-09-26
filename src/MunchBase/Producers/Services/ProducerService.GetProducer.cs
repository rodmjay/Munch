using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Producers.Services;

public partial class ProducerService
{
    public Task<T> GetProducer<T>(IProducer producer) where T : ProducerDto
    {
        throw new NotImplementedException();
    }

    public Task<T> GetProducer<T>(IAdmin admin, int producerId) where T : ProducerDto
    {
        return Repository.Queryable().Where(x => x.Id == producerId).ProjectTo<T>(ProjectionMapping).FirstAsync();
    }

    public Task<List<T>> GetProducer<T>(int producerId) where T : ProducerDto
    {
        throw new NotImplementedException();
    }
}