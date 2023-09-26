using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Dumps.Entities;

namespace MunchBase.Channels.Entities;

public class ChannelIntent : BaseEntity<ChannelIntent>
{
    public Dump Dump { get; set; }
    public int ContentDumpId { get; set; }
    public Channel Channel { get; set; }
    public int ChannelId { get; set; }
    public override void Configure(EntityTypeBuilder<ChannelIntent> builder)
    {
        builder.HasKey(x => new {x.ContentDumpId, x.ChannelId});

        builder.HasOne(x => x.Channel)
            .WithMany(x => x.ChannelIntents)
            .HasForeignKey(x => x.ChannelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Dump)
            .WithMany(x => x.ChannelIntents)
            .HasForeignKey(x => x.ContentDumpId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}