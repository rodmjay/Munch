using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Media.Entities
{
    public class Media : BaseEntity<Media>
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? MediaSetId { get; set; }
        public MediaSet MediaSet { get; set; }
        public Photo Photo { get; set; }
        public Video Video { get; set; }
        public MediaApproval Approval { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime Timestamp { get; set; }

        public ApprovalStatus Status { get; set; }
        public ICollection<MediaTag> Tags { get; set; }
        public string Caption { get; set; }
        public bool IsDraft { get; set; }

        public override void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MediaSet)
                .WithMany(x => x.Media)
                .HasForeignKey(x => x.MediaSetId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Photo)
                .WithOne(x => x.Media)
                .HasForeignKey<Photo>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Video)
                .WithOne(x => x.Media)
                .HasForeignKey<Video>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Approval)
                .WithOne(x => x.Media)
                .HasForeignKey<MediaApproval>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithOne(x => x.Media)
                .HasForeignKey(x => x.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
