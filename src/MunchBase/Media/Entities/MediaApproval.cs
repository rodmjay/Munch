using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Administration.Entities;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Media.Entities;

public class MediaApproval : BaseEntity<MediaApproval>
{
    public int Id { get; set; }
    public int AdminId { get; set; }
    public Media Media { get; set; }
    public Admin Admin { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsApproved { get; set; }
    public string RejectionReason { get; set; }

    public override void Configure(EntityTypeBuilder<MediaApproval> builder)
    {
        builder.HasOne(x => x.Media)
            .WithOne(x => x.Approval)
            .HasForeignKey<MediaApproval>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Admin)
            .WithMany(x => x.MediaApprovals)
            .HasForeignKey(x => x.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}