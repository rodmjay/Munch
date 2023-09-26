using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Editors.Entities;

namespace MunchBase.Dumps.Entities;

public class DumpSession : BaseEntity<DumpSession>
{
    public int ContentDumpId { get; set; }
    public Dump Dump { get; set; }
    public int EditingSessionId { get; set; }
    public EditSession EditSession { get; set; }
    public override void Configure(EntityTypeBuilder<DumpSession> builder)
    {
        builder.HasOne(x => x.Dump)
            .WithMany(x=>x.EditingSessions)
            .HasForeignKey(x=>x.ContentDumpId);

        builder.HasOne(x => x.EditSession)
            .WithMany(x=>x.ContentDumps)
            .HasForeignKey(x=>x.EditingSessionId);

        builder.HasKey(x => new {x.ContentDumpId, x.EditingSessionId});
    }
}