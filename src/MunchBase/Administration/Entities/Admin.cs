using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Media.Entities;
using MunchBase.Users.Entities;

namespace MunchBase.Administration.Entities;

public class Admin : BaseEntity<Admin>
{
    public int Id { get; set; }
    public User User { get; set; }
    public bool Active { get; set; }
    public ICollection<MediaApproval> MediaApprovals { get; set; }
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne(x => x.Admin)
            .HasForeignKey<Admin>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.MediaApprovals)
            .WithOne(x => x.Admin)
            .HasForeignKey(x => x.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}