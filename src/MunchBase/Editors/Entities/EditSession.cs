using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Dumps.Entities;

namespace MunchBase.Editors.Entities;

public class EditSession : BaseEntity<EditSession>
{
    public int EditorId { get; set; }
    public Editor Editor { get; set; }
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DumpSession> ContentDumps { get; set; }

    public override void Configure(EntityTypeBuilder<EditSession> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Editor)
            .WithMany(x=>x.Sessions)
            .HasForeignKey(x=>x.EditorId);

        builder.HasMany(x => x.ContentDumps)
            .WithOne(x => x.EditSession)
            .HasForeignKey(x => x.EditingSessionId);
    }
}