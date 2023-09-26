using Microsoft.AspNetCore.Mvc;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.ViewModels;

namespace Munch.EditorApi.Controllers
{
    public class EditorController : BaseEditorController
    {
        private readonly IEditorService _service;

        public EditorController(IServiceProvider serviceProvider, IEditorService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<EditorDto> GetEditorProfile()
        {
            return _service.GetEditor<EditorDto>(Editor);
        }
    }
}
