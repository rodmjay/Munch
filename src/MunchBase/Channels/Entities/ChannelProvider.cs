using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Providers.Entities;

namespace MunchBase.Channels.Entities;

public class ChannelProvider : BaseEntity<ChannelProvider>
{
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }
    public string Identifier { get; set; }
    public override void Configure(EntityTypeBuilder<ChannelProvider> builder)
    {
        builder.HasKey(x => new {x.ChannelId, x.ProviderId});

        builder.HasOne(x => x.Provider)
            .WithMany(x => x.Channels)
            .HasForeignKey(x => x.ProviderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Channel)
            .WithMany(x => x.Providers)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}