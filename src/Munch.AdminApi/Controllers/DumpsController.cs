using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Dumps.Interfaces;
using MunchBase.Dumps.ViewModels;

namespace Munch.AdminApi.Controllers
{
    public class DumpsController : BaseAdminController,
        IReadDump<DumpDto>,
        IReadDumps<DumpDto>
    {
        private readonly IDumpService _service;

        public DumpsController(IServiceProvider serviceProvider, IDumpService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedList<DumpDto>> GetDumps([FromQuery] DumpQuery query, [FromQuery] PagingQuery paging)
        {
            return _service.GetDumps<DumpDto>(Admin, paging, query);
        }

        [HttpGet("{dumpId}")]
        public Task<DumpDto> GetDump([FromRoute] int dumpId)
        {
            return _service.GetDump<DumpDto>(Admin, dumpId);
        }
    }
}
