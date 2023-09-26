using MunchBase.Common.Middleware.Bases;
using MunchBase.Editors.Interfaces;

namespace Munch.EditorApi.Controllers
{
    public abstract class BaseEditorController : BaseController
    {
        private readonly IEditorAccessor _accessor;
        protected IEditor Editor => _accessor.GetEditor(User);

        protected BaseEditorController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _accessor = serviceProvider.GetRequiredService<IEditorAccessor>();
        }
    }
}
