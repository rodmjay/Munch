using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;

namespace MunchBase.Media.Entities;

public class MediaTag : BaseEntity<MediaTag>
{
    public string Tag { get; set; }
    public int MediaId { get; set; }
    public Media Media { get; set; }
    public override void Configure(EntityTypeBuilder<MediaTag> builder)
    {
        builder.HasKey(x => new {x.MediaId, x.Tag});
        builder.HasOne(x => x.Media)
            .WithMany(x => x.Tags)
            .HasForeignKey(x => x.MediaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}