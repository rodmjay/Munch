using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Models;
using MunchBase.Dumps.Entities;
using MunchBase.Dumps.ViewModels;
using MunchBase.Media.Entities;
using MunchBase.Models.Interfaces;
using MunchBase.Producers.ViewModels;

namespace MunchBase.Dumps.Services;

public partial class DumpService
{
    public async Task<Result> CreateDump(IProducer producer, DumpInput input)
    {
        var dump = new Dump()
        {
            Name = input.Name,
            ProducerId = producer.Id,
            Instructions = input.Instructions,
            EditorId = input.EditorId,
            ApprovalStatus = ApprovalStatus.PendingApproval,
            ObjectState = ObjectState.Added
        };

        var editor = await _editorRepo.Queryable()
            .Where(x => x.Id == input.EditorId).FirstOrDefaultAsync();

        var records = await Repository.InsertAsync(dump, true);

        var models = await _modelRepository.Queryable().Where(x => input.ModelIds.Contains(x.Id))
            .ToListAsync();

        foreach (var model in models)
        {
            dump.Models.Add(new DumpModel()
            {
                Dump = dump,
                ModelId = model.Id,
                ObjectState = ObjectState.Added
            });
        }

        var channels = await Channels.Where(x => input.Channels.Contains(x.Id))
            .ToListAsync();

        foreach (var channel in channels)
        {
            dump.ChannelIntents.Add(new ChannelIntent()
            {
                Dump = dump,
                ChannelId = channel.Id
            });
        }

        records += await Repository.UpdateAsync(dump, true);
        if(records > 0)
            return Result.Success(dump.Id);

        return Result.Failed();
    }

    public Task<Result> CreateDump(IModel model, DumpInput input)
    {
        throw new NotImplementedException();
    }
}