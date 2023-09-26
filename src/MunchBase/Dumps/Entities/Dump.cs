using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Administration.Entities;
using MunchBase.Channels.Entities;
using MunchBase.Common.Data.Bases;
using MunchBase.Editors.Entities;
using MunchBase.Media.Entities;
using MunchBase.Producers.Entities;

namespace MunchBase.Dumps.Entities
{
    public class Dump : BaseEntity<Dump>
    {
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public string Instructions { get; set; }
        public int Id { get; set; }
        public int? EditorId { get; set; }
        public Editor Editor { get; set; }
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public ICollection<Content> Content { get; set; }
        public ICollection<DumpModel> Models { get; set; }
        public ICollection<DumpSession> EditingSessions { get; set; }
        public ICollection<ChannelIntent> ChannelIntents { get; set; }
        public ICollection<DumpProvider> Providers { get; set; }

        public override void Configure(EntityTypeBuilder<Dump> builder)
        {
            builder.HasMany(x => x.Models)
                .WithOne(x => x.Dump)
                .HasForeignKey(x => x.DumpId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Editor)
                .WithMany(x => x.ContentDumps)
                .HasForeignKey(x => x.EditorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Content)
                .WithOne(x => x.Dump)
                .HasForeignKey(x => x.ContentDumpId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Producer)
                .WithMany(x => x.Dumps)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
