using System;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Common.Services.Bases;
using MunchBase.Producers.Entities;
using MunchBase.Producers.Interfaces;

namespace MunchBase.Producers.Services
{
    public partial class ProducerService : BaseService<Producer>, IProducerService
    {
        public ProducerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<Result> DeleteProducer(IAdmin admin, int producerId)
        {
            throw new NotImplementedException();
        }
    }
}
