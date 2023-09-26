using MunchBase.Administration.Interfaces;
using MunchBase.Common.Middleware.Bases;

namespace Munch.AdminApi.Controllers
{
    public abstract class BaseAdminController : BaseController
    {
        private readonly IAdminAccessor _adminAccessor;
        protected IAdmin Admin => _adminAccessor.GetAdmin(User);

        protected BaseAdminController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
             _adminAccessor = serviceProvider.GetRequiredService<IAdminAccessor>();
        }
    }
}
