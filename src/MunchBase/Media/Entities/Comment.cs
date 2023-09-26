using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Consumers.Entities;

namespace MunchBase.Media.Entities;

public class Comment : BaseEntity<Comment>
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int MediaSetId { get; set; }
    public int ConsumerId { get; set; }
    public Consumer Consumer { get; set; }
    public MediaSet MediaSet { get; set; }
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(x => x.MediaSet)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Consumer)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.ConsumerId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}