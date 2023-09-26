using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Models;
using MunchBase.Editors.Interfaces;
using MunchBase.Media.Entities;
using MunchBase.Media.ViewModels;
using MunchBase.Models.Entities;

namespace MunchBase.Media.Services;

public partial class MediaSetService
{
    public async Task<Result> CreateMediaSet(IEditor editor, MediaSetInput input)
    {
        var providers = await Providers.Where(x => input.Providers.Contains(x.Id)).ToListAsync();
        var models = await Models.Where(x => input.Models.Contains(x.Id)).ToListAsync();
        var channels = await Channels.Where(x => input.Channels.Contains(x.Id)).ToListAsync();

        int producerId = input.ProducerId.HasValue ? input.ProducerId.Value : 0;

        if (!input.ProducerId.HasValue && input.DumpId.HasValue)
        {
            var dump = await Dumps.Where(x => x.Id == input.DumpId).FirstAsync();
            producerId = dump.ProducerId;
        }

        var mediaSet = new MediaSet()
        {
            EditorId = editor.Id,
            Caption = input.Caption,
            ProducerId = producerId,
            ObjectState = ObjectState.Added
        };

        var records = await Repository.InsertAsync(mediaSet, true);

        foreach (var provider in providers)
        {
            mediaSet.Providers.Add(new MediaSetProvider()
            {
                MediaSetId = mediaSet.Id,
                ProviderId = provider.Id,
                ObjectState = ObjectState.Added
            });
        }

        foreach (var model in models)
        {
            mediaSet.Models.Add(new ModelMediaSet()
            {
                MediaSetId = mediaSet.Id,
                ModelId = model.Id,
                ObjectState = ObjectState.Added
            });
        }


        foreach (var channel in channels)
        {
            mediaSet.Channels.Add(new ChannelMediaSet()
            {
                MediaSetId = mediaSet.Id,
                ChannelId = channel.Id,
                ObjectState = ObjectState.Added
            });
        }

        foreach (var media in input.Media)
        {
            mediaSet.Media.Add(new Entities.Media()
            {
                MediaSetId = mediaSet.Id,
                Caption = media.Caption,
                IsExplicit = media.IsExplicit,
                ObjectState = ObjectState.Added
            });
        }

        records += Repository.InsertOrUpdateGraph(mediaSet, true);
        if (records > 0)
            return Result.Success(mediaSet.Id);

        return Result.Failed();
    }
}