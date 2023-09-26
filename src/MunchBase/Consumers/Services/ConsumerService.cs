using System;
using MunchBase.Common.Services.Bases;
using MunchBase.Consumers.Entities;
using MunchBase.Consumers.Interfaces;

namespace MunchBase.Consumers.Services;

public partial class ConsumerService : BaseService<Consumer>, IConsumerService
{
    public ConsumerService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}