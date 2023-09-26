using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Dumps.ViewModels;

namespace MunchBase.Dumps.Interfaces
{
    public interface IReadDumps<T> where T : DumpDto
    {
        Task<PagedList<T>> GetDumps([FromQuery] DumpQuery query, [FromQuery] PagingQuery paging);
    }
}
