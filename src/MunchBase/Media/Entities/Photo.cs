using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Media.Entities;

public class Photo : BaseEntity<Photo>
{
    public int Id { get; set; }
    public Media Media { get; set; }
    public override void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasOne(x => x.Media)
            .WithOne(x => x.Photo)
            .HasForeignKey<Photo>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}