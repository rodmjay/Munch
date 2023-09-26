using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Consumers.Entities;

namespace MunchBase.Channels.Entities;

public class ChannelSubscription : BaseEntity<ChannelSubscription>
{
    public Channel Channel { get; set; }
    public Consumer Consumer { get; set; }
    public int ChannelId { get; set; }
    public int ConsumerId { get; set; }
    public override void Configure(EntityTypeBuilder<ChannelSubscription> builder)
    {
        builder.HasKey(x => new { x.ChannelId, x.ConsumerId });
        builder.HasOne(x => x.Channel)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Consumer)
            .WithMany(x => x.ChannelSubscriptions)
            .HasForeignKey(x => x.ConsumerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}