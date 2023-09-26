using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Editors.Interfaces;
using MunchBase.Editors.ViewModels;

namespace Munch.AdminApi.Controllers;

public class EditorsController : BaseAdminController
{
    private readonly IEditorService _service;

    public EditorsController(IServiceProvider serviceProvider, IEditorService service) : base(serviceProvider)
    {
        _service = service;
    }

    [HttpGet]
    public Task<PagedList<EditorDto>> GetEditors([FromQuery] EditorQuery query, [FromQuery] PagingQuery paging)
    {
        return _service.GetEditors<EditorDto>(Admin, query, paging);
    }


    [HttpGet("{editorId}")]
    public Task<EditorDto> GetEditor([FromRoute] int editorId)
    {
        return _service.GetEditor<EditorDto>(Admin, editorId);
    }
}