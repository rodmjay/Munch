using MunchBase.Common.Middleware.Bases;
using MunchBase.Models.Interfaces;

namespace Munch.ModelApi.Controllers
{
    public abstract class BaseModelController : BaseController
    {
        private readonly IModelAccessor _accessor;
        protected IModel Model => _accessor.GetModel(User);

        protected BaseModelController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _accessor = serviceProvider.GetRequiredService<IModelAccessor>();
        }
    }
}
