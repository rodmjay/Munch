using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Media.Entities;

namespace MunchBase.Channels.Entities;

public class ChannelMediaSet : BaseEntity<ChannelMediaSet>
{
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
    public int MediaSetId { get; set; }
    public MediaSet MediaSet { get; set; }
    public override void Configure(EntityTypeBuilder<ChannelMediaSet> builder)
    {
        builder.HasKey(x => new {x.ChannelId, x.MediaSetId});

        builder.HasOne(x => x.Channel)
            .WithMany(x => x.MediaSets)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.MediaSet)
            .WithMany(x => x.Channels)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}