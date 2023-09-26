using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Producers.Entities;

namespace MunchBase.Channels.Entities;

public class ChannelProducer : BaseEntity<ChannelProducer>
{
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
    public int ProducerId { get; set; }
    public Producer Producer { get; set; }
    public override void Configure(EntityTypeBuilder<ChannelProducer> builder)
    {
        builder.HasKey(x => new {x.ProducerId, x.ChannelId});

        builder.HasOne(x => x.Channel)
            .WithMany(x => x.Producers)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Producer)
            .WithMany(x => x.Channels)
            .HasForeignKey(x => x.ProducerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}