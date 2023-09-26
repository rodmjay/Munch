using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Media.Entities;

namespace MunchBase.Models.Entities;

public class ModelMediaSet : BaseEntity<ModelMediaSet>
{

    public int MediaSetId { get; set; }
    public MediaSet MediaSet { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
    public ICollection<ModelProviderMediaSet> PublishedMediaSets { get; set; }
    public override void Configure(EntityTypeBuilder<ModelMediaSet> builder)
    {
        builder.HasKey(x => new { x.MediaSetId, x.ModelId });

        builder.HasOne(x => x.Model)
            .WithMany(x => x.MediaSets)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.MediaSet)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}