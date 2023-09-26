using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunchBase.Common.Models;
using MunchBase.Dumps.ViewModels;

namespace MunchBase.Dumps.Interfaces;

public interface ICreateDump
{
    Task<Result> CreateDump([FromBody] DumpInput input);
}
public interface IReadDump<T> where T : DumpDto
{
    Task<T> GetDump([FromRoute] int dumpId);
}