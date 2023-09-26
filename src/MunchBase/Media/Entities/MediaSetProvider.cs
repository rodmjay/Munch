using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Models.Entities;
using MunchBase.Providers.Entities;

namespace MunchBase.Media.Entities;

public class MediaSetProvider : BaseEntity<MediaSetProvider>
{
    public MediaSetProvider()
    {
        this.PublishedMediaSets = new List<ModelProviderMediaSet>();
    }
    public int MediaSetId { get; set; }
    public int ProviderId { get; set; }
    public MediaSet MediaSet { get; set; }
    public Provider Provider { get; set; }
    public ICollection<ModelProviderMediaSet> PublishedMediaSets { get; set; }
    public override void Configure(EntityTypeBuilder<MediaSetProvider> builder)
    {
        builder.HasKey(x => new {x.ProviderId, x.MediaSetId});

        builder.HasOne(x => x.MediaSet)
            .WithMany(x => x.Providers)
            .HasForeignKey(x => x.MediaSetId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Provider)
            .WithMany(x => x.MediaSets)
            .HasForeignKey(x => x.ProviderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}