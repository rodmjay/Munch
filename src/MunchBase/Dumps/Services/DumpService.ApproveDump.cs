using System;
using System.Threading.Tasks;
using MunchBase.Administration.Interfaces;
using MunchBase.Common.Models;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Services;

public partial class DumpService
{
    public Task<Result> ApproveDump(IAdmin admin, int dumpId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ApproveDump(IProducer producer, int dumpId)
    {
        throw new NotImplementedException();
    }
}