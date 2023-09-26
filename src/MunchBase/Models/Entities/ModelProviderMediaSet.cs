using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Media.Entities;

namespace MunchBase.Models.Entities;

public class ModelProviderMediaSet : BaseEntity<ModelProviderMediaSet>
{
    public int ModelId { get; set; }
    public int MediaSetId { get; set; }
    public int ProviderId { get; set; }

    public ModelMediaSet ModelMediaSet { get; set; }
    public ModelProvider ModelProvider { get; set; }
    public MediaSetProvider MediaSetProvider { get; set; }

    public override void Configure(EntityTypeBuilder<ModelProviderMediaSet> builder)
    {
        builder.HasKey(x => new {x.ModelId, x.MediaSetId, x.ProviderId});

        builder.HasOne(x => x.ModelMediaSet)
            .WithMany(x => x.PublishedMediaSets)
            .HasForeignKey(x => new {x.MediaSetId, x.ModelId})
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.ModelProvider)
            .WithMany(x => x.PublishedMediaSets)
            .HasForeignKey(x => new { x.ModelId, x.ProviderId })
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.MediaSetProvider)
            .WithMany(x => x.PublishedMediaSets)
            .HasForeignKey(x => new {x.ProviderId, x.MediaSetId})
            .OnDelete(DeleteBehavior.NoAction);
    }
}