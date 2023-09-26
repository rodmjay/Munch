using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunchBase.Common.Data.Bases;
using MunchBase.Providers.Entities;

namespace MunchBase.Models.Entities
{
    public class ModelProvider : BaseEntity<ModelProvider>
    {
        public ModelProvider()
        {
            this.PublishedMediaSets = new List<ModelProviderMediaSet>();
        }
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public string Username { get; set; }
        public ICollection<ModelProviderMediaSet> PublishedMediaSets { get; set; }

        public override void Configure(EntityTypeBuilder<ModelProvider> builder)
        {
            builder.HasKey(x => new
            {
                x.ModelId,
                x.ProviderId
            });

            builder.HasOne(x => x.Provider)
                .WithMany(x => x.ModelProviders)
                .HasForeignKey(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Providers)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}