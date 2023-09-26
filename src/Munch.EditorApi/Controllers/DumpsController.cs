using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Dumps.Interfaces;
using MunchBase.Dumps.ViewModels;

namespace Munch.EditorApi.Controllers
{
    public class DumpsController : BaseEditorController,
        IReadDumps<DumpDto>,
        IReadDump<DumpDto>
    {
        private readonly IDumpService _service;

        public DumpsController(IServiceProvider serviceProvider, IDumpService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedList<DumpDto>> GetDumps([FromQuery] DumpQuery query, [FromQuery] PagingQuery paging)
        {
            return _service.GetDumps<DumpDto>(Editor, paging, query);
        }

        [HttpGet("{dumpId}")]
        public Task<DumpDto> GetDump([FromRoute] int dumpId)
        {
            return _service.GetDump<DumpDto>(Editor, dumpId);
        }
    }
}
