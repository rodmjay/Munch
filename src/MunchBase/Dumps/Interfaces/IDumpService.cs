using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Dumps.ViewModels;
using MunchBase.Editors.Interfaces;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Interfaces;

public interface IDumpService
{
    Task<PagedList<T>> GetDumps<T>(IEditor editor, PagingQuery paging, DumpQuery query) where T : DumpDto;
    Task<PagedList<T>> GetDumps<T>(IProducer producer, PagingQuery paging, DumpQuery query) where T : DumpDto;
    Task<PagedList<T>> GetDumps<T>(IAdmin admin, PagingQuery paging, DumpQuery query) where T : DumpDto;
    Task<T> GetDump<T>(IAdmin admin, int dumpId) where T : DumpDto;
    Task<T> GetDump<T>(IEditor editor, int dumpId) where T : DumpDto;
    Task<T> GetDump<T>(IProducer producer, int dumpId) where T : DumpDto;
    Task<Result> ApproveDump(IAdmin admin, int dumpId);
    Task<Result> ApproveDump(IProducer producer, int dumpId);
    Task<Result> AssignToEditor(IProducer producer, int dumpId, IEditor editor);
    Task<Result> DeleteDump(IProducer producer, int dumpId);
    Task<Result> CreateDump(IProducer producer, DumpInput input);
    Task<Result> CreateDump(IModel producer, DumpInput input);

}