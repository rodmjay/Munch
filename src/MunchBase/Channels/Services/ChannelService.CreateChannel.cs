using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunchBase.Administration.Interfaces;
using MunchBase.Channels.Entities;
using MunchBase.Channels.ViewModels;
using MunchBase.Common.Data.Enums;
using MunchBase.Common.Models;

namespace MunchBase.Channels.Services;

public partial class ChannelService
{
    public async Task<Result> CreateChannel(IAdmin admin, ChannelInput input)
    {
        var channel = new Channel()
        {
            Name = input.Name,
            ObjectState = ObjectState.Added
        };

        await Repository.InsertAsync(channel, true);

        var providers = await Providers.Where(x => input.Providers.Select(a => a.ProviderId).Contains(x.Id))
            .ToListAsync();

        foreach (var provider in providers)
        {
            channel.Providers.Add(new ChannelProvider()
            {
                Channel = channel,
                ProviderId = provider.Id,
                Identifier = input.Providers.First(x => x.ProviderId == provider.Id).Identifier,
                ObjectState = ObjectState.Added
            });
        }


        var producers = await Producers.Where(x => input.Producers.Contains(x.Id)).ToListAsync();
        foreach (var producer in producers)
        {
            channel.Producers.Add(new ChannelProducer()
            {
                Channel = channel,
                Producer = producer,
                ObjectState = ObjectState.Added
            });
        }

        await Repository.UpdateAsync(channel, true);

        return Result.Success(channel.Id);
    }
}