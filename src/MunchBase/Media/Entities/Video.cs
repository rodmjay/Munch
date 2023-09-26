using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Media.Entities;

public class Video : BaseEntity<Video>
{
    public TimeSpan Duration { get; set; }
    public Media Media { get; set; }
    public int Id { get; set; }
    public override void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasOne(x => x.Media)
            .WithOne(x => x.Video)
            .HasForeignKey<Video>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}