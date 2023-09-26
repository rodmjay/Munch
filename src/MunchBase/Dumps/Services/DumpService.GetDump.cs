using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Dumps.ViewModels;
using MunchBase.Editors.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Services;

public partial class DumpService
{
    public Task<T> GetDump<T>(IAdmin admin, int contentDumpId) where T : DumpDto
    {
        return GetDump<T>(contentDumpId);
    }

    public Task<T> GetDump<T>(IEditor editor, int contentDumpId) where T : DumpDto
    {
        return GetDump<T>(contentDumpId);
    }

    public Task<T> GetDump<T>(IProducer producer, int contentDumpId) where T : DumpDto
    {
        return GetDump<T>(contentDumpId);
    }

    private Task<T> GetDump<T>(int contentDumpId) where T : DumpDto
    {
        return Repository.Queryable().Where(x => x.Id == contentDumpId).ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }
}