using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Providers.Entities;

namespace MunchBase.Dumps.Entities;

public class DumpProvider : BaseEntity<DumpProvider>
{
    public int ContentDumpId { get; set; }
    public Dump Dump { get; set; }
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }
    public override void Configure(EntityTypeBuilder<DumpProvider> builder)
    {
        builder.HasKey(x => new {x.ProviderId, x.ContentDumpId});

        builder.HasOne(x=>x.Dump)
            .WithMany(x=>x.Providers)
            .HasForeignKey(x=>x.ContentDumpId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Provider)
            .WithMany(x => x.ContentDumps)
            .HasForeignKey(x => x.ProviderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}