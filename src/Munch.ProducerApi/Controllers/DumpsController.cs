using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Dumps.Interfaces;
using MunchBase.Dumps.ViewModels;

namespace Munch.ProducerApi.Controllers
{
    public class DumpsController : BaseProducerController,
        IReadDumps<DumpDto>,
        IReadDump<DumpDto>,
        ICreateDump
    {
        private readonly IDumpService _service;

        public DumpsController(IServiceProvider serviceProvider, IDumpService service) : base(serviceProvider)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedList<DumpDto>> GetDumps([FromQuery] DumpQuery query, [FromQuery] PagingQuery paging)
        {
            return _service.GetDumps<DumpDto>(Producer, paging, query);
        }

        [HttpGet("{dumpId}")]
        public Task<DumpDto> GetDump([FromRoute] int dumpId)
        {
            return _service.GetDump<DumpDto>(Producer, dumpId);
        }

        [HttpPost]
        public Task<Result> CreateDump(DumpInput input)
        {
            return _service.CreateDump(Producer, input);
        }
    }
}
