using MunchBase.Common.Middleware.Bases;
using MunchBase.Producers.Interfaces;
using MunchBase.Producers.ViewModels;

namespace Munch.ProducerApi.Controllers
{
    public abstract class BaseProducerController : BaseController
    {
        private readonly IProducerAccessor _accessor;
        protected IProducer Producer => _accessor.GetProducer(User);

        protected BaseProducerController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _accessor = serviceProvider.GetRequiredService<IProducerAccessor>();
        }
    }
}
