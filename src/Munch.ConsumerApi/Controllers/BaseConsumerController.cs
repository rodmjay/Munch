using MunchBase.Common.Middleware.Bases;
using MunchBase.Consumers.Interfaces;

namespace Munch.ConsumerApi.Controllers
{
    public abstract class BaseConsumerController : BaseController
    {
        private readonly IConsumerAccessor _accessor;
        protected IConsumer Consumer => _accessor.GetConsumer(User);

        protected BaseConsumerController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _accessor = serviceProvider.GetRequiredService<IConsumerAccessor>();
        }
    }
}
